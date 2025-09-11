using ChatAppNats.Models;
using NATS.Client.Core;
using Serilog;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChatAppNats.Services
{
    public class ChatService : IDisposable, IAsyncDisposable
    {
        private NatsConnection? _nats;
        private const string Subject = "chat.room1";
        private CancellationTokenSource? _cts;

        

        public event Action<string>? OnMessageReceived;
        public event Action<string>? OnStatusChanged;


        public async Task ConnectToNats()
        {
            try
            {
                Log.Information("Attempting to connect to NATS server...");
                //
                // 1. Load the JWT and Seed from Credentials
                //
                var (jwt, seed) = LoadCreds();
                if (jwt == null || seed == null)
                {
                    OnStatusChanged?.Invoke("Invalid .creds file format.");
                    return;
                }


                // 2. Create NATS Connection
                _nats = await CreateConnectionAsync(jwt, seed);

                // 3. Subscribe to Messages
                await SubscribeToMessageAsync();


                OnStatusChanged?.Invoke("Connected to NATS server");
                Log.Information("Connected to NATS server successfully.");
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke("Connection Failed: " + ex.Message);
                Log.Error(ex, "Failed to connect to NATS server.");
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
                return (null, null);
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
                Log.Information("Credentials loaded successfully.");
            else
                Log.Warning("Credentials not found in creds file.");

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
            Log.Information("NATS connection established to {0}", opts.Url);
            return connection;
        }



        //
        //Subscribe to the chat subject and raises OnMessageReceived
        //
        private async Task SubscribeToMessageAsync()
        {
            if (_nats == null) return;
            _cts = new CancellationTokenSource();

            _ = Task.Run(async () =>
            {
                try
                {
                    await foreach (var msg in _nats.SubscribeAsync<byte[]>(Subject).WithCancellation(_cts.Token))
                    {
                        try
                        {
                            var chatMsg = JsonSerializer.Deserialize<ChatMessage>(msg.Data ?? Array.Empty<byte>());
                            if (chatMsg != null)
                            {
                                if (chatMsg.Type == "text" && chatMsg.UserName != null && chatMsg.Data != null)
                                {
                                    string text = Encoding.UTF8.GetString(chatMsg.Data);
                                    OnMessageReceived?.Invoke($"{chatMsg.UserName}: {text}");
                                    Log.Information("Text message received: {0}", text);
                                }
                                else if (chatMsg.Type == "file" && chatMsg.FileName != null && chatMsg.Data != null && chatMsg.Data.Length > 0)
                                {
                                    string fileName = chatMsg.FileName;
                                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                    string filePath = Path.Combine(desktopPath, fileName);
                                    await File.WriteAllBytesAsync(filePath, chatMsg.Data);
                                    OnMessageReceived?.Invoke($"[File] Received file saved to Desktop: {fileName}");
                                    Log.Information("File message received and saved: {0}", fileName);
                                }
                                else
                                {
                                    Log.Warning("Received message with invalid or empty data/type.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "Error processing received message.");
                            OnStatusChanged?.Invoke($"Error processing message: {ex.Message}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Log.Information("Subscription cancelled.");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred in the subscription loop.");
                }
            });
                
               
            Log.Information("Subscribed to subject: {0}", Subject);
        }


        //
        //This is the Method for sending the Messages to the UI
        //
        //public async Task SendMessageAsync(string message)
        //{
        //    if (_nats != null && !string.IsNullOrWhiteSpace(message))
        //    {
        //        await _nats.PublishAsync(Subject, message);

        //        logger.Info("Message sent: {0}", message);
        //    }
        //    else
        //    {
        //        logger.Warn("Cannot send message. NATS connection is null or message is empty.");
        //    }
        //}


        public async Task SendTextAsync(string userName, string message)
        {
            if (_nats != null && !string.IsNullOrWhiteSpace(message))
            {
                var chatMsg = new ChatMessage
                {
                    Type = "text",
                    UserName = userName,
                    Data = Encoding.UTF8.GetBytes(message)
                };

                var payload = JsonSerializer.SerializeToUtf8Bytes(chatMsg);
                await _nats.PublishAsync(Subject, payload);

                Log.Information("Text message sent: {0}", message);
            }
        }


        public async Task SendFileAsync(string userName, string filePath)
        {
            if (_nats != null && File.Exists(filePath))
            {
                try
                {
                    var fileBytes = await File.ReadAllBytesAsync(filePath);
                    var chatMsg = new ChatMessage
                    {
                        Type = "file",
                        UserName = userName,
                        FileName = Path.GetFileName(filePath),
                        Data = fileBytes
                    };

                    var payload = JsonSerializer.SerializeToUtf8Bytes(chatMsg);
                    await _nats.PublishAsync(Subject, payload);

                    Log.Information("File message sent: {0}", chatMsg.FileName);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to read file for sending: {0}", filePath);
                    OnStatusChanged?.Invoke($"Error sending file: {ex.Message}");
                }
            }
            else
            {
                Log.Warning("Cannot send file. NATS connection is null or file does not exist: {0}", filePath);
                OnStatusChanged?.Invoke("Error: File not found or NATS not connected.");
            }
        }


        public async Task Disconnect()
        {
            _cts?.Cancel();
            if (_nats != null)
            {
                await _nats.DisposeAsync();
                Log.Information("NATS connection disposed.");
            }
        }


        // used to free up resources when the object is no longer used 
        // for synchronous method
        public void Dispose()
        {
            Disconnect().Wait();
        }

        
        // for asynchronous methods
        public async ValueTask DisposeAsync()
        {
            await Disconnect();
        }
    }
}