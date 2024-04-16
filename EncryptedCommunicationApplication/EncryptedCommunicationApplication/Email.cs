using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptedCommunicationApplication
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        // If compose button was clicked, execute below indented code
        {
            Compose compose = new Compose();
            this.Hide();
            // Close current window
            compose.Show();
            // Show compose window
        }

        private void button2_Click(object sender, EventArgs e)
        // If inbox button was clicked, execute below indented code
        {
            Inbox inbox = new Inbox();
            this.Hide();
            // Close current window
            inbox.Show();
            // Show inbox window
        }

        private void button3_Click(object sender, EventArgs e)
        // If back button was clicked, execute below indented code
        {
            Home home = new Home();
            this.Hide();
            // Close current window
            home.Show();
            // Display home window
        }
    }
}
