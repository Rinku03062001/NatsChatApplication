using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppNats
{
    public partial class RegisterForm : Form
    {
        private string connectionString = @"server=RINKU-LAPPY\SQLEXPRESS; Database=ChatAppDB; TrustServerCertificate=True; Trusted_Connection=True";
        //private string connectionString = @"Server=synapsedb.c1ysu4usmo3z.ap-south-1.rds.amazonaws.com, 1433;
        //                                Database=SynapseDB;
        //                                User Id=Rinku2001;
        //                                Password=Rin-#KU29%;
        //                                TrustServerCertificate=True;
        //                                Encrypt=True;
        //                                Connect Timeout=60;";


        // Regex pattern for validation
        private const string usernNameRegex = @"^[a-zA-Z][a-zA-Z0-9_]{2,19}$";
        private const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        
        private readonly ToolTip validationToolTip = new ToolTip();

        public RegisterForm()
        {
            InitializeComponent();
            SetupValidation();
        }


        private void SetupValidation()
        {
            // Validation Events
            txtUsername.TextChanged += (s, e) => ValidateUsername();
            txtEmail.TextChanged += (s, e) => ValidateEmail();
            txtPassword.TextChanged += (s, e) => ValidatePassword();
            txtConfirmPassword.TextChanged += (s, e) => ValidateConfirmPassword();
        }


        


        private void ClearValidationStatus(Label statusLabel)
        {
            if (statusLabel != null)
            {
                statusLabel.Text = "";
                statusLabel.Visible = false;
            }
        }


        private void ValidateUsername()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowValidationIndicator(lblUsernameStatus, "Required", false);
                return;
            }
            if (!Regex.IsMatch(txtUsername.Text, usernNameRegex))
            {
                ShowValidationIndicator(lblUsernameStatus, "3-20 chars, start with letter, only letters, numbers, underscore", false);
                return;
            }

            ShowValidationIndicator(lblUsernameStatus, "Valid Username", true);
        }


        private void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowValidationIndicator(lblEmailStatus, "Email is required", false);
                return;
            }
            if (!Regex.IsMatch(txtEmail.Text, EmailRegex))
            {
                ShowValidationIndicator(lblEmailStatus, "Invalid email format", false);
                return;
            }
            ShowValidationIndicator(lblEmailStatus, "Valid Email", true);
        }



        private void ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowValidationIndicator(lblPasswordStatus, "Password is required", false);
                return;
            }
            if (!Regex.IsMatch(txtPassword.Text, PasswordRegex))
            {
                ShowValidationIndicator(lblPasswordStatus, "Min 8 chars, 1 upper, 1 lower, 1 digit, 1 special char", false);
                return;
            }
            ShowValidationIndicator(lblPasswordStatus, "Strong Password", true);
            ValidateConfirmPassword(); // re-validate confirm password
        }



        private void ValidateConfirmPassword()
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowValidationIndicator(lblConfirmPasswordStatus, "Please confirm your password", false);
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowValidationIndicator(lblConfirmPasswordStatus, "Passwords do not match", false);
                return;
            }
            ShowValidationIndicator(lblConfirmPasswordStatus, "Passwords match", true);
        }



        private void ShowValidationIndicator(Label statusLabel, string message, bool isValid)
        {
            if (statusLabel != null)
            {
                statusLabel.Text = message;
                statusLabel.Visible = true;
                statusLabel.ForeColor = isValid ? Color.MediumSpringGreen : Color.Red;
            }
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                string username = txtUsername.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();


                if (IsUsernameExists(username))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }


                if (IsEmailExists(email))
                {
                    MessageBox.Show("Email already registered. Please use a different email.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                string passwordHash = HashPassword(password);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        string query = "insert into Users (UserName, Email, PasswordHash, CreatedAt) values (@UserName, @Email, @PasswordHash, @CreatedAt)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserName", username);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registration successful! Please login.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // clear fields after successful registration
                                ClearFields();

                                this.Hide();
                                LoginForm loginForm = new LoginForm();
                                loginForm.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Database error: {ex.Message}", "Registration Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unexpected error: {ex.Message}", "Registration Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private bool IsUsernameExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select COUNT(1) from Users where UserName=@UserName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        private bool IsEmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Select COUNT(1) from Users where Email=@Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }



        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }


        private bool ValidateInputs()
        {
            // validate username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowValidationError(txtUsername, "Please enter a username");
                txtUsername.Focus();
                return false;
            }

            if(!Regex.IsMatch(txtUsername.Text, usernNameRegex))
            {
                ShowValidationError(txtUsername, "Username must be 3-20 characters, start with a letter, and can contain letters, numbers, and underscores");
                txtUsername.Focus();
                return false;
            }


            // validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowValidationError(txtEmail, "Please enter an email address");
                txtEmail.Focus();
                return false;
            }

            if(!Regex.IsMatch(txtEmail.Text, EmailRegex))
            {
                ShowValidationError(txtEmail,"Please enter a valid email address");
                txtEmail.Focus();
                return false;
            }


            // validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowValidationError(txtPassword, "Please enter a password");
                txtPassword.Focus();
                return false;
            }

            if(!Regex.IsMatch(txtPassword.Text, PasswordRegex))
            {
                ShowValidationError(txtPassword, "Password must be at least 8 characters, include at least one uppercase letter, one lowercase letter, one digit, and one special character");
                txtPassword.Focus();
                return false;
            }


            // validate Confirm Password
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                ShowValidationError(txtConfirmPassword, "Please confirm your password");
                txtConfirmPassword.Focus();
                return false;
            }

            if(txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowValidationError(txtConfirmPassword,"Passwords do not match");
                txtConfirmPassword.Focus();
                return false;
            }
            return true;
        }



        private void ShowValidationError(Control control, string message)
        {
            int x = control.Width / 4;
            int y = control.Height;
            validationToolTip.Show(message, control, x, y, 2000);
        }


        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtConfirmPassword.Clear();
            txtUsername.Focus();

            // clear validation labels
            ClearValidationStatus(lblUsername);
            ClearValidationStatus(lblEmail);
            ClearValidationStatus(lblPassword);
            ClearValidationStatus(lblConfirmpassword);

            txtUsername.Focus();
        }

        

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnRegister_Click(sender, e);
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnRegister_Click(sender, e);
            }
        }
    }
}
