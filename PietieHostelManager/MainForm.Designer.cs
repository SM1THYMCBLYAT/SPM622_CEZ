namespace PietieHostelManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            btnManageBooking = new Button();
            imageList1 = new ImageList(components);
            btnCreateBooking = new Button();
            button1 = new Button();
            dtpBefore = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            dtpAfter = new DateTimePicker();
            label6 = new Label();
            buttonOpenAdmin = new Button();
            btnSignOut = new Button();
            panel4 = new Panel();
            lblUsername = new Label();
            panel2 = new Panel();
            btnShowAllRooms = new Button();
            label2 = new Label();
            label1 = new Label();
            cmbRoomType = new ComboBox();
            cmbRoomStatus = new ComboBox();
            dgvRooms = new DataGridView();
            panel3 = new Panel();
            btnShowAllBookings = new Button();
            btnSearchBookings = new Button();
            imageList2 = new ImageList(components);
            txtSearchBox = new TextBox();
            label5 = new Label();
            cmbFilterBooking = new ComboBox();
            label4 = new Label();
            cmbPaymentStatus = new ComboBox();
            label3 = new Label();
            cmbOccupancy = new ComboBox();
            dgvBookings = new DataGridView();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnManageBooking);
            panel1.Controls.Add(btnCreateBooking);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dtpBefore);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpAfter);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(buttonOpenAdmin);
            panel1.Controls.Add(btnSignOut);
            panel1.Controls.Add(panel4);
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1910, 206);
            panel1.TabIndex = 0;
            // 
            // btnManageBooking
            // 
            btnManageBooking.Font = new Font("Segoe UI", 11F);
            btnManageBooking.ImageAlign = ContentAlignment.TopCenter;
            btnManageBooking.ImageKey = "pngtree-vector-plus-icon-png-image_1024584.jpg";
            btnManageBooking.ImageList = imageList1;
            btnManageBooking.Location = new Point(220, 52);
            btnManageBooking.Name = "btnManageBooking";
            btnManageBooking.Size = new Size(133, 141);
            btnManageBooking.TabIndex = 11;
            btnManageBooking.Text = "Manage Guest/Booking";
            btnManageBooking.TextAlign = ContentAlignment.BottomCenter;
            btnManageBooking.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "347895.png");
            imageList1.Images.SetKeyName(1, "pngtree-vector-plus-icon-png-image_1024584.jpg");
            // 
            // btnCreateBooking
            // 
            btnCreateBooking.Font = new Font("Segoe UI", 11F);
            btnCreateBooking.ImageAlign = ContentAlignment.TopCenter;
            btnCreateBooking.ImageKey = "pngtree-vector-plus-icon-png-image_1024584.jpg";
            btnCreateBooking.ImageList = imageList1;
            btnCreateBooking.Location = new Point(37, 51);
            btnCreateBooking.Name = "btnCreateBooking";
            btnCreateBooking.Size = new Size(133, 141);
            btnCreateBooking.TabIndex = 10;
            btnCreateBooking.Text = "Add Guest/Booking";
            btnCreateBooking.TextAlign = ContentAlignment.BottomCenter;
            btnCreateBooking.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(707, 236);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // dtpBefore
            // 
            dtpBefore.CustomFormat = "yyyy-MM-dd";
            dtpBefore.Format = DateTimePickerFormat.Custom;
            dtpBefore.Location = new Point(457, 144);
            dtpBefore.Name = "dtpBefore";
            dtpBefore.ShowCheckBox = true;
            dtpBefore.Size = new Size(200, 23);
            dtpBefore.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(457, 122);
            label8.Name = "label8";
            label8.Size = new Size(51, 19);
            label8.TabIndex = 7;
            label8.Text = "Before:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(457, 52);
            label7.Name = "label7";
            label7.Size = new Size(42, 19);
            label7.TabIndex = 6;
            label7.Text = "After:";
            // 
            // dtpAfter
            // 
            dtpAfter.CustomFormat = "yyyy-MM-dd";
            dtpAfter.Format = DateTimePickerFormat.Custom;
            dtpAfter.Location = new Point(457, 74);
            dtpAfter.Name = "dtpAfter";
            dtpAfter.ShowCheckBox = true;
            dtpAfter.Size = new Size(200, 23);
            dtpAfter.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(457, 14);
            label6.Name = "label6";
            label6.Size = new Size(173, 20);
            label6.TabIndex = 3;
            label6.Text = "Filter bookings by date:";
            // 
            // buttonOpenAdmin
            // 
            buttonOpenAdmin.Font = new Font("Segoe UI", 12F);
            buttonOpenAdmin.ImageAlign = ContentAlignment.TopCenter;
            buttonOpenAdmin.ImageKey = "347895.png";
            buttonOpenAdmin.ImageList = imageList1;
            buttonOpenAdmin.Location = new Point(1750, 106);
            buttonOpenAdmin.Name = "buttonOpenAdmin";
            buttonOpenAdmin.Size = new Size(118, 86);
            buttonOpenAdmin.TabIndex = 2;
            buttonOpenAdmin.Text = "Admin Panel";
            buttonOpenAdmin.TextAlign = ContentAlignment.BottomCenter;
            buttonOpenAdmin.UseVisualStyleBackColor = true;
            buttonOpenAdmin.Click += buttonOpenAdmin_Click;
            // 
            // btnSignOut
            // 
            btnSignOut.Font = new Font("Segoe UI", 17F);
            btnSignOut.Location = new Point(1709, 50);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(200, 42);
            btnSignOut.TabIndex = 1;
            btnSignOut.Text = "Sign out";
            btnSignOut.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblUsername);
            panel4.Location = new Point(1709, -1);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 45);
            panel4.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUsername.Location = new Point(16, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(98, 25);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "HolyChris";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightCyan;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnShowAllRooms);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbRoomType);
            panel2.Controls.Add(cmbRoomStatus);
            panel2.Controls.Add(dgvRooms);
            panel2.Location = new Point(5, 217);
            panel2.Name = "panel2";
            panel2.Size = new Size(448, 833);
            panel2.TabIndex = 1;
            // 
            // btnShowAllRooms
            // 
            btnShowAllRooms.Font = new Font("Segoe UI", 11F);
            btnShowAllRooms.Location = new Point(359, 23);
            btnShowAllRooms.Name = "btnShowAllRooms";
            btnShowAllRooms.Size = new Size(84, 36);
            btnShowAllRooms.TabIndex = 12;
            btnShowAllRooms.Text = "Show All";
            btnShowAllRooms.UseVisualStyleBackColor = true;
            btnShowAllRooms.Click += btnShowAllRooms_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(176, 5);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 4;
            label2.Text = "Room Type:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(6, 5);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 3;
            label1.Text = "Room Status:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 16F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(176, 23);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(164, 38);
            cmbRoomType.TabIndex = 2;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // cmbRoomStatus
            // 
            cmbRoomStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomStatus.Font = new Font("Segoe UI", 16F);
            cmbRoomStatus.FormattingEnabled = true;
            cmbRoomStatus.Items.AddRange(new object[] { "", "Vacant", "Occupied", "Full", "Unavailable" });
            cmbRoomStatus.Location = new Point(6, 23);
            cmbRoomStatus.Name = "cmbRoomStatus";
            cmbRoomStatus.Size = new Size(164, 38);
            cmbRoomStatus.TabIndex = 1;
            cmbRoomStatus.SelectedIndexChanged += cmbRoomStatus_SelectedIndexChanged;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeColumns = false;
            dgvRooms.AllowUserToResizeRows = false;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(3, 61);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(440, 767);
            dgvRooms.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightCyan;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnShowAllBookings);
            panel3.Controls.Add(btnSearchBookings);
            panel3.Controls.Add(txtSearchBox);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(cmbFilterBooking);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(cmbPaymentStatus);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(cmbOccupancy);
            panel3.Controls.Add(dgvBookings);
            panel3.Location = new Point(459, 217);
            panel3.Name = "panel3";
            panel3.Size = new Size(1456, 833);
            panel3.TabIndex = 2;
            // 
            // btnShowAllBookings
            // 
            btnShowAllBookings.Font = new Font("Segoe UI", 11F);
            btnShowAllBookings.Location = new Point(1367, 23);
            btnShowAllBookings.Name = "btnShowAllBookings";
            btnShowAllBookings.Size = new Size(84, 36);
            btnShowAllBookings.TabIndex = 11;
            btnShowAllBookings.Text = "Show All";
            btnShowAllBookings.UseVisualStyleBackColor = true;
            // 
            // btnSearchBookings
            // 
            btnSearchBookings.ImageKey = "search-icon-png-5.png";
            btnSearchBookings.ImageList = imageList2;
            btnSearchBookings.Location = new Point(961, 23);
            btnSearchBookings.Name = "btnSearchBookings";
            btnSearchBookings.Size = new Size(40, 36);
            btnSearchBookings.TabIndex = 10;
            btnSearchBookings.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "search-icon-png-5.png");
            // 
            // txtSearchBox
            // 
            txtSearchBox.Font = new Font("Segoe UI", 16F);
            txtSearchBox.Location = new Point(209, 24);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(746, 36);
            txtSearchBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(17, 5);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 8;
            label5.Text = "Filter search by:";
            // 
            // cmbFilterBooking
            // 
            cmbFilterBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterBooking.Font = new Font("Segoe UI", 16F);
            cmbFilterBooking.FormattingEnabled = true;
            cmbFilterBooking.Items.AddRange(new object[] { "Booking ID", "Room Number", "Full Name", "Phone", "Email" });
            cmbFilterBooking.Location = new Point(17, 23);
            cmbFilterBooking.Name = "cmbFilterBooking";
            cmbFilterBooking.Size = new Size(176, 38);
            cmbFilterBooking.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(1021, 5);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 6;
            label4.Text = "Payment Status:";
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatus.Font = new Font("Segoe UI", 16F);
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Items.AddRange(new object[] { "", "Pending", "Paid" });
            cmbPaymentStatus.Location = new Point(1021, 23);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(164, 38);
            cmbPaymentStatus.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(1197, 5);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 4;
            label3.Text = "Guest Occupancy:";
            // 
            // cmbOccupancy
            // 
            cmbOccupancy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOccupancy.Font = new Font("Segoe UI", 16F);
            cmbOccupancy.FormattingEnabled = true;
            cmbOccupancy.Items.AddRange(new object[] { "", "Checked In", "Checked Out", "Pending", "Cancelled" });
            cmbOccupancy.Location = new Point(1197, 23);
            cmbOccupancy.Name = "cmbOccupancy";
            cmbOccupancy.Size = new Size(164, 38);
            cmbOccupancy.TabIndex = 3;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dgvBookings.AllowUserToResizeColumns = false;
            dgvBookings.AllowUserToResizeRows = false;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookings.Location = new Point(3, 61);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1448, 767);
            dgvBookings.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1924, 1061);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Hostel Manager";
            WindowState = FormWindowState.Maximized;
            FormClosed += MainForm_FormClosed;
            Shown += MainForm_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvRooms;
        private DataGridView dgvBookings;
        private Panel panel4;
        private Button buttonOpenAdmin;
        private Button btnSignOut;
        private Label lblUsername;
        private ImageList imageList1;
        private ComboBox cmbRoomType;
        private ComboBox cmbRoomStatus;
        private Label label1;
        private ComboBox cmbOccupancy;
        private Label label2;
        private Label label4;
        private ComboBox cmbPaymentStatus;
        private Label label3;
        private ComboBox cmbFilterBooking;
        private Button btnSearchBookings;
        private ImageList imageList2;
        private TextBox txtSearchBox;
        private Label label5;
        private DateTimePicker dtpBefore;
        private Label label8;
        private Label label7;
        private DateTimePicker dtpAfter;
        private Label label6;
        private Button btnShowAllRooms;
        private Button btnShowAllBookings;
        private Button btnManageBooking;
        private Button btnCreateBooking;
        private Button button1;
    }
}
