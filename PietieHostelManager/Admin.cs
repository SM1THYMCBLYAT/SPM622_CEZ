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
using System.Linq;

namespace PietieHostelManager
{
    public partial class Admin : Form
    {

        private readonly string connectionString =
            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";
        private string? selectedUsername = null;
        private int? selectedRoomID = null;
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
                CASE
                    WHEN r.Status = 'Unavailable' THEN 'Unavailable'
                    WHEN COUNT(g.GuestID) = 0 THEN 'Vacant'
                    WHEN COUNT(g.GuestID) >= rt.Capacity THEN 'Full'
                    ELSE 'Occupied'
                END AS [Status],
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

                    AdminRoomsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    AdminRoomsDataGridView.MultiSelect = false;
                    AdminRoomsDataGridView.ReadOnly = true;
                    AdminRoomsDataGridView.AllowUserToAddRows = false;
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

        private void UpdateRoomTypeFilter()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Type FROM RoomTypes ORDER BY Type";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();

                        FilterRoomTypeComboBox.Items.Clear();
                        FilterRoomTypeComboBox.Items.Add("");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FilterRoomTypeComboBox.Items.Add(reader["Type"].ToString());
                            }
                        }
                    }
                }

                FilterRoomStatusComboBox.Items.Clear();
                FilterRoomStatusComboBox.Items.Add("");
                FilterRoomStatusComboBox.Items.Add("Vacant");
                FilterRoomStatusComboBox.Items.Add("Occupied");
                FilterRoomStatusComboBox.Items.Add("Full");
                FilterRoomStatusComboBox.Items.Add("Unavailable");

                FilterRoomTypeComboBox.SelectedIndex = 0;
                FilterRoomStatusComboBox.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Database Error:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyRoomFilters()
        {
            if (AdminRoomsDataGridView.DataSource is DataTable table)
            {
                List<string> filters = new List<string>();

                string selectedType = FilterRoomTypeComboBox.Text;
                string selectedStatus = FilterRoomStatusComboBox.Text;

                if (!string.IsNullOrWhiteSpace(selectedType))
                {
                    string safeType = selectedType.Replace("'", "''");
                    filters.Add($"[Room Type] = '{safeType}'");
                }

                if (!string.IsNullOrWhiteSpace(selectedStatus))
                {
                    string safeStatus = selectedStatus.Replace("'", "''");
                    filters.Add($"[Status] = '{safeStatus}'");
                }

                table.DefaultView.RowFilter = string.Join(" AND ", filters);
            }
        }

        private void LoadAuditLog()
        {
            try
            {
                string sql = @"
            SELECT
                AuditID AS [Audit ID],
                Username AS [Username],
                RecordType AS [Record Type],
                QueryDate AS [Query Date],
                Details AS [Details]
            FROM AuditLog
            ORDER BY AuditID DESC;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    AdminAuditLogDataGridView.DataSource = table;

                    AdminAuditLogDataGridView.ReadOnly = true;
                    AdminAuditLogDataGridView.AllowUserToAddRows = false;
                    AdminAuditLogDataGridView.AllowUserToDeleteRows = false;
                    AdminAuditLogDataGridView.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;
                    AdminAuditLogDataGridView.MultiSelect = false;
                    AdminAuditLogDataGridView.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load the audit log.\n\n" + ex.Message,
                    "Audit Log Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void Admin_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadRooms();
            UpdateRoomTypeFilter();
            LoadAuditLog();
        }

        private void AdminRoomsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminRoomsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (AdminRoomsDataGridView.SelectedRows.Count > 0)
            {
                object? value = AdminRoomsDataGridView
                    .SelectedRows[0]
                    .Cells["Room ID"].Value;

                if (value != null && value != DBNull.Value)
                {
                    selectedRoomID = Convert.ToInt32(value);
                }
                else
                {
                    selectedRoomID = null;
                }
            }
            else
            {
                selectedRoomID = null;
            }
        }
        private void AdminAddRoomButton_Click(object sender, EventArgs e)
        {
            string roomNumberInput = Interaction.InputBox(
                "Enter the new room number:",
                "Add Room",
                "");

            if (string.IsNullOrWhiteSpace(roomNumberInput))
                return;

            if (!int.TryParse(roomNumberInput, out int roomNumber) ||
                roomNumber <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive room number.",
                    "Invalid Room Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string typeQuery = @"
        SELECT Type, Capacity
        FROM RoomTypes
        ORDER BY Type;";

            var roomTypes = new List<(string Type, int Capacity)>();

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(typeQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add((
                                reader["Type"].ToString()!,
                                Convert.ToInt32(reader["Capacity"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load room types: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (roomTypes.Count == 0)
            {
                MessageBox.Show(
                    "No room types exist yet. Please create a room type first.",
                    "No Room Types",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string typeOptions = string.Join(
                Environment.NewLine,
                roomTypes.Select(t => $"{t.Type} (capacity: {t.Capacity})"));

            string selectedTypeInput = Interaction.InputBox(
                "Available room types:" + Environment.NewLine +
                typeOptions + Environment.NewLine + Environment.NewLine +
                "Enter the room type:",
                "Select Room Type",
                "");

            if (string.IsNullOrWhiteSpace(selectedTypeInput))
                return;

            var matchingType = roomTypes.FirstOrDefault(
                t => t.Type.Equals(
                    selectedTypeInput.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (matchingType.Type == null)
            {
                MessageBox.Show(
                    "Please enter one of the listed room types.",
                    "Invalid Room Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Create this room?" + Environment.NewLine +
                Environment.NewLine +
                $"Room Number: {roomNumber}" + Environment.NewLine +
                $"Room Type: {matchingType.Type}" + Environment.NewLine +
                $"Maximum Capacity: {matchingType.Capacity}" +
                Environment.NewLine +
                "Initial Status: Vacant",
                "Confirm Room Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            string insertQuery = @"
        INSERT INTO Rooms (RoomNumber, Type, Status)
        OUTPUT INSERTED.RoomID
        VALUES (@RoomNumber, @Type, @Status);";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    command.Parameters.AddWithValue("@Type", matchingType.Type);
                    command.Parameters.AddWithValue("@Status", "Vacant");

                    connection.Open();

                    int newRoomID = Convert.ToInt32(command.ExecuteScalar());
                    AuditLogger.LogAction(
                        "Rooms",
                        newRoomID,
                        $"Created room {roomNumber}");
                }

                MessageBox.Show(
                    "Room created successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                selectedRoomID = null;
                LoadRooms();
                LoadAuditLog();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "The room could not be created because it violates " +
                        "a database constraint. Check the selected room type " +
                        "and the room details." + Environment.NewLine +
                        Environment.NewLine + ex.Message,
                        "Database Constraint",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Failed to create room: " + ex.Message,
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

        private void AdminEditRoomButton_Click(object sender, EventArgs e)
        {
            if (selectedRoomID == null)
            {
                MessageBox.Show(
                    "Please select a room to edit.",
                    "No Room Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int roomId = selectedRoomID.Value;
            int currentRoomNumber;
            string currentType;
            string currentStatus;
            int currentOccupants;

            string selectQuery = @"
        SELECT
            r.RoomNumber,
            r.Type,
            r.Status,
            COUNT(g.GuestID) AS Occupants
        FROM Rooms r
        LEFT JOIN Bookings b ON r.RoomID = b.RoomID
        LEFT JOIN Guests g
            ON b.GuestID = g.GuestID
            AND g.Occupancy = 'Checked In'
        WHERE r.RoomID = @RoomID
        GROUP BY r.RoomNumber, r.Type, r.Status;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "The selected room could not be found.",
                                "Room Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            selectedRoomID = null;
                            LoadRooms();
                            return;
                        }

                        currentRoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                        currentType = reader["Type"].ToString()!;
                        currentStatus = reader["Status"].ToString()!;
                        currentOccupants = Convert.ToInt32(reader["Occupants"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to retrieve room details: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string roomNumberInput = Interaction.InputBox(
                "Enter the room number:",
                "Edit Room",
                currentRoomNumber.ToString());

            if (string.IsNullOrWhiteSpace(roomNumberInput))
                return;

            if (!int.TryParse(roomNumberInput, out int roomNumber) ||
                roomNumber <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive room number.",
                    "Invalid Room Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string typeQuery = @"
        SELECT Type, Capacity
        FROM RoomTypes
        ORDER BY Type;";

            var roomTypes = new List<(string Type, int Capacity)>();

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(typeQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add((
                                reader["Type"].ToString()!,
                                Convert.ToInt32(reader["Capacity"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load room types: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (roomTypes.Count == 0)
            {
                MessageBox.Show(
                    "Create a room type before editing this room.",
                    "No Room Types",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string typeOptions = string.Join(
                ", ",
                roomTypes.Select(t => $"{t.Type} (capacity {t.Capacity})"));

            string newType = Interaction.InputBox(
                $"Available room types: {typeOptions}\nEnter the room type:",
                "Edit Room Type",
                currentType);

            if (string.IsNullOrWhiteSpace(newType))
                return;

            var matchingType = roomTypes.FirstOrDefault(
                t => t.Type.Equals(
                    newType.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (matchingType.Type == null)
            {
                MessageBox.Show(
                    "Please enter one of the available room types.",
                    "Invalid Room Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (matchingType.Capacity < currentOccupants)
            {
                MessageBox.Show(
                    $"This room currently has {currentOccupants} checked-in guest(s), " +
                    $"but the selected room type only accommodates " +
                    $"{matchingType.Capacity} guest(s).\n\n" +
                    "Choose a room type with sufficient capacity.",
                    "Insufficient Room Capacity",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Save changes to Room ID {roomId}?\n\n" +
                $"Room Number: {roomNumber}\n" +
                $"Room Type: {matchingType.Type}\n" +
                $"Current Occupants: {currentOccupants}\n" +
                $"Maximum Capacity: {matchingType.Capacity}",
                "Confirm Room Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            string updateQuery = @"
        UPDATE Rooms
        SET RoomNumber = @RoomNumber,
            Type = @Type
        WHERE RoomID = @RoomID;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    command.Parameters.AddWithValue("@Type", matchingType.Type);
                    command.Parameters.AddWithValue("@RoomID", roomId);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        List<string> changes = new List<string>();

                        if (currentRoomNumber != roomNumber)
                        {
                            changes.Add(
                                $"room number changed from {currentRoomNumber} to {roomNumber}");
                        }

                        if (!currentType.Equals(
                            matchingType.Type,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            changes.Add(
                                $"room type changed from {currentType} to {matchingType.Type}");
                        }

                        if (changes.Count > 0)
                        {
                            string details =
                                $"Room ID {roomId}: " +
                                string.Join("; ", changes) + ".";

                            AuditLogger.LogAction(
                                "Rooms",
                                roomId,
                                details);

                            LoadAuditLog();
                        }

                        MessageBox.Show(
                            changes.Count > 0
                                ? "Room updated and audit log recorded successfully."
                                : "No changes were made to the room.",
                            "Room Update",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadRooms();
                    }

                    else
                    {
                        MessageBox.Show(
                            "The room could not be updated.",
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        selectedRoomID = null;
                        LoadRooms();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Failed to update room: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void AdminDeleteRoomButton_Click(object sender, EventArgs e)
        {
            if (selectedRoomID == null)
            {
                MessageBox.Show(
                    "Please select a room to delete.",
                    "No Room Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int roomId = selectedRoomID.Value;
            int roomNumber;
            string roomType;

            // Retrieve the room details before deleting it.
            string selectQuery = @"
        SELECT RoomNumber, Type
        FROM Rooms
        WHERE RoomID = @RoomID;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "The selected room could not be found.",
                                "Room Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            selectedRoomID = null;
                            LoadRooms();
                            return;
                        }

                        roomNumber = Convert.ToInt32(reader["RoomNumber"]);
                        roomType = reader["Type"].ToString()!;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to retrieve room details: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete this room?\n\n" +
                $"Room ID: {roomId}\n" +
                $"Room Number: {roomNumber}\n" +
                $"Room Type: {roomType}",
                "Confirm Room Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string deleteQuery =
                "DELETE FROM Rooms WHERE RoomID = @RoomID;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Log only after the deletion succeeds.
                        AuditLogger.LogAction(
                            "Rooms",
                            roomId,
                            $"Room ID {roomId}: Deleted room {roomNumber} " +
                            $"(Type: {roomType}).");

                        LoadAuditLog();

                        MessageBox.Show(
                            "Room deleted and audit log recorded successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        selectedRoomID = null;
                        LoadRooms();
                    }
                    else
                    {
                        MessageBox.Show(
                            "The selected room could not be found.",
                            "Room Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        selectedRoomID = null;
                        LoadRooms();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "This room cannot be deleted because it is referenced " +
                        "by existing bookings. Remove or resolve those bookings first.",
                        "Room Has Bookings",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Failed to delete room: " + ex.Message,
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



        private void AdminAddRoomTypeButton_Click(object sender, EventArgs e)
        {
            string type = Interaction.InputBox(
                "Enter the new room type name:",
                "Add Room Type",
                "").Trim();

            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show(
                    "Room type name cannot be empty.",
                    "Invalid Room Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (type.Length > 100)
            {
                MessageBox.Show(
                    "Room type name cannot exceed 100 characters.",
                    "Invalid Room Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string capacityInput = Interaction.InputBox(
                "Enter the maximum number of guests for this room type:",
                "Add Room Type",
                "");

            if (string.IsNullOrWhiteSpace(capacityInput))
                return;

            if (!int.TryParse(capacityInput, out int capacity) ||
                capacity <= 0)
            {
                MessageBox.Show(
                    "Capacity must be a positive whole number.",
                    "Invalid Capacity",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show(
                $"Create this room type?\n\n" +
                $"Type: {type}\n" +
                $"Maximum Capacity: {capacity}",
                "Confirm Room Type Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
                return;

            string query = @"
        INSERT INTO RoomTypes (Type, Capacity)
        VALUES (@Type, @Capacity);";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Capacity", capacity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Room type created successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        "This room type already exists. Please use a different name.",
                        "Duplicate Room Type",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Failed to create room type: " + ex.Message,
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

        private void AdminEditRoomTypeButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    List<(string Type, int Capacity)> roomTypes =
                        new List<(string Type, int Capacity)>();

                    string selectQuery =
                        "SELECT Type, Capacity FROM RoomTypes ORDER BY Type;";

                    using (SqlCommand command =
                           new SqlCommand(selectQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add((
                                reader.GetString(0),
                                reader.GetInt32(1)));
                        }
                    }

                    if (roomTypes.Count == 0)
                    {
                        MessageBox.Show(
                            "There are no room types to edit.",
                            "Edit Room Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    string availableTypes = string.Join(
                        Environment.NewLine,
                        roomTypes.Select(t => $"{t.Type} (Capacity: {t.Capacity})"));

                    string oldType = Interaction.InputBox(
                        "Enter the exact room type you want to edit:\n\n" +
                        availableTypes,
                        "Select Room Type",
                        "").Trim();

                    if (string.IsNullOrWhiteSpace(oldType))
                        return;

                    var selectedType = roomTypes.FirstOrDefault(
                        t => string.Equals(
                            t.Type,
                            oldType,
                            StringComparison.OrdinalIgnoreCase));

                    if (selectedType.Type == null)
                    {
                        MessageBox.Show(
                            "The specified room type was not found.",
                            "Room Type Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    oldType = selectedType.Type;

                    string newType = Interaction.InputBox(
                        "Enter the new room type name:",
                        "Edit Room Type",
                        oldType).Trim();

                    if (string.IsNullOrWhiteSpace(newType))
                    {
                        MessageBox.Show(
                            "Room type name cannot be empty.",
                            "Invalid Room Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    if (newType.Length > 100)
                    {
                        MessageBox.Show(
                            "Room type name cannot exceed 100 characters.",
                            "Invalid Room Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    string capacityInput = Interaction.InputBox(
                        "Enter the new maximum capacity:",
                        "Edit Room Type",
                        selectedType.Capacity.ToString());

                    if (string.IsNullOrWhiteSpace(capacityInput))
                        return;

                    if (!int.TryParse(capacityInput, out int newCapacity) ||
                        newCapacity <= 0)
                    {
                        MessageBox.Show(
                            "Capacity must be a positive whole number.",
                            "Invalid Capacity",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    string occupancyQuery = @"
                SELECT r.RoomNumber, COUNT(g.GuestID) AS Occupants
                FROM Rooms r
                LEFT JOIN Bookings b ON r.RoomID = b.RoomID
                LEFT JOIN Guests g
                    ON b.GuestID = g.GuestID
                    AND g.Occupancy = 'Checked In'
                WHERE r.Type = @Type
                GROUP BY r.RoomID, r.RoomNumber;";

                    using (SqlCommand command =
                           new SqlCommand(occupancyQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Type", oldType);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int roomNumber = reader.GetInt32(0);
                                int occupants = reader.GetInt32(1);

                                if (newCapacity < occupants)
                                {
                                    MessageBox.Show(
                                        $"Cannot set capacity to {newCapacity}.\n\n" +
                                        $"Room {roomNumber} currently has " +
                                        $"{occupants} checked-in guest(s).\n" +
                                        "The new capacity cannot be lower than " +
                                        "the current occupancy of any room.",
                                        "Capacity Too Low",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }

                    DialogResult confirmation = MessageBox.Show(
                        $"Save these room type changes?\n\n" +
                        $"Current name: {oldType}\n" +
                        $"New name: {newType}\n" +
                        $"Current capacity: {selectedType.Capacity}\n" +
                        $"New capacity: {newCapacity}",
                        "Confirm Room Type Changes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmation != DialogResult.Yes)
                        return;

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (!string.Equals(oldType, newType, StringComparison.Ordinal))
                            {
                                string updateRoomsQuery =
                                    "UPDATE Rooms SET Type = @NewType WHERE Type = @OldType;";

                                using (SqlCommand command = new SqlCommand(
                                    updateRoomsQuery, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@NewType", newType);
                                    command.Parameters.AddWithValue("@OldType", oldType);
                                    command.ExecuteNonQuery();
                                }
                            }

                            string updateTypeQuery = @"
                        UPDATE RoomTypes
                        SET Type = @NewType, Capacity = @Capacity
                        WHERE Type = @OldType;";

                            using (SqlCommand command = new SqlCommand(
                                updateTypeQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@NewType", newType);
                                command.Parameters.AddWithValue("@Capacity", newCapacity);
                                command.Parameters.AddWithValue("@OldType", oldType);

                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                    throw new InvalidOperationException(
                                        "The room type no longer exists.");
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    LoadRooms();

                    MessageBox.Show(
                        "Room type updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        MessageBox.Show(
                            "A room type with that name already exists.",
                            "Duplicate Room Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to update room type: " + ex.Message,
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
        }



        private void AdminDeleteRoomTypeButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 1. Load existing room types.
                    List<string> roomTypes = new List<string>();

                    string selectQuery =
                        "SELECT Type FROM RoomTypes ORDER BY Type;";

                    using (SqlCommand command =
                           new SqlCommand(selectQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomTypes.Add(reader.GetString(0));
                        }
                    }

                    if (roomTypes.Count == 0)
                    {
                        MessageBox.Show(
                            "There are no room types to delete.",
                            "Delete Room Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    // 2. Let the administrator select a room type.
                    string availableTypes = string.Join(
                        Environment.NewLine,
                        roomTypes);

                    string selectedType = Interaction.InputBox(
                        "Enter the exact room type you want to delete:\n\n" +
                        availableTypes,
                        "Select Room Type",
                        "").Trim();

                    if (string.IsNullOrWhiteSpace(selectedType))
                        return;

                    string matchingType = roomTypes.FirstOrDefault(
                        type => string.Equals(
                            type,
                            selectedType,
                            StringComparison.OrdinalIgnoreCase));

                    if (matchingType == null)
                    {
                        MessageBox.Show(
                            "The specified room type was not found.",
                            "Room Type Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    selectedType = matchingType;

                    // 3. Prevent deletion if any rooms use this type.
                    string checkQuery =
                        "SELECT COUNT(*) FROM Rooms WHERE Type = @Type;";

                    using (SqlCommand command =
                           new SqlCommand(checkQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Type", selectedType);

                        int roomCount = (int)command.ExecuteScalar();

                        if (roomCount > 0)
                        {
                            MessageBox.Show(
                                $"Cannot delete room type '{selectedType}'.\n\n" +
                                $"{roomCount} room(s) currently use this type. " +
                                "Change or remove those rooms before deleting the type.",
                                "Room Type In Use",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 4. Confirm deletion.
                    DialogResult confirmation = MessageBox.Show(
                        $"Are you sure you want to delete room type " +
                        $"'{selectedType}'?\n\nThis action cannot be undone.",
                        "Confirm Room Type Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmation != DialogResult.Yes)
                        return;

                    // 5. Delete the unused room type.
                    string deleteQuery =
                        "DELETE FROM RoomTypes WHERE Type = @Type;";

                    using (SqlCommand command =
                           new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Type", selectedType);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "The room type no longer exists.",
                                "Delete Room Type",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    MessageBox.Show(
                        "Room type deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show(
                            "This room type is still referenced by other records " +
                            "and cannot be deleted.",
                            "Room Type In Use",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to delete room type: " + ex.Message,
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

        private void FilterRoomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomFilters();
        }

        private void FilterRoomStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomFilters();
        }

        private void AdminAuditLogDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
