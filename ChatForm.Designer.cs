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
            txtMessage = new TextBox();
            btnSend = new Button();
            btnSendFile = new Button();
            showMessageLayoutPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(100, 11);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(600, 67);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.ControlLight;
            btnSend.Location = new Point(706, 11);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(100, 67);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send\r\n";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.Location = new Point(9, 13);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(83, 65);
            btnSendFile.TabIndex = 3;
            btnSendFile.Text = "SendFile";
            btnSendFile.UseVisualStyleBackColor = true;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // showMessageLayoutPanel
            // 
            showMessageLayoutPanel.AutoScroll = true;
            showMessageLayoutPanel.Dock = DockStyle.Top;
            showMessageLayoutPanel.Location = new Point(0, 0);
            showMessageLayoutPanel.Name = "showMessageLayoutPanel";
            showMessageLayoutPanel.Size = new Size(814, 353);
            showMessageLayoutPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSendFile);
            panel1.Controls.Add(btnSend);
            panel1.Controls.Add(txtMessage);
            panel1.Location = new Point(3, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 86);
            panel1.TabIndex = 4;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(814, 540);
            Controls.Add(showMessageLayoutPanel);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Synapse";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnSendFile;
        private FlowLayoutPanel showMessageLayoutPanel;
        private Panel panel1;
    }
}
