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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtMessage = new TextBox();
            panelTypeMessage = new Panel();
            ImageButtonEmojis = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonAttachment = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonSend = new Guna.UI2.WinForms.Guna2ImageButton();
            splitContainer1 = new SplitContainer();
            panelLeft2 = new Panel();
            lstGroups = new ListBox();
            panelLeftHeader2 = new Panel();
            lblChatTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ImageButtonCreateGroup = new Guna.UI2.WinForms.Guna2ImageButton();
            panelLeft1 = new Panel();
            listBoxUsers = new ListBox();
            panelLeftHeader1 = new Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel1 = new Panel();
            panelShowMessage = new Panel();
            flowLayoutPanelChat = new FlowLayoutPanel();
            topPanel = new Panel();
            guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonAudioCall = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonVideoCall = new Guna.UI2.WinForms.Guna2ImageButton();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            panelTypeMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeft2.SuspendLayout();
            panelLeftHeader2.SuspendLayout();
            panelLeft1.SuspendLayout();
            panelLeftHeader1.SuspendLayout();
            panel1.SuspendLayout();
            panelShowMessage.SuspendLayout();
            topPanel.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.Location = new Point(102, 10);
            txtMessage.Margin = new Padding(3, 2, 3, 2);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(548, 51);
            txtMessage.TabIndex = 1;
            // 
            // panelTypeMessage
            // 
            panelTypeMessage.Controls.Add(ImageButtonEmojis);
            panelTypeMessage.Controls.Add(txtMessage);
            panelTypeMessage.Controls.Add(ImageButtonAttachment);
            panelTypeMessage.Controls.Add(ImageButtonSend);
            panelTypeMessage.Dock = DockStyle.Bottom;
            panelTypeMessage.Location = new Point(0, 359);
            panelTypeMessage.Margin = new Padding(3, 2, 3, 2);
            panelTypeMessage.Name = "panelTypeMessage";
            panelTypeMessage.Size = new Size(699, 65);
            panelTypeMessage.TabIndex = 4;
            // 
            // ImageButtonEmojis
            // 
            ImageButtonEmojis.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonEmojis.HoverState.ImageSize = new Size(64, 64);
            ImageButtonEmojis.Image = (Image)resources.GetObject("ImageButtonEmojis.Image");
            ImageButtonEmojis.ImageOffset = new Point(0, 0);
            ImageButtonEmojis.ImageRotate = 0F;
            ImageButtonEmojis.ImageSize = new Size(36, 36);
            ImageButtonEmojis.Location = new Point(11, 11);
            ImageButtonEmojis.Margin = new Padding(3, 2, 3, 2);
            ImageButtonEmojis.Name = "ImageButtonEmojis";
            ImageButtonEmojis.PressedState.ImageSize = new Size(64, 64);
            ImageButtonEmojis.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ImageButtonEmojis.Size = new Size(33, 49);
            ImageButtonEmojis.TabIndex = 6;
            // 
            // ImageButtonAttachment
            // 
            ImageButtonAttachment.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonAttachment.HoverState.ImageSize = new Size(64, 64);
            ImageButtonAttachment.Image = (Image)resources.GetObject("ImageButtonAttachment.Image");
            ImageButtonAttachment.ImageOffset = new Point(0, 0);
            ImageButtonAttachment.ImageRotate = 0F;
            ImageButtonAttachment.ImageSize = new Size(36, 36);
            ImageButtonAttachment.Location = new Point(54, 11);
            ImageButtonAttachment.Margin = new Padding(3, 2, 3, 2);
            ImageButtonAttachment.Name = "ImageButtonAttachment";
            ImageButtonAttachment.PressedState.ImageSize = new Size(64, 64);
            ImageButtonAttachment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ImageButtonAttachment.Size = new Size(32, 49);
            ImageButtonAttachment.TabIndex = 5;
            ImageButtonAttachment.Click += ImageButtonAttachment_Click;
            // 
            // ImageButtonSend
            // 
            ImageButtonSend.Anchor = AnchorStyles.Right;
            ImageButtonSend.BackColor = Color.Transparent;
            ImageButtonSend.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonSend.HoverState.ImageSize = new Size(64, 64);
            ImageButtonSend.Image = (Image)resources.GetObject("ImageButtonSend.Image");
            ImageButtonSend.ImageOffset = new Point(0, 0);
            ImageButtonSend.ImageRotate = 0F;
            ImageButtonSend.ImageSize = new Size(36, 36);
            ImageButtonSend.Location = new Point(654, 11);
            ImageButtonSend.Margin = new Padding(3, 2, 3, 2);
            ImageButtonSend.Name = "ImageButtonSend";
            ImageButtonSend.PressedState.ImageSize = new Size(64, 64);
            ImageButtonSend.ShadowDecoration.CustomizableEdges = customizableEdges3;
            ImageButtonSend.Size = new Size(40, 49);
            ImageButtonSend.TabIndex = 4;
            ImageButtonSend.Click += ImageButtonSend_Click;
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
            panelLeftHeader2.Controls.Add(lblChatTitle);
            panelLeftHeader2.Controls.Add(ImageButtonCreateGroup);
            panelLeftHeader2.Dock = DockStyle.Top;
            panelLeftHeader2.Location = new Point(0, 0);
            panelLeftHeader2.Margin = new Padding(3, 2, 3, 2);
            panelLeftHeader2.Name = "panelLeftHeader2";
            panelLeftHeader2.Size = new Size(153, 37);
            panelLeftHeader2.TabIndex = 1;
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
            // ImageButtonCreateGroup
            // 
            ImageButtonCreateGroup.BackColor = Color.Transparent;
            ImageButtonCreateGroup.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonCreateGroup.HoverState.ImageSize = new Size(64, 64);
            ImageButtonCreateGroup.Image = (Image)resources.GetObject("ImageButtonCreateGroup.Image");
            ImageButtonCreateGroup.ImageOffset = new Point(0, 0);
            ImageButtonCreateGroup.ImageRotate = 0F;
            ImageButtonCreateGroup.ImageSize = new Size(30, 30);
            ImageButtonCreateGroup.Location = new Point(114, 10);
            ImageButtonCreateGroup.Margin = new Padding(3, 2, 3, 2);
            ImageButtonCreateGroup.Name = "ImageButtonCreateGroup";
            ImageButtonCreateGroup.PressedState.ImageSize = new Size(64, 64);
            ImageButtonCreateGroup.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ImageButtonCreateGroup.Size = new Size(37, 22);
            ImageButtonCreateGroup.TabIndex = 2;
            ImageButtonCreateGroup.Click += ImageButtonCreateGroup_Click;
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
            topPanel.Controls.Add(guna2ImageButton1);
            topPanel.Controls.Add(ImageButtonAudioCall);
            topPanel.Controls.Add(ImageButtonVideoCall);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 2, 3, 2);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(699, 37);
            topPanel.TabIndex = 7;
            // 
            // guna2ImageButton1
            // 
            guna2ImageButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
            guna2ImageButton1.ImageOffset = new Point(0, 0);
            guna2ImageButton1.ImageRotate = 0F;
            guna2ImageButton1.ImageSize = new Size(30, 30);
            guna2ImageButton1.Location = new Point(653, 4);
            guna2ImageButton1.Margin = new Padding(3, 2, 3, 2);
            guna2ImageButton1.Name = "guna2ImageButton1";
            guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2ImageButton1.Size = new Size(32, 30);
            guna2ImageButton1.TabIndex = 0;
            // 
            // ImageButtonAudioCall
            // 
            ImageButtonAudioCall.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImageButtonAudioCall.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.HoverState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.Image = (Image)resources.GetObject("ImageButtonAudioCall.Image");
            ImageButtonAudioCall.ImageOffset = new Point(0, 0);
            ImageButtonAudioCall.ImageRotate = 0F;
            ImageButtonAudioCall.ImageSize = new Size(30, 30);
            ImageButtonAudioCall.Location = new Point(604, 2);
            ImageButtonAudioCall.Margin = new Padding(3, 2, 3, 2);
            ImageButtonAudioCall.Name = "ImageButtonAudioCall";
            ImageButtonAudioCall.PressedState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ImageButtonAudioCall.Size = new Size(32, 32);
            ImageButtonAudioCall.TabIndex = 0;
            // 
            // ImageButtonVideoCall
            // 
            ImageButtonVideoCall.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImageButtonVideoCall.AnimatedGIF = true;
            ImageButtonVideoCall.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonVideoCall.HoverState.ImageSize = new Size(64, 64);
            ImageButtonVideoCall.Image = (Image)resources.GetObject("ImageButtonVideoCall.Image");
            ImageButtonVideoCall.ImageOffset = new Point(0, 0);
            ImageButtonVideoCall.ImageRotate = 0F;
            ImageButtonVideoCall.ImageSize = new Size(30, 30);
            ImageButtonVideoCall.Location = new Point(547, 2);
            ImageButtonVideoCall.Margin = new Padding(3, 2, 3, 2);
            ImageButtonVideoCall.Name = "ImageButtonVideoCall";
            ImageButtonVideoCall.PressedState.ImageSize = new Size(64, 64);
            ImageButtonVideoCall.ShadowDecoration.CustomizableEdges = customizableEdges7;
            ImageButtonVideoCall.Size = new Size(32, 32);
            ImageButtonVideoCall.TabIndex = 0;
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
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelLeft2.ResumeLayout(false);
            panelLeftHeader2.ResumeLayout(false);
            panelLeftHeader2.PerformLayout();
            panelLeft1.ResumeLayout(false);
            panelLeftHeader1.ResumeLayout(false);
            panelLeftHeader1.PerformLayout();
            panel1.ResumeLayout(false);
            panelShowMessage.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtMessage;
        private Panel panelTypeMessage;
        private SplitContainer splitContainer1;
        private ListBox listBoxUsers;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonSend;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonAttachment;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonEmojis;
        private FlowLayoutPanel flowLayoutPanelChat;
        private Panel topPanel;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonVideoCall;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonAudioCall;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonCreateGroup;
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
    }
}
