namespace PietieHostelManager
{
    partial class CreateBookingForm
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
            AddFirstNameTextBox = new TextBox();
            AddLastNameTextBox = new TextBox();
            AddPhoneTextBox = new TextBox();
            AddEmailTextBox = new TextBox();
            label6 = new Label();
            CreateBookingDataGridView = new DataGridView();
            label8 = new Label();
            label9 = new Label();
            CreateBookingStartDatePicker = new DateTimePicker();
            CreateBookingEndDatePicker = new DateTimePicker();
            label10 = new Label();
            label11 = new Label();
            CreatePaymentStatusComboBox = new ComboBox();
            CreateBookingButton = new Button();
            CancelBookingButton = new Button();
            AddNoPhoneCheckBox = new CheckBox();
            AddNoEmailCheckBox = new CheckBox();
            CreateTotalPriceTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)CreateBookingDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Add guest";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 42);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "First Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 67);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 2;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 94);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 3;
            label4.Text = "Phone Number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 122);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 4;
            label5.Text = "Email Address:";
            // 
            // AddFirstNameTextBox
            // 
            AddFirstNameTextBox.Location = new Point(139, 42);
            AddFirstNameTextBox.Margin = new Padding(3, 2, 3, 2);
            AddFirstNameTextBox.Name = "AddFirstNameTextBox";
            AddFirstNameTextBox.Size = new Size(110, 23);
            AddFirstNameTextBox.TabIndex = 5;
            // 
            // AddLastNameTextBox
            // 
            AddLastNameTextBox.Location = new Point(139, 67);
            AddLastNameTextBox.Margin = new Padding(3, 2, 3, 2);
            AddLastNameTextBox.Name = "AddLastNameTextBox";
            AddLastNameTextBox.Size = new Size(110, 23);
            AddLastNameTextBox.TabIndex = 6;
            // 
            // AddPhoneTextBox
            // 
            AddPhoneTextBox.Location = new Point(139, 92);
            AddPhoneTextBox.Margin = new Padding(3, 2, 3, 2);
            AddPhoneTextBox.Name = "AddPhoneTextBox";
            AddPhoneTextBox.Size = new Size(110, 23);
            AddPhoneTextBox.TabIndex = 7;
            // 
            // AddEmailTextBox
            // 
            AddEmailTextBox.Location = new Point(139, 116);
            AddEmailTextBox.Margin = new Padding(3, 2, 3, 2);
            AddEmailTextBox.Name = "AddEmailTextBox";
            AddEmailTextBox.Size = new Size(110, 23);
            AddEmailTextBox.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(9, 145);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 9;
            label6.Text = "Create booking";
            // 
            // CreateBookingDataGridView
            // 
            CreateBookingDataGridView.AllowUserToAddRows = false;
            CreateBookingDataGridView.AllowUserToDeleteRows = false;
            CreateBookingDataGridView.AllowUserToResizeColumns = false;
            CreateBookingDataGridView.AllowUserToResizeRows = false;
            CreateBookingDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreateBookingDataGridView.ColumnHeadersHeight = 29;
            CreateBookingDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            CreateBookingDataGridView.Location = new Point(10, 162);
            CreateBookingDataGridView.Margin = new Padding(3, 2, 3, 2);
            CreateBookingDataGridView.MultiSelect = false;
            CreateBookingDataGridView.Name = "CreateBookingDataGridView";
            CreateBookingDataGridView.ReadOnly = true;
            CreateBookingDataGridView.RowHeadersVisible = false;
            CreateBookingDataGridView.RowHeadersWidth = 51;
            CreateBookingDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CreateBookingDataGridView.Size = new Size(375, 141);
            CreateBookingDataGridView.TabIndex = 10;
            CreateBookingDataGridView.SelectionChanged += CreateBookingDataGridView_SelectionChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 311);
            label8.Name = "label8";
            label8.Size = new Size(61, 15);
            label8.TabIndex = 12;
            label8.Text = "Start Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 336);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 13;
            label9.Text = "End Date:";
            // 
            // CreateBookingStartDatePicker
            // 
            CreateBookingStartDatePicker.CustomFormat = "yyyy-MM-dd";
            CreateBookingStartDatePicker.Format = DateTimePickerFormat.Custom;
            CreateBookingStartDatePicker.Location = new Point(139, 308);
            CreateBookingStartDatePicker.Margin = new Padding(3, 2, 3, 2);
            CreateBookingStartDatePicker.Name = "CreateBookingStartDatePicker";
            CreateBookingStartDatePicker.Size = new Size(137, 23);
            CreateBookingStartDatePicker.TabIndex = 14;
            CreateBookingStartDatePicker.ValueChanged += BookingStartDatePicker_ValueChanged;
            // 
            // CreateBookingEndDatePicker
            // 
            CreateBookingEndDatePicker.CustomFormat = "yyyy-MM-dd";
            CreateBookingEndDatePicker.Format = DateTimePickerFormat.Custom;
            CreateBookingEndDatePicker.Location = new Point(139, 332);
            CreateBookingEndDatePicker.Margin = new Padding(3, 2, 3, 2);
            CreateBookingEndDatePicker.Name = "CreateBookingEndDatePicker";
            CreateBookingEndDatePicker.Size = new Size(137, 23);
            CreateBookingEndDatePicker.TabIndex = 15;
            CreateBookingEndDatePicker.ValueChanged += BookingEndDatePicker_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(10, 359);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
            label10.TabIndex = 16;
            label10.Text = "Price:  (R)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 384);
            label11.Name = "label11";
            label11.Size = new Size(92, 15);
            label11.TabIndex = 17;
            label11.Text = "Payment Status:";
            // 
            // CreatePaymentStatusComboBox
            // 
            CreatePaymentStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CreatePaymentStatusComboBox.FormattingEnabled = true;
            CreatePaymentStatusComboBox.Items.AddRange(new object[] { "Paid", "Pending" });
            CreatePaymentStatusComboBox.Location = new Point(139, 382);
            CreatePaymentStatusComboBox.Margin = new Padding(3, 2, 3, 2);
            CreatePaymentStatusComboBox.Name = "CreatePaymentStatusComboBox";
            CreatePaymentStatusComboBox.Size = new Size(137, 23);
            CreatePaymentStatusComboBox.TabIndex = 19;
            // 
            // CreateBookingButton
            // 
            CreateBookingButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateBookingButton.Location = new Point(10, 438);
            CreateBookingButton.Margin = new Padding(3, 2, 3, 2);
            CreateBookingButton.Name = "CreateBookingButton";
            CreateBookingButton.Size = new Size(124, 22);
            CreateBookingButton.TabIndex = 20;
            CreateBookingButton.Text = "Create Booking";
            CreateBookingButton.UseVisualStyleBackColor = true;
            CreateBookingButton.Click += CreateBookingButton_Click;
            // 
            // CancelBookingButton
            // 
            CancelBookingButton.BackColor = Color.OrangeRed;
            CancelBookingButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBookingButton.ForeColor = Color.White;
            CancelBookingButton.Location = new Point(259, 438);
            CancelBookingButton.Margin = new Padding(3, 2, 3, 2);
            CancelBookingButton.Name = "CancelBookingButton";
            CancelBookingButton.Size = new Size(124, 22);
            CancelBookingButton.TabIndex = 21;
            CancelBookingButton.Text = "Cancel Booking";
            CancelBookingButton.UseVisualStyleBackColor = false;
            CancelBookingButton.Click += CancelBookingButton_Click;
            // 
            // AddNoPhoneCheckBox
            // 
            AddNoPhoneCheckBox.AutoSize = true;
            AddNoPhoneCheckBox.Location = new Point(254, 95);
            AddNoPhoneCheckBox.Margin = new Padding(3, 2, 3, 2);
            AddNoPhoneCheckBox.Name = "AddNoPhoneCheckBox";
            AddNoPhoneCheckBox.Size = new Size(126, 19);
            AddNoPhoneCheckBox.TabIndex = 22;
            AddNoPhoneCheckBox.Text = "No Phone Number";
            AddNoPhoneCheckBox.UseVisualStyleBackColor = true;
            AddNoPhoneCheckBox.CheckedChanged += NoPhoneCheckBox_CheckedChanged;
            // 
            // AddNoEmailCheckBox
            // 
            AddNoEmailCheckBox.AutoSize = true;
            AddNoEmailCheckBox.Location = new Point(254, 118);
            AddNoEmailCheckBox.Margin = new Padding(3, 2, 3, 2);
            AddNoEmailCheckBox.Name = "AddNoEmailCheckBox";
            AddNoEmailCheckBox.Size = new Size(119, 19);
            AddNoEmailCheckBox.TabIndex = 23;
            AddNoEmailCheckBox.Text = "No Email Address";
            AddNoEmailCheckBox.UseVisualStyleBackColor = true;
            AddNoEmailCheckBox.CheckedChanged += NoEmailCheckBox_CheckedChanged;
            // 
            // CreateTotalPriceTextBox
            // 
            CreateTotalPriceTextBox.Location = new Point(139, 357);
            CreateTotalPriceTextBox.Margin = new Padding(3, 2, 3, 2);
            CreateTotalPriceTextBox.Name = "CreateTotalPriceTextBox";
            CreateTotalPriceTextBox.ReadOnly = true;
            CreateTotalPriceTextBox.Size = new Size(137, 23);
            CreateTotalPriceTextBox.TabIndex = 24;
            // 
            // CreateBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 490);
            Controls.Add(CreateTotalPriceTextBox);
            Controls.Add(AddNoEmailCheckBox);
            Controls.Add(AddNoPhoneCheckBox);
            Controls.Add(CancelBookingButton);
            Controls.Add(CreateBookingButton);
            Controls.Add(CreatePaymentStatusComboBox);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(CreateBookingEndDatePicker);
            Controls.Add(CreateBookingStartDatePicker);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(CreateBookingDataGridView);
            Controls.Add(label6);
            Controls.Add(AddEmailTextBox);
            Controls.Add(AddPhoneTextBox);
            Controls.Add(AddLastNameTextBox);
            Controls.Add(AddFirstNameTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateBookingForm";
            Text = "Create Guest and Booking";
            Load += CreateBooking_Load;
            ((System.ComponentModel.ISupportInitialize)CreateBookingDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox AddFirstNameTextBox;
        private TextBox AddLastNameTextBox;
        private TextBox AddPhoneTextBox;
        private TextBox AddEmailTextBox;
        private Label label6;
        private DataGridView CreateBookingDataGridView;
        private Label label8;
        private Label label9;
        private DateTimePicker CreateBookingStartDatePicker;
        private DateTimePicker CreateBookingEndDatePicker;
        private Label label10;
        private Label label11;
        private ComboBox CreatePaymentStatusComboBox;
        private Button CreateBookingButton;
        private Button CancelBookingButton;
        private CheckBox AddNoPhoneCheckBox;
        private CheckBox AddNoEmailCheckBox;
        private TextBox CreateTotalPriceTextBox;
    }
}