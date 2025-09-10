using ChatAppNats.Services;
using NLog;
using System.Threading.Tasks;
namespace ChatAppNats
{
    public partial class ChatForm : Form
    {
        //NLog Logger
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        ChatService chatService;
        private readonly string userName;

        public ChatForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;

            chatService = new ChatService();

            // subscribe to service events
            chatService.OnMessageReceived += AppendMessage;
            chatService.OnStatusChanged += AppendMessage;

            // await Connect
            _ = chatService.ConnectToNats();

            logger.Info("ChatForm initialized for user: " + userName);
        }



        public void AppendMessage(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => listBox1.Items.Add(message)));
                logger.Info("Message appended via Invoke: " + message);
            }
            else
            {
                listBox1.Items.Add(message);
                logger.Info("Message appended directly: " + message);
            }
        }



        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            string msg = $"{userName}: {message}";

            if (!string.IsNullOrEmpty(message))
            {
                await chatService.SendTextAsync(msg);
                logger.Info("Message sent: " + msg);
                txtMessage.Clear();
            }
            else
            {
                logger.Warn("Attempted to send empty message.");
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
                        await chatService.SendFileAsync(openFileDialog.FileName);
                        MessageBox.Show("File sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error sending file : " + ex.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
    }
}