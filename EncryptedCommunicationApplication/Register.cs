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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        // If back button was clicked, execute below indented code
        {
            Start start = new Start();
            this.Hide();
            // Close current window
            start.Show();
            // Display start window
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
