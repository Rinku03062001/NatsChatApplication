using ChatAppNats.Services;
using Serilog;
using System.Threading.Tasks;

namespace ChatAppNats
{
    public partial class ChatForm : Form
    {

        ChatService chatService;
        private readonly string userName;

        public ChatForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            this.Text = $"Chat App - {userName}"; // Set form title

            chatService = new ChatService();

            // subscribe to service events
            chatService.OnMessageReceived += AppendMessage;
            chatService.OnStatusChanged += AppendMessage;

            // await Connect
            _ = chatService.ConnectToNats();

            Log.Information("ChatForm initialized for user: " + userName);
        }


        private async void ChatForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (chatService != null)
            {
                await chatService.Disconnect();
            }
        }



        public void AppendMessage(string message)
        {
            if (showMessageLayoutPanel.InvokeRequired)
            {
                showMessageLayoutPanel.Invoke(new Action(() => AppendMessage(message)));
                Log.Information("Message appended via Invoke: " + message);
            }
            else
            {
                Label labelMessage = new Label
                {
                    Text = message,
                    AutoSize = true,
                    MaximumSize = new Size(250, 0),
                    Font = new Font("Arial", 10),
                    Padding = new Padding(5),
                    Margin = new Padding(5),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.None
                };

                showMessageLayoutPanel.Controls.Add(labelMessage);
                showMessageLayoutPanel.ScrollControlIntoView(labelMessage);
                Log.Information("Message appended directly: " + message);
            }
        }



        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                // Disable the button to prevent duplicate clicks
                btnSend.Enabled = false;
                try
                {
                    await chatService.SendTextAsync(userName, message);
                    Log.Information("Message sent: " + message);
                    txtMessage.Clear();
                }
                finally
                {
                    // Re-enable the button regardless of success or failure
                    btnSend.Enabled = true;
                }
            }
            else
            {
                Log.Warning("Attempted to send empty message.");
            }
        }

        // Change the signature of btnSendFile_Click to match the expected EventHandler signature.
        // It should return void, not Task.

        private async void btnSendFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to send";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Disable the button to prevent duplicate clicks
                        btnSendFile.Enabled = false;
                        await chatService.SendFileAsync(userName, openFileDialog.FileName);
                        MessageBox.Show("File send initiated. Check log for status.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Log.Information("File send initiated: " + openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error preparing file for send: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error(ex, "Error preparing file for send: " + openFileDialog.FileName);
                    }
                    finally
                    {
                        // Re-enable the button
                        btnSendFile.Enabled = true;
                    }
                }
            }
        }
    }
}