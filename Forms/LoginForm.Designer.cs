namespace ChatAppNats
{
    partial class LoginForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtBoxEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            panelRight = new Panel();
            label4 = new Label();
            label1 = new Label();
            linkLabelCreateAccount = new LinkLabel();
            linkLabelForgetPassword = new LinkLabel();
            labelPassword = new Label();
            labelEmail = new Label();
            panelTop = new Panel();
            buttonClose = new Button();
            labelLogin = new Label();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            panelRight.SuspendLayout();
            panelTop.SuspendLayout();
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.CustomizableEdges = customizableEdges1;
            txtBoxEmail.DefaultText = "";
            txtBoxEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBoxEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBoxEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBoxEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBoxEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxEmail.Font = new Font("Cambria", 11F, FontStyle.Bold);
            txtBoxEmail.ForeColor = Color.Black;
            txtBoxEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxEmail.Location = new Point(9, 157);
            txtBoxEmail.Margin = new Padding(3, 5, 3, 5);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderForeColor = Color.LightGray;
            txtBoxEmail.PlaceholderText = "Enter Email";
            txtBoxEmail.SelectedText = "";
            txtBoxEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtBoxEmail.Size = new Size(438, 50);
            txtBoxEmail.TabIndex = 0;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.CustomizableEdges = customizableEdges3;
            txtBoxPassword.DefaultText = "";
            txtBoxPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBoxPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBoxPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBoxPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBoxPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxPassword.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBoxPassword.ForeColor = Color.Black;
            txtBoxPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxPassword.Location = new Point(9, 289);
            txtBoxPassword.Margin = new Padding(4, 5, 4, 5);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderForeColor = Color.LightGray;
            txtBoxPassword.PlaceholderText = "Enter Password";
            txtBoxPassword.SelectedText = "";
            txtBoxPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtBoxPassword.Size = new Size(438, 50);
            txtBoxPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Animated = true;
            btnLogin.AutoRoundedCorners = true;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(9, 411);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(438, 49);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(label4);
            panelRight.Controls.Add(label1);
            panelRight.Controls.Add(linkLabelCreateAccount);
            panelRight.Controls.Add(linkLabelForgetPassword);
            panelRight.Controls.Add(btnLogin);
            panelRight.Controls.Add(txtBoxEmail);
            panelRight.Controls.Add(txtBoxPassword);
            panelRight.Controls.Add(labelPassword);
            panelRight.Controls.Add(labelEmail);
            panelRight.Controls.Add(panelTop);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(397, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(473, 527);
            panelRight.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 483);
            label4.Name = "label4";
            label4.Size = new Size(167, 20);
            label4.TabIndex = 7;
            label4.Text = "Don't have an account ?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Yi Baiti", 11F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 0);
            label1.Location = new Point(58, 68);
            label1.Name = "label1";
            label1.Size = new Size(368, 19);
            label1.TabIndex = 6;
            label1.Text = "Enter your credentials to access your account";
            // 
            // linkLabelCreateAccount
            // 
            linkLabelCreateAccount.AutoSize = true;
            linkLabelCreateAccount.Location = new Point(272, 483);
            linkLabelCreateAccount.Name = "linkLabelCreateAccount";
            linkLabelCreateAccount.Size = new Size(110, 20);
            linkLabelCreateAccount.TabIndex = 4;
            linkLabelCreateAccount.TabStop = true;
            linkLabelCreateAccount.Text = "Create Account";
            linkLabelCreateAccount.LinkClicked += linkLabelCreateAccount_LinkClicked;
            // 
            // linkLabelForgetPassword
            // 
            linkLabelForgetPassword.AutoSize = true;
            linkLabelForgetPassword.Location = new Point(283, 344);
            linkLabelForgetPassword.Name = "linkLabelForgetPassword";
            linkLabelForgetPassword.Size = new Size(162, 20);
            linkLabelForgetPassword.TabIndex = 3;
            linkLabelForgetPassword.TabStop = true;
            linkLabelForgetPassword.Text = "Forgot your Password ?";
            linkLabelForgetPassword.Click += linkLabelForgetPassword_Click;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Castellar", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassword.Location = new Point(9, 259);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(140, 25);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Castellar", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmail.Location = new Point(9, 127);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(197, 25);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email Address";
            // 
            // panelTop
            // 
            panelTop.Controls.Add(buttonClose);
            panelTop.Controls.Add(labelLogin);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(473, 65);
            panelTop.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.White;
            buttonClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.ForeColor = Color.Red;
            buttonClose.Location = new Point(428, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(45, 30);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "X";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelLogin.Location = new Point(175, 19);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(132, 28);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "LOGIN FORM";
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.Controls.Add(pictureBox1);
            guna2GradientPanel1.Controls.Add(label3);
            guna2GradientPanel1.Controls.Add(label2);
            guna2GradientPanel1.CustomizableEdges = customizableEdges7;
            guna2GradientPanel1.Dock = DockStyle.Left;
            guna2GradientPanel1.FillColor = Color.DarkBlue;
            guna2GradientPanel1.FillColor2 = Color.RoyalBlue;
            guna2GradientPanel1.Location = new Point(0, 0);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2GradientPanel1.Size = new Size(399, 527);
            guna2GradientPanel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(134, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(95, 95);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(24, 292);
            label3.Name = "label3";
            label3.Size = new Size(356, 72);
            label3.TabIndex = 0;
            label3.Text = "Stay Connected, Anytime and Anywhere\r\nSignIn To Start Your Conversation\r\n\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(83, 55);
            label2.Name = "label2";
            label2.Size = new Size(206, 27);
            label2.TabIndex = 0;
            label2.Text = "Welcome To Synapse";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(870, 527);
            Controls.Add(guna2GradientPanel1);
            Controls.Add(panelRight);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtBoxEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Panel panelRight;
        private Panel panelTop;
        private Label labelLogin;
        private Label labelPassword;
        private Label labelEmail;
        private LinkLabel linkLabelCreateAccount;
        private LinkLabel linkLabelForgetPassword;
        private Label label1;
        private Button buttonClose;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}