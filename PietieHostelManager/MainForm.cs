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
                dgvRooms.Columns["Status"].Width = 140;
                dgvRooms.Columns["Type"].Width = 130;
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
                string paymentStatus = cmbPaymentStatus.Text;
                string occupancy = cmbOccupancy.Text;

                string sql = @"SELECT
                                   b.BookingID,
                                   r.RoomNumber AS [Room#],
                                   (g.FirstName + ' ' + g.LastName) AS [Full Name],
                                   g.PhoneNumber AS [Phone],
                                   g.Email,
                                   b.BookingDateStart AS [Start Date]
                                   b.BookingDateEnd AS [End Date],
                                   b.Price,
                                   b.TotalPrice,
                                   b.PaymentStatus,
                                   g.Occupancy
                               FROM Bookings b
                               INNER JOIN Rooms r ON b.RoomID = r.RoomID
                               INNER JOIN Guests g ON b.GuestID = g.GuestID
                               WHERE {searchCondition}
                                 AND (@StartDate IS NULL OR bBookingDateStart >= @StartDate)
                                 AND (@EndDate IS NULL OR bBookingDateEnd <= @EndDate)
                                 AND (@PaymentStatus IS NULL OR b.PaymentStatus = @PaymentStatus)
                                 AND (@Occupancy IS NULL OR g.Occupancy = @Occupancy);";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, conn);

                switch (cmbFilterBooking.SelectedIndex)
                {
                    case 1:
                        searchCondition = "CAST(b.BookingID AS VARCHAR) LIKE @SearchText";
                        break;
                    case 2:
                        searchCondition = "r.RoomNumber LIKE @SearchText";
                        break;
                    case 3:
                        searchCondition = "(g.FirstName + ' ' + g.LastName) LIKE %@SearchText%";
                        break;
                    case 4:
                        searchCondition = "g.PhoneNumber LIKE %@SearchText%";
                        break;
                    case 5:
                        searchCondition = "g.Email LIKE %@SearchText%";
                        break;
                    default:
                        searchCondition = "1=1";
                        break;
                }

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

                dgvRooms.Columns["BookingID"].Width = 80;
                dgvRooms.Columns["Room#"].Width = 80;
                dgvRooms.Columns["Full Name"].Width = 160;
                dgvRooms.Columns["Phone"].Width = 120;
                dgvRooms.Columns["Email"].Width = 240;
                dgvRooms.Columns["Start Date"].Width = 80;
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

        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            using (var createBooking = new CreateBooking())
            {
                createBooking.ShowDialog();
            }
        }

        private void buttonOpenAdmin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
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
    }
}
