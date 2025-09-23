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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateGroupForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            clbUsers = new CheckedListBox();
            txtGroupName = new TextBox();
            btnCreateGroup = new Button();
            btnClose = new Guna.UI2.WinForms.Guna2ImageButton();
            txtSearchUser = new TextBox();
            lstSelectedUsers = new ListBox();
            SuspendLayout();
            // 
            // clbUsers
            // 
            clbUsers.BackColor = Color.LightSlateGray;
            clbUsers.Dock = DockStyle.Left;
            clbUsers.Font = new Font("Segoe UI", 9F);
            clbUsers.FormattingEnabled = true;
            clbUsers.Location = new Point(0, 0);
            clbUsers.Name = "clbUsers";
            clbUsers.Size = new Size(194, 450);
            clbUsers.TabIndex = 0;
            clbUsers.ItemCheck += clbUsers_ItemCheck;
            // 
            // txtGroupName
            // 
            txtGroupName.BackColor = Color.Silver;
            txtGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtGroupName.ForeColor = Color.Black;
            txtGroupName.Location = new Point(200, 0);
            txtGroupName.Multiline = true;
            txtGroupName.Name = "txtGroupName";
            txtGroupName.PlaceholderText = "Enter Group Name";
            txtGroupName.Size = new Size(455, 54);
            txtGroupName.TabIndex = 1;
            // 
            // btnCreateGroup
            // 
            btnCreateGroup.BackColor = Color.FromArgb(192, 64, 0);
            btnCreateGroup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateGroup.Location = new Point(200, 390);
            btnCreateGroup.Name = "btnCreateGroup";
            btnCreateGroup.Size = new Size(507, 60);
            btnCreateGroup.TabIndex = 2;
            btnCreateGroup.Text = "Create Group";
            btnCreateGroup.UseVisualStyleBackColor = false;
            btnCreateGroup.Click += btnCreateGroup_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.CheckedState.ImageSize = new Size(64, 64);
            btnClose.HoverState.ImageSize = new Size(64, 64);
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageOffset = new Point(0, 0);
            btnClose.ImageRotate = 0F;
            btnClose.Location = new Point(661, 12);
            btnClose.Name = "btnClose";
            btnClose.PressedState.ImageSize = new Size(64, 64);
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnClose.Size = new Size(42, 34);
            btnClose.TabIndex = 3;
            btnClose.Click += btnClose_Click;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(200, 60);
            txtSearchUser.Multiline = true;
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.Size = new Size(289, 51);
            txtSearchUser.TabIndex = 4;
            txtSearchUser.TextChanged += txtSearchUser_TextChanged;
            // 
            // lstSelectedUsers
            // 
            lstSelectedUsers.FormattingEnabled = true;
            lstSelectedUsers.Location = new Point(204, 119);
            lstSelectedUsers.Name = "lstSelectedUsers";
            lstSelectedUsers.Size = new Size(285, 264);
            lstSelectedUsers.TabIndex = 5;
            // 
            // CreateGroupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(711, 450);
            Controls.Add(lstSelectedUsers);
            Controls.Add(txtSearchUser);
            Controls.Add(btnClose);
            Controls.Add(btnCreateGroup);
            Controls.Add(txtGroupName);
            Controls.Add(clbUsers);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateGroupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateGroupForm";
            Load += CreateGroupForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox clbUsers;
        private TextBox txtGroupName;
        private Button btnCreateGroup;
        private Guna.UI2.WinForms.Guna2ImageButton btnClose;
        private TextBox txtSearchUser;
        private ListBox lstSelectedUsers;
    }
}