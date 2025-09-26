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
            panelLeft1 = new Panel();
            panel2 = new Panel();
            listBoxUsers = new ListBox();
            panelLeftHeader1 = new Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ImageButtonCreateGroup = new Guna.UI2.WinForms.Guna2ImageButton();
            panel1 = new Panel();
            panelShowMessage = new Panel();
            flowLayoutPanelChat = new FlowLayoutPanel();
            topPanel = new Panel();
            guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonAudioCall = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonVideoCall = new Guna.UI2.WinForms.Guna2ImageButton();
            panelTypeMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeft2.SuspendLayout();
            panelLeftHeader2.SuspendLayout();
            panelLeft1.SuspendLayout();
            panel2.SuspendLayout();
            panelLeftHeader1.SuspendLayout();
            panel1.SuspendLayout();
            panelShowMessage.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.Location = new Point(116, 13);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(626, 67);
            txtMessage.TabIndex = 1;
            // 
            // panelTypeMessage
            // 
            panelTypeMessage.Controls.Add(ImageButtonEmojis);
            panelTypeMessage.Controls.Add(txtMessage);
            panelTypeMessage.Controls.Add(ImageButtonAttachment);
            panelTypeMessage.Controls.Add(ImageButtonSend);
            panelTypeMessage.Dock = DockStyle.Bottom;
            panelTypeMessage.Location = new Point(0, 478);
            panelTypeMessage.Name = "panelTypeMessage";
            panelTypeMessage.Size = new Size(799, 87);
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
            ImageButtonEmojis.Location = new Point(13, 15);
            ImageButtonEmojis.Name = "ImageButtonEmojis";
            ImageButtonEmojis.PressedState.ImageSize = new Size(64, 64);
            ImageButtonEmojis.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ImageButtonEmojis.Size = new Size(38, 65);
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
            ImageButtonAttachment.Location = new Point(62, 15);
            ImageButtonAttachment.Name = "ImageButtonAttachment";
            ImageButtonAttachment.PressedState.ImageSize = new Size(64, 64);
            ImageButtonAttachment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ImageButtonAttachment.Size = new Size(37, 65);
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
            ImageButtonSend.Location = new Point(748, 15);
            ImageButtonSend.Name = "ImageButtonSend";
            ImageButtonSend.PressedState.ImageSize = new Size(64, 64);
            ImageButtonSend.ShadowDecoration.CustomizableEdges = customizableEdges3;
            ImageButtonSend.Size = new Size(46, 65);
            ImageButtonSend.TabIndex = 4;
            ImageButtonSend.Click += ImageButtonSend_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
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
            splitContainer1.Size = new Size(1176, 565);
            splitContainer1.SplitterDistance = 373;
            splitContainer1.TabIndex = 6;
            // 
            // panelLeft2
            // 
            panelLeft2.Controls.Add(lstGroups);
            panelLeft2.Controls.Add(panelLeftHeader2);
            panelLeft2.Dock = DockStyle.Fill;
            panelLeft2.Location = new Point(208, 0);
            panelLeft2.Name = "panelLeft2";
            panelLeft2.Size = new Size(165, 565);
            panelLeft2.TabIndex = 5;
            // 
            // lstGroups
            // 
            lstGroups.BackColor = Color.SkyBlue;
            lstGroups.Dock = DockStyle.Fill;
            lstGroups.FormattingEnabled = true;
            lstGroups.Location = new Point(0, 49);
            lstGroups.Name = "lstGroups";
            lstGroups.Size = new Size(165, 516);
            lstGroups.TabIndex = 0;
            // 
            // panelLeftHeader2
            // 
            panelLeftHeader2.BackColor = Color.Transparent;
            panelLeftHeader2.Controls.Add(lblChatTitle);
            panelLeftHeader2.Dock = DockStyle.Top;
            panelLeftHeader2.Location = new Point(0, 0);
            panelLeftHeader2.Name = "panelLeftHeader2";
            panelLeftHeader2.Size = new Size(165, 49);
            panelLeftHeader2.TabIndex = 1;
            // 
            // lblChatTitle
            // 
            lblChatTitle.BackColor = Color.Transparent;
            lblChatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatTitle.ForeColor = Color.Blue;
            lblChatTitle.Location = new Point(41, 6);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(70, 30);
            lblChatTitle.TabIndex = 3;
            lblChatTitle.Text = "Groups\r\n";
            // 
            // panelLeft1
            // 
            panelLeft1.Controls.Add(panel2);
            panelLeft1.Controls.Add(panelLeftHeader1);
            panelLeft1.Dock = DockStyle.Left;
            panelLeft1.Location = new Point(0, 0);
            panelLeft1.Name = "panelLeft1";
            panelLeft1.Size = new Size(208, 565);
            panelLeft1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(listBoxUsers);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(208, 516);
            panel2.TabIndex = 1;
            // 
            // listBoxUsers
            // 
            listBoxUsers.BackColor = SystemColors.GradientInactiveCaption;
            listBoxUsers.BorderStyle = BorderStyle.FixedSingle;
            listBoxUsers.Dock = DockStyle.Fill;
            listBoxUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxUsers.ForeColor = SystemColors.InactiveCaptionText;
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.ItemHeight = 25;
            listBoxUsers.Location = new Point(0, 0);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(208, 516);
            listBoxUsers.TabIndex = 0;
            listBoxUsers.SelectedIndexChanged += listBoxUsers_SelectedIndexChanged;
            // 
            // panelLeftHeader1
            // 
            panelLeftHeader1.BackColor = Color.OldLace;
            panelLeftHeader1.Controls.Add(guna2HtmlLabel1);
            panelLeftHeader1.Controls.Add(ImageButtonCreateGroup);
            panelLeftHeader1.Dock = DockStyle.Top;
            panelLeftHeader1.Location = new Point(0, 0);
            panelLeftHeader1.Name = "panelLeftHeader1";
            panelLeftHeader1.Size = new Size(208, 49);
            panelLeftHeader1.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Indigo;
            guna2HtmlLabel1.Location = new Point(12, 9);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(87, 37);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Chats";
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
            ImageButtonCreateGroup.Location = new Point(150, 17);
            ImageButtonCreateGroup.Name = "ImageButtonCreateGroup";
            ImageButtonCreateGroup.PressedState.ImageSize = new Size(64, 64);
            ImageButtonCreateGroup.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ImageButtonCreateGroup.Size = new Size(42, 29);
            ImageButtonCreateGroup.TabIndex = 2;
            ImageButtonCreateGroup.Click += ImageButtonCreateGroup_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelShowMessage);
            panel1.Controls.Add(topPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 478);
            panel1.TabIndex = 5;
            // 
            // panelShowMessage
            // 
            panelShowMessage.Controls.Add(flowLayoutPanelChat);
            panelShowMessage.Dock = DockStyle.Fill;
            panelShowMessage.Location = new Point(0, 49);
            panelShowMessage.Name = "panelShowMessage";
            panelShowMessage.Size = new Size(799, 429);
            panelShowMessage.TabIndex = 8;
            // 
            // flowLayoutPanelChat
            // 
            flowLayoutPanelChat.AutoScroll = true;
            flowLayoutPanelChat.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanelChat.Dock = DockStyle.Fill;
            flowLayoutPanelChat.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelChat.Location = new Point(0, 0);
            flowLayoutPanelChat.Name = "flowLayoutPanelChat";
            flowLayoutPanelChat.Size = new Size(799, 429);
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
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(799, 49);
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
            guna2ImageButton1.Location = new Point(746, 6);
            guna2ImageButton1.Name = "guna2ImageButton1";
            guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2ImageButton1.Size = new Size(36, 40);
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
            ImageButtonAudioCall.Location = new Point(690, 3);
            ImageButtonAudioCall.Name = "ImageButtonAudioCall";
            ImageButtonAudioCall.PressedState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.ShadowDecoration.CustomizableEdges = customizableEdges6;
            ImageButtonAudioCall.Size = new Size(36, 43);
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
            ImageButtonVideoCall.Location = new Point(625, 3);
            ImageButtonVideoCall.Name = "ImageButtonVideoCall";
            ImageButtonVideoCall.PressedState.ImageSize = new Size(64, 64);
            ImageButtonVideoCall.ShadowDecoration.CustomizableEdges = customizableEdges7;
            ImageButtonVideoCall.Size = new Size(36, 43);
            ImageButtonVideoCall.TabIndex = 0;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(1176, 565);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            panel2.ResumeLayout(false);
            panelLeftHeader1.ResumeLayout(false);
            panelLeftHeader1.PerformLayout();
            panel1.ResumeLayout(false);
            panelShowMessage.ResumeLayout(false);
            topPanel.ResumeLayout(false);
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
        private Panel panel2;
    }
}
