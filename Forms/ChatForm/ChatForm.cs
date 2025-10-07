
using ChatAppNats.Data;
using ChatAppNats.Models;
using ChatAppNats.Services;
using Serilog;
using System.Data;
using System.Diagnostics;
using System.Drawing; // Make sure this is included
using System.Windows.Forms; // Make sure this is included

namespace ChatAppNats
{
    public partial class ChatForm : Form
    {
        private readonly ChatService _chatService;
        private readonly ILogger _logger;
        private readonly string? _userName;
        private readonly string? _targetUser;
        private readonly CreateGroupForm _createGroupForm;

        private string? _selectedUser;
        private int? _selectedUserId;
        private int CurrentUserId;
        public Group _selectedGroup;

        private Dictionary<string, Group> groupMap = new Dictionary<string, Group>();
        private readonly Dictionary<string, List<string>> _messages = new Dictionary<string, List<string>>();

        // Track the date of the last displayed message for date dividers
        private DateTime? _lastMessageDate = null;

        public ChatForm(string? userName, ILogger? logger = null)
        {
            InitializeComponent();

            _userName = (userName ?? "Unknown").Trim().ToLower();
            Text = $"Synapse - {_userName}";

            // Ensure ChatService is initialized early
            _chatService = new ChatService(_userName, null, _logger);
            _createGroupForm = new CreateGroupForm(userName, _chatService);

            _logger = logger ?? Log.Logger;
            _logger.Information("Opening ChatForm for User={User}, Target={Target}", _userName, _targetUser);

            try
            {
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
                // Ensure CurrentUserId is set on load
                using (var context = new ApplicationDbContext())
                {
                    var currentUser = context.Users.FirstOrDefault(u => u.UserName == _userName);
                    if (currentUser != null)
                    {
                        CurrentUserId = currentUser.UserId;
                    }

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

            LoadGroups();
        }


        private async void ImageButtonSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            // Use local time for message saving and display
            DateTime sendAt = DateTime.Now;

            if (!string.IsNullOrEmpty(message))
            {
                // ... (existing logic for sending message to group or user)
                try
                {
                    if (_selectedGroup != null)
                    {
                        string fullMessage = $"{_userName}: {message}";
                        await _chatService.publishGroupMessageAsync(_selectedGroup.GroupId, fullMessage);
                        DisplayMessage(_userName, message, sendAt, isMe: true);

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
                                    SendAt = sendAt,
                                    IsRead = true,
                                });
                                context.SaveChanges();
                            }
                        }
                    }
                    else if (_selectedUserId.HasValue)
                    {
                        string fullMessage = $"{_userName}: {message}";
                        await _chatService.PublishMessageAsync(fullMessage);
                        DisplayMessage(_userName, message, sendAt, isMe: true);

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
                                    SendAt = sendAt,
                                    IsRead = false
                                });
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a user or group to send a message.");
                        return;
                    }

                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error sending message from {User}", _userName);
                    MessageBox.Show($"Error sending message: {ex.Message}");
                }
            }
        }


        private void OnMessageReceived(string rawMessage)
        {
            try
            {
                string sender = "Other";
                string content = rawMessage;
                // Use local time for received messages
                DateTime receivedAt = DateTime.Now;

                var parts = rawMessage.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    sender = parts[0].Trim();
                    content = parts[1].Trim();
                }


                if (string.Equals(sender, _userName, StringComparison.OrdinalIgnoreCase))
                {
                    _logger.Debug("Ignoring self-sent message received via subscription.");
                    return;
                }

                string displaySender = sender;
                bool isMe = displaySender.Equals(_userName, StringComparison.OrdinalIgnoreCase);

                if (content.StartsWith("FILE:"))
                {
                    var fileParts = content.Split(new[] { ':' }, 3);
                    if (fileParts.Length == 3)
                    {
                        string fileName = fileParts[1];
                        string base64Data = fileParts[2];
                        try
                        {
                            byte[] fileBytes = Convert.FromBase64String(base64Data);
                            string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ChatDownloads");
                            Directory.CreateDirectory(downloadFolder);
                            string filePath = Path.Combine(downloadFolder, fileName);
                            File.WriteAllBytes(filePath, fileBytes);

                            if (flowLayoutPanelChat.InvokeRequired)
                            {
                                flowLayoutPanelChat.Invoke(new Action(() => DisplayMessage(displaySender, filePath, receivedAt, isMe, isFile: true)));
                            }
                            else
                            {
                                DisplayMessage(displaySender, filePath, receivedAt, isMe, isFile: true);
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, "Failed to process received file message.");
                        }
                    }
                }
                else
                {
                    // Standard text message
                    if (flowLayoutPanelChat.InvokeRequired)
                    {
                        flowLayoutPanelChat.Invoke(new Action(() => DisplayMessage(displaySender, content, receivedAt, isMe)));
                    }
                    else
                    {
                        DisplayMessage(displaySender, content, receivedAt, isMe);
                    }
                }

            }

            catch (Exception ex)
            {
                _logger.Error(ex, "Error processing received message in ChatForm for {User}", _userName);
            }
        }

        // ... (OnFormClosing, listBoxUsers_SelectedIndexChanged, ImageButtonAttachment_Click, SendFileToReceiver methods are unchanged)

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
                try
                {
                    lstGroups.ClearSelected();
                    _selectedGroup = null;

                    if (listBoxUsers.SelectedValue != null)
                    {
                        _selectedUserId = (int?)listBoxUsers.SelectedValue;
                    }

                    var selectedUserObj = listBoxUsers.SelectedItem as dynamic;
                    _selectedUser = selectedUserObj?.UserName?.ToString().Trim().ToLower();


                    if (!string.IsNullOrEmpty(_selectedUser) && _selectedUserId.HasValue)
                    {
                        _chatService.SetTargetUser(_selectedUser);
                        flowLayoutPanelChat.Controls.Clear();
                        _lastMessageDate = null;
                        LoadChatHistory(_selectedUserId.Value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in user selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                        .Where(m => m.GroupId == null)
                        .Where(m =>
                            (m.SenderId == senderUser.UserId && m.ReceiverId == targetUserId) ||
                            (m.SenderId == targetUserId && m.ReceiverId == senderUser.UserId))
                        .OrderBy(m => m.SendAt)
                        .ToList();

                    var userIds = chats.Select(c => c.SenderId).Distinct().ToList();


                    var userMap = context.Users
                        .Where(u => userIds.Contains(u.UserId))
                        .ToDictionary(u => u.UserId, u => u.UserName);

                    // Clear and reset date tracker
                    flowLayoutPanelChat.Controls.Clear();
                    _lastMessageDate = null;

                    foreach (var msg in chats)
                    {
                        string? senderName = userMap.ContainsKey(msg.SenderId) ? userMap[msg.SenderId] : $"User {msg.SenderId}";
                        bool isMe = msg.SenderId == senderUser.UserId;

                        DisplayMessage(senderName, msg.Text, msg.SendAt, isMe: isMe);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error loading chat history for {User}", _userName);
            }
        }

        // ... (ImageButtonAttachment_Click and SendFileToReceiver are unchanged)

        private void ImageButtonAttachment_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null && _selectedGroup == null)
            {
                MessageBox.Show("Please select a user or group before sending a file.");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select a file to send";
                ofd.Filter = "All files (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = ofd.FileName;
                    string fileName = Path.GetFileName(sourceFile);
                    DateTime sendAt = DateTime.Now;

                    string downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ChatDownloads");
                    Directory.CreateDirectory(downloadFolder);
                    string destFile = Path.Combine(downloadFolder, fileName);

                    try
                    {
                        // Copy the file to a local destination (e.g., for image preview)
                        File.Copy(sourceFile, destFile, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying file : " + ex.Message);
                        return;
                    }

                    // show in chat panel with the 'Me' alignment
                    DisplayMessage(_userName, destFile, sendAt, isMe: true, isFile: true);

                    // send to receiver
                    SendFileToReceiver(sourceFile, fileName);
                }
            }
        }

        private async void SendFileToReceiver(string filePath, string fileName)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string base64Data = Convert.ToBase64String(fileBytes);
                string message = $"FILE:{fileName}:{base64Data}";
                string finalMessage = $"{_userName}: {message}";

                if (_selectedGroup != null)
                {
                    await _chatService.publishGroupMessageAsync(_selectedGroup.GroupId, finalMessage);
                }
                else if (_selectedUser != null)
                {
                    await _chatService.PublishMessageAsync(_selectedUser, finalMessage);
                }
                else
                {
                    MessageBox.Show("No receiver selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending file: " + ex.Message);
            }
        }


        // ----------------------------------------------------------------------
        // MODIFIED METHOD: DisplayMessage (OPTIMIZED FOR VISUALS)
        // Uses a combination of FlowLayoutPanel (for alignment) and TableLayoutPanel (for content+time).
        // ----------------------------------------------------------------------
        private void DisplayMessage(string sender, string content, DateTime sendAt, bool isMe, bool isFile = false)
        {
            // 1. Check for Date Change and insert divider if necessary
            if (_lastMessageDate == null || _lastMessageDate.Value.Date != sendAt.Date)
            {
                InsertDateDivider(sendAt);
                _lastMessageDate = sendAt;
            }

            // --- Inner Message Bubble (Content Panel) ---

            // 2. Create the TableLayoutPanel for content and time
            TableLayoutPanel innerLayout = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(0),
                BackColor = Color.Transparent // Important: Use transparent background
            };
            // Message content will take up most space, time stamp will be fixed width
            innerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            innerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));

            // 3. Message Content Control (Label/Link/Picture)
            Control messageControl;
            if (!isFile)
            {
                Label lbl = new Label
                {
                    Text = content,
                    AutoSize = true,
                    MaximumSize = new Size(300, 0), // Max message width
                    Margin = new Padding(0, 0, 5, 0),
                    Font = new Font(FontFamily.GenericSansSerif, 10),
                    ForeColor = Color.Black
                };

                // Prepend sender name for group messages (only if not 'Me')
                if (!isMe && _selectedGroup != null)
                {
                    lbl.Text = $"{sender}: {content}";
                    lbl.MaximumSize = new Size(300, 0);
                }

                messageControl = lbl;
            }
            else
            {
                // ... (File/Image logic remains mostly the same, ensuring AutoSize and Tags are correct)
                string ext = Path.GetExtension(content).ToLower();
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                {
                    PictureBox pic = new PictureBox
                    {
                        Image = Image.FromFile(content),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 150,
                        Height = 150,
                        Cursor = Cursors.Hand,
                        Tag = content
                    };
                    pic.Click += (s, e) => Process.Start(new ProcessStartInfo { FileName = content, UseShellExecute = true });
                    messageControl = pic;
                }
                else
                {
                    LinkLabel link = new LinkLabel
                    {
                        Text = Path.GetFileName(content),
                        AutoSize = true,
                        Tag = content,
                        MaximumSize = new Size(300, 0),
                        ForeColor = Color.Blue
                    };
                    link.Click += (s, e) => Process.Start(new ProcessStartInfo { FileName = link.Tag.ToString(), UseShellExecute = true });
                    messageControl = link;
                }
                messageControl.Margin = new Padding(0, 0, 5, 0);
            }

            // 4. Time Stamp Label
            Label lblTime = new Label
            {
                Text = sendAt.ToShortTimeString(),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                TextAlign = ContentAlignment.BottomRight,
                Font = new Font(FontFamily.GenericSansSerif, 7, FontStyle.Regular),
                ForeColor = Color.Gray,
                Margin = new Padding(0),
                MinimumSize = new Size(45, 15) // Ensure minimum space for time
            };

            // 5. Add controls to inner layout
            innerLayout.Controls.Add(messageControl, 0, 0);
            innerLayout.Controls.Add(lblTime, 1, 0);

            // Set anchoring for content and time to keep them aligned
            messageControl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            messageControl.Margin = new Padding(0);

            // --- Outer Bubble Panel ---

            // 6. Message Bubble Panel
            Panel msgBubblePanel = new Panel
            {
                AutoSize = true,
                BackColor = isMe ? Color.FromArgb(220, 248, 198) : Color.White, // WhatsApp Green/White
                Padding = new Padding(8, 6, 8, 6),
                Margin = new Padding(5, 4, 5, 4), // Vertical spacing between bubbles
                MaximumSize = new Size(350, 0), // Max width for the bubble
                MinimumSize = new Size(100, 20) // Ensure a minimum size
            };
            msgBubblePanel.Controls.Add(innerLayout);
            innerLayout.Dock = DockStyle.Fill;


            // --- Alignment Container ---

            // 7. Outer FlowLayoutPanel for Alignment (Left or Right)
            FlowLayoutPanel alignmentPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                Width = flowLayoutPanelChat.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10, // Leave some margin
                // RightToLeft aligns controls to the right (sent messages)
                FlowDirection = isMe ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                WrapContents = false,
                Margin = new Padding(0)
            };

            // Add a padding label/panel to the *received* side to push it away from the left edge slightly
            if (!isMe)
            {
                alignmentPanel.Padding = new Padding(10, 0, 0, 0);
            }
            else
            {
                alignmentPanel.Padding = new Padding(0, 0, 10, 0);
            }

            alignmentPanel.Controls.Add(msgBubblePanel);

            // 8. Add to the main chat panel
            flowLayoutPanelChat.Controls.Add(alignmentPanel);

            // 9. Scroll to bottom (Using BeginInvoke for safety with rendering)
            flowLayoutPanelChat.BeginInvoke((MethodInvoker)delegate
            {
                flowLayoutPanelChat.ScrollControlIntoView(alignmentPanel);
                flowLayoutPanelChat.VerticalScroll.Value = flowLayoutPanelChat.VerticalScroll.Maximum;
            });
        }

        // ----------------------------------------------------------------------
        // NEW METHOD: InsertDateDivider
        // Creates and inserts a date header in the chat.
        // ----------------------------------------------------------------------
        private void InsertDateDivider(DateTime date)
        {
            string dateText = FormatDateForDivider(date);

            Label dateLabel = new Label
            {
                Text = dateText,
                AutoSize = true,
                BackColor = Color.FromArgb(220, 220, 220), // Light grey background for divider
                ForeColor = Color.Black,
                Padding = new Padding(8, 3, 8, 3),
                Margin = new Padding(0),
                BorderStyle = BorderStyle.None, // No border needed
                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)
            };

            // Create a small panel to contain and center the date label
            Panel centerPanel = new Panel
            {
                AutoSize = false,
                Height = dateLabel.Height + dateLabel.Padding.Vertical + 10,
                Width = flowLayoutPanelChat.ClientSize.Width,
                Margin = new Padding(0, 15, 0, 10), // Add vertical spacing around the date
                BackColor = Color.Transparent
            };

            centerPanel.Controls.Add(dateLabel);
            dateLabel.Location = new Point((centerPanel.Width - dateLabel.Width) / 2, 5); // Manually center

            flowLayoutPanelChat.Controls.Add(centerPanel);
        }

        // ----------------------------------------------------------------------
        // NEW METHOD: FormatDateForDivider
        // Formats the date string to "Today," "Yesterday," or a full date.
        // ----------------------------------------------------------------------
        private string FormatDateForDivider(DateTime date)
        {
            if (date.Date == DateTime.Today)
            {
                return "TODAY";
            }
            else if (date.Date == DateTime.Today.AddDays(-1))
            {
                return "YESTERDAY";
            }
            else
            {
                return date.ToString("dd/MM/yyyy").ToUpper();
            }
        }



        private void ImageButtonCreateGroup_Click(object sender, EventArgs e)
        {
            var createGroupForm = new CreateGroupForm(_userName, _chatService);
            createGroupForm.GroupCreated += () => LoadGroups();
            createGroupForm.ShowDialog();
        }



        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = lstGroups.SelectedItem;
            if (selectedItem == null) return;

            try
            {
                listBoxUsers.ClearSelected();
                _selectedUserId = null;

                string? selectedName = selectedItem.ToString() ?? string.Empty;
                if (!groupMap.ContainsKey(selectedName)) return;

                _selectedGroup = groupMap[selectedName];

                flowLayoutPanelChat.Controls.Clear();
                _lastMessageDate = null;

                _chatService.SubscribeDurableGroup(_selectedGroup.GroupId, OnMessageReceived);
                LoadGroupChatHistory(_selectedGroup.GroupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in group selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LoadGroups()
        {
            var groupNames = _createGroupForm.GetUserGroups(_userName);
            lstGroups.Items.Clear();
            groupMap.Clear();
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

                    var messages = context.Messages
                        .Where(m => m.GroupId == groupId)
                        .OrderBy(m => m.SendAt)
                        .ToList();

                    var userIds = messages.Select(m => m.SenderId).Distinct().ToList();
                    var userMap = context.Users
                        .Where(u => userIds.Contains(u.UserId))
                        .ToDictionary(u => u.UserId, u => u.UserName);

                    // Clear and reset date tracker
                    flowLayoutPanelChat.Controls.Clear();
                    _lastMessageDate = null;

                    foreach (var msg in messages)
                    {
                        string? senderName = userMap.ContainsKey(msg.SenderId)
                            ? userMap[msg.SenderId]
                            : $"User {msg.SenderId}";

                        bool isMe = msg.SenderId == CurrentUserId;

                        DisplayMessage(senderName, msg.Text, msg.SendAt, isMe: isMe);
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
