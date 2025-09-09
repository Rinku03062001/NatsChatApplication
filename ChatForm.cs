using ChatAppNats.Services;
using NLog;
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
                await chatService.SendMessageAsync(msg);
                logger.Info("Message sent: " + msg);
                txtMessage.Clear();
            }
            else
            {
                logger.Warn("Attempted to send empty message.");
            }
        }


    }
}