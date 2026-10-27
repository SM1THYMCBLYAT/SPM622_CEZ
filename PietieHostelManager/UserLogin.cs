using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PietieHostelManager
{
    public partial class UserLogin : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HostelDB"].ConnectionString;

        public UserLogin()
        {
            InitializeComponent();
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(
                    Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Empty required fields",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                string hashedPassword = ComputeSha256Hash(password);

                var conn = new SqlConnection(connectionString);
                var cmd = new SqlCommand(@"SELECT COUNT(*) FROM Users WHERE Username = @Username", conn);

                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int iCount = (int)cmd.ExecuteScalar();

                if (iCount == 0)
                {
                    MessageBox.Show(
                        "Username not found",
                        "Invalid Username",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                cmd = new SqlCommand(@"SELECT COUNT(*) FROM Users WHERE Password = @Password AND Username = @Username", conn);

                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Username", username);

                iCount = (int)cmd.ExecuteScalar();

                if (iCount == 0)
                {
                    MessageBox.Show(
                        "Incorrect password",
                        "Invalid Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                cmd = new SqlCommand(@"SELECT COUNT(*) FROM Users WHERE Role = 'Admin' AND Username = @Username", conn);

                cmd.Parameters.AddWithValue("@Username", username);

                iCount = (int)cmd.ExecuteScalar();

                if (iCount == 0)
                {
                    MainForm mainForm = new MainForm(username, "Staff");
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MainForm mainForm = new MainForm(username, "Admin");
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "An error occurred while connecting to the database. Please try again later.\n\n" + ex,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        "An unexpected error occurred. Please try again later.\n\n" + ex,
                        "Login Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void btnShowPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}
