using ChatAppNats.Data;
using ChatAppNats.Models;
using ChatAppNats.Services;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Data;
using System.Windows.Forms;

namespace ChatAppNats
{
    public partial class ChatForm : Form
    {
        private readonly ChatService _chatService;
        private readonly ILogger _logger;
        private readonly string _userName;
        private readonly string _targetUser;
        private readonly CreateGroupForm _createGroupForm;

        private string _selectedUser;
        private int? _selectedUserId;



        public ChatForm(string userName, ILogger logger = null)
        {
            InitializeComponent();

            _userName = (userName ?? "Unknown").Trim().ToLower();
            Text = $"Synapse - {_userName}";

            _createGroupForm = new CreateGroupForm(userName, _chatService);

            _logger = logger ?? Log.Logger;
            _logger.Information("Opening ChatForm for User={User}, Target={Target}", _userName, _targetUser);

            try
            {
                _chatService = new ChatService(_userName, null, _logger);
                //_chatService.Subscribe(OnMessageReceived);
                _chatService.SubscribeDurable(OnMessageReceived);
                _logger.Information("ChatService subscription started for {User}", _userName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to initialize ChatService in ChatForm for {User}", _userName);
                MessageBox.Show("Failed to connect to chat service. Please check logs.");
            }
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

                    //_logger.Information("Users fetched: {Count}", users.Count);

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

            LoadGroups();
        }




        private async void ImageButtonSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    if (_selectedGroup != null)
                    {
                        string fullMessage = $"{_userName}: {message}";

                        // publish to nats subject for the group
                        await _chatService.publishGroupMessageAsync(_selectedGroup.GroupId, fullMessage);

                        // Display in chat panel
                        DisplayMessage("Me", message, isMe: true);

                        using (var context = new ApplicationDbContext())
                        {
                            var senderUser = context.Users.FirstOrDefault(u => u.UserName == _userName);
                            if (senderUser != null)
                            {
                                context.Messages.Add(new Models.Message
                                {
                                    SenderId = senderUser.UserId,
                                    GroupId = _selectedGroup.GroupId,
                                    Text = message,
                                    SendAt = DateTime.UtcNow,
                                    IsRead = true,
                                });
                                context.SaveChanges();
                            }
                        }
                        _logger.Information("User {User} sent message='{Message}' to Group {Group}",
                                _userName, message, _selectedGroup.GroupName);
                    }
                    else if (_selectedUserId.HasValue)
                    {
                        string fullMessage = $"{_userName}: {message}";
                        await _chatService.PublishMessageAsync(fullMessage);

                        //lstLogs.Items.Add($"Me: {message}");
                        DisplayMessage("Me", message, isMe: true);

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
                                context.SaveChanges();
                            }
                        }

                        _logger.Information("User {User} sent message='{Message}' to UserId {TargetId}",
                                    _userName, message, _selectedUserId.Value);
                    }
                    else
                    {
                        // No recipient selected
                        MessageBox.Show("Please select a user or group to send a message.");
                        return;
                    }

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

        private void OnMessageReceived(string rawMessage)
        {
            try
            {
                // Messages come in as "sender: content"
                string sender = "Other";
                string content = rawMessage;

                var parts = rawMessage.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    sender = parts[0].Trim();
                    content = parts[1].Trim();

                    // if the sender is me mark it
                    if (string.Equals(sender, _userName, StringComparison.OrdinalIgnoreCase))
                    {
                        sender = "Me";
                    }
                }


                if (flowLayoutPanelChat.InvokeRequired)
                {
                    flowLayoutPanelChat.Invoke(new Action(() => DisplayMessage(sender, content, false)));
                }
                else
                {
                    //lstLogs.Items.Add(message);
                    DisplayMessage(sender, content, isMe: sender == "Me");
                }

                _logger.Information("User {User} received message='{Message}'", _userName, rawMessage);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error processing received message in ChatForm for {User}", _userName);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _logger.Information("Closing ChatForm for {User}", _userName);
            _chatService?.Dispose();
            base.OnFormClosing(e);
            Application.Exit();
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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file to send";
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
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


        private void DisplayMessage(string sender, string content, bool isMe = false, bool isFile = false)
        {
            Panel msgPanel = new Panel
            {
                AutoSize = true,
                BackColor = sender == "Me" ? Color.LightBlue : Color.LightGreen,
                Padding = new Padding(5),
                Margin = new Padding(5)
            };

            if (!isFile)
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
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
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

        private void ImageButtonCreateGroup_Click(object sender, EventArgs e)
        {
            var createGroupForm = new CreateGroupForm(_userName, _chatService);

            // Subscribe to event
            createGroupForm.GroupCreated += () => LoadGroups();

            createGroupForm.ShowDialog();
        }


        private Dictionary<string, Group> groupMap = new Dictionary<string, Group>();
        private void LoadGroups()
        {
            var groupNames = _createGroupForm.GetUserGroups(_userName);


            //lstGroups.DataSource = groups;
            //lstGroups.DisplayMember = "GroupName"; // what will be shown in the listbox
            //lstGroups.ValueMember = "GroupId";

            lstGroups.Items.Clear();
            groupMap.Clear();

            //foreach (var group in groups)
            //{
            //    lstGroups.Items.Add(group);
            //}
            using (var context = new ApplicationDbContext())
            {
                foreach (var name in groupNames)
                {
                    var group = context.Groups.FirstOrDefault(g => g.GroupName == name);
                    if (group != null)
                    {
                        lstGroups.Items.Add(name);
                        groupMap[name] = group;
                    }
                }
            }
        }


        private Group _selectedGroup;
        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItem == null) return;

            string selectedName = lstGroups.SelectedItem.ToString();
            if (!groupMap.ContainsKey(selectedName)) return;

            _selectedGroup = groupMap[selectedName];


            _logger.Information("{User} selected group {Group}", _userName, _selectedGroup.GroupName);

            // clear old chat
            flowLayoutPanelChat.Controls.Clear();


            // Subscribe to this group's message
            _chatService.SubscribeDurableGroup(_selectedGroup.GroupId, OnMessageReceived);

            // Load Group Chat Messages
            LoadGroupChatHistory(_selectedGroup.GroupId);
        }


        private int CurrentUserId;
        private void LoadGroupChatHistory(int groupId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (CurrentUserId == 0)
                    {
                        var user = context.Users.FirstOrDefault(u => u.UserName == _userName);
                        if (user != null)
                        {
                            CurrentUserId = user.UserId;
                        }
                    }


                    //var group = context.Groups.FirstOrDefault(g => g.GroupId == groupId);
                    //if (group == null) return;

                    var messages = context.Messages
                        .Where(m => m.GroupId == groupId)
                        .OrderBy(m => m.SendAt)
                        .ToList();


                    var userIds = messages.Select(m => m.SenderId).Distinct().ToList();
                    var userMap = context.Users
                        .Where(u => userIds.Contains(u.UserId))
                        .ToDictionary(u => u.UserId, u => u.UserName);

                    foreach (var msg in messages)
                    {
                        string senderName = userMap.ContainsKey(msg.SenderId)
                            ? userMap[msg.SenderId]
                            : $"User {msg.SenderId}";

                        DisplayMessage(senderName, msg.Text, isMe:msg.SenderId == CurrentUserId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error loading group chat history for {User}", _userName);
                MessageBox.Show("Error loading group chat history. Check logs.");
            }
        }
    }
}