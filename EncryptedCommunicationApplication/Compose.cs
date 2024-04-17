using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EncryptedCommunicationApplication
{
    public partial class Compose : Form
    {
        public Compose()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Email email = new Email();
            this.Hide();
            // Close current window
            email.Show();
            // Display email window
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailMessage emailSend = new MailMessage();
            // Create new email (that can be configured.)

            emailSend.To.Add(new MailAddress(textBox1.Text));
            // Add this input, as the recipient data
            emailSend.Subject = textBox2.Text;
            // Add this input, as subject data
            emailSend.Body = textBox3.Text;
            // Add this input, as body data.
            SmtpClient connectionSMTP = new SmtpClient("smtp.gmail.com", 587);
            // Configure SMTP client using a secure connection (supported by GMAIL.)
            connectionSMTP.EnableSsl = true;
            // Enable SSL, for security
            connectionSMTP.UseDefaultCredentials = false;
            // Configured credentials have been provided
            emailSend.From = new MailAddress("theeldercircle@gmail.com");
            // Configured email address (to transmit emails from.)
            connectionSMTP.Credentials = new NetworkCredential("theeldercircle@gmail.com", "mwmn enlq vnha iauy");
            // Configured credentials for this account.

            connectionSMTP.Send(emailSend);
            // Submit the configured email (including the stored information.)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
