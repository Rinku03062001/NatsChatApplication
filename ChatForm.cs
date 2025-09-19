using ChatAppNats.Services;
using Serilog;
using System;
using System.Windows.Forms;

namespace ChatAppNats
{
    public partial class ChatForm : Form
    {
        private readonly ChatService _chatPublisher;
        private readonly ILogger _logger;
        private readonly string _userName;
        private readonly string _targetUser;

        public ChatForm(string userName, string targetUser = null, ILogger logger = null)
        {
            InitializeComponent();

            _userName = (userName ?? "Unknown").Trim().ToLower();
            _targetUser = (targetUser ?? "Unknown").Trim().ToLower();
            Text = $"Synapse - {_userName}";

            _logger = logger ?? Log.Logger;

            _logger.Information("Opening ChatForm for User={User}, Target={Target}", _userName, _targetUser);

            try
            {
                _chatPublisher = new ChatService(_userName, _targetUser, _logger);
                _chatPublisher.Subscribe(OnMessageReceived);
                _logger.Information("ChatService subscription started for {User}", _userName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to initialize ChatService in ChatForm for {User}", _userName);
                MessageBox.Show("Failed to connect to chat service. Please check logs.");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    string fullMessage = $"{_userName}: {message}";
                    await _chatPublisher.PublishMessageAsync(fullMessage);

                    lstLogs.Items.Add($"Me: {message}");
                    _logger.Information("User {User} sent message='{Message}' to {Target}", _userName, message, _targetUser);

                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error sending message from {User} to {Target}", _userName, _targetUser);
                    MessageBox.Show($"Error sending message: {ex.Message}");
                }
            }
            else
            {
                _logger.Warning("Send button clicked by {User}, but message was empty", _userName);
            }
        }

        private void OnMessageReceived(string message)
        {
            try
            {
                if (lstLogs.InvokeRequired)
                {
                    lstLogs.Invoke(new Action(() => lstLogs.Items.Add(message)));
                }
                else
                {
                    lstLogs.Items.Add(message);
                }

                _logger.Information("User {User} received message='{Message}'", _userName, message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error processing received message in ChatForm for {User}", _userName);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _logger.Information("Closing ChatForm for {User}", _userName);
            _chatPublisher?.Dispose();
            base.OnFormClosing(e);
        }

    }
}
