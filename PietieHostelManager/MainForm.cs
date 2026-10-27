using System.ComponentModel;

namespace PietieHostelManager
{
    public partial class MainForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string User { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserRole { get; set; }
        public MainForm(string username, string userRole)
        {
            InitializeComponent();
            User = username;
            UserRole = userRole;
        }

        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            using (var createBooking = new CreateBooking())
            {
                createBooking.ShowDialog();
            }
        }

        private void buttonOpenAdmin_Click(object sender, EventArgs e)
        {
            using (var openAdmin = new Admin())
            {
                openAdmin.ShowDialog();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
