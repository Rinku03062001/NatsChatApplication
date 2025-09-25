using ChatAppNats.Data;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Text;

namespace ChatAppNats
{
    public partial class LoginForm : Form
    {
        private string connectionString = @"server=RINKU-LAPPY\SQLEXPRESS; Database=ChatAppDB; TrustServerCertificate=True; Trusted_Connection=True";

        public LoginForm()
        {
            InitializeComponent();
            linkLabelForgetPassword.Click += linkLabelForgetPassword_Click;
            ;
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text.Trim();
            string password = txtBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Email and Password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "Select userName from Users where Email=@Email and PasswordHash=@PasswordHash";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    //int count = Convert.ToInt32(cmd.ExecuteScalar());
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string loggedInUser = result.ToString();

                        // MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // TODO: Open ChatForm or MainForm
                        this.Hide();

                        if (string.IsNullOrWhiteSpace(loggedInUser))
                        {
                            loggedInUser = email;
                        }


                        //// prompt for targt user
                        //string enteredTarget = Interaction.InputBox("Enter target user for direct chat (leave blank for global):", "Chat Form");
                        //string? targetuser = string.IsNullOrWhiteSpace(enteredTarget) ? null : enteredTarget;


                        ChatForm chatForm = new ChatForm(loggedInUser);
                        chatForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxEmail.Clear();
            txtBoxPassword.Clear();
            txtBoxEmail.Focus();
        }

        private void linkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Close();
        }




        private string GenerateTemporaryPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$!";

            var sb = new StringBuilder();

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] data = new byte[length];
                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(data);
                    uint randomValue = BitConverter.ToUInt32(data, 0);
                    sb.Append(chars[(int)(randomValue % (uint)chars.Length)]);
                }
            }


            return sb.ToString();
            //var random = new Random();
            //return new string(Enumerable.Repeat(chars, length)
            //    .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        private void linkLabelForgetPassword_Click(object sender, EventArgs e)
        {
            string email = Interaction.InputBox(
                "Enter your registered email to reset your password",
                "Forgot Password",
                "");
            this.Close();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Email == email.Trim());
                    if (user == null)
                    {
                        MessageBox.Show("No user found with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    // Generate temporary password
                    string tempPassword = GenerateTemporaryPassword();

                    if (string.IsNullOrEmpty(tempPassword))
                    {
                        MessageBox.Show("Failed to generate temporary password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    user.PasswordHash = ComputeSha256Hash(tempPassword);
                    context.SaveChanges();


                    Interaction.InputBox($"Your temporary password is:\n{tempPassword}\nPlease login and change it.",
                            "Password Reset", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

