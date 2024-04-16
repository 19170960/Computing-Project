using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace EncryptedCommunicationApplication
{
    public partial class SMS : Form
    {
        public SMS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        // If back button was clicked, execute below indented code
        {
            Home home = new Home();
            this.Hide();
            // Close current window
            home.Show();
            // Display home window
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        // When button is clicked, execute below indented code
        {
            TwilioClient.Init("AC21300f0aa6ad6af38121f633cf450cf6", "8744083f8c4c1e9a5722b99e1b4cac97");
            // Configure twilio client credentials

            MessageResource SMStransmit = MessageResource.Create(to: new Twilio.Types.PhoneNumber(textBox2.Text), from: new Twilio.Types.PhoneNumber("+447700171424"), body: textBox1.Text);
            // Transmit an SMS using a mobile phone number, and body (inputted using the provided text-boxes.) 
            richTextBox1.AppendText("Me: " + textBox1.Text + "\n");
            // Display transmitted SMS within the provided text-box.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
