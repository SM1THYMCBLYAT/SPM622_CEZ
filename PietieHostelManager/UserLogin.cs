using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly string connectionString =
            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";
        public UserLogin()
        {
            InitializeComponent();
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            UserLoginTextPassword.PasswordChar = '*';
            this.AcceptButton = UserLoginButtonLogin;
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

        private void LoginButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserLoginButtonLogin_Click(object sender, EventArgs e)
        {
            string username = UserLoginTextUsername.Text.Trim();
            string password = UserLoginTextPassword.Text;

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter both username and password.",
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                string enteredPasswordHash = ComputeSha256Hash(password);

                string storedPasswordHash;
                string role;

                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT PasswordHash, Role
                        FROM Users
                        WHERE Username = @Username";
                }
            }



            catch (SqlException)
            {
                MessageBox.Show(
                    "An error occurred while connecting to the database. Please try again later.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                        "An unexpected error occurred. Please try again later.",
                        "Login Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        private void ShowInvalidLogin()
        {
            MessageBox.Show(
                "Invalid username or password.",
                "Login Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            UserLoginTextPassword.Clear();
            UserLoginTextPassword.Focus();
        }
    }
}
