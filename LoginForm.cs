using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppNats
{
    public partial class LoginForm : Form
    {
        private string connectionString = @"server=RINKU-LAPPY\SQLEXPRESS; Database=ChatAppDB; TrustServerCertificate=True; Trusted_Connection=True";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text.Trim();
            string password = txtBoxPassword.Text.Trim();

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
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
                
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    //int count = Convert.ToInt32(cmd.ExecuteScalar());
                    var result = cmd.ExecuteScalar();

                    if(result != null)
                    {
                        string loggedInUser = result.ToString();

                        // MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // TODO: Open ChatForm or MainForm
                        this.Hide();

                        if(string.IsNullOrWhiteSpace(loggedInUser))
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
    }
}
