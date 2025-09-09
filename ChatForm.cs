using ChatAppNats.Services;
namespace ChatAppNats
{
    public partial class ChatForm : Form
    {
       
        ChatService chatService;
        

        public ChatForm()
        {
            InitializeComponent();
            

            chatService = new ChatService();

            // subscribe to service events
            chatService.OnMessageReceived += AppendMessage;
            chatService.OnStatusChanged += AppendMessage;

            // await Connect
            _ = chatService.ConnectToNats();
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

            string userName = Environment.UserName;
            string msg = $"{userName}: {message}";

            if (!string.IsNullOrEmpty(message))
            {
                await chatService.SendMessageAsync(msg);
                txtMessage.Clear();
            }
        }


    }
}