namespace PietieHostelManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
    }
}
