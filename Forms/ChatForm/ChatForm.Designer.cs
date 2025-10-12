namespace ChatAppNats
{
    partial class ChatForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            txtMessage = new TextBox();
            panelTypeMessage = new Panel();
            pictureBoxSend = new PictureBox();
            pictureBoxAttachment = new PictureBox();
            pictureBoxEmoji = new PictureBox();
            splitContainer1 = new SplitContainer();
            panelLeft2 = new Panel();
            lstGroups = new ListBox();
            panelLeftHeader2 = new Panel();
            pictureBoxCreateGroup = new PictureBox();
            lblChatTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panelLeft1 = new Panel();
            listBoxUsers = new ListBox();
            panelLeftHeader1 = new Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel1 = new Panel();
            panelShowMessage = new Panel();
            flowLayoutPanelChat = new FlowLayoutPanel();
            topPanel = new Panel();
            pictureBoxVoiceCall = new PictureBox();
            pictureBoxSearch = new PictureBox();
            pictureBoxLogOut = new PictureBox();
            pictureBoxVideoCall = new PictureBox();
            lblChatUser = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolTipPictureBox = new ToolTip(components);
            panelTypeMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAttachment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmoji).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeft2.SuspendLayout();
            panelLeftHeader2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCreateGroup).BeginInit();
            panelLeft1.SuspendLayout();
            panelLeftHeader1.SuspendLayout();
            panel1.SuspendLayout();
            panelShowMessage.SuspendLayout();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVoiceCall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideoCall).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.HideSelection = false;
            txtMessage.Location = new Point(91, 10);
            txtMessage.Margin = new Padding(3, 2, 3, 2);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Type a Message......";
            txtMessage.Size = new Size(559, 51);
            txtMessage.TabIndex = 1;
            // 
            // panelTypeMessage
            // 
            panelTypeMessage.Controls.Add(pictureBoxSend);
            panelTypeMessage.Controls.Add(txtMessage);
            panelTypeMessage.Controls.Add(pictureBoxAttachment);
            panelTypeMessage.Controls.Add(pictureBoxEmoji);
            panelTypeMessage.Dock = DockStyle.Bottom;
            panelTypeMessage.Location = new Point(0, 359);
            panelTypeMessage.Margin = new Padding(3, 2, 3, 2);
            panelTypeMessage.Name = "panelTypeMessage";
            panelTypeMessage.Size = new Size(699, 65);
            panelTypeMessage.TabIndex = 4;
            // 
            // pictureBoxSend
            // 
            pictureBoxSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxSend.BackColor = Color.Transparent;
            pictureBoxSend.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSend.Image = (Image)resources.GetObject("pictureBoxSend.Image");
            pictureBoxSend.Location = new Point(656, 20);
            pictureBoxSend.Name = "pictureBoxSend";
            pictureBoxSend.Size = new Size(34, 33);
            pictureBoxSend.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSend.TabIndex = 7;
            pictureBoxSend.TabStop = false;
            pictureBoxSend.Click += pictureBoxSend_Click;
            // 
            // pictureBoxAttachment
            // 
            pictureBoxAttachment.Image = (Image)resources.GetObject("pictureBoxAttachment.Image");
            pictureBoxAttachment.Location = new Point(47, 20);
            pictureBoxAttachment.Name = "pictureBoxAttachment";
            pictureBoxAttachment.Size = new Size(38, 32);
            pictureBoxAttachment.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAttachment.TabIndex = 7;
            pictureBoxAttachment.TabStop = false;
            pictureBoxAttachment.Click += pictureBoxAttachment_Click;
            // 
            // pictureBoxEmoji
            // 
            pictureBoxEmoji.Image = (Image)resources.GetObject("pictureBoxEmoji.Image");
            pictureBoxEmoji.Location = new Point(3, 20);
            pictureBoxEmoji.Name = "pictureBoxEmoji";
            pictureBoxEmoji.Size = new Size(38, 32);
            pictureBoxEmoji.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEmoji.TabIndex = 7;
            pictureBoxEmoji.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelLeft2);
            splitContainer1.Panel1.Controls.Add(panelLeft1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(panelTypeMessage);
            splitContainer1.Size = new Size(1029, 424);
            splitContainer1.SplitterDistance = 326;
            splitContainer1.TabIndex = 6;
            // 
            // panelLeft2
            // 
            panelLeft2.Controls.Add(lstGroups);
            panelLeft2.Controls.Add(panelLeftHeader2);
            panelLeft2.Dock = DockStyle.Right;
            panelLeft2.Location = new Point(173, 0);
            panelLeft2.Margin = new Padding(3, 2, 3, 2);
            panelLeft2.Name = "panelLeft2";
            panelLeft2.Size = new Size(153, 424);
            panelLeft2.TabIndex = 5;
            // 
            // lstGroups
            // 
            lstGroups.BackColor = Color.SkyBlue;
            lstGroups.Dock = DockStyle.Fill;
            lstGroups.FormattingEnabled = true;
            lstGroups.ItemHeight = 15;
            lstGroups.Location = new Point(0, 37);
            lstGroups.Margin = new Padding(3, 2, 3, 2);
            lstGroups.Name = "lstGroups";
            lstGroups.Size = new Size(153, 387);
            lstGroups.TabIndex = 0;
            lstGroups.SelectedIndexChanged += lstGroups_SelectedIndexChanged;
            // 
            // panelLeftHeader2
            // 
            panelLeftHeader2.BackColor = Color.Transparent;
            panelLeftHeader2.Controls.Add(pictureBoxCreateGroup);
            panelLeftHeader2.Controls.Add(lblChatTitle);
            panelLeftHeader2.Dock = DockStyle.Top;
            panelLeftHeader2.Location = new Point(0, 0);
            panelLeftHeader2.Margin = new Padding(3, 2, 3, 2);
            panelLeftHeader2.Name = "panelLeftHeader2";
            panelLeftHeader2.Size = new Size(153, 37);
            panelLeftHeader2.TabIndex = 1;
            // 
            // pictureBoxCreateGroup
            // 
            pictureBoxCreateGroup.Image = (Image)resources.GetObject("pictureBoxCreateGroup.Image");
            pictureBoxCreateGroup.Location = new Point(118, 10);
            pictureBoxCreateGroup.Name = "pictureBoxCreateGroup";
            pictureBoxCreateGroup.Size = new Size(32, 24);
            pictureBoxCreateGroup.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCreateGroup.TabIndex = 4;
            pictureBoxCreateGroup.TabStop = false;
            pictureBoxCreateGroup.Click += pictureBoxCreateGroup_Click;
            // 
            // lblChatTitle
            // 
            lblChatTitle.BackColor = Color.Transparent;
            lblChatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatTitle.ForeColor = Color.Blue;
            lblChatTitle.Location = new Point(3, 7);
            lblChatTitle.Margin = new Padding(3, 2, 3, 2);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(57, 23);
            lblChatTitle.TabIndex = 3;
            lblChatTitle.Text = "Groups\r\n";
            // 
            // panelLeft1
            // 
            panelLeft1.Controls.Add(listBoxUsers);
            panelLeft1.Controls.Add(panelLeftHeader1);
            panelLeft1.Dock = DockStyle.Fill;
            panelLeft1.Location = new Point(0, 0);
            panelLeft1.Margin = new Padding(3, 2, 3, 2);
            panelLeft1.Name = "panelLeft1";
            panelLeft1.Size = new Size(326, 424);
            panelLeft1.TabIndex = 4;
            // 
            // listBoxUsers
            // 
            listBoxUsers.BackColor = SystemColors.GradientInactiveCaption;
            listBoxUsers.BorderStyle = BorderStyle.FixedSingle;
            listBoxUsers.Dock = DockStyle.Fill;
            listBoxUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxUsers.ForeColor = SystemColors.InactiveCaptionText;
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.ItemHeight = 19;
            listBoxUsers.Location = new Point(0, 37);
            listBoxUsers.Margin = new Padding(3, 2, 3, 2);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(326, 387);
            listBoxUsers.TabIndex = 0;
            listBoxUsers.SelectedIndexChanged += listBoxUsers_SelectedIndexChanged;
            // 
            // panelLeftHeader1
            // 
            panelLeftHeader1.BackColor = Color.OldLace;
            panelLeftHeader1.Controls.Add(guna2HtmlLabel1);
            panelLeftHeader1.Dock = DockStyle.Top;
            panelLeftHeader1.Location = new Point(0, 0);
            panelLeftHeader1.Margin = new Padding(3, 2, 3, 2);
            panelLeftHeader1.Name = "panelLeftHeader1";
            panelLeftHeader1.Size = new Size(326, 37);
            panelLeftHeader1.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Indigo;
            guna2HtmlLabel1.Location = new Point(10, 7);
            guna2HtmlLabel1.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(69, 31);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Chats";
            // 
            // panel1
            // 
            panel1.Controls.Add(panelShowMessage);
            panel1.Controls.Add(topPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(699, 359);
            panel1.TabIndex = 5;
            // 
            // panelShowMessage
            // 
            panelShowMessage.Controls.Add(flowLayoutPanelChat);
            panelShowMessage.Dock = DockStyle.Fill;
            panelShowMessage.Location = new Point(0, 37);
            panelShowMessage.Margin = new Padding(3, 2, 3, 2);
            panelShowMessage.Name = "panelShowMessage";
            panelShowMessage.Size = new Size(699, 322);
            panelShowMessage.TabIndex = 8;
            // 
            // flowLayoutPanelChat
            // 
            flowLayoutPanelChat.AutoScroll = true;
            flowLayoutPanelChat.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanelChat.Dock = DockStyle.Fill;
            flowLayoutPanelChat.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelChat.Location = new Point(0, 0);
            flowLayoutPanelChat.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanelChat.Name = "flowLayoutPanelChat";
            flowLayoutPanelChat.Size = new Size(699, 322);
            flowLayoutPanelChat.TabIndex = 6;
            flowLayoutPanelChat.WrapContents = false;
            // 
            // topPanel
            // 
            topPanel.BackColor = SystemColors.InactiveCaption;
            topPanel.Controls.Add(pictureBoxVoiceCall);
            topPanel.Controls.Add(pictureBoxSearch);
            topPanel.Controls.Add(pictureBoxLogOut);
            topPanel.Controls.Add(pictureBoxVideoCall);
            topPanel.Controls.Add(lblChatUser);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 2, 3, 2);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(699, 37);
            topPanel.TabIndex = 7;
            // 
            // pictureBoxVoiceCall
            // 
            pictureBoxVoiceCall.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxVoiceCall.BackColor = Color.Transparent;
            pictureBoxVoiceCall.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxVoiceCall.Image = (Image)resources.GetObject("pictureBoxVoiceCall.Image");
            pictureBoxVoiceCall.InitialImage = (Image)resources.GetObject("pictureBoxVoiceCall.InitialImage");
            pictureBoxVoiceCall.Location = new Point(618, 5);
            pictureBoxVoiceCall.Name = "pictureBoxVoiceCall";
            pictureBoxVoiceCall.Size = new Size(35, 25);
            pictureBoxVoiceCall.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxVoiceCall.TabIndex = 7;
            pictureBoxVoiceCall.TabStop = false;
            // 
            // pictureBoxSearch
            // 
            pictureBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxSearch.BackColor = Color.Transparent;
            pictureBoxSearch.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxSearch.Image = (Image)resources.GetObject("pictureBoxSearch.Image");
            pictureBoxSearch.InitialImage = (Image)resources.GetObject("pictureBoxSearch.InitialImage");
            pictureBoxSearch.Location = new Point(659, 5);
            pictureBoxSearch.Name = "pictureBoxSearch";
            pictureBoxSearch.Size = new Size(35, 25);
            pictureBoxSearch.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSearch.TabIndex = 7;
            pictureBoxSearch.TabStop = false;
            // 
            // pictureBoxLogOut
            // 
            pictureBoxLogOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxLogOut.BackColor = Color.Transparent;
            pictureBoxLogOut.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxLogOut.Image = (Image)resources.GetObject("pictureBoxLogOut.Image");
            pictureBoxLogOut.InitialImage = (Image)resources.GetObject("pictureBoxLogOut.InitialImage");
            pictureBoxLogOut.Location = new Point(521, 5);
            pictureBoxLogOut.Name = "pictureBoxLogOut";
            pictureBoxLogOut.Size = new Size(35, 25);
            pictureBoxLogOut.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogOut.TabIndex = 7;
            pictureBoxLogOut.TabStop = false;
            pictureBoxLogOut.Click += pictureBoxLogOut_Click;
            // 
            // pictureBoxVideoCall
            // 
            pictureBoxVideoCall.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxVideoCall.BackColor = Color.Transparent;
            pictureBoxVideoCall.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxVideoCall.Image = (Image)resources.GetObject("pictureBoxVideoCall.Image");
            pictureBoxVideoCall.InitialImage = (Image)resources.GetObject("pictureBoxVideoCall.InitialImage");
            pictureBoxVideoCall.Location = new Point(574, 5);
            pictureBoxVideoCall.Name = "pictureBoxVideoCall";
            pictureBoxVideoCall.Size = new Size(35, 25);
            pictureBoxVideoCall.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxVideoCall.TabIndex = 7;
            pictureBoxVideoCall.TabStop = false;
            // 
            // lblChatUser
            // 
            lblChatUser.AutoSize = true;
            lblChatUser.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatUser.ForeColor = Color.Navy;
            lblChatUser.Location = new Point(35, 10);
            lblChatUser.Name = "lblChatUser";
            lblChatUser.Size = new Size(95, 20);
            lblChatUser.TabIndex = 2;
            lblChatUser.Text = "select a user";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 26);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolTipPictureBox
            // 
            toolTipPictureBox.Popup += toolTipLogout_Popup;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1029, 424);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Synapse";
            Load += ChatForm_Load;
            panelTypeMessage.ResumeLayout(false);
            panelTypeMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSend).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAttachment).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmoji).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelLeft2.ResumeLayout(false);
            panelLeftHeader2.ResumeLayout(false);
            panelLeftHeader2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCreateGroup).EndInit();
            panelLeft1.ResumeLayout(false);
            panelLeftHeader1.ResumeLayout(false);
            panelLeftHeader1.PerformLayout();
            panel1.ResumeLayout(false);
            panelShowMessage.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVoiceCall).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideoCall).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtMessage;
        private Panel panelTypeMessage;
        private SplitContainer splitContainer1;
        private ListBox listBoxUsers;
        private FlowLayoutPanel flowLayoutPanelChat;
        private Panel topPanel;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonAudioCall;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private ListBox lstGroups;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChatTitle;
        private Panel panelLeft1;
        private Panel panelLeftHeader1;
        private Panel panelLeft2;
        private Panel panelLeftHeader2;
        private Panel panel1;
        private Panel panelShowMessage;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private Label lblChatUser;
        private PictureBox pictureBoxVideoCall;
        private PictureBox pictureBoxVoiceCall;
        private PictureBox pictureBoxSearch;
        private PictureBox pictureBoxLogOut;
        private PictureBox pictureBoxSend;
        private PictureBox pictureBoxAttachment;
        private PictureBox pictureBoxEmoji;
        private ToolTip toolTipPictureBox;
        private PictureBox pictureBoxCreateGroup;
    }
}
