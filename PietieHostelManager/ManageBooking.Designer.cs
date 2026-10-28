namespace PietieHostelManager
{
    partial class ManageBookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ManageFirstNameTextBox = new TextBox();
            ManageLastNameTextBox = new TextBox();
            ManagePhoneTextBox = new TextBox();
            ManageStartDateTimePicker = new DateTimePicker();
            ManageEndDateTimePicker = new DateTimePicker();
            ManageEmailTextBox = new TextBox();
            ManageTotalPriceTextBox = new TextBox();
            ManagePaymentStatusComboBox = new ComboBox();
            label6 = new Label();
            ManageNoPhoneCheckBox = new CheckBox();
            ManageNoEmailCheckBox = new CheckBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            ManageSearchGuestIDButton = new Button();
            ManageSearchGuestIDTextBox = new TextBox();
            ManageOccupancyComboBox = new ComboBox();
            occTextBox = new Label();
            ManageRoomLabel = new Label();
            label7 = new Label();
            UpdateBookingButton = new Button();
            CancelUpdateButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Manage User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 29);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 1;
            label2.Text = "Search by Guest ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 56);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 2;
            label3.Text = "First Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 83);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 3;
            label4.Text = "Last Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 110);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 4;
            label5.Text = "Phone Number:";
            // 
            // ManageFirstNameTextBox
            // 
            ManageFirstNameTextBox.Location = new Point(130, 53);
            ManageFirstNameTextBox.Margin = new Padding(3, 2, 3, 2);
            ManageFirstNameTextBox.Name = "ManageFirstNameTextBox";
            ManageFirstNameTextBox.Size = new Size(110, 23);
            ManageFirstNameTextBox.TabIndex = 6;
            // 
            // ManageLastNameTextBox
            // 
            ManageLastNameTextBox.Location = new Point(130, 80);
            ManageLastNameTextBox.Margin = new Padding(3, 2, 3, 2);
            ManageLastNameTextBox.Name = "ManageLastNameTextBox";
            ManageLastNameTextBox.Size = new Size(110, 23);
            ManageLastNameTextBox.TabIndex = 7;
            // 
            // ManagePhoneTextBox
            // 
            ManagePhoneTextBox.Location = new Point(130, 107);
            ManagePhoneTextBox.Margin = new Padding(3, 2, 3, 2);
            ManagePhoneTextBox.Name = "ManagePhoneTextBox";
            ManagePhoneTextBox.Size = new Size(110, 23);
            ManagePhoneTextBox.TabIndex = 8;
            // 
            // ManageStartDateTimePicker
            // 
            ManageStartDateTimePicker.CustomFormat = "yyyy-MM-dd";
            ManageStartDateTimePicker.Format = DateTimePickerFormat.Custom;
            ManageStartDateTimePicker.Location = new Point(130, 242);
            ManageStartDateTimePicker.Margin = new Padding(3, 2, 3, 2);
            ManageStartDateTimePicker.Name = "ManageStartDateTimePicker";
            ManageStartDateTimePicker.Size = new Size(110, 23);
            ManageStartDateTimePicker.TabIndex = 10;
            ManageStartDateTimePicker.ValueChanged += ManageStartDateTimePicker_ValueChanged;
            // 
            // ManageEndDateTimePicker
            // 
            ManageEndDateTimePicker.CustomFormat = "yyyy-MM-dd";
            ManageEndDateTimePicker.Format = DateTimePickerFormat.Custom;
            ManageEndDateTimePicker.Location = new Point(130, 269);
            ManageEndDateTimePicker.Margin = new Padding(3, 2, 3, 2);
            ManageEndDateTimePicker.Name = "ManageEndDateTimePicker";
            ManageEndDateTimePicker.Size = new Size(110, 23);
            ManageEndDateTimePicker.TabIndex = 11;
            ManageEndDateTimePicker.ValueChanged += ManageEndDateTimePicker_ValueChanged;
            // 
            // ManageEmailTextBox
            // 
            ManageEmailTextBox.Location = new Point(130, 134);
            ManageEmailTextBox.Margin = new Padding(3, 2, 3, 2);
            ManageEmailTextBox.Name = "ManageEmailTextBox";
            ManageEmailTextBox.Size = new Size(110, 23);
            ManageEmailTextBox.TabIndex = 12;
            // 
            // ManageTotalPriceTextBox
            // 
            ManageTotalPriceTextBox.Location = new Point(130, 296);
            ManageTotalPriceTextBox.Margin = new Padding(3, 2, 3, 2);
            ManageTotalPriceTextBox.Name = "ManageTotalPriceTextBox";
            ManageTotalPriceTextBox.ReadOnly = true;
            ManageTotalPriceTextBox.Size = new Size(110, 23);
            ManageTotalPriceTextBox.TabIndex = 13;
            // 
            // ManagePaymentStatusComboBox
            // 
            ManagePaymentStatusComboBox.FormattingEnabled = true;
            ManagePaymentStatusComboBox.Items.AddRange(new object[] { "Paid", "Cancelled" });
            ManagePaymentStatusComboBox.Location = new Point(130, 323);
            ManagePaymentStatusComboBox.Margin = new Padding(3, 2, 3, 2);
            ManagePaymentStatusComboBox.Name = "ManagePaymentStatusComboBox";
            ManagePaymentStatusComboBox.Size = new Size(110, 23);
            ManagePaymentStatusComboBox.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 137);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 17;
            label6.Text = "Email Address:";
            // 
            // ManageNoPhoneCheckBox
            // 
            ManageNoPhoneCheckBox.AutoSize = true;
            ManageNoPhoneCheckBox.Location = new Point(244, 97);
            ManageNoPhoneCheckBox.Margin = new Padding(3, 2, 3, 2);
            ManageNoPhoneCheckBox.Name = "ManageNoPhoneCheckBox";
            ManageNoPhoneCheckBox.Size = new Size(126, 19);
            ManageNoPhoneCheckBox.TabIndex = 19;
            ManageNoPhoneCheckBox.Text = "No Phone Number";
            ManageNoPhoneCheckBox.UseVisualStyleBackColor = true;
            ManageNoPhoneCheckBox.CheckedChanged += ManagePhoneCheckBox_CheckedChanged;
            // 
            // ManageNoEmailCheckBox
            // 
            ManageNoEmailCheckBox.AutoSize = true;
            ManageNoEmailCheckBox.Location = new Point(244, 122);
            ManageNoEmailCheckBox.Margin = new Padding(3, 2, 3, 2);
            ManageNoEmailCheckBox.Name = "ManageNoEmailCheckBox";
            ManageNoEmailCheckBox.Size = new Size(119, 19);
            ManageNoEmailCheckBox.TabIndex = 20;
            ManageNoEmailCheckBox.Text = "No Email Address";
            ManageNoEmailCheckBox.UseVisualStyleBackColor = true;
            ManageNoEmailCheckBox.CheckedChanged += ManageEmailCheckBox_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 248);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 21;
            label8.Text = "Start Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 275);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 22;
            label9.Text = "End Date:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 299);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 23;
            label10.Text = "Price: (R)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 326);
            label11.Name = "label11";
            label11.Size = new Size(92, 15);
            label11.TabIndex = 24;
            label11.Text = "Payment Status:";
            // 
            // ManageSearchGuestIDButton
            // 
            ManageSearchGuestIDButton.Location = new Point(251, 29);
            ManageSearchGuestIDButton.Margin = new Padding(3, 2, 3, 2);
            ManageSearchGuestIDButton.Name = "ManageSearchGuestIDButton";
            ManageSearchGuestIDButton.Size = new Size(82, 22);
            ManageSearchGuestIDButton.TabIndex = 25;
            ManageSearchGuestIDButton.Text = "Search";
            ManageSearchGuestIDButton.UseVisualStyleBackColor = true;
            ManageSearchGuestIDButton.Click += SearchGuestIDButton_Click;
            // 
            // ManageSearchGuestIDTextBox
            // 
            ManageSearchGuestIDTextBox.Location = new Point(130, 26);
            ManageSearchGuestIDTextBox.Margin = new Padding(3, 2, 3, 2);
            ManageSearchGuestIDTextBox.Name = "ManageSearchGuestIDTextBox";
            ManageSearchGuestIDTextBox.Size = new Size(110, 23);
            ManageSearchGuestIDTextBox.TabIndex = 26;
            // 
            // ManageOccupancyComboBox
            // 
            ManageOccupancyComboBox.FormattingEnabled = true;
            ManageOccupancyComboBox.Items.AddRange(new object[] { "Checked In", "Checked Out", "Pending", "Cancelled" });
            ManageOccupancyComboBox.Location = new Point(130, 350);
            ManageOccupancyComboBox.Margin = new Padding(3, 2, 3, 2);
            ManageOccupancyComboBox.Name = "ManageOccupancyComboBox";
            ManageOccupancyComboBox.Size = new Size(110, 23);
            ManageOccupancyComboBox.TabIndex = 27;
            // 
            // occTextBox
            // 
            occTextBox.AutoSize = true;
            occTextBox.Location = new Point(10, 353);
            occTextBox.Name = "occTextBox";
            occTextBox.Size = new Size(70, 15);
            occTextBox.TabIndex = 28;
            occTextBox.Text = "Occupancy:";
            // 
            // ManageRoomLabel
            // 
            ManageRoomLabel.AutoSize = true;
            ManageRoomLabel.Location = new Point(251, 56);
            ManageRoomLabel.Name = "ManageRoomLabel";
            ManageRoomLabel.Size = new Size(112, 15);
            ManageRoomLabel.TabIndex = 29;
            ManageRoomLabel.Text = "Room: Not Selected";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(10, 213);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 30;
            label7.Text = "Manage Booking";
            // 
            // UpdateBookingButton
            // 
            UpdateBookingButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateBookingButton.Location = new Point(10, 393);
            UpdateBookingButton.Margin = new Padding(3, 2, 3, 2);
            UpdateBookingButton.Name = "UpdateBookingButton";
            UpdateBookingButton.Size = new Size(124, 22);
            UpdateBookingButton.TabIndex = 31;
            UpdateBookingButton.Text = "Update Booking";
            UpdateBookingButton.UseVisualStyleBackColor = true;
            UpdateBookingButton.Click += UpdateBookingButton_Click;
            // 
            // CancelUpdateButton
            // 
            CancelUpdateButton.BackColor = Color.OrangeRed;
            CancelUpdateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelUpdateButton.ForeColor = Color.White;
            CancelUpdateButton.Location = new Point(239, 393);
            CancelUpdateButton.Margin = new Padding(3, 2, 3, 2);
            CancelUpdateButton.Name = "CancelUpdateButton";
            CancelUpdateButton.Size = new Size(124, 22);
            CancelUpdateButton.TabIndex = 32;
            CancelUpdateButton.Text = "Cancel";
            CancelUpdateButton.UseVisualStyleBackColor = false;
            CancelUpdateButton.Click += CancelUpdateButton_Click;
            // 
            // ManageBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 426);
            Controls.Add(CancelUpdateButton);
            Controls.Add(UpdateBookingButton);
            Controls.Add(label7);
            Controls.Add(ManageRoomLabel);
            Controls.Add(occTextBox);
            Controls.Add(ManageOccupancyComboBox);
            Controls.Add(ManageSearchGuestIDTextBox);
            Controls.Add(ManageSearchGuestIDButton);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(ManageNoEmailCheckBox);
            Controls.Add(ManageNoPhoneCheckBox);
            Controls.Add(label6);
            Controls.Add(ManagePaymentStatusComboBox);
            Controls.Add(ManageTotalPriceTextBox);
            Controls.Add(ManageEmailTextBox);
            Controls.Add(ManageEndDateTimePicker);
            Controls.Add(ManageStartDateTimePicker);
            Controls.Add(ManagePhoneTextBox);
            Controls.Add(ManageLastNameTextBox);
            Controls.Add(ManageFirstNameTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageBookingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Guest and Booking";
            FormClosing += ManageBookingForm_FormClosing;
            Load += ManageBookingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private MaskedTextBox maskedTextBox1;
        private TextBox ManageFirstNameTextBox;
        private TextBox ManageLastNameTextBox;
        private TextBox ManagePhoneTextBox;
        private DateTimePicker ManageStartDateTimePicker;
        private DateTimePicker ManageEndDateTimePicker;
        private TextBox ManageEmailTextBox;
        private TextBox ManageTotalPriceTextBox;
        private ComboBox ManagePaymentStatusComboBox;
        private Label label6;
        private CheckBox ManageNoPhoneCheckBox;
        private CheckBox ManageNoEmailCheckBox;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button ManageSearchGuestIDButton;
        private TextBox ManageSearchGuestIDTextBox;
        private ComboBox ManageOccupancyComboBox;
        private Label occTextBox;
        private Label ManageRoomLabel;
        private Label label7;
        private Button UpdateBookingButton;
        private Button CancelUpdateButton;
    }
}