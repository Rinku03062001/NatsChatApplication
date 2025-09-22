using ChatAppNats.Data;
using ChatAppNats.Models;
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

        private string _selectedUser;
        private int? _selectedUserId;


        public ChatForm(string userName, ILogger logger = null)
        {
            InitializeComponent();

            _userName = (userName ?? "Unknown").Trim().ToLower();
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



        private async void ImageButtonSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    string fullMessage = $"{_userName}: {message}";
                    await _chatPublisher.PublishMessageAsync(fullMessage);

                    //lstLogs.Items.Add($"Me: {message}");
                    DisplayMessage("Me", message); 


                    // save messages to db
                    using (var context = new ApplicationDbContext())
                    {
                        var senderUser = context.Users.FirstOrDefault(u => u.UserName == _userName);
                        if (senderUser != null)
                        {
                            context.Messages.Add(new Models.Message
                            {
                                SenderId = senderUser.UserId,
                                ReceiverId = _selectedUserId.Value,
                                Text = message,
                                SendAt = DateTime.Now,
                                IsRead = false
                            });
                        }

                        context.SaveChanges();
                    }


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
                if (flowLayoutPanelChat.InvokeRequired)
                {
                    flowLayoutPanelChat.Invoke(new Action(() => DisplayMessage("Other", message, false)));
                }
                else
                {
                    //lstLogs.Items.Add(message);
                    DisplayMessage("Other", message, false);
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
            Application.Exit();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var users = context.Users
                        .Where(u => u.UserName != _userName)
                        .Select(u => new { u.UserId, u.UserName })
                        .ToList();

                    listBoxUsers.DisplayMember = "UserName";
                    listBoxUsers.ValueMember = "UserId";
                    listBoxUsers.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error loading registered users in ChatForm");
                MessageBox.Show("Error loading users. Check Logs.");
            }
        }



        private void OpenFileDialogFor(AttachmentType type)
        {
            MessageBox.Show($"You selected {type}");
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItems != null)
            {
                _selectedUserId = (int)listBoxUsers.SelectedValue;
                _logger.Information("{User} selected chat with {Target}", _userName, _selectedUser);

                // cleat old chat display
                //lstLogs.Items.Clear();
                flowLayoutPanelChat.Controls.Clear();

                // Load chat history 
                LoadChatHistory(_selectedUserId.Value);
            }
        }


        private void LoadChatHistory(int targetUserId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var senderUser = context.Users.FirstOrDefault(u => u.UserName == _userName);
                    if (senderUser == null) return;

                    var chats = context.Messages
                        .Where(m =>
                            (m.SenderId == senderUser.UserId && m.ReceiverId == targetUserId) ||
                            (m.SenderId == targetUserId && m.ReceiverId == senderUser.UserId))
                        .OrderBy(m => m.SendAt)
                        .ToList();


                    // fetch all involved users (sender + receivers)
                    var userIds = chats.Select(c => c.SenderId).Distinct().ToList();
                    var userMap = context.Users
                        .Where(u => userIds.Contains(u.UserId))
                        .ToDictionary(u => u.UserId, u => u.UserName);

                    //lstLogs.Items.Clear();
                    flowLayoutPanelChat.Controls.Clear();

                    foreach (var msg in chats)
                    {
                        string prefix = msg.SenderId == senderUser.UserId ? "Me" : userMap[msg.SenderId];
                        //lstLogs.Items.Add($"{prefix}: {msg.Text}");
                        DisplayMessage(prefix, msg.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error loading chat history for {User} with UserId {TargetId}",
                    _userName, targetUserId);
                MessageBox.Show("Error loading chat history. Check logs.");
            }
        }

        private void ImageButtonAttachment_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file to send";
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Multiselect = false;

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = ofd.FileName;
                    string fileName = Path.GetFileName(sourceFile);

                    // copy to desktop
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string destFile = Path.Combine(desktopPath, fileName);

                    try
                    {
                        File.Copy(sourceFile, destFile, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying file : " + ex.Message);
                        return;
                    }

                    // show in chat panel
                    DisplayMessage("Me", sourceFile, true);

                    // send to receiver
                    SendFileToReceiver(sourceFile, fileName);


                    // Show in lstLogs
                    //lstLogs.Items.Add($"You sent : {fileName}");

                 
                }
            }
        }



        private void SendFileToReceiver(string filePath, string fileName)
        {
            MessageBox.Show($"Sending File '{fileName}' to receiver... ");

            byte[] fileBytes = File.ReadAllBytes(filePath);
        }


        private void DisplayMessage(string sender, string content, bool isFile = false)
        {
            Panel msgPanel = new Panel
            {
                AutoSize = true,
                BackColor = sender == "Me" ? Color.LightBlue : Color.LightGreen,
                Padding = new Padding(5),
                Margin = new Padding(5)
            };

            if(!isFile)
            {
                // Normal Text
                Label lbl = new Label
                {
                    Text = $"{sender}: {content}",
                    AutoSize = true,
                    MaximumSize = new Size(300, 0)
                };
                msgPanel.Controls.Add(lbl);
            }
            else
            {
                string ext = Path.GetExtension(content).ToLower();
                if(ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                {
                    // Image Preview
                    PictureBox pic = new PictureBox
                    {
                        Image = Image.FromFile(content),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 150,
                        Height = 150
                    };
                    flowLayoutPanelChat.Controls.Add(pic);
                }
                else
                {
                    // Non Image File : SHow file name
                    LinkLabel link = new LinkLabel
                    {
                        Text = $"@ {Path.GetFileName(content)}",
                        AutoSize = true,
                        Tag = content
                    };
                    link.Click += (s, e) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = link.Tag.ToString(),
                            UseShellExecute = true
                        });
                    };
                    msgPanel.Controls.Add(link);
                }
            }

            flowLayoutPanelChat.Controls.Add(msgPanel);
            flowLayoutPanelChat.ScrollControlIntoView(msgPanel);
        }

    }
}