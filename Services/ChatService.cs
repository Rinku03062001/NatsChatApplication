using NATS.Client.Core;
using System.Reflection;
using NLog;

namespace ChatAppNats.Services
{
    public class ChatService
    {
        private NatsConnection? _nats;
        private const string Subject = "chat.room1";

        // NLog Logger
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public event Action<string>? OnMessageReceived;
        public event Action<string>? OnStatusChanged;


        public async Task ConnectToNats()
        {
            try
            {
                logger.Info("Attempting to connect to NATS server...");
                //
                // 1. Load the JWT and Seed from Credentials
                //
                var (jwt, seed) = LoadCreds();
                if (jwt == null || seed == null)
                {
                    OnStatusChanged?.Invoke("Invalid .creds file format.");
                    return ;
                }


                // 2. Create NATS Connection
                _nats = await CreateConnectionAsync(jwt, seed);

                // 3. Subscribe to Messages
                SubscribeToMessage();


                OnStatusChanged?.Invoke("Connected to NATS server");
                logger.Info("Connected to NATS server successfully.");
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke("Connection Failed: " + ex.Message);
                logger.Error(ex, "Failed to connect to NATS server.");
            }
        }



        //
        //Loads JWT and Seed from embedded .creds file
        //
        private (string? jwt, string? seed) LoadCreds()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetName().Name + ".NGS-ChatApp-Rinku-User.creds";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                OnStatusChanged?.Invoke("Could not find embedded resource: " + resourceName);
                return(null,null);
            }

            using var reader = new StreamReader(stream);
            string credsContent = reader.ReadToEnd();


            //
            // Parse creds
            //
            var lines = credsContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            string? jwt = null, seed = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("-----BEGIN NATS USER JWT-----"))
                {
                    jwt = lines[Array.IndexOf(lines, line) + 1].Trim();
                }
                if (line.StartsWith("-----BEGIN USER NKEY SEED-----"))
                {
                    seed = lines[Array.IndexOf(lines, line) + 1].Trim();
                }
            }
            if (jwt != null && seed != null)
                logger.Info("Credentials loaded successfully.");
            else
                logger.Warn("Credentials not found in creds file.");

            return (jwt, seed);
        }



        //
        //Creates and Connects to the NATS Server
        //
        private async Task<NatsConnection> CreateConnectionAsync(string jwt, string seed)
        {
            var opts = NatsOpts.Default with
            {
                Url = "nats://connect.ngs.global:4222",
                AuthOpts = new NatsAuthOpts
                {
                    Jwt = jwt,
                    Seed = seed
                }
            };

            var connection = new NatsConnection(opts);
            await connection.ConnectAsync();
            logger.Info("NATS connection established to {0}", opts.Url);
            return connection;
        }



        //
        //Subscribe to the chat subject and raises OnMessageReceived
        //
        private void SubscribeToMessage()
        {
            if (_nats == null) return;

            _ = Task.Run(async () =>
            {
                await foreach (var msg in _nats.SubscribeAsync<string>(Subject))
                {
                    OnMessageReceived?.Invoke(msg.Data ?? string.Empty);

                    logger.Info("Messsage received: {0}", msg.Data);    
                }
            });
            logger.Info("Subscribed to subject: {0}", Subject);
        }


        //
        //This is the Method for sending the Messages to the UI
        //
        public async Task SendMessageAsync(string message)
        {
            if (_nats != null && !string.IsNullOrWhiteSpace(message))
            {
                await _nats.PublishAsync(Subject, message);

                logger.Info("Message sent: {0}", message);
            }
            else
            {
                logger.Warn("Cannot send message. NATS connection is null or message is empty.");
            }
        }
    }
}
