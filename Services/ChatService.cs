using NATS.Client;
using NATS.Client.JetStream;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppNats.Services
{
    public class ChatService : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IJetStream _js;
        private readonly IJetStreamManagement _jsm;
        private const string StreamName = "Synapse_Publisher";

        private readonly string _userName;
        private readonly string _subjectToPublish;
        private readonly string _subjectToSubscribe;
        private readonly string _durableName;

        private readonly ILogger _logger;

        public ChatService(string userName, string targetUser, ILogger logger = null)
        {
            _logger = logger ?? Log.Logger; // use global logger if not injected

            _userName = userName;
            _subjectToPublish = $"Synapse_Publisher.{targetUser}";
            _subjectToSubscribe = $"Synapse_Publisher.{userName}";
            _durableName = $"chat_consumer_{userName}";

            _logger.Information("Initializing ChatService for {User}, target={Target}, publish={Publish}, subscribe={Subscribe}, durable={Durable}",
                _userName, targetUser, _subjectToPublish, _subjectToSubscribe, _durableName);

            try
            {
                ConnectionFactory cf = new ConnectionFactory();
                Options opts = ConnectionFactory.GetDefaultOptions();

                opts.Url = "tls://connect.ngs.global:4222";
                opts.SetUserCredentials(@"D:\C# Project\NATS Project\JetStreamDemo\Publisher\NGS-ChatApp-Rinku-User.creds");
                opts.Name = $"Chat Publisher - {_userName}";
                opts.Secure = true;
                opts.TLSRemoteCertificationValidationCallback = (sender, certificate, chain, errors) => true;

                _connection = cf.CreateConnection(opts);
                _js = _connection.CreateJetStreamContext();
                _jsm = _connection.CreateJetStreamManagementContext();

                _logger.Information("Connected to NATS successfully as {User}", _userName);

                var streamConfig = StreamConfiguration.Builder()
                    .WithName(StreamName)
                    .WithSubjects("Synapse_Publisher.*")
                    .WithMaxBytes(1024 * 1024 * 1024)
                    .Build();

                try
                {
                    _jsm.GetStreamInfo(StreamName);
                    _logger.Debug("Stream {StreamName} already exists", StreamName);
                }
                catch (NATSJetStreamException)
                {
                    _jsm.AddStream(streamConfig);
                    _logger.Information("Stream {StreamName} created", StreamName);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to initialize ChatService for {User}", _userName);
                throw;
            }
        }

        // Publisher
        public async Task PublishMessageAsync(string message)
        {
            try
            {
                var msg = new Msg(_subjectToPublish, Encoding.UTF8.GetBytes(message));
                var ack = await _js.PublishAsync(msg);

                if (ack != null)
                {
                    _logger.Information("Message published by {User} to {Subject}, seq={Seq}, text={Message}",
                        _userName, _subjectToPublish.Split('.')[1], _subjectToPublish, ack.Seq, message);
                }
                else
                {
                    _logger.Warning("Publish failed by {User} to {Subject}, text={Message}",
                        _userName, _subjectToPublish, message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error publishing message by {User} to {Subject}, text={Message}",
                    _userName, _subjectToPublish, message);
            }
        }

        // Subscriber
        public void Subscribe(Action<string> onMessage)
        {
            _logger.Information("Setting up subscriber for {User}, subject={Subject}, durable={Durable}",
                _userName, _subjectToSubscribe, _durableName);

            var consumerConfig = ConsumerConfiguration.Builder()
                .WithFilterSubject(_subjectToSubscribe)
                .WithDurable(_durableName)
                .WithDeliverPolicy(DeliverPolicy.All)
                .WithAckPolicy(AckPolicy.Explicit)
                .Build();

            try
            {
                _jsm.AddOrUpdateConsumer(StreamName, consumerConfig);
                _logger.Debug("Consumer durable {Durable} configured", _durableName);
            }
            catch (NATSJetStreamException ex)
            {
                _logger.Error(ex, "Consumer setup failed for durable {Durable}", _durableName);
            }

            PullSubscribeOptions pso = PullSubscribeOptions.BindTo(StreamName, _durableName);

            try
            {
                var sub = _js.PullSubscribe(_subjectToSubscribe, pso);
                _logger.Information("Subscribed successfully to {Subject} with durable {Durable}",
                    _subjectToSubscribe, _durableName);

                Task.Run(async () =>
                {
                    while (true)
                    {
                        try
                        {
                            var messages = sub.Fetch(10, 1000);
                            foreach (var msg in messages)
                            {
                                var text = Encoding.UTF8.GetString(msg.Data);
                                _logger.Information("User {User} received message='{Message}' from subject={Subject}",
                                    _userName, text, _subjectToSubscribe);

                                msg.Ack();

                                if (onMessage != null && Application.OpenForms.Count > 0)
                                {
                                    var form = Application.OpenForms[0];
                                    form.Invoke(() => onMessage(text));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, "Error pulling messages for {User}", _userName);
                        }
                        await Task.Delay(500);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Subscribe failed for {User} on subject {Subject}",
                    _userName, _subjectToSubscribe);
            }
        }

        public void Dispose()
        {
            _logger.Information("Closing connection for {User}", _userName);
            _connection?.Close();
        }
    }
}
