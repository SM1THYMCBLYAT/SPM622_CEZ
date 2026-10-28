using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;
using Microsoft.Data.SqlClient;

namespace PietieHostelManager
{
    public partial class Admin : Form
    {

        private readonly string connectionString =
            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";

        public Admin()
        {
            InitializeComponent();
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

        private void AdminCreateUserButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminChangeUserPasswordButton_Click(object sender, EventArgs e)
        {

        }

        private void AdminDeleteUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}
