using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace PietieHostelManager
{
    public partial class ManageBookingForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HostelDB"].ConnectionString;
        private decimal DailyRate = Properties.Settings.Default.DailyRate;
        private int currentBookingID;
        private int currentGuestID;
        private DataTable bookingTable;
        private MainForm mainFormReference;

        public ManageBookingForm(MainForm parentForm)
        {
            InitializeComponent();
            mainFormReference = parentForm;
        }

        private void SearchGuestIDButton_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlCheck = @"SELECT COUNT(*) FROM Guests WHERE GuestID = @GuestID";
                int guestID = int.Parse(ManageSearchGuestIDTextBox.Text.Trim());

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlCheck, conn);

                cmd.Parameters.AddWithValue("@GuestID", guestID);

                conn.Open();
                int iCount = (int)cmd.ExecuteScalar();

                if (iCount == 0)
                {
                    MessageBox.Show(
                        "Guest not found",
                        "Not found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                string sql = @"SELECT
                                   g.FirstName,
                                   g.LastName,
                                   g.PhoneNumber,
                                   g.Email,
                                   b.BookingDateStart,
                                   b.BookingDateEnd,
                                   b.TotalPrice,
                                   b.PaymentStatus,
                                   g.Occupancy,
                                   b.BookingID
                               FROM Guests g
                               INNER JOIN Bookings b ON g.GuestID = b.GuestID
                               WHERE g.GuestID = @GuestID;";

                bookingTable = new DataTable();
                cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@GuestID", guestID);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                bookingTable.Clear();
                sqlAdapter.Fill(bookingTable);

                if (bookingTable.Rows.Count > 0)
                {
                    DataRow row = bookingTable.Rows[0];
                    string FirstName = row["FirstName"].ToString();
                    string LastName = row["LastName"].ToString();
                    string Phone = row["PhoneNumber"].ToString();
                    string Email = row["Email"].ToString();
                    DateTime startDate = row["BookingDateStart"] != DBNull.Value ? Convert.ToDateTime(row["BookingDateStart"]) : DateTime.Today;
                    DateTime endDate = row["BookingDateEnd"] != DBNull.Value ? Convert.ToDateTime(row["BookingDateEnd"]) : DateTime.Today.AddDays(1);
                    decimal Price = Convert.ToDecimal(row["TotalPrice"]);
                    string PaymentStatus = row["PaymentStatus"].ToString();
                    string Occupancy = row["Occupancy"].ToString();
                    int bookingID = Convert.ToInt32(row["BookingID"]);

                    ManageFirstNameTextBox.Text = FirstName;
                    ManageLastNameTextBox.Text = LastName;
                    ManagePhoneTextBox.Text = Phone;
                    ManageEmailTextBox.Text = Email;
                    ManageStartDateTimePicker.Value = startDate;
                    ManageEndDateTimePicker.Value = endDate;
                    ManageTotalPriceTextBox.Text = Price.ToString();
                    ManagePaymentStatusComboBox.Text = PaymentStatus;
                    ManageOccupancyComboBox.Text = Occupancy;

                    currentBookingID = bookingID;
                    currentGuestID = guestID;
                }
                else
                {
                    MessageBox.Show(
                        "Guest and booking details unabled to be occupied",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database Error:\n\n" + ex,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
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

        private void CalculateTotalPrice()
        {
            DateTime startDate = ManageStartDateTimePicker.Value;
            DateTime endDate = ManageEndDateTimePicker.Value;

            if (endDate <= startDate)
            {
                ManageTotalPriceTextBox.Text = "0.00";
                return;
            }

            int numberOfDays = (endDate - startDate).Days;
            decimal totalPrice = numberOfDays * DailyRate;

            ManageTotalPriceTextBox.Text = totalPrice.ToString();
        }

        private void ManageBookingForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateBookingButton_Click(object sender, EventArgs e)
        {
            if (ManageStartDateTimePicker.Value > ManageEndDateTimePicker.Value)
            {
                MessageBox.Show(
                    "Please input valid dates",
                    "Invalid Criteria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = @"UPDATE Guests
                               SET FirstName = @FirstName,
                                   LastName = @LastName,
                                   PhoneNumber = @PhoneNumber,
                                   Email = @Email,
                                   Occupancy = @Occupancy
                               WHERE GuestID = @GuestID;";

                string FirstName = ManageFirstNameTextBox.Text.Trim();
                string LastName = ManageLastNameTextBox.Text.Trim();
                int Phone;
                try { Phone = int.Parse(ManagePhoneTextBox.Text.Trim()); }
                catch { MessageBox.Show("Enter a valid phone number"); return; }
                string Email = ManageEmailTextBox.Text.Trim();
                string Occupancy = ManageOccupancyComboBox.Text.Trim();

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", Phone);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Occupancy", Occupancy);
                cmd.Parameters.AddWithValue("@GuestID", currentGuestID);

                conn.Open();
                cmd.ExecuteNonQuery();

                sql = @"UPDATE Bookings 
                        SET BookingDateStart = @StartDate, 
                            BookingDateEnd = @EndDate, 
                            Price = @Price, 
                            TotalPrice = @TotalPrice, 
                            PaymentStatus = @PaymentStatus 
                        WHERE BookingID = @BookingID;";

                DateTime StartDate = ManageStartDateTimePicker.Value;
                DateTime EndDate = ManageEndDateTimePicker.Value;
                DateTime NextBillDate = StartDate.AddMonths(1);
                if (NextBillDate > EndDate) { NextBillDate = EndDate; }
                decimal Price = (NextBillDate - StartDate).Days * DailyRate;
                decimal TotalPrice = Convert.ToDecimal(ManageTotalPriceTextBox.Text.Trim());
                string PaymentStatus = ManagePaymentStatusComboBox.Text;

                cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = EndDate;
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                cmd.Parameters.AddWithValue("@BookingID", currentBookingID);
                cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database Error:\n\n" + ex,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ManageStartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void ManageEndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void ManageBookingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string sql = @"INSERT INTO AuditLog (Username, RecordType, GivenID, QueryDate, Details)
                               VALUES (@Username, @RecordType, @GivenID, @QueryDate, @Details)";

                string Username = mainFormReference.User;
                string RecordType = "Bookings";
                int GivenID = currentBookingID;
                DateTime QueryDate = DateTime.Today;
                string Details = "Updated booking";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@RecordType", RecordType);
                cmd.Parameters.AddWithValue("@GivenID", GivenID);
                cmd.Parameters.Add("@QueryDate", SqlDbType.Date).Value = QueryDate;
                cmd.Parameters.AddWithValue("@Details", Details);

                conn.Open();
                cmd.ExecuteNonQuery();

                RecordType = "Guests";
                GivenID = currentGuestID;
                Details = "Updated guest details";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@RecordType", RecordType);
                cmd.Parameters.AddWithValue("@GivenID", GivenID);
                cmd.Parameters.Add("@QueryDate", SqlDbType.Date).Value = QueryDate;
                cmd.Parameters.AddWithValue("@Details", Details);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database Error:\n\n" + ex,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        private void CancelUpdateButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
