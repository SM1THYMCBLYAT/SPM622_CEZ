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
            AdminRoomsDataGridView = new DataGridView();
            AdminAddRoomButton = new Button();
            AdminEditRoomButton = new Button();
            AdminDeleteRoomButton = new Button();
            AdminAddRoomTypeButton = new Button();
            AdminEditRoomTypeButton = new Button();
            AdminDeleteRoomTypeButton = new Button();
            AdminCreateUserButton = new Button();
            AdminChangeUserPasswordButton = new Button();
            AdminDeleteUserButton = new Button();
            AdminUsersDataGridView = new DataGridView();
            FilterRoomTypeComboBox = new ComboBox();
            FilterRoomStatusComboBox = new ComboBox();
            label2 = new Label();
            AdminAuditLogDataGridView = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)AdminRoomsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdminUsersDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdminAuditLogDataGridView).BeginInit();
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
            // AdminRoomsDataGridView
            // 
            AdminRoomsDataGridView.AllowUserToAddRows = false;
            AdminRoomsDataGridView.AllowUserToDeleteRows = false;
            AdminRoomsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AdminRoomsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AdminRoomsDataGridView.Location = new Point(9, 76);
            AdminRoomsDataGridView.Name = "AdminRoomsDataGridView";
            AdminRoomsDataGridView.RowHeadersVisible = false;
            AdminRoomsDataGridView.RowHeadersWidth = 51;
            AdminRoomsDataGridView.Size = new Size(590, 176);
            AdminRoomsDataGridView.TabIndex = 1;
            AdminRoomsDataGridView.CellContentClick += AdminRoomsDataGridView_CellContentClick;
            AdminRoomsDataGridView.SelectionChanged += AdminRoomsDataGridView_SelectionChanged;
            // 
            // AdminAddRoomButton
            // 
            AdminAddRoomButton.Location = new Point(12, 258);
            AdminAddRoomButton.Name = "AdminAddRoomButton";
            AdminAddRoomButton.Size = new Size(94, 55);
            AdminAddRoomButton.TabIndex = 2;
            AdminAddRoomButton.Text = "Add Room";
            AdminAddRoomButton.UseVisualStyleBackColor = true;
            AdminAddRoomButton.Click += AdminAddRoomButton_Click;
            // 
            // AdminEditRoomButton
            // 
            AdminEditRoomButton.Location = new Point(148, 258);
            AdminEditRoomButton.Name = "AdminEditRoomButton";
            AdminEditRoomButton.Size = new Size(94, 55);
            AdminEditRoomButton.TabIndex = 3;
            AdminEditRoomButton.Text = "Edit Room";
            AdminEditRoomButton.UseVisualStyleBackColor = true;
            AdminEditRoomButton.Click += AdminEditRoomButton_Click;
            // 
            // AdminDeleteRoomButton
            // 
            AdminDeleteRoomButton.Location = new Point(297, 258);
            AdminDeleteRoomButton.Name = "AdminDeleteRoomButton";
            AdminDeleteRoomButton.Size = new Size(94, 55);
            AdminDeleteRoomButton.TabIndex = 4;
            AdminDeleteRoomButton.Text = "Delete Room";
            AdminDeleteRoomButton.UseVisualStyleBackColor = true;
            AdminDeleteRoomButton.Click += AdminDeleteRoomButton_Click;
            // 
            // AdminAddRoomTypeButton
            // 
            AdminAddRoomTypeButton.Location = new Point(12, 319);
            AdminAddRoomTypeButton.Name = "AdminAddRoomTypeButton";
            AdminAddRoomTypeButton.Size = new Size(94, 51);
            AdminAddRoomTypeButton.TabIndex = 5;
            AdminAddRoomTypeButton.Text = "Add Room Type";
            AdminAddRoomTypeButton.UseVisualStyleBackColor = true;
            AdminAddRoomTypeButton.Click += AdminAddRoomTypeButton_Click;
            // 
            // AdminEditRoomTypeButton
            // 
            AdminEditRoomTypeButton.Location = new Point(148, 319);
            AdminEditRoomTypeButton.Name = "AdminEditRoomTypeButton";
            AdminEditRoomTypeButton.Size = new Size(94, 51);
            AdminEditRoomTypeButton.TabIndex = 6;
            AdminEditRoomTypeButton.Text = "Edit Room Type";
            AdminEditRoomTypeButton.UseVisualStyleBackColor = true;
            AdminEditRoomTypeButton.Click += AdminEditRoomTypeButton_Click;
            // 
            // AdminDeleteRoomTypeButton
            // 
            AdminDeleteRoomTypeButton.Location = new Point(297, 319);
            AdminDeleteRoomTypeButton.Name = "AdminDeleteRoomTypeButton";
            AdminDeleteRoomTypeButton.Size = new Size(94, 51);
            AdminDeleteRoomTypeButton.TabIndex = 7;
            AdminDeleteRoomTypeButton.Text = "Delete Room Type";
            AdminDeleteRoomTypeButton.UseVisualStyleBackColor = true;
            AdminDeleteRoomTypeButton.Click += AdminDeleteRoomTypeButton_Click;
            // 
            // AdminCreateUserButton
            // 
            AdminCreateUserButton.Location = new Point(12, 575);
            AdminCreateUserButton.Name = "AdminCreateUserButton";
            AdminCreateUserButton.Size = new Size(94, 52);
            AdminCreateUserButton.TabIndex = 8;
            AdminCreateUserButton.Text = "Create User";
            AdminCreateUserButton.UseVisualStyleBackColor = true;
            AdminCreateUserButton.Click += AdminCreateUserButton_Click;
            // 
            // AdminChangeUserPasswordButton
            // 
            AdminChangeUserPasswordButton.Location = new Point(148, 575);
            AdminChangeUserPasswordButton.Name = "AdminChangeUserPasswordButton";
            AdminChangeUserPasswordButton.Size = new Size(94, 52);
            AdminChangeUserPasswordButton.TabIndex = 9;
            AdminChangeUserPasswordButton.Text = "Change Password";
            AdminChangeUserPasswordButton.UseVisualStyleBackColor = true;
            AdminChangeUserPasswordButton.Click += AdminChangeUserPasswordButton_Click;
            // 
            // AdminDeleteUserButton
            // 
            AdminDeleteUserButton.Location = new Point(297, 575);
            AdminDeleteUserButton.Name = "AdminDeleteUserButton";
            AdminDeleteUserButton.Size = new Size(94, 52);
            AdminDeleteUserButton.TabIndex = 10;
            AdminDeleteUserButton.Text = "Delete User";
            AdminDeleteUserButton.UseVisualStyleBackColor = true;
            AdminDeleteUserButton.Click += AdminDeleteUserButton_Click;
            // 
            // AdminUsersDataGridView
            // 
            AdminUsersDataGridView.AllowUserToAddRows = false;
            AdminUsersDataGridView.AllowUserToDeleteRows = false;
            AdminUsersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AdminUsersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AdminUsersDataGridView.Location = new Point(12, 422);
            AdminUsersDataGridView.MultiSelect = false;
            AdminUsersDataGridView.Name = "AdminUsersDataGridView";
            AdminUsersDataGridView.RowHeadersVisible = false;
            AdminUsersDataGridView.RowHeadersWidth = 51;
            AdminUsersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AdminUsersDataGridView.Size = new Size(587, 147);
            AdminUsersDataGridView.TabIndex = 11;
            AdminUsersDataGridView.CellContentClick += AdminUserTable_CellContentClick;
            AdminUsersDataGridView.SelectionChanged += AdminUserTable_SelectionChanged;
            // 
            // FilterRoomTypeComboBox
            // 
            FilterRoomTypeComboBox.FormattingEnabled = true;
            FilterRoomTypeComboBox.Location = new Point(9, 42);
            FilterRoomTypeComboBox.Name = "FilterRoomTypeComboBox";
            FilterRoomTypeComboBox.Size = new Size(151, 28);
            FilterRoomTypeComboBox.TabIndex = 12;
            FilterRoomTypeComboBox.Text = "Filter Room Type";
            FilterRoomTypeComboBox.SelectedIndexChanged += FilterRoomTypeComboBox_SelectedIndexChanged;
            // 
            // FilterRoomStatusComboBox
            // 
            FilterRoomStatusComboBox.FormattingEnabled = true;
            FilterRoomStatusComboBox.Location = new Point(203, 42);
            FilterRoomStatusComboBox.Name = "FilterRoomStatusComboBox";
            FilterRoomStatusComboBox.Size = new Size(151, 28);
            FilterRoomStatusComboBox.TabIndex = 13;
            FilterRoomStatusComboBox.Text = "Filter Room Status";
            FilterRoomStatusComboBox.SelectedIndexChanged += FilterRoomStatusComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 399);
            label2.Name = "label2";
            label2.Size = new Size(200, 20);
            label2.TabIndex = 14;
            label2.Text = "User Account Management";
            // 
            // AdminAuditLogDataGridView
            // 
            AdminAuditLogDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AdminAuditLogDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AdminAuditLogDataGridView.Location = new Point(622, 76);
            AdminAuditLogDataGridView.Name = "AdminAuditLogDataGridView";
            AdminAuditLogDataGridView.RowHeadersWidth = 51;
            AdminAuditLogDataGridView.Size = new Size(450, 493);
            AdminAuditLogDataGridView.TabIndex = 15;
            AdminAuditLogDataGridView.CellContentClick += AdminAuditLogDataGridView_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(622, 9);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 16;
            label3.Text = "Audit Log";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 653);
            Controls.Add(label3);
            Controls.Add(AdminAuditLogDataGridView);
            Controls.Add(label2);
            Controls.Add(FilterRoomStatusComboBox);
            Controls.Add(FilterRoomTypeComboBox);
            Controls.Add(AdminUsersDataGridView);
            Controls.Add(AdminDeleteUserButton);
            Controls.Add(AdminChangeUserPasswordButton);
            Controls.Add(AdminCreateUserButton);
            Controls.Add(AdminDeleteRoomTypeButton);
            Controls.Add(AdminEditRoomTypeButton);
            Controls.Add(AdminAddRoomTypeButton);
            Controls.Add(AdminDeleteRoomButton);
            Controls.Add(AdminEditRoomButton);
            Controls.Add(AdminAddRoomButton);
            Controls.Add(AdminRoomsDataGridView);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Admin";
            Text = "Admin";
            WindowState = FormWindowState.Maximized;
            Load += Admin_Load;
            ((System.ComponentModel.ISupportInitialize)AdminRoomsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdminUsersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdminAuditLogDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView AdminRoomsDataGridView;
        private Button AdminAddRoomButton;
        private Button AdminEditRoomButton;
        private Button AdminDeleteRoomButton;
        private Button AdminAddRoomTypeButton;
        private Button AdminEditRoomTypeButton;
        private Button AdminDeleteRoomTypeButton;
        private Button AdminCreateUserButton;
        private Button AdminChangeUserPasswordButton;
        private Button AdminDeleteUserButton;
        private DataGridView AdminUsersDataGridView;
        private ComboBox FilterRoomTypeComboBox;
        private ComboBox FilterRoomStatusComboBox;
        private Label label2;
        private DataGridView AdminAuditLogDataGridView;
        private Label label3;
    }
}