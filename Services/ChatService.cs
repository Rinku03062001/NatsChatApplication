
using Microsoft.Data.SqlClient;
using NATS.Client;
using NATS.Client.JetStream;
using Serilog;
using System.Text;

namespace ChatAppNats.Services
{
    public class ChatService : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IJetStream _js;
        private readonly IJetStreamManagement _jsm;
        private const string StreamName = "Synapse_Publisher";

        private readonly string _userName;
        private string _subjectToPublish;
        private readonly string _subjectToSubscribe;
        private string _durableName;

        private readonly ILogger _logger;
        //private static string connectionString = @"server=RINKU-LAPPY\SQLEXPRESS; Database=ChatAppDB; TrustServerCertificate=True; Trusted_Connection=True";
        private static string connectionString = @"Server=synapsedb.c1ysu4usmo3z.ap-south-1.rds.amazonaws.com, 1433;
                                        Database=SynapseDB;
                                        User Id=Rinku2001;
                                        Password=Rin-#KU29%;
                                        TrustServerCertificate=True;
                                        Encrypt=True;
                                        Connect Timeout=60;";


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
        public async Task PublishMessageAsync(string message, string userName = null)
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


        public async Task publishGroupMessageAsync(int groupId, string message)
        {
            _subjectToPublish = $"group.{groupId}";
            await PublishMessageAsync(message);
        }



        public void SubscribeDurable(Action<string> onMessage)
        {
            _logger.Information("Setting up JetStream durable push subscriber for {User}, subject={Subject}",
                _userName, _subjectToSubscribe);

            try
            {
                // Generate a unique deliver subject for push consumer
                string deliverSubject = $"deliver.{_userName}.{Guid.NewGuid()}";

                // Configure the consumer as a push consumer
                var consumerConfig = ConsumerConfiguration.Builder()
                    .WithDurable(_durableName)              // unique durable per user
                    .WithDeliverSubject(deliverSubject)     // required for push consumer
                    .WithDeliverPolicy(DeliverPolicy.New)   // deliver all missed messages
                    .WithFilterSubject(_subjectToSubscribe) // filter to this subject
                    .WithAckPolicy(AckPolicy.Explicit)      // explicit ACK required
                    .Build();

                // Add or update the consumer in JetStream
                _jsm.AddOrUpdateConsumer(StreamName, consumerConfig);
                _logger.Information("Consumer configured as push for {User} with durable {Durable}", _userName, _durableName);

                // Bind push subscription to this durable
                var pso = PushSubscribeOptions.BindTo(StreamName, _durableName);

                // Subscribe with a callback to handle incoming messages
                var sub = _js.PushSubscribeAsync(_subjectToSubscribe, (sender, args) =>
                {
                    args.Message.Ack(); // Acknowledge immediately to avoid redelivery
                    try
                    {
                        string text = Encoding.UTF8.GetString(args.Message.Data);
                        args.Message.Ack(); // acknowledge message

                        _logger.Information("User {User} received message='{Message}'", _userName, text);

                        if (onMessage != null && Application.OpenForms.Count > 0)
                        {
                            var form = Application.OpenForms[0];
                            form.Invoke(() => onMessage(text)); // safely update UI
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, "Error handling incoming message for {User}", _userName);
                    }
                }, false, pso);

                _logger.Information("Push subscription active for {User}", _userName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "JetStream push subscribe failed for {User} on subject {Subject}",
                    _userName, _subjectToSubscribe);
            }
        }

        public void SubscribeDurableGroup(int groupId, Action<string> onMessage)
        {
            _subjectToPublish = $"group.{groupId}";
            _durableName = $"durable_{_userName}_{groupId}";
            SubscribeDurable(onMessage);
        }



        public void SetTargetUser(string targetUser)
        {
            _subjectToPublish = $"Synapse_Publisher.{targetUser}";
            _logger.Information("Target user changed for {User}, new target={Target}, publish={Publish}",
                _userName, targetUser, _subjectToPublish);
        }



        public static void MarkMessageAsDeleted(int messageId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Messages SET IsDeleted = 1 WHERE MessageId = @MessageId", conn);
                cmd.Parameters.AddWithValue("@MessageId", messageId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            _logger.Information("Closing connection for {User}", _userName);
            _connection?.Close();
        }
    }
}