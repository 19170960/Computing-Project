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
using System.Security.Cryptography;


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

            RSACryptoServiceProvider encryptionRSA = new RSACryptoServiceProvider(4096);
            // Configure RSA encryption algorithm to use 4096 bytes of data

            string textCipherSubject = Convert.ToBase64String(encryptionRSA.Encrypt(Encoding.UTF8.GetBytes(textBox2.Text), false));
            // Encrypt plain text subject

            string textDecryptedSubject = Encoding.UTF8.GetString(encryptionRSA.Decrypt(Convert.FromBase64String(textCipherSubject), false));
            // Decrypt cipher text subject

            string textCipherRecipient = Convert.ToBase64String(encryptionRSA.Encrypt(Encoding.UTF8.GetBytes(textBox1.Text), false));
            // Encrypt plain text recipient

            string textDecryptedRecipient = Encoding.UTF8.GetString(encryptionRSA.Decrypt(Convert.FromBase64String(textCipherRecipient), false));
            // Decrypt cipher text recipient

            string textCipherBody = Convert.ToBase64String(encryptionRSA.Encrypt(Encoding.UTF8.GetBytes(textBox3.Text), false));
            // Encrypt plain text email body

            string textDecryptedBody = Encoding.UTF8.GetString(encryptionRSA.Decrypt(Convert.FromBase64String(textCipherBody), false));
            // Decrypt cipher text body

            emailSend.To.Add(new MailAddress(textDecryptedRecipient));
            // Add this input, as the recipient data
            emailSend.Subject = textDecryptedSubject;
            // Add this input, as subject data
            emailSend.Body = textDecryptedBody;
            // Add this input, as body data.
            SmtpClient connectionSMTP = new SmtpClient("smtp.gmail.com", 587);
            // Configure SMTP client using a secure connection (supported by GMAIL.)
            connectionSMTP.EnableSsl = true;
            // Enable SSL, for security
            connectionSMTP.UseDefaultCredentials = false;
            // Configured credentials have been provided
            emailSend.From = new MailAddress("frido7310@gmail.com");
            // Configured email address (to transmit emails from.)
            connectionSMTP.Credentials = new NetworkCredential("frido7310@gmail.com", "zwzp gefg ijea aanj");
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
