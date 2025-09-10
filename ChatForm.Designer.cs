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
            listBox1 = new ListBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            btnSendFile = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(6, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 344);
            listBox1.TabIndex = 0;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(95, 362);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(564, 75);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.ControlLight;
            btnSend.Location = new Point(665, 366);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(122, 67);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send\r\n";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.Location = new Point(6, 362);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(83, 65);
            btnSendFile.TabIndex = 3;
            btnSendFile.Text = "SendFile";
            btnSendFile.UseVisualStyleBackColor = true;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(794, 440);
            Controls.Add(btnSendFile);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(listBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Synapse";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnSendFile;
    }
}
