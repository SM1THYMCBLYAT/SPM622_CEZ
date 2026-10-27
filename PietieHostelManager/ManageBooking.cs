using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PietieHostelManager
{
    public partial class ManageBookingForm : Form
    {
        private int? currentBookingID = null;
        private int? currentGuestID = null;

        private readonly string connectionString = @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";
        public ManageBookingForm()
        {
            InitializeComponent();
        }


        private void LoadManageRooms()
        {
            string sql = @"
        SELECT
            r.RoomID,
            r.RoomNumber,
            r.Type,
            r.Status,
            rt.Capacity,
            COUNT(
                CASE
                    WHEN g.Occupancy = 'Checked In'
                         AND b.CheckOutDate IS NULL
                    THEN b.BookingID
                END
            ) AS CurrentOccupants
        FROM Rooms r
        INNER JOIN RoomTypes rt ON r.Type = rt.Type
        LEFT JOIN Bookings b ON r.RoomID = b.RoomID
        LEFT JOIN Guests g ON b.GuestID = g.GuestID
        GROUP BY
            r.RoomID,
            r.RoomNumber,
            r.Type,
            r.Status,
            rt.Capacity
        ORDER BY r.RoomNumber;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable roomsTable = new DataTable();
                    adapter.Fill(roomsTable);

                    ManageBookingDataGridView.DataSource = roomsTable;

                    // Keep the internal room ID available for selection.
                    if (ManageBookingDataGridView.Columns.Contains("RoomID"))
                    {
                        ManageBookingDataGridView.Columns["RoomID"].Visible = false;
                    }

                    ManageBookingDataGridView.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    ManageBookingDataGridView.MultiSelect = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Unable to load rooms:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void SearchGuestIDButton_Click(object sender, EventArgs e)
        {
            ManageRoomLabel.Text = "Room: Not selected";

            if (!int.TryParse(ManageSearchGuestIDTextBox.Text.Trim(), out int guestID))
            {
                MessageBox.Show(
                    "Please enter a valid Guest ID.",
                    "Invalid Guest ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string sql = @"
        SELECT
            b.BookingID,
            g.GuestID,
            b.RoomID,
            r.RoomNumber,
            b.BookingDateStart,
            b.BookingDateEnd,
            b.Price,
            b.TotalPrice,
            b.PaymentStatus,
            g.FirstName,
            g.LastName,
            g.PhoneNumber,
            g.Email,
            g.Occupancy
        FROM Guests g
        INNER JOIN Bookings b ON b.GuestID = g.GuestID
        INNER JOIN Rooms r ON r.RoomID = b.RoomID
        WHERE g.GuestID = @GuestID;";

            try
            {
                int roomID;
                DateTime startDate;
                DateTime endDate;
                decimal totalPrice;
                string paymentStatus;
                string occupancy;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@GuestID", SqlDbType.Int).Value = guestID;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check whether a booking was found BEFORE reading columns.
                        if (!reader.Read())
                        {
                            currentBookingID = null;
                            currentGuestID = null;

                            ManageRoomLabel.Text = "Room: Not found";

                            MessageBox.Show(
                                "No booking was found for this Guest ID.",
                                "Booking Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            return;
                        }

                        // Read booking details after reader.Read() succeeds.
                        currentBookingID = Convert.ToInt32(reader["BookingID"]);
                        currentGuestID = Convert.ToInt32(reader["GuestID"]);

                        roomID = Convert.ToInt32(reader["RoomID"]);
                        int roomNumber = Convert.ToInt32(reader["RoomNumber"]);

                        ManageRoomLabel.Text = $"Room Number: {roomNumber}";

                        startDate = Convert.ToDateTime(reader["BookingDateStart"]);
                        endDate = Convert.ToDateTime(reader["BookingDateEnd"]);
                        totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                        paymentStatus = reader["PaymentStatus"].ToString();
                        occupancy = reader["Occupancy"].ToString();

                        ManageFirstNameTextBox.Text = reader["FirstName"].ToString();
                        ManageLastNameTextBox.Text = reader["LastName"].ToString();

                        bool noPhone =
                            reader["PhoneNumber"] == DBNull.Value ||
                            string.IsNullOrWhiteSpace(reader["PhoneNumber"].ToString());

                        ManageNoPhoneCheckBox.Checked = noPhone;
                        ManagePhoneTextBox.Text = noPhone
                            ? ""
                            : reader["PhoneNumber"].ToString();
                        ManagePhoneTextBox.Enabled = !noPhone;

                        bool noEmail =
                            reader["Email"] == DBNull.Value ||
                            string.IsNullOrWhiteSpace(reader["Email"].ToString());

                        ManageNoEmailCheckBox.Checked = noEmail;
                        ManageEmailTextBox.Text = noEmail
                            ? ""
                            : reader["Email"].ToString();
                        ManageEmailTextBox.Enabled = !noEmail;
                    }
                }

                ManageStartDateTimePicker.Value = startDate;
                ManageEndDateTimePicker.Value = endDate;

                ManageTotalPriceTextBox.Text = totalPrice.ToString(
                    "C2",
                    System.Globalization.CultureInfo.GetCultureInfo("en-ZA"));

                ManagePaymentStatusComboBox.Items.Clear();
                ManagePaymentStatusComboBox.Items.Add("Pending");
                ManagePaymentStatusComboBox.Items.Add("Paid");
                ManagePaymentStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                if (ManagePaymentStatusComboBox.Items.Contains(paymentStatus))
                {
                    ManagePaymentStatusComboBox.SelectedItem = paymentStatus;
                }
                else
                {
                    ManagePaymentStatusComboBox.SelectedIndex = 0;
                }

                ManageOccupancyComboBox.Items.Clear();
                ManageOccupancyComboBox.Items.Add("Pending");
                ManageOccupancyComboBox.Items.Add("Checked In");
                ManageOccupancyComboBox.Items.Add("Checked Out");
                ManageOccupancyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                if (ManageOccupancyComboBox.Items.Contains(occupancy))
                {
                    ManageOccupancyComboBox.SelectedItem = occupancy;
                }
                else
                {
                    ManageOccupancyComboBox.SelectedIndex = 0;
                }

                LoadManageRooms();

                foreach (DataGridViewRow row in ManageBookingDataGridView.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    if (Convert.ToInt32(row.Cells["RoomID"].Value) == roomID)
                    {
                        row.Selected = true;
                        ManageBookingDataGridView.CurrentCell = row.Cells["RoomNumber"];
                        break;
                    }
                }

                MessageBox.Show(
                    "Booking and guest details loaded successfully.",
                    "Booking Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while loading the booking:\n\n" + ex.Message,
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ManagePhoneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ManagePhoneTextBox.Enabled = !ManageNoPhoneCheckBox.Checked;

            if (ManageNoPhoneCheckBox.Checked)
            {
                ManagePhoneTextBox.Clear();
            }

        }

        private void ManageEmailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ManageEmailTextBox.Enabled = !ManageNoEmailCheckBox.Checked;

            if (ManageNoEmailCheckBox.Checked)
            {
                ManageEmailTextBox.Clear();
            }
        }

        private void ManageBookingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
