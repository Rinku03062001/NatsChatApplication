using NATS.Client.Core;
using System.Reflection;
namespace ChatAppNats
{
    public partial class ChatForm : Form
    {
        // Change the declaration of _nats to nullable to fix CS8618
        private NatsConnection? _nats;
        private const string Subject = "chat.room1";

        public ChatForm()
        {
            InitializeComponent();
            ConnectToNats();
        }



        private async void ConnectToNats()
        {
            try
            {
                // Load .creds from embedded resources
                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = assembly.GetName().Name + ".NGS-ChatApp-Rinku-User.creds";

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    AppendMessage("Could not find embedded resource: " + resourceName);
                    return;
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


                if (jwt == null || seed == null)
                {
                    AppendMessage("Invalid .creds file format.");
                    return;
                }


                // Build the nats connection options
                var opts = NatsOpts.Default with
                {
                    Url = "nats://connect.ngs.global:4222",
                    AuthOpts = new NatsAuthOpts
                    {
                        Jwt = jwt,
                        Seed = seed
                    }
                };

                _nats = new NatsConnection(opts);
                await _nats.ConnectAsync();


                // subscribe to the chat subject
                _ = Task.Run(async () =>
                {
                    await foreach (var msg in _nats.SubscribeAsync<string>(Subject))
                    {
                        AppendMessage(msg.Data ?? string.Empty);
                    }
                });

                AppendMessage("Connected to NATS server.");

            }
            catch (Exception ex)
            {
                AppendMessage("Connection Failed: " + ex.Message);
            }
        }




        public void AppendMessage(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => listBox1.Items.Add(message)));
            }
            else
            {
                listBox1.Items.Add(message);
            }
        }


        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            string myName = Environment.UserName;
            string msg = $"{myName}: {message}";

            if (!string.IsNullOrEmpty(message) && _nats != null)
            {
                await _nats.PublishAsync(Subject, msg);
                txtMessage.Clear();
            }
        }

        
    }
}
