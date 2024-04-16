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
    public partial class Inbox : Form
    {
        public Inbox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        // If back button was clicked, execute below indented code
        {
            Email email = new Email();
            this.Hide();
            // Close current window
            email.Show();
            // Display email window
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
