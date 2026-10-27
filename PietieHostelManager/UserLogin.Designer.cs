namespace PietieHostelManager
{
    partial class UserLogin
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
            UserLoginTextUsername = new TextBox();
            UserLoginTextPassword = new TextBox();
            UserLoginButtonLogin = new Button();
            UserLoginButtonCancel = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // UserLoginTextUsername
            // 
            UserLoginTextUsername.Location = new Point(33, 31);
            UserLoginTextUsername.Name = "UserLoginTextUsername";
            UserLoginTextUsername.PlaceholderText = "Username";
            UserLoginTextUsername.Size = new Size(125, 27);
            UserLoginTextUsername.TabIndex = 0;
            // 
            // UserLoginTextPassword
            // 
            UserLoginTextPassword.Location = new Point(33, 76);
            UserLoginTextPassword.Name = "UserLoginTextPassword";
            UserLoginTextPassword.PasswordChar = '*';
            UserLoginTextPassword.PlaceholderText = "Password";
            UserLoginTextPassword.Size = new Size(125, 27);
            UserLoginTextPassword.TabIndex = 1;
            // 
            // UserLoginButtonLogin
            // 
            UserLoginButtonLogin.Location = new Point(12, 398);
            UserLoginButtonLogin.Name = "UserLoginButtonLogin";
            UserLoginButtonLogin.Size = new Size(94, 29);
            UserLoginButtonLogin.TabIndex = 2;
            UserLoginButtonLogin.Text = "Log In";
            UserLoginButtonLogin.UseVisualStyleBackColor = true;
            UserLoginButtonLogin.Click += UserLoginButtonLogin_Click;
            // 
            // UserLoginButtonCancel
            // 
            UserLoginButtonCancel.Location = new Point(153, 398);
            UserLoginButtonCancel.Name = "UserLoginButtonCancel";
            UserLoginButtonCancel.Size = new Size(94, 29);
            UserLoginButtonCancel.TabIndex = 3;
            UserLoginButtonCancel.Text = "Cancel";
            UserLoginButtonCancel.UseVisualStyleBackColor = true;
            UserLoginButtonCancel.Click += LoginButtonCancel_Click;
            // 
            // button1
            // 
            button1.Location = new Point(64, 222);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "test connection";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(259, 439);
            Controls.Add(button1);
            Controls.Add(UserLoginButtonCancel);
            Controls.Add(UserLoginButtonLogin);
            Controls.Add(UserLoginTextPassword);
            Controls.Add(UserLoginTextUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserLogin";
            Load += UserLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserLoginTextUsername;
        private TextBox UserLoginTextPassword;
        private Button UserLoginButtonLogin;
        private Button UserLoginButtonCancel;
        private Button button1;
    }
}