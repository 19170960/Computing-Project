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
    public partial class InboxData : Form
    {
        public InboxData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        // If back button was clicked, execute below indented code
        {
            Inbox inbox = new Inbox();
            this.Hide();
            // Close current window
            inbox.Show();
            // Display inbox window
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
