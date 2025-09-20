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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtBoxEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
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
            txtBoxEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxEmail.Location = new Point(80, 33);
            txtBoxEmail.Margin = new Padding(3, 5, 3, 5);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "Enter Email";
            txtBoxEmail.SelectedText = "";
            txtBoxEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtBoxEmail.Size = new Size(280, 51);
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
            txtBoxPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxPassword.Location = new Point(80, 106);
            txtBoxPassword.Margin = new Padding(3, 5, 3, 5);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Enter Password";
            txtBoxPassword.SelectedText = "";
            txtBoxPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtBoxPassword.Size = new Size(280, 51);
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
            btnLogin.Location = new Point(138, 175);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(147, 49);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(438, 246);
            Controls.Add(btnLogin);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxEmail);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtBoxEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
    }
}