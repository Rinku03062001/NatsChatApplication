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
            listBox1 = new ListBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 344);
            listBox1.TabIndex = 0;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(7, 362);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(625, 75);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = SystemColors.ControlLight;
            btnSend.Location = new Point(640, 366);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(147, 67);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send\r\n";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(794, 440);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(listBox1);
            MaximizeBox = false;
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox txtMessage;
        private Button btnSend;
        
    }
}
