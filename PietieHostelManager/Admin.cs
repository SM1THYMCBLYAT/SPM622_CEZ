using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PietieHostelManager
{
    public partial class Admin : Form
    {

        private readonly string connectionString =
            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";
        private string? selectedUsername = null;
        public Admin()
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
        private void LoadUsers()
        {
            string query = @"
        SELECT Username, Role
        FROM Users
        ORDER BY Username;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                using (SqlDataAdapter adapter =
                       new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    AdminUsersDataGridView.DataSource = table;
                    AdminUsersDataGridView.SelectionMode =DataGridViewSelectionMode.FullRowSelect;

                    AdminUsersDataGridView.MultiSelect = false;

                    AdminUsersDataGridView.ReadOnly = true;

                    AdminUsersDataGridView.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load users: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            string query = @"
        SELECT
            r.RoomID AS [Room ID],
            r.RoomNumber AS [Room Number],
            r.Type AS [Room Type],
            COUNT(g.GuestID) AS [Occupants],
            r.Status AS [Status],
            rt.Capacity AS [Max Capacity]
        FROM Rooms r
        INNER JOIN RoomTypes rt
            ON r.Type = rt.Type
        LEFT JOIN Bookings b
            ON r.RoomID = b.RoomID
        LEFT JOIN Guests g
            ON b.GuestID = g.GuestID
            AND g.Occupancy = 'Checked In'
        GROUP BY
            r.RoomID,
            r.RoomNumber,
            r.Type,
            r.Status,
            rt.Capacity
        ORDER BY r.RoomNumber;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                using (SqlDataAdapter adapter =
                       new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    AdminRoomsDataGridView.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load rooms: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void Admin_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadRooms();

        }

        private void AdminRoomsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminAddRoomButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminEditRoomButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminDeleteRoomButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminAddRoomTypeButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminEditRoomTypeButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminDeleteRoomTypeButton_Click(object sender, EventArgs e)
        {

        }
        private void AdminUserTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AdminUserTable_SelectionChanged(object sender, EventArgs e)
        {
            if (AdminUsersDataGridView.SelectedRows.Count > 0)
            {
                selectedUsername = 
                    AdminUsersDataGridView.SelectedRows[0]
                    .Cells["Username"].Value?.ToString();
            }
            else
            {
                selectedUsername = null;
            }
        }

        private void AdminCreateUserButton_Click(object sender, EventArgs e)
        {
            string username = Interaction.InputBox(
                "Enter a username:",
                "Create User",
                "").Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Username cannot be empty.",
                    "Invalid Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string password = Interaction.InputBox(
                "Enter a password:",
                "Create User",
                "");

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Password cannot be empty.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string role = Interaction.InputBox(
                "Enter a role (Admin or Staff):",
                "Create User",
                "Staff").Trim();

            if (!role.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                !role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Role must be either Admin or Staff.",
                    "Invalid Role",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            role = role.Equals("Admin", StringComparison.OrdinalIgnoreCase)
                ? "Admin"
                : "Staff";

            DialogResult confirmation = MessageBox.Show(
                $"Create user '{username}' with role '{role}'?",
                "Confirm User Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            // Use the same SHA-256 hashing method as UserLogin.cs.
            string hashedPassword = ComputeSha256Hash(password);

            string query = @"
        INSERT INTO Users (Username, Password, Role)
        VALUES (@Username, @Password, @Role);";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@Role", role);

                    connection.Open();

                    command.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "User created successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                selectedUsername = null;
                LoadUsers();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "That username already exists. Please choose another.",
                        "Duplicate Username",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Failed to create user: " + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AdminChangeUserPasswordButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedUsername))
            {
                MessageBox.Show(
                    "Please select a user first.",
                    "No User Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string newPassword = Interaction.InputBox(
                $"Enter a new password for '{selectedUsername}':",
                "Change User Password",
                "");

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show(
                    "Password cannot be empty.",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Change the password for '{selectedUsername}'?",
                "Confirm Password Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            // Hash the new password using SHA-256.
            string hashedPassword = ComputeSha256Hash(newPassword);

            string query = @"
        UPDATE Users
        SET Password = @Password
        WHERE Username = @Username;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@Username", selectedUsername);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "Password changed successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "The selected user could not be found.",
                            "User Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        LoadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to change password: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void AdminDeleteUserButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedUsername))
            {
                MessageBox.Show(
                    "Please select a user to delete.",
                    "No User Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete user '{selectedUsername}'?",
                "Confirm User Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            string query = "DELETE FROM Users WHERE Username = @Username";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@Username", selectedUsername);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(
                            "User deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        selectedUsername = null;
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show(
                            "The selected user could not be found.",
                            "User Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        LoadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to delete user: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
