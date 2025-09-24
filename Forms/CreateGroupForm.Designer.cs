namespace ChatAppNats
{
    partial class CreateGroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateGroupForm));
            clbUsers = new CheckedListBox();
            txtGroupName = new TextBox();
            btnCreateGroup = new Button();
            txtSearchUser = new TextBox();
            lstSelectedUsers = new ListBox();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            buttonClose = new Button();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // clbUsers
            // 
            clbUsers.BackColor = Color.CadetBlue;
            clbUsers.Dock = DockStyle.Left;
            clbUsers.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clbUsers.FormattingEnabled = true;
            clbUsers.Location = new Point(0, 0);
            clbUsers.Name = "clbUsers";
            clbUsers.Size = new Size(227, 527);
            clbUsers.TabIndex = 0;
            clbUsers.ItemCheck += clbUsers_ItemCheck;
            // 
            // txtGroupName
            // 
            txtGroupName.BackColor = Color.Silver;
            txtGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtGroupName.ForeColor = Color.Black;
            txtGroupName.Location = new Point(233, 109);
            txtGroupName.Multiline = true;
            txtGroupName.Name = "txtGroupName";
            txtGroupName.PlaceholderText = "Enter Group Name";
            txtGroupName.Size = new Size(233, 41);
            txtGroupName.TabIndex = 1;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.LightBlue;
            btnCreateGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateGroup.Location = new Point(233, 454);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(448, 60);
            btnCreateGroup.TabIndex = 2;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(233, 156);
            txtSearchUser.Multiline = true;
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.PlaceholderText = "Search for a Friend";
            txtSearchUser.Size = new Size(448, 32);
            txtSearchUser.TabIndex = 4;
            txtSearchUser.TextChanged += txtSearchUser_TextChanged;
            // 
            // lstSelectedUsers
            // 
            lstSelectedUsers.BackColor = Color.Teal;
            lstSelectedUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSelectedUsers.FormattingEnabled = true;
            lstSelectedUsers.ItemHeight = 25;
            lstSelectedUsers.Location = new Point(233, 194);
            lstSelectedUsers.Name = "lstSelectedUsers";
            lstSelectedUsers.Size = new Size(448, 254);
            lstSelectedUsers.TabIndex = 5;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(label1);
            guna2CustomGradientPanel1.Controls.Add(pictureBox1);
            guna2CustomGradientPanel1.Controls.Add(buttonClose);
            guna2CustomGradientPanel1.Controls.Add(txtGroupName);
            guna2CustomGradientPanel1.Controls.Add(txtSearchUser);
            guna2CustomGradientPanel1.Controls.Add(lstSelectedUsers);
            guna2CustomGradientPanel1.Controls.Add(btnCreateGroup);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.FillColor = Color.LightGreen;
            guna2CustomGradientPanel1.FillColor2 = Color.MediumSeaGreen;
            guna2CustomGradientPanel1.FillColor3 = Color.Teal;
            guna2CustomGradientPanel1.FillColor4 = Color.LightBlue;
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(687, 527);
            guna2CustomGradientPanel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(367, 35);
            label1.Name = "label1";
            label1.Size = new Size(154, 28);
            label1.TabIndex = 8;
            label1.Text = "Create a Group";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(233, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 60);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.ForeColor = Color.Red;
            buttonClose.Location = new Point(638, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(43, 38);
            buttonClose.TabIndex = 6;
            buttonClose.Text = "X";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // CreateGroupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(687, 527);
            Controls.Add(clbUsers);
            Controls.Add(guna2CustomGradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateGroupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateGroupForm";
            Load += CreateGroupForm_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox clbUsers;
        private TextBox txtGroupName;
        private Button btnCreateGroup;
        private TextBox txtSearchUser;
        private ListBox lstSelectedUsers;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private PictureBox pictureBox1;
        private Button buttonClose;
        private Label label1;
    }
}