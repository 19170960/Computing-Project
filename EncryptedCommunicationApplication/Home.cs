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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        // If SMS button was clicked, execute below indented code
        {
            SMS sms = new SMS();
            this.Hide();
            // Close current window
            sms.Show();
            // Display SMS window
        }

        private void button2_Click(object sender, EventArgs e)
        // If email button was clicked, execute below indented code
        {
            Email email = new Email();
            this.Hide();
            // Close current window
            email.Show();
            // Display email window
        }

        private void button3_Click(object sender, EventArgs e)
        // If back button was clicked, execute below indented code
        {
            Start start = new Start();
            this.Hide();
            // Close current window
            start.Show();
            // Display start window
        }
    }
}
