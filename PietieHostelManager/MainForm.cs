using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Configuration;

namespace PietieHostelManager
{
    public partial class MainForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string User { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserRole { get; set; }
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["HostelDB"].ConnectionString;
        private SqlDataAdapter sqlAdapter;
        private DataTable roomsTable;
        private DataTable bookingsTable;
        private decimal DailyRate = Properties.Settings.Default.DailyRate;

        public MainForm(string username, string userRole)
        {
            InitializeComponent();
            User = username;
            UserRole = userRole;
        }

        private void LoadRoomsTable()
        {
            try
            {
                string sql = @"SELECT
                                   r.RoomNumber AS [Room#],
                                   r.Status,
                                   r.Type,
                                   COUNT(b.GuestID) AS Occupants
                               FROM Rooms r
                               LEFT JOIN Bookings b ON r.RoomID = b.RoomID
                               WHERE (@Type IS NULL OR r.Type = @Type)
                                 AND (@Status IS NULL OR r.Status = @Status)
                               GROUP BY r.RoomNumber, r.Status, r.Type;";
                string RoomStatus = cmbRoomStatus.Text;
                string RoomType = cmbRoomType.Text;

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);

                if (RoomType == "") { cmd.Parameters.AddWithValue("@Type", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Type", RoomType); }

                if (RoomStatus == "") { cmd.Parameters.AddWithValue("@Status", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Status", RoomStatus); }

                conn.Open();
                roomsTable = new DataTable();
                roomsTable.Clear();
                sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(roomsTable);

                dgvRooms.DataSource = roomsTable;
                dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                dgvRooms.Columns["Room#"].Width = 87;
                dgvRooms.Columns["Status"].Width = 127;
                dgvRooms.Columns["Type"].Width = 126;
                dgvRooms.Columns["Occupants"].Width = 80;
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

        private void LoadBookingsTable()
        {
            try
            {
                string searchCondition;
                switch (cmbFilterBooking.SelectedIndex)
                {
                    case 1:
                        searchCondition = "CAST(b.BookingID AS VARCHAR) LIKE @SearchText";
                        break;
                    case 2:
                        searchCondition = "r.RoomNumber LIKE @SearchText";
                        break;
                    case 3:
                        searchCondition = "(g.FirstName + ' ' + g.LastName) LIKE @SearchText";
                        break;
                    case 4:
                        searchCondition = "g.PhoneNumber LIKE @SearchText";
                        break;
                    case 5:
                        searchCondition = "g.Email LIKE @SearchText";
                        break;
                    default:
                        searchCondition = "1=1";
                        break;
                }
                string sql = $@"SELECT
                                   b.BookingID,
                                   r.RoomNumber AS [Room#],
                                   (g.FirstName + ' ' + g.LastName) AS [Full Name],
                                   g.PhoneNumber AS [Phone],
                                   g.Email,
                                   b.BookingDateStart AS [Start Date],
                                   b.BookingDateEnd AS [End Date],
                                   b.Price,
                                   b.TotalPrice AS [Total Price],
                                   b.PaymentStatus AS [Payment Status],
                                   g.Occupancy
                               FROM Bookings b
                               INNER JOIN Rooms r ON b.RoomID = r.RoomID
                               INNER JOIN Guests g ON b.GuestID = g.GuestID
                               WHERE ({searchCondition})
                                 AND (@StartDate IS NULL OR b.BookingDateStart >= @StartDate)
                                 AND (@EndDate IS NULL OR b.BookingDateEnd <= @EndDate)
                                 AND (@PaymentStatus IS NULL OR b.PaymentStatus = @PaymentStatus)
                                 AND (@Occupancy IS NULL OR g.Occupancy = @Occupancy);";
                string paymentStatus = cmbPaymentStatus.Text;
                string occupancy = cmbOccupancy.Text;

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);

                string search = txtSearchBox.Text.Trim();
                if (string.IsNullOrEmpty(search)) { cmd.Parameters.AddWithValue("@SearchText", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@SearchText", "%" + search + "%"); }

                if (!dtpAfter.Checked) { cmd.Parameters.AddWithValue("@StartDate", DBNull.Value); }
                else { cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpAfter.Value.Date; }

                if (!dtpBefore.Checked) { cmd.Parameters.AddWithValue("@EndDate", DBNull.Value); }
                else { cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpBefore.Value.Date; }

                if (paymentStatus == "") { cmd.Parameters.AddWithValue("@PaymentStatus", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus); }

                if (occupancy == "") { cmd.Parameters.AddWithValue("@Occupancy", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@Occupancy", occupancy); }

                conn.Open();
                bookingsTable = new DataTable();
                bookingsTable.Clear();
                sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(bookingsTable);

                dgvBookings.DataSource = bookingsTable;
                dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                dgvBookings.Columns["BookingID"].Width = 80;
                dgvBookings.Columns["Room#"].Width = 80;
                dgvBookings.Columns["Full Name"].Width = 200;
                dgvBookings.Columns["Phone"].Width = 88;
                dgvBookings.Columns["Email"].Width = 350;
                dgvBookings.Columns["Start Date"].Width = 100;
                dgvBookings.Columns["End Date"].Width = 100;
                dgvBookings.Columns["Price"].Width = 95;
                dgvBookings.Columns["Total Price"].Width = 95;
                dgvBookings.Columns["Payment Status"].Width = 120;
                dgvBookings.Columns["Occupancy"].Width = 120;
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

        private void buttonOpenAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Enabled = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateRoomTypeFilter()
        {
            try
            {
                string sql = "SELECT Type FROM RoomTypes";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                cmbRoomType.Items.Clear();
                cmbRoomType.Items.Add("");
                while (reader.Read())
                {
                    cmbRoomType.Items.Add(reader["Type"].ToString());
                }
                cmbRoomType.SelectedIndex = 0;
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            UpdateRoomTypeFilter();
            LoadRoomsTable();
            LoadBookingsTable();
            lblUsername.Text = User;
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomsTable();
        }

        private void cmbRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomsTable();
        }

        private void btnShowAllRooms_Click(object sender, EventArgs e)
        {
            cmbRoomStatus.SelectedIndex = 0;
            cmbRoomType.SelectedIndex = 0;
            LoadRoomsTable();
        }

        private void btnShowAllBookings_Click(object sender, EventArgs e)
        {
            dtpAfter.Checked = false;
            dtpBefore.Checked = false;
            cmbFilterBooking.SelectedIndex = 0;
            txtSearchBox.Clear();
            cmbPaymentStatus.SelectedIndex = 0;
            cmbOccupancy.SelectedIndex = 0;
            LoadBookingsTable();
        }

        private void cmbOccupancy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingsTable();
        }

        private void cmbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingsTable();
        }

        private void btnSearchBookings_Click(object sender, EventArgs e)
        {
            LoadBookingsTable();
        }

        private void dtpBefore_ValueChanged(object sender, EventArgs e)
        {
            LoadBookingsTable();
        }

        private void dtpAfter_ValueChanged(object sender, EventArgs e)
        {
            LoadBookingsTable();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            User = "";
            UserRole = "";
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            CreateBookingForm createBooking = new CreateBookingForm();
            createBooking.Show();
        }

        private void btnManageBooking_Click(object sender, EventArgs e)
        {
            ManageBookingForm manageBooking = new ManageBookingForm();
            manageBooking.Show();
        }

        private void UpdatePrices()
        {
            try
            {
                string selectQuery = "SELECT BookingID, BookingDateStart, BookingDateEnd FROM Bookings";
                string updateQuery = @"UPDATE Bookings SET Price = @Price, TotalPrice = @TotalPrice WHERE BookingID = @BookingID";

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                DataTable bookingsTable = new DataTable();

                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                SqlDataReader reader = selectCmd.ExecuteReader();
                bookingsTable.Load(reader);

                foreach (DataRow row in bookingsTable.Rows)
                {
                    int bookingID = Convert.ToInt32(row["BookingID"]);
                    DateTime startDate = Convert.ToDateTime(row["BookingDateStart"]);
                    DateTime endDate = Convert.ToDateTime(row["BookingDateEnd"]);

                    int totalDays = (endDate - startDate).Days;
                    decimal totalPrice = totalDays * DailyRate;

                    DateTime today = DateTime.Today;
                    DateTime currentAnchor = new DateTime(today.Year, today.Month, startDate.Day);
                    DateTime nextAnchor = currentAnchor.AddMonths(1);

                    if (today > endDate)
                    {
                        DateTime trackDate = startDate;
                        while (trackDate < endDate)
                        {
                            trackDate = trackDate.AddMonths(1);
                        }
                        trackDate = trackDate.AddMonths(-1);

                        currentAnchor = trackDate;
                        nextAnchor = endDate;
                    }

                    if (today < startDate)
                    {
                        currentAnchor = startDate;
                        nextAnchor = currentAnchor.AddMonths(1);
                        if (nextAnchor > endDate)
                        {
                            nextAnchor = endDate;
                        }
                    }

                    decimal price = (nextAnchor - currentAnchor).Days * DailyRate;

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    cmd.ExecuteNonQuery();
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

            LoadBookingsTable();
        }

        private void btnUpdatePrices_Click(object sender, EventArgs e)
        {
            UpdatePrices();
        }
    }
}
