namespace PietieHostelManager
{
    partial class Admin
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
            dataGridView1 = new DataGridView();
            AdminRoomID = new DataGridViewTextBoxColumn();
            AdminRoomNumber = new DataGridViewTextBoxColumn();
            AdminRoomType = new DataGridViewTextBoxColumn();
            AdminOccupants = new DataGridViewTextBoxColumn();
            AdminStatus = new DataGridViewTextBoxColumn();
            AdminMaxCapacity = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            AdminUserTable = new DataGridView();
            AdminUsername = new DataGridViewTextBoxColumn();
            AdminRole = new DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdminUserTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Room Management";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { AdminRoomID, AdminRoomNumber, AdminRoomType, AdminOccupants, AdminStatus, AdminMaxCapacity });
            dataGridView1.Location = new Point(12, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(690, 176);
            dataGridView1.TabIndex = 1;
            // 
            // AdminRoomID
            // 
            AdminRoomID.HeaderText = "Room ID";
            AdminRoomID.MinimumWidth = 6;
            AdminRoomID.Name = "AdminRoomID";
            // 
            // AdminRoomNumber
            // 
            AdminRoomNumber.HeaderText = "Room Number";
            AdminRoomNumber.MinimumWidth = 6;
            AdminRoomNumber.Name = "AdminRoomNumber";
            // 
            // AdminRoomType
            // 
            AdminRoomType.HeaderText = "Room Type";
            AdminRoomType.MinimumWidth = 6;
            AdminRoomType.Name = "AdminRoomType";
            // 
            // AdminOccupants
            // 
            AdminOccupants.HeaderText = "Occupants";
            AdminOccupants.MinimumWidth = 6;
            AdminOccupants.Name = "AdminOccupants";
            // 
            // AdminStatus
            // 
            AdminStatus.HeaderText = "Status";
            AdminStatus.MinimumWidth = 6;
            AdminStatus.Name = "AdminStatus";
            // 
            // AdminMaxCapacity
            // 
            AdminMaxCapacity.HeaderText = "Max Capacity";
            AdminMaxCapacity.MinimumWidth = 6;
            AdminMaxCapacity.Name = "AdminMaxCapacity";
            // 
            // button1
            // 
            button1.Location = new Point(12, 259);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Add Room";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(148, 259);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Edit Room";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(297, 259);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 4;
            button3.Text = "Delete Room";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 294);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "Add Room Type";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(148, 294);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 6;
            button5.Text = "Edit Room Type";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(297, 294);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 7;
            button6.Text = "Delete Room Type";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(297, 388);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 8;
            button7.Text = "Create User";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(297, 423);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 9;
            button8.Text = "Change Password";
            button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.Location = new Point(297, 458);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 10;
            button9.Text = "Delete User";
            button9.UseVisualStyleBackColor = true;
            // 
            // AdminUserTable
            // 
            AdminUserTable.AllowUserToAddRows = false;
            AdminUserTable.AllowUserToDeleteRows = false;
            AdminUserTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AdminUserTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AdminUserTable.Columns.AddRange(new DataGridViewColumn[] { AdminUsername, AdminRole });
            AdminUserTable.Location = new Point(12, 388);
            AdminUserTable.MultiSelect = false;
            AdminUserTable.Name = "AdminUserTable";
            AdminUserTable.RowHeadersVisible = false;
            AdminUserTable.RowHeadersWidth = 51;
            AdminUserTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AdminUserTable.Size = new Size(254, 147);
            AdminUserTable.TabIndex = 11;
            AdminUserTable.CellContentClick += AdminUserTable_CellContentClick;
            // 
            // AdminUsername
            // 
            AdminUsername.HeaderText = "Username";
            AdminUsername.MinimumWidth = 6;
            AdminUsername.Name = "AdminUsername";
            // 
            // AdminRole
            // 
            AdminRole.HeaderText = "Role";
            AdminRole.MinimumWidth = 6;
            AdminRole.Name = "AdminRole";
            AdminRole.Resizable = DataGridViewTriState.True;
            AdminRole.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 694);
            Controls.Add(AdminUserTable);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdminUserTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn AdminRoomID;
        private DataGridViewTextBoxColumn AdminRoomNumber;
        private DataGridViewTextBoxColumn AdminRoomType;
        private DataGridViewTextBoxColumn AdminOccupants;
        private DataGridViewTextBoxColumn AdminStatus;
        private DataGridViewTextBoxColumn AdminMaxCapacity;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private DataGridView AdminUserTable;
        private DataGridViewTextBoxColumn AdminUsername;
        private DataGridViewComboBoxColumn AdminRole;
    }
}