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
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 0;
            label1.Text = "Add guest";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 56);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "First Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 89);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 2;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 125);
            label4.Name = "label4";
            label4.Size = new Size(111, 20);
            label4.TabIndex = 3;
            label4.Text = "Phone Number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 162);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 4;
            label5.Text = "Email Address:";
            // 
            // AddFirstNameTextBox
            // 
            AddFirstNameTextBox.Location = new Point(159, 56);
            AddFirstNameTextBox.Name = "AddFirstNameTextBox";
            AddFirstNameTextBox.Size = new Size(125, 27);
            AddFirstNameTextBox.TabIndex = 5;
            // 
            // AddLastNameTextBox
            // 
            AddLastNameTextBox.Location = new Point(159, 89);
            AddLastNameTextBox.Name = "AddLastNameTextBox";
            AddLastNameTextBox.Size = new Size(125, 27);
            AddLastNameTextBox.TabIndex = 6;
            // 
            // AddPhoneTextBox
            // 
            AddPhoneTextBox.Location = new Point(159, 122);
            AddPhoneTextBox.Name = "AddPhoneTextBox";
            AddPhoneTextBox.Size = new Size(125, 27);
            AddPhoneTextBox.TabIndex = 7;
            // 
            // AddEmailTextBox
            // 
            AddEmailTextBox.Location = new Point(159, 155);
            AddEmailTextBox.Name = "AddEmailTextBox";
            AddEmailTextBox.Size = new Size(125, 27);
            AddEmailTextBox.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(10, 193);
            label6.Name = "label6";
            label6.Size = new Size(115, 20);
            label6.TabIndex = 9;
            label6.Text = "Create booking";
            // 
            // CreateBookingDataGridView
            // 
            CreateBookingDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CreateBookingDataGridView.ColumnHeadersHeight = 29;
            CreateBookingDataGridView.Location = new Point(12, 216);
            CreateBookingDataGridView.Name = "CreateBookingDataGridView";
            CreateBookingDataGridView.ReadOnly = true;
            CreateBookingDataGridView.RowHeadersVisible = false;
            CreateBookingDataGridView.RowHeadersWidth = 51;
            CreateBookingDataGridView.Size = new Size(768, 188);
            CreateBookingDataGridView.TabIndex = 10;
            CreateBookingDataGridView.CellContentClick += CreateBookingDataGridView_CellContentClick;
            CreateBookingDataGridView.SelectionChanged += CreateBookingDataGridView_SelectionChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 415);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 12;
            label8.Text = "Start Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 448);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 13;
            label9.Text = "End Date:";
            // 
            // CreateBookingStartDatePicker
            // 
            CreateBookingStartDatePicker.Format = DateTimePickerFormat.Short;
            CreateBookingStartDatePicker.Location = new Point(159, 410);
            CreateBookingStartDatePicker.Name = "CreateBookingStartDatePicker";
            CreateBookingStartDatePicker.Size = new Size(125, 27);
            CreateBookingStartDatePicker.TabIndex = 14;
            CreateBookingStartDatePicker.ValueChanged += BookingStartDatePicker_ValueChanged;
            // 
            // CreateBookingEndDatePicker
            // 
            CreateBookingEndDatePicker.Format = DateTimePickerFormat.Short;
            CreateBookingEndDatePicker.Location = new Point(159, 443);
            CreateBookingEndDatePicker.Name = "CreateBookingEndDatePicker";
            CreateBookingEndDatePicker.Size = new Size(125, 27);
            CreateBookingEndDatePicker.TabIndex = 15;
            CreateBookingEndDatePicker.ValueChanged += BookingEndDatePicker_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 479);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 16;
            label10.Text = "Price:  (R)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 512);
            label11.Name = "label11";
            label11.Size = new Size(112, 20);
            label11.TabIndex = 17;
            label11.Text = "Payment Status:";
            // 
            // CreatePaymentStatusComboBox
            // 
            CreatePaymentStatusComboBox.FormattingEnabled = true;
            CreatePaymentStatusComboBox.Location = new Point(159, 509);
            CreatePaymentStatusComboBox.Name = "CreatePaymentStatusComboBox";
            CreatePaymentStatusComboBox.Size = new Size(125, 28);
            CreatePaymentStatusComboBox.TabIndex = 19;
            // 
            // CreateBookingButton
            // 
            CreateBookingButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateBookingButton.Location = new Point(12, 584);
            CreateBookingButton.Name = "CreateBookingButton";
            CreateBookingButton.Size = new Size(142, 29);
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
            CancelBookingButton.Location = new Point(296, 584);
            CancelBookingButton.Name = "CancelBookingButton";
            CancelBookingButton.Size = new Size(142, 29);
            CancelBookingButton.TabIndex = 21;
            CancelBookingButton.Text = "Cancel Booking";
            CancelBookingButton.UseVisualStyleBackColor = false;
            CancelBookingButton.Click += CancelBookingButton_Click;
            // 
            // AddNoPhoneCheckBox
            // 
            AddNoPhoneCheckBox.AutoSize = true;
            AddNoPhoneCheckBox.Location = new Point(290, 127);
            AddNoPhoneCheckBox.Name = "AddNoPhoneCheckBox";
            AddNoPhoneCheckBox.Size = new Size(154, 24);
            AddNoPhoneCheckBox.TabIndex = 22;
            AddNoPhoneCheckBox.Text = "No Phone Number";
            AddNoPhoneCheckBox.UseVisualStyleBackColor = true;
            AddNoPhoneCheckBox.CheckedChanged += NoPhoneCheckBox_CheckedChanged;
            // 
            // AddNoEmailCheckBox
            // 
            AddNoEmailCheckBox.AutoSize = true;
            AddNoEmailCheckBox.Location = new Point(290, 157);
            AddNoEmailCheckBox.Name = "AddNoEmailCheckBox";
            AddNoEmailCheckBox.Size = new Size(149, 24);
            AddNoEmailCheckBox.TabIndex = 23;
            AddNoEmailCheckBox.Text = "No Email Address";
            AddNoEmailCheckBox.UseVisualStyleBackColor = true;
            AddNoEmailCheckBox.CheckedChanged += NoEmailCheckBox_CheckedChanged;
            // 
            // CreateTotalPriceTextBox
            // 
            CreateTotalPriceTextBox.Location = new Point(159, 476);
            CreateTotalPriceTextBox.Name = "CreateTotalPriceTextBox";
            CreateTotalPriceTextBox.Size = new Size(125, 27);
            CreateTotalPriceTextBox.TabIndex = 24;
            // 
            // CreateBookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
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
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateBookingForm";
            Text = "Create Guest and Booking";
            WindowState = FormWindowState.Maximized;
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