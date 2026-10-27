using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using System.Drawing.Text;
using Microsoft.Data.SqlClient;

namespace PietieHostelManager
{
    public partial class CreateBookingForm : Form
    {
        public CreateBookingForm()
        {
            InitializeComponent();
        }
        private const decimal DailyRate = 150.00m; //test purposes, can be removed on final version

        public int? SelectedRoomID { get; private set; }

        private bool ValidateGuestInfo()
        {
            if (string.IsNullOrWhiteSpace(AddFirstNameTextBox.Text))
            {
                MessageBox.Show("please enter the geust's first name.");
                AddFirstNameTextBox.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(AddLastNameTextBox.Text))
            {
                MessageBox.Show("please enter the geust's last name.");
                AddLastNameTextBox.Focus();
                return false;
            }
            if (!AddNoPhoneCheckBox.Checked &&
                string.IsNullOrWhiteSpace(AddPhoneTextBox.Text))
            {
                MessageBox.Show("please enter the geust's phone number or check the 'No Phone' box.");
                AddPhoneTextBox.Focus();
                return false;
            }
            if (!AddNoEmailCheckBox.Checked &&
                string.IsNullOrWhiteSpace(AddEmailTextBox.Text))
            {
                MessageBox.Show("please enter the geust's email address or check the 'No Email' box.");
                AddEmailTextBox.Focus();
                return false;
            }
            if (!AddNoEmailCheckBox.Checked)
            {
                try
                {
                    var email = new MailAddress(AddEmailTextBox.Text.Trim());

                    if (email.Address != AddEmailTextBox.Text.Trim())
                    {
                        MessageBox.Show("Please enter a valid email address.");
                        AddEmailTextBox.Focus();
                        return false;
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid email address.");
                    AddEmailTextBox.Focus();
                    return false;
                }
            }
            return true;
        }

        private int SaveGuest()
        {
            string connectionString =
                            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";


            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Database connection string was not found.");
            }

            string query = @"
        INSERT INTO Guests
            (FirstName, LastName, PhoneNumber, Email, Occupancy)
        OUTPUT INSERTED.GuestID
        VALUES
            (@FirstName, @LastName, @PhoneNumber, @Email, @Occupancy);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 100)
                    .Value = AddFirstNameTextBox.Text.Trim();

                command.Parameters.Add("@LastName", SqlDbType.VarChar, 100)
                    .Value = AddLastNameTextBox.Text.Trim();

                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 20)
                    .Value = AddNoPhoneCheckBox.Checked
                        ? DBNull.Value
                        : AddPhoneTextBox.Text.Trim();

                command.Parameters.Add("@Email", SqlDbType.VarChar, 150)
                    .Value = AddNoEmailCheckBox.Checked
                        ? DBNull.Value
                        : AddEmailTextBox.Text.Trim();

                command.Parameters.Add("@Occupancy", SqlDbType.VarChar, 20)
                    .Value = "Pending";

                connection.Open();

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void LoadRooms()
        {
            string connectionString =
                            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";


            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show("Database connection string was not found.");
                return;
            }

            string query = @"
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
        INNER JOIN RoomTypes rt
            ON r.Type = rt.Type
        LEFT JOIN Bookings b
            ON r.RoomID = b.RoomID
        LEFT JOIN Guests g
            ON b.GuestID = g.GuestID
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
                using (SqlDataAdapter adapter =
                       new SqlDataAdapter(query, connection))
                {
                    DataTable roomsTable = new DataTable();

                    adapter.Fill(roomsTable);

                    CreateBookingDataGridView.DataSource = roomsTable;

                    // Keep the database ID available without displaying it.
                    CreateBookingDataGridView.Columns["RoomID"].Visible = false;

                    CreateBookingDataGridView.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    CreateBookingDataGridView.ReadOnly = true;
                    CreateBookingDataGridView.AllowUserToAddRows = false;
                    CreateBookingDataGridView.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    CreateBookingDataGridView.MultiSelect = false;

                    CreateBookingDataGridView.Columns["RoomNumber"].Width = 90;
                    CreateBookingDataGridView.Columns["Type"].Width = 130;
                    CreateBookingDataGridView.Columns["Status"].Width = 110;
                    CreateBookingDataGridView.Columns["Capacity"].Width = 90;
                    CreateBookingDataGridView.Columns["CurrentOccupants"].Width = 140;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load rooms from the database.\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalPrice()
        {
            DateTime startDate = CreateBookingStartDatePicker.Value.Date;
            DateTime endDate = CreateBookingEndDatePicker.Value.Date;

            if (endDate <= startDate)
            {
                CreateTotalPriceTextBox.Text = "0.00";
                return;
            }

            int numberOfDays = (endDate - startDate).Days;
            decimal totalPrice = numberOfDays * DailyRate;

            CreateTotalPriceTextBox.Text = totalPrice.ToString("C2",
                System.Globalization.CultureInfo.GetCultureInfo("en-ZA"));
        }

        private void CreateBooking_Load(object sender, EventArgs e)
        {
            LoadRooms();
            CalculateTotalPrice();

            CreatePaymentStatusComboBox.Items.Clear();
            CreatePaymentStatusComboBox.Items.Add("Pending");
            CreatePaymentStatusComboBox.Items.Add("Paid");
            //PaymentStatusComboBox.Items.Add("Overdue"); deprecied, as overdue booking will be seen as "pending"

            CreatePaymentStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            CreatePaymentStatusComboBox.SelectedIndex = 0;
        }

        private void NoPhoneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AddPhoneTextBox.Enabled = !AddNoPhoneCheckBox.Checked;
            if (AddNoPhoneCheckBox.Checked)
            {
                AddPhoneTextBox.Clear();
            }
        }

        private void NoEmailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AddEmailTextBox.Enabled = !AddNoEmailCheckBox.Checked;
            if (AddNoEmailCheckBox.Checked)
            {
                AddEmailTextBox.Clear();
            }
        }

        private void CreateBookingDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreateBookingDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CreateBookingDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow =
                    CreateBookingDataGridView.SelectedRows[0];

                SelectedRoomID = Convert.ToInt32(
                    selectedRow.Cells["RoomID"].Value);
            }
            else
            {
                SelectedRoomID = null;
            }
        }

        private void CreateBookingButton_Click(object sender, EventArgs e)
        {
            if (!ValidateGuestInfo())
                return;

            if (CreateBookingDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room.");
                return;
            }

            DateTime startDate = CreateBookingStartDatePicker.Value.Date;
            DateTime endDate = CreateBookingEndDatePicker.Value.Date;

            if (startDate < DateTime.Today)
            {
                MessageBox.Show("The booking start date cannot be in the past.");
                return;
            }

            if (endDate <= startDate)
            {
                MessageBox.Show("The end date must be after the start date.");
                return;
            }

            int roomID = Convert.ToInt32(
                CreateBookingDataGridView.SelectedRows[0].Cells["RoomID"].Value);

            int numberOfDays = (endDate - startDate).Days;
            decimal totalPrice = numberOfDays * DailyRate;

            string paymentStatus = CreatePaymentStatusComboBox.Text.Trim();

            if (paymentStatus != "Pending" &&
                paymentStatus != "Paid")
            //paymentStatus != "Overdue")
            {
                MessageBox.Show("Please select a valid payment status.");
                return;
            }

            string connectionString =
                @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string guestQuery = @"
                    INSERT INTO Guests
                        (FirstName, LastName, PhoneNumber, Email, Occupancy)
                    OUTPUT INSERTED.GuestID
                    VALUES
                        (@FirstName, @LastName, @PhoneNumber, @Email, @Occupancy);";

                        int guestID;

                        using (SqlCommand command =
                               new SqlCommand(guestQuery, connection, transaction))
                        {
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 100)
                                .Value = AddFirstNameTextBox.Text.Trim();

                            command.Parameters.Add("@LastName", SqlDbType.VarChar, 100)
                                .Value = AddLastNameTextBox.Text.Trim();

                            command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 20)
                                .Value = AddNoPhoneCheckBox.Checked
                                    ? DBNull.Value
                                    : (object)AddPhoneTextBox.Text.Trim();

                            command.Parameters.Add("@Email", SqlDbType.VarChar, 150)
                                .Value = AddNoEmailCheckBox.Checked
                                    ? DBNull.Value
                                    : (object)AddEmailTextBox.Text.Trim();

                            command.Parameters.Add("@Occupancy", SqlDbType.VarChar, 20)
                                .Value = "Pending";

                            guestID = Convert.ToInt32(command.ExecuteScalar());
                        }

                        string bookingQuery = @"
                    INSERT INTO Bookings
                        (GuestID, RoomID, BookingDateStart, BookingDateEnd,
                         PaymentStatus, TotalPrice, Price)
                    VALUES
                        (@GuestID, @RoomID, @StartDate, @EndDate,
                         @PaymentStatus, @TotalPrice, @Price);";

                        using (SqlCommand command =
                               new SqlCommand(bookingQuery, connection, transaction))
                        {
                            command.Parameters.Add("@GuestID", SqlDbType.Int).Value = guestID;
                            command.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomID;
                            command.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                            command.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;

                            command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar, 20)
                                .Value = paymentStatus;

                            SqlParameter totalParam =
                                command.Parameters.Add("@TotalPrice", SqlDbType.Decimal);
                            totalParam.Precision = 10;
                            totalParam.Scale = 2;
                            totalParam.Value = totalPrice;

                            SqlParameter priceParam =
                                command.Parameters.Add("@Price", SqlDbType.Decimal);
                            priceParam.Precision = 10;
                            priceParam.Scale = 2;
                            priceParam.Value = DailyRate;

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show(
                            $"Booking created successfully!\nGuest ID: {guestID}\n" +
                            $"Room ID: {roomID}\nNights: {numberOfDays}\n" +
                            $"Total: {totalPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-ZA"))}");

                        LoadRooms();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (SqlException)
                        {
                        }

                        MessageBox.Show(
                            "Booking could not be created:\n" + ex.Message,
                            "Booking Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BookingStartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void BookingEndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();

        }

        private void CancelBookingButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Are you sure you want to cancel this booking?",
        "Confirm Cancellation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            AddFirstNameTextBox.Clear();
            AddLastNameTextBox.Clear();

            AddPhoneTextBox.Clear();
            AddNoPhoneCheckBox.Checked = false;

            AddEmailTextBox.Clear();
            AddNoEmailCheckBox.Checked = false;

            CreateBookingStartDatePicker.Value = DateTime.Today;
            CreateBookingEndDatePicker.Value = DateTime.Today.AddDays(1);

            CreatePaymentStatusComboBox.SelectedItem = "Pending";

            CalculateTotalPrice();

            CreateBookingDataGridView.ClearSelection();

            SelectedRoomID = null;
        }
    }
}
