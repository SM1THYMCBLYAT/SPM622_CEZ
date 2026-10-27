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
            ManageBookingDataGridView = new DataGridView();
            ManageStartDateTimePicker = new DateTimePicker();
            ManageEndDateTimePicker = new DateTimePicker();
            ManageEmailTextBox = new TextBox();
            ManageTotalPriceTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            ManagePaymentStatusComboBox = new ComboBox();
            label6 = new Label();
            label7 = new Label();
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
            ((System.ComponentModel.ISupportInitialize)ManageBookingDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Manage User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 34);
            label2.Name = "label2";
            label2.Size = new Size(136, 20);
            label2.TabIndex = 1;
            label2.Text = "Search by Guest ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 2;
            label3.Text = "First Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 3;
            label4.Text = "Last Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 129);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 4;
            label5.Text = "Phone Number:";
            // 
            // ManageFirstNameTextBox
            // 
            ManageFirstNameTextBox.Location = new Point(148, 60);
            ManageFirstNameTextBox.Name = "ManageFirstNameTextBox";
            ManageFirstNameTextBox.Size = new Size(125, 27);
            ManageFirstNameTextBox.TabIndex = 6;
            // 
            // ManageLastNameTextBox
            // 
            ManageLastNameTextBox.Location = new Point(148, 93);
            ManageLastNameTextBox.Name = "ManageLastNameTextBox";
            ManageLastNameTextBox.Size = new Size(125, 27);
            ManageLastNameTextBox.TabIndex = 7;
            // 
            // ManagePhoneTextBox
            // 
            ManagePhoneTextBox.Location = new Point(148, 126);
            ManagePhoneTextBox.Name = "ManagePhoneTextBox";
            ManagePhoneTextBox.Size = new Size(125, 27);
            ManagePhoneTextBox.TabIndex = 8;
            // 
            // ManageBookingDataGridView
            // 
            ManageBookingDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ManageBookingDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ManageBookingDataGridView.Location = new Point(12, 225);
            ManageBookingDataGridView.Name = "ManageBookingDataGridView";
            ManageBookingDataGridView.RowHeadersWidth = 51;
            ManageBookingDataGridView.Size = new Size(768, 188);
            ManageBookingDataGridView.TabIndex = 9;
            // 
            // ManageStartDateTimePicker
            // 
            ManageStartDateTimePicker.Format = DateTimePickerFormat.Short;
            ManageStartDateTimePicker.Location = new Point(148, 419);
            ManageStartDateTimePicker.Name = "ManageStartDateTimePicker";
            ManageStartDateTimePicker.Size = new Size(125, 27);
            ManageStartDateTimePicker.TabIndex = 10;
            // 
            // ManageEndDateTimePicker
            // 
            ManageEndDateTimePicker.Format = DateTimePickerFormat.Short;
            ManageEndDateTimePicker.Location = new Point(148, 452);
            ManageEndDateTimePicker.Name = "ManageEndDateTimePicker";
            ManageEndDateTimePicker.Size = new Size(125, 27);
            ManageEndDateTimePicker.TabIndex = 11;
            // 
            // ManageEmailTextBox
            // 
            ManageEmailTextBox.Location = new Point(148, 159);
            ManageEmailTextBox.Name = "ManageEmailTextBox";
            ManageEmailTextBox.Size = new Size(125, 27);
            ManageEmailTextBox.TabIndex = 12;
            // 
            // ManageTotalPriceTextBox
            // 
            ManageTotalPriceTextBox.Location = new Point(148, 485);
            ManageTotalPriceTextBox.Name = "ManageTotalPriceTextBox";
            ManageTotalPriceTextBox.Size = new Size(125, 27);
            ManageTotalPriceTextBox.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(12, 612);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(112, 612);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 15;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // ManagePaymentStatusComboBox
            // 
            ManagePaymentStatusComboBox.FormattingEnabled = true;
            ManagePaymentStatusComboBox.Location = new Point(148, 518);
            ManagePaymentStatusComboBox.Name = "ManagePaymentStatusComboBox";
            ManagePaymentStatusComboBox.Size = new Size(125, 28);
            ManagePaymentStatusComboBox.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 162);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 17;
            label6.Text = "Email Address:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 202);
            label7.Name = "label7";
            label7.Size = new Size(127, 20);
            label7.TabIndex = 18;
            label7.Text = "Manage Booking";
            // 
            // ManageNoPhoneCheckBox
            // 
            ManageNoPhoneCheckBox.AutoSize = true;
            ManageNoPhoneCheckBox.Location = new Point(279, 129);
            ManageNoPhoneCheckBox.Name = "ManageNoPhoneCheckBox";
            ManageNoPhoneCheckBox.Size = new Size(154, 24);
            ManageNoPhoneCheckBox.TabIndex = 19;
            ManageNoPhoneCheckBox.Text = "No Phone Number";
            ManageNoPhoneCheckBox.UseVisualStyleBackColor = true;
            ManageNoPhoneCheckBox.CheckedChanged += ManagePhoneCheckBox_CheckedChanged;
            // 
            // ManageNoEmailCheckBox
            // 
            ManageNoEmailCheckBox.AutoSize = true;
            ManageNoEmailCheckBox.Location = new Point(279, 162);
            ManageNoEmailCheckBox.Name = "ManageNoEmailCheckBox";
            ManageNoEmailCheckBox.Size = new Size(149, 24);
            ManageNoEmailCheckBox.TabIndex = 20;
            ManageNoEmailCheckBox.Text = "No Email Address";
            ManageNoEmailCheckBox.UseVisualStyleBackColor = true;
            ManageNoEmailCheckBox.CheckedChanged += ManageEmailCheckBox_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 424);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 21;
            label8.Text = "Start Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 457);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 22;
            label9.Text = "End Date:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 488);
            label10.Name = "label10";
            label10.Size = new Size(67, 20);
            label10.TabIndex = 23;
            label10.Text = "Price: (R)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 521);
            label11.Name = "label11";
            label11.Size = new Size(112, 20);
            label11.TabIndex = 24;
            label11.Text = "Payment Status:";
            // 
            // ManageSearchGuestIDButton
            // 
            ManageSearchGuestIDButton.Location = new Point(279, 27);
            ManageSearchGuestIDButton.Name = "ManageSearchGuestIDButton";
            ManageSearchGuestIDButton.Size = new Size(94, 29);
            ManageSearchGuestIDButton.TabIndex = 25;
            ManageSearchGuestIDButton.Text = "Search";
            ManageSearchGuestIDButton.UseVisualStyleBackColor = true;
            ManageSearchGuestIDButton.Click += SearchGuestIDButton_Click;
            // 
            // ManageSearchGuestIDTextBox
            // 
            ManageSearchGuestIDTextBox.Location = new Point(148, 28);
            ManageSearchGuestIDTextBox.Name = "ManageSearchGuestIDTextBox";
            ManageSearchGuestIDTextBox.Size = new Size(125, 27);
            ManageSearchGuestIDTextBox.TabIndex = 26;
            // 
            // ManageOccupancyComboBox
            // 
            ManageOccupancyComboBox.FormattingEnabled = true;
            ManageOccupancyComboBox.Location = new Point(148, 557);
            ManageOccupancyComboBox.Name = "ManageOccupancyComboBox";
            ManageOccupancyComboBox.Size = new Size(125, 28);
            ManageOccupancyComboBox.TabIndex = 27;
            // 
            // occTextBox
            // 
            occTextBox.AutoSize = true;
            occTextBox.Location = new Point(12, 560);
            occTextBox.Name = "occTextBox";
            occTextBox.Size = new Size(84, 20);
            occTextBox.TabIndex = 28;
            occTextBox.Text = "Occupancy:";
            // 
            // ManageRoomLabel
            // 
            ManageRoomLabel.AutoSize = true;
            ManageRoomLabel.Location = new Point(379, 34);
            ManageRoomLabel.Name = "ManageRoomLabel";
            ManageRoomLabel.Size = new Size(142, 20);
            ManageRoomLabel.TabIndex = 29;
            ManageRoomLabel.Text = "Room: Not Selected";
            // 
            // ManageBookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
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
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(ManagePaymentStatusComboBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ManageTotalPriceTextBox);
            Controls.Add(ManageEmailTextBox);
            Controls.Add(ManageEndDateTimePicker);
            Controls.Add(ManageStartDateTimePicker);
            Controls.Add(ManageBookingDataGridView);
            Controls.Add(ManagePhoneTextBox);
            Controls.Add(ManageLastNameTextBox);
            Controls.Add(ManageFirstNameTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManageBookingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Manage Guest and Booking";
            WindowState = FormWindowState.Maximized;
            Load += ManageBookingForm_Load;
            ((System.ComponentModel.ISupportInitialize)ManageBookingDataGridView).EndInit();
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
        private DataGridView ManageBookingDataGridView;
        private DateTimePicker ManageStartDateTimePicker;
        private DateTimePicker ManageEndDateTimePicker;
        private TextBox ManageEmailTextBox;
        private TextBox ManageTotalPriceTextBox;
        private Button button1;
        private Button button2;
        private ComboBox ManagePaymentStatusComboBox;
        private Label label6;
        private Label label7;
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
    }
}