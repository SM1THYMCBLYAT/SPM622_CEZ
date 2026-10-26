namespace PietieHostelManager
{
    partial class CreateBooking
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            CreateBookingRoomNumber = new DataGridViewTextBoxColumn();
            CreateBookingRoomStatus = new DataGridViewTextBoxColumn();
            CreateBookingRoomType = new DataGridViewTextBoxColumn();
            CreateBookingRoomOccupants = new DataGridViewTextBoxColumn();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label10 = new Label();
            label11 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // textBox1
            // 
            textBox1.Location = new Point(159, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(159, 89);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(159, 122);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(159, 155);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 8;
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
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CreateBookingRoomNumber, CreateBookingRoomStatus, CreateBookingRoomType, CreateBookingRoomOccupants });
            dataGridView1.Location = new Point(12, 216);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(416, 188);
            dataGridView1.TabIndex = 10;
            // 
            // CreateBookingRoomNumber
            // 
            CreateBookingRoomNumber.HeaderText = "Room Number";
            CreateBookingRoomNumber.MinimumWidth = 6;
            CreateBookingRoomNumber.Name = "CreateBookingRoomNumber";
            // 
            // CreateBookingRoomStatus
            // 
            CreateBookingRoomStatus.HeaderText = "Status";
            CreateBookingRoomStatus.MinimumWidth = 6;
            CreateBookingRoomStatus.Name = "CreateBookingRoomStatus";
            // 
            // CreateBookingRoomType
            // 
            CreateBookingRoomType.HeaderText = "Type";
            CreateBookingRoomType.MinimumWidth = 6;
            CreateBookingRoomType.Name = "CreateBookingRoomType";
            // 
            // CreateBookingRoomOccupants
            // 
            CreateBookingRoomOccupants.HeaderText = "Occupants";
            CreateBookingRoomOccupants.MinimumWidth = 6;
            CreateBookingRoomOccupants.Name = "CreateBookingRoomOccupants";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(323, 31);
            label7.Name = "label7";
            label7.Size = new Size(105, 20);
            label7.TabIndex = 11;
            label7.Text = "required fields";
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
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(159, 410);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(125, 27);
            dateTimePicker1.TabIndex = 14;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(159, 443);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(125, 27);
            dateTimePicker2.TabIndex = 15;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(159, 509);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 19;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 584);
            button1.Name = "button1";
            button1.Size = new Size(142, 29);
            button1.TabIndex = 20;
            button1.Text = "Create Booking";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.OrangeRed;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(296, 584);
            button2.Name = "button2";
            button2.Size = new Size(142, 29);
            button2.TabIndex = 21;
            button2.Text = "Cancel Booking";
            button2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(290, 127);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(154, 24);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "No Phone Number";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(290, 157);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(149, 24);
            checkBox2.TabIndex = 23;
            checkBox2.Text = "No Email Address";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(159, 476);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 24;
            // 
            // CreateBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 625);
            Controls.Add(textBox5);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateBooking";
            Text = "CreateBooking";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn CreateBookingRoomNumber;
        private DataGridViewTextBoxColumn CreateBookingRoomStatus;
        private DataGridViewTextBoxColumn CreateBookingRoomType;
        private DataGridViewTextBoxColumn CreateBookingRoomOccupants;
        private Label label7;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label10;
        private Label label11;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox5;
    }
}