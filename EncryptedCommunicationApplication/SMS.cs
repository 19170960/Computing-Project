using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            TwilioClient.Init("AC21300f0aa6ad6af38121f633cf450cf6", "a717799949c8d665805043f86767ebd3");
            // Configure twilio client credentials

            RSACryptoServiceProvider encryptionRSA = new RSACryptoServiceProvider(4096);
            // Configure RSA encryption algorithm to use 4096 bytes of data

            string textCipher = Convert.ToBase64String(encryptionRSA.Encrypt(Encoding.UTF8.GetBytes(textBox1.Text), false));
            // Encrypt plain text message body

            string textDecrypted = Encoding.UTF8.GetString(encryptionRSA.Decrypt(Convert.FromBase64String(textCipher), false));
            // Decrypt plain text message body
            MessageResource SMStransmit = MessageResource.Create(to: new Twilio.Types.PhoneNumber(textBox2.Text), from: new Twilio.Types.PhoneNumber("+447700171424"), body: textDecrypted);
            // Transmit an SMS using a mobile phone number, and decrypted body (inputted using the provided text-boxes.) 
            richTextBox1.AppendText("Me: " + textDecrypted + "\n");
            // Display the transmitted SMS (in plain-text) within the provided text-box.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
