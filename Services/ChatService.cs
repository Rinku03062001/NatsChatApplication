using NATS.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Services
{
    public class ChatService
    {
        private NatsConnection? _nats;
        private const string Subject = "chat.room1";


        public event Action<string>? OnMessageReceived;
        public event Action<string>? OnStatusChanged;


        public async Task ConnectToNats()
        {
            try
            {
                // 1. Load JWT and Seed from Creds
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
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke("Connection Failed: " + ex.Message);
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


            // Parse creds
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
                }
            });
        }


        //
        //This is the Method for sending the Messages to the UI
        //
        public async Task SendMessageAsync(string message)
        {
            if (_nats != null && !string.IsNullOrWhiteSpace(message))
            {
                await _nats.PublishAsync(Subject, message);
            }
        }
    }
}
