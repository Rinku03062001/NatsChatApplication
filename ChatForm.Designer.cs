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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtMessage = new TextBox();
            panel1 = new Panel();
            ImageButtonEmojis = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonAttachment = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonSend = new Guna.UI2.WinForms.Guna2ImageButton();
            splitContainer1 = new SplitContainer();
            lblChatTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lstGroups = new ListBox();
            ImageButtonCreateGroup = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            listBoxUsers = new ListBox();
            topPanel = new Panel();
            guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonAudioCall = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonVideoCall = new Guna.UI2.WinForms.Guna2ImageButton();
            flowLayoutPanelChat = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(115, 13);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(634, 67);
            txtMessage.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(ImageButtonEmojis);
            panel1.Controls.Add(ImageButtonAttachment);
            panel1.Controls.Add(ImageButtonSend);
            panel1.Controls.Add(txtMessage);
            panel1.Location = new Point(3, 466);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 87);
            panel1.TabIndex = 4;
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
            ImageButtonEmojis.ShadowDecoration.CustomizableEdges = customizableEdges8;
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
            ImageButtonAttachment.ShadowDecoration.CustomizableEdges = customizableEdges9;
            ImageButtonAttachment.Size = new Size(37, 65);
            ImageButtonAttachment.TabIndex = 5;
            ImageButtonAttachment.Click += ImageButtonAttachment_Click;
            // 
            // ImageButtonSend
            // 
            ImageButtonSend.BackColor = Color.Transparent;
            ImageButtonSend.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonSend.HoverState.ImageSize = new Size(64, 64);
            ImageButtonSend.Image = (Image)resources.GetObject("ImageButtonSend.Image");
            ImageButtonSend.ImageOffset = new Point(0, 0);
            ImageButtonSend.ImageRotate = 0F;
            ImageButtonSend.ImageSize = new Size(36, 36);
            ImageButtonSend.Location = new Point(746, 15);
            ImageButtonSend.Name = "ImageButtonSend";
            ImageButtonSend.PressedState.ImageSize = new Size(64, 64);
            ImageButtonSend.ShadowDecoration.CustomizableEdges = customizableEdges10;
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
            splitContainer1.Panel1.Controls.Add(lblChatTitle);
            splitContainer1.Panel1.Controls.Add(lstGroups);
            splitContainer1.Panel1.Controls.Add(ImageButtonCreateGroup);
            splitContainer1.Panel1.Controls.Add(guna2HtmlLabel1);
            splitContainer1.Panel1.Controls.Add(listBoxUsers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(topPanel);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanelChat);
            splitContainer1.Size = new Size(1176, 565);
            splitContainer1.SplitterDistance = 373;
            splitContainer1.TabIndex = 6;
            // 
            // lblChatTitle
            // 
            lblChatTitle.BackColor = Color.Transparent;
            lblChatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChatTitle.ForeColor = Color.Blue;
            lblChatTitle.Location = new Point(259, 22);
            lblChatTitle.Name = "lblChatTitle";
            lblChatTitle.Size = new Size(70, 30);
            lblChatTitle.TabIndex = 3;
            lblChatTitle.Text = "Groups\r\n";
            // 
            // lstGroups
            // 
            lstGroups.FormattingEnabled = true;
            lstGroups.Location = new Point(232, 58);
            lstGroups.Name = "lstGroups";
            lstGroups.Size = new Size(136, 504);
            lstGroups.TabIndex = 0;
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
            ImageButtonCreateGroup.Location = new Point(184, 17);
            ImageButtonCreateGroup.Name = "ImageButtonCreateGroup";
            ImageButtonCreateGroup.PressedState.ImageSize = new Size(64, 64);
            ImageButtonCreateGroup.ShadowDecoration.CustomizableEdges = customizableEdges11;
            ImageButtonCreateGroup.Size = new Size(42, 29);
            ImageButtonCreateGroup.TabIndex = 2;
            ImageButtonCreateGroup.Click += ImageButtonCreateGroup_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Indigo;
            guna2HtmlLabel1.Location = new Point(0, 9);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(87, 37);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Chats";
            // 
            // listBoxUsers
            // 
            listBoxUsers.BackColor = Color.Orange;
            listBoxUsers.BorderStyle = BorderStyle.FixedSingle;
            listBoxUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxUsers.ForeColor = SystemColors.InactiveCaptionText;
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.ItemHeight = 25;
            listBoxUsers.Location = new Point(0, 53);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(226, 527);
            listBoxUsers.TabIndex = 0;
            listBoxUsers.SelectedIndexChanged += listBoxUsers_SelectedIndexChanged;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(guna2ImageButton1);
            topPanel.Controls.Add(ImageButtonAudioCall);
            topPanel.Controls.Add(ImageButtonVideoCall);
            topPanel.Location = new Point(3, 3);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(801, 49);
            topPanel.TabIndex = 7;
            // 
            // guna2ImageButton1
            // 
            guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
            guna2ImageButton1.ImageOffset = new Point(0, 0);
            guna2ImageButton1.ImageRotate = 0F;
            guna2ImageButton1.ImageSize = new Size(30, 30);
            guna2ImageButton1.Location = new Point(746, 6);
            guna2ImageButton1.Name = "guna2ImageButton1";
            guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2ImageButton1.Size = new Size(36, 40);
            guna2ImageButton1.TabIndex = 0;
            // 
            // ImageButtonAudioCall
            // 
            ImageButtonAudioCall.CheckedState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.HoverState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.Image = (Image)resources.GetObject("ImageButtonAudioCall.Image");
            ImageButtonAudioCall.ImageOffset = new Point(0, 0);
            ImageButtonAudioCall.ImageRotate = 0F;
            ImageButtonAudioCall.ImageSize = new Size(30, 30);
            ImageButtonAudioCall.Location = new Point(690, 3);
            ImageButtonAudioCall.Name = "ImageButtonAudioCall";
            ImageButtonAudioCall.PressedState.ImageSize = new Size(64, 64);
            ImageButtonAudioCall.ShadowDecoration.CustomizableEdges = customizableEdges13;
            ImageButtonAudioCall.Size = new Size(36, 43);
            ImageButtonAudioCall.TabIndex = 0;
            // 
            // ImageButtonVideoCall
            // 
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
            ImageButtonVideoCall.ShadowDecoration.CustomizableEdges = customizableEdges14;
            ImageButtonVideoCall.Size = new Size(36, 43);
            ImageButtonVideoCall.TabIndex = 0;
            // 
            // flowLayoutPanelChat
            // 
            flowLayoutPanelChat.AutoScroll = true;
            flowLayoutPanelChat.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelChat.Location = new Point(3, 58);
            flowLayoutPanelChat.Name = "flowLayoutPanelChat";
            flowLayoutPanelChat.Size = new Size(801, 402);
            flowLayoutPanelChat.TabIndex = 6;
            flowLayoutPanelChat.WrapContents = false;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1176, 565);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Synapse";
            Load += ChatForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtMessage;
        private Panel panel1;
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
    }
}
