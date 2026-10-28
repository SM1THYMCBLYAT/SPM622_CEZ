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
            ((System.ComponentModel.ISupportInitialize)AdminRoomsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AdminUsersDataGridView).BeginInit();
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
            AdminRoomsDataGridView.Location = new Point(12, 77);
            AdminRoomsDataGridView.Name = "AdminRoomsDataGridView";
            AdminRoomsDataGridView.RowHeadersVisible = false;
            AdminRoomsDataGridView.RowHeadersWidth = 51;
            AdminRoomsDataGridView.Size = new Size(690, 176);
            AdminRoomsDataGridView.TabIndex = 1;
            AdminRoomsDataGridView.CellContentClick += AdminRoomsDataGridView_CellContentClick;
            // 
            // AdminAddRoomButton
            // 
            AdminAddRoomButton.Location = new Point(12, 259);
            AdminAddRoomButton.Name = "AdminAddRoomButton";
            AdminAddRoomButton.Size = new Size(94, 29);
            AdminAddRoomButton.TabIndex = 2;
            AdminAddRoomButton.Text = "Add Room";
            AdminAddRoomButton.UseVisualStyleBackColor = true;
            AdminAddRoomButton.Click += AdminAddRoomButton_Click;
            // 
            // AdminEditRoomButton
            // 
            AdminEditRoomButton.Location = new Point(148, 259);
            AdminEditRoomButton.Name = "AdminEditRoomButton";
            AdminEditRoomButton.Size = new Size(94, 29);
            AdminEditRoomButton.TabIndex = 3;
            AdminEditRoomButton.Text = "Edit Room";
            AdminEditRoomButton.UseVisualStyleBackColor = true;
            AdminEditRoomButton.Click += AdminEditRoomButton_Click;
            // 
            // AdminDeleteRoomButton
            // 
            AdminDeleteRoomButton.Location = new Point(297, 259);
            AdminDeleteRoomButton.Name = "AdminDeleteRoomButton";
            AdminDeleteRoomButton.Size = new Size(94, 29);
            AdminDeleteRoomButton.TabIndex = 4;
            AdminDeleteRoomButton.Text = "Delete Room";
            AdminDeleteRoomButton.UseVisualStyleBackColor = true;
            AdminDeleteRoomButton.Click += AdminDeleteRoomButton_Click;
            // 
            // AdminAddRoomTypeButton
            // 
            AdminAddRoomTypeButton.Location = new Point(12, 294);
            AdminAddRoomTypeButton.Name = "AdminAddRoomTypeButton";
            AdminAddRoomTypeButton.Size = new Size(94, 29);
            AdminAddRoomTypeButton.TabIndex = 5;
            AdminAddRoomTypeButton.Text = "Add Room Type";
            AdminAddRoomTypeButton.UseVisualStyleBackColor = true;
            AdminAddRoomTypeButton.Click += AdminAddRoomTypeButton_Click;
            // 
            // AdminEditRoomTypeButton
            // 
            AdminEditRoomTypeButton.Location = new Point(148, 294);
            AdminEditRoomTypeButton.Name = "AdminEditRoomTypeButton";
            AdminEditRoomTypeButton.Size = new Size(94, 29);
            AdminEditRoomTypeButton.TabIndex = 6;
            AdminEditRoomTypeButton.Text = "Edit Room Type";
            AdminEditRoomTypeButton.UseVisualStyleBackColor = true;
            AdminEditRoomTypeButton.Click += AdminEditRoomTypeButton_Click;
            // 
            // AdminDeleteRoomTypeButton
            // 
            AdminDeleteRoomTypeButton.Location = new Point(297, 294);
            AdminDeleteRoomTypeButton.Name = "AdminDeleteRoomTypeButton";
            AdminDeleteRoomTypeButton.Size = new Size(94, 29);
            AdminDeleteRoomTypeButton.TabIndex = 7;
            AdminDeleteRoomTypeButton.Text = "Delete Room Type";
            AdminDeleteRoomTypeButton.UseVisualStyleBackColor = true;
            AdminDeleteRoomTypeButton.Click += AdminDeleteRoomTypeButton_Click;
            // 
            // AdminCreateUserButton
            // 
            AdminCreateUserButton.Location = new Point(12, 541);
            AdminCreateUserButton.Name = "AdminCreateUserButton";
            AdminCreateUserButton.Size = new Size(94, 29);
            AdminCreateUserButton.TabIndex = 8;
            AdminCreateUserButton.Text = "Create User";
            AdminCreateUserButton.UseVisualStyleBackColor = true;
            AdminCreateUserButton.Click += AdminCreateUserButton_Click;
            // 
            // AdminChangeUserPasswordButton
            // 
            AdminChangeUserPasswordButton.Location = new Point(148, 541);
            AdminChangeUserPasswordButton.Name = "AdminChangeUserPasswordButton";
            AdminChangeUserPasswordButton.Size = new Size(94, 29);
            AdminChangeUserPasswordButton.TabIndex = 9;
            AdminChangeUserPasswordButton.Text = "Change Password";
            AdminChangeUserPasswordButton.UseVisualStyleBackColor = true;
            AdminChangeUserPasswordButton.Click += AdminChangeUserPasswordButton_Click;
            // 
            // AdminDeleteUserButton
            // 
            AdminDeleteUserButton.Location = new Point(297, 541);
            AdminDeleteUserButton.Name = "AdminDeleteUserButton";
            AdminDeleteUserButton.Size = new Size(94, 29);
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
            AdminUsersDataGridView.Location = new Point(12, 388);
            AdminUsersDataGridView.MultiSelect = false;
            AdminUsersDataGridView.Name = "AdminUsersDataGridView";
            AdminUsersDataGridView.RowHeadersVisible = false;
            AdminUsersDataGridView.RowHeadersWidth = 51;
            AdminUsersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AdminUsersDataGridView.Size = new Size(690, 147);
            AdminUsersDataGridView.TabIndex = 11;
            AdminUsersDataGridView.CellContentClick += AdminUserTable_CellContentClick;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 694);
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
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            ((System.ComponentModel.ISupportInitialize)AdminRoomsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)AdminUsersDataGridView).EndInit();
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
    }
}