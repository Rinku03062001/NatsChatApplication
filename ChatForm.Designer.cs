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
            panel1 = new Panel();
            lstLogs = new ListBox();
            splitContainer1 = new SplitContainer();
            flowLayoutPanelUsers = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(106, 15);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(597, 67);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.MediumTurquoise;
            btnSend.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(706, 14);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(88, 67);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send\r\n";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnSendFile
            // 
            btnSendFile.BackColor = Color.Turquoise;
            btnSendFile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSendFile.Location = new Point(3, 15);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(106, 65);
            btnSendFile.TabIndex = 3;
            btnSendFile.Text = "SendFile";
            btnSendFile.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMessage);
            panel1.Controls.Add(btnSendFile);
            panel1.Controls.Add(btnSend);
            panel1.Location = new Point(3, 466);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 87);
            panel1.TabIndex = 4;
            // 
            // lstLogs
            // 
            lstLogs.BackColor = Color.SeaGreen;
            lstLogs.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstLogs.ForeColor = SystemColors.InactiveBorder;
            lstLogs.FormattingEnabled = true;
            lstLogs.ItemHeight = 25;
            lstLogs.Location = new Point(3, 6);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(794, 454);
            lstLogs.TabIndex = 5;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(3, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanelUsers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(lstLogs);
            splitContainer1.Size = new Size(1056, 553);
            splitContainer1.SplitterDistance = 249;
            splitContainer1.TabIndex = 6;
            // 
            // flowLayoutPanelUsers
            // 
            flowLayoutPanelUsers.AutoScroll = true;
            flowLayoutPanelUsers.Location = new Point(3, 3);
            flowLayoutPanelUsers.Name = "flowLayoutPanelUsers";
            flowLayoutPanelUsers.Size = new Size(243, 543);
            flowLayoutPanelUsers.TabIndex = 0;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.MistyRose;
            ClientSize = new Size(1058, 565);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChatForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Synapse";
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
        private Button btnSend;
        private Button btnSendFile;
        private Panel panel1;
        private ListBox lstLogs;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanelUsers;
    }
}
