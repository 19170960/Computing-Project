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
        public InboxData(string emailSender, string emailSubject, string emailBody)
        {
            InitializeComponent();

            string emailSenderData = emailSender;
            // Set emailSenderData string as input
            string emailSubjectData = emailSubject;
            // Set emailSubjectData string as input
            string emailBodyData = emailBody;
            // Set emailBodyData string as input

            emailSenderDisplay(emailSenderData);
            // Display sender input
            emailSubjectDisplay(emailSubjectData);
            // Display subject input
            emailBodyDisplay(emailBodyData);
            // Display body input
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

        private void emailSenderDisplay(string emailSenderData)
        {
            textBox1.Text = emailSenderData;
            // Set text box to display the email sender
        }

        private void emailSubjectDisplay(string emailSubjectData)
        {
            textBox2.Text = emailSubjectData;
            // Configure the text box to display the email subject
        }

        private void emailBodyDisplay(string emailBodyData)
        {
            WebBrowser inboxEmail = new WebBrowser();
            // Configure web browser, in order to correctly display email information
            inboxEmail.DocumentText = emailBodyData;
            // Configure the text, as the body of the email
            inboxEmail.Location = new Point(70, 180);
            // Configure location of web browser
            inboxEmail.Size = new Size(580, 100);
            // Configure size of web browser
            this.Controls.Add(inboxEmail);
            // Display the web browser (containing the email body.)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InboxData_Load(object sender, EventArgs e)
        {

        }
    }
}
