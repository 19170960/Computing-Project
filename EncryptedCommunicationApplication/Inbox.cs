using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using System.Security.Cryptography;

namespace EncryptedCommunicationApplication
{
    public partial class Inbox : Form
    {
        public string emailSender;
        public string emailSubject;
        public string emailBody;
        // store email information (subject, body, and sender) as strings

        List<string> listEmailSender = new List<string>();
        List<string> listEmailSubject = new List<string>();
        List<string> listEmailBody = new List<string>();
        // Store email information within lists
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

        private async Task emailDisplay()
        {
            using(var emailReceiveClient = new ImapClient()){ 
            // Create new client using IMAP

            await emailReceiveClient.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            // Await a connection to the async method (using the specified IMAP configuration
            emailReceiveClient.Authenticate("frido7310@gmail.com", "zwzp gefg ijea aanj");
            // Authenticate the IMAP connection, using the configured credentials
            emailReceiveClient.Inbox.Open(FolderAccess.ReadOnly);
            // Configure client for reading permissions
            for (int i=0; i<emailReceiveClient.Inbox.Count; i++){
            // Iterate the below indented code (for the amount of emails, within the inbox)
                MimeMessage email = emailReceiveClient.Inbox.GetMessage(i);
                // Get the ID of the specific email
                string emailRecipient = Convert.ToString(email.To);
                // Store the email recipient
                string emailSender = Convert.ToString(email.From);
                // Store the email sender
                string emailSubject = Convert.ToString(email.Subject);
                // Store the email subject
                string emailBody = Convert.ToString(email.Body);
                // Store the email body

                System.Windows.Forms.LinkLabel linkLabelEmailSubject = new System.Windows.Forms.LinkLabel();
                // Create new link label
                linkLabelEmailSubject.Width = 150;
                // Configure link label width

                RSACryptoServiceProvider encryptionRSA = new RSACryptoServiceProvider(4096);
                // Configure RSA encryption algorithm to use 4096 bytes of data

                string textCipherSubject = Convert.ToBase64String(encryptionRSA.Encrypt(Encoding.UTF8.GetBytes(emailSubject), false));
                // Encrypt plain-text subject

                string textDecryptedSubject = Encoding.UTF8.GetString(encryptionRSA.Decrypt(Convert.FromBase64String(textCipherSubject), false));
                // Decrypt cipher subject data

                linkLabelEmailSubject.Text = textDecryptedSubject;
                // Configure link label text as email subject
                flowLayoutPanel2.Controls.Add(linkLabelEmailSubject);
                // Add link label to the panel (within the displayed GUI.

                listEmailSender.Add(emailSender);
                // Add email sender to list
                listEmailSubject.Add(emailSubject);
                // Add email subject to list
                listEmailBody.Add(emailBody);
                // Add email body to list

                setEmailSender(emailSender);
                // Set the email sender value as the current email sender
                setEmailSubject(emailSubject);
                // Set the email subject value as the current email subject
                setEmailBody(emailBody);
                // Set the email body value as the current email body

                System.Windows.Forms.Label labelEmailSender = new System.Windows.Forms.Label();

                string textCipherSender = Convert.ToBase64String(encryptionRSA.Encrypt(Encoding.UTF8.GetBytes(emailSender), false));
                // Encrypt plain-text sender

                string textDecryptedSender = Encoding.UTF8.GetString(encryptionRSA.Decrypt(Convert.FromBase64String(textCipherSender), false));
                // Decrypt cipher sender data

                labelEmailSender.Text = textDecryptedSender;
                // Configure label (set to sender/author name)

                flowLayoutPanel1.Controls.Add(labelEmailSender);
                // Add this label to the panel (displayed by the GUI.)

                linkLabelEmailSubject.Click += linkLabelEmailSubjectEvent;
                // If a link label is clicked, display its email relative information
            }

            emailReceiveClient.Disconnect(true);
            // Disconnect from the client
            }
        }

        private void linkLabelEmailSubjectEvent(object sender, EventArgs e)
        {
            System.Windows.Forms.LinkLabel linkLabelEmailSubject = (System.Windows.Forms.LinkLabel)sender;
            // Create a link label
            for (int i = 0; i < listEmailSubject.Count; i++)
            {
            // Iterate through the below indented code (for the amount of emails, within the inbox)
                if (listEmailSubject[i] == linkLabelEmailSubject.Text)
                // if the particular email subject (iterated through as apart of this cycle) is equal to the subject email (located on the link label) execute the bwlow code 
                {
                    InboxData emailInboxUser = new InboxData(listEmailSender[i], listEmailSubject[i], listEmailBody[i]);
                    // Create an email form displaying the relevant email information for this particular email subject
                    this.Hide();
                    // Hide current window
                    emailInboxUser.Show();
                    // Display the email window
                }
            }

        }

        public void setEmailSender(string sender)
        {
            emailSender = sender;
        }

        public string getEmailSender()
        {
            return emailSender;
        }

        public void setEmailSubject(string subject)
        {
            emailSubject = subject;
        }

        public string getEmailSubject()
        {
            return emailSubject;
        }

        public void setEmailBody(string body)
        {
            emailBody = body;
        }

        public string getEmailBody()
        {
            return emailBody;
        }

        private async void Inbox_Load_1(object sender, EventArgs e)
        {
            await emailDisplay();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
