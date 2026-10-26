using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;

namespace PietieHostelManager
{
    public partial class Admin : Form
    {

        private readonly string connectionString =
            @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";
       
        public Admin()
        {
            InitializeComponent();
        }

        private void LoadUsers() 
        {
            //string query = @"
            //SELECT Username, Role
            //from Users
            //ORDER BY Username";

            //using (SqlConnection connection =
            //           new SqlConnection(connectionString))
            //using (SqlCommand command =
            //       new SqlCommand(query, connection))
            //using (SqlDataAdapter adapter =
            //       new SqlDataAdapter(command))
            //{
            //    DataTable table = new DataTable();

            //    connection.Open();
            //    adapter.Fill(table);

            //    AdminUserTable.DataSource = table;
            //}
        }            
        private void AdminUserTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}
