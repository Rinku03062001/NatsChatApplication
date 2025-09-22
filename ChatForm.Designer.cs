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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtMessage = new TextBox();
            panel1 = new Panel();
            ImageButtonEmojis = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonAttachment = new Guna.UI2.WinForms.Guna2ImageButton();
            ImageButtonSend = new Guna.UI2.WinForms.Guna2ImageButton();
            lstLogs = new ListBox();
            splitContainer1 = new SplitContainer();
            listBoxUsers = new ListBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            ImageButtonEmojis.ShadowDecoration.CustomizableEdges = customizableEdges7;
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
            ImageButtonAttachment.ShadowDecoration.CustomizableEdges = customizableEdges8;
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
            ImageButtonSend.ShadowDecoration.CustomizableEdges = customizableEdges9;
            ImageButtonSend.Size = new Size(46, 65);
            ImageButtonSend.TabIndex = 4;
            ImageButtonSend.Click += ImageButtonSend_Click;
            // 
            // lstLogs
            // 
            lstLogs.BackColor = Color.SeaGreen;
            lstLogs.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstLogs.ForeColor = SystemColors.InactiveBorder;
            lstLogs.FormattingEnabled = true;
            lstLogs.ItemHeight = 25;
            lstLogs.Location = new Point(3, 0);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(801, 454);
            lstLogs.TabIndex = 5;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBoxUsers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(lstLogs);
            splitContainer1.Size = new Size(1057, 565);
            splitContainer1.SplitterDistance = 246;
            splitContainer1.TabIndex = 6;
            // 
            // listBoxUsers
            // 
            listBoxUsers.BackColor = Color.Orange;
            listBoxUsers.BorderStyle = BorderStyle.FixedSingle;
            listBoxUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxUsers.ForeColor = SystemColors.InactiveCaptionText;
            listBoxUsers.FormattingEnabled = true;
            listBoxUsers.ItemHeight = 25;
            listBoxUsers.Location = new Point(0, 3);
            listBoxUsers.Name = "listBoxUsers";
            listBoxUsers.Size = new Size(241, 552);
            listBoxUsers.TabIndex = 0;
            listBoxUsers.SelectedIndexChanged += listBoxUsers_SelectedIndexChanged;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1057, 565);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Synapse";
            Load += ChatForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtMessage;
        private Panel panel1;
        private ListBox lstLogs;
        private SplitContainer splitContainer1;
        private ListBox listBoxUsers;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonSend;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonAttachment;
        private Guna.UI2.WinForms.Guna2ImageButton ImageButtonEmojis;
    }
}
