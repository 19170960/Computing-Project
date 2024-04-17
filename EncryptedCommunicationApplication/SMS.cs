using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

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
        private void threadSMSReceive()
        {
            NamedPipeServerStream pipeReceive = new NamedPipeServerStream("pipeReceive", PipeDirection.InOut);
           
            pipeReceive.WaitForConnection();

            StreamReader SMSread = new StreamReader(pipeReceive);

            richTextBox1.AppendText(textBox2.Text + ": " + SMSread.ReadLine() + "\n");

            pipeReceive.Close();

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
            Thread SMSreceive = new Thread(new ThreadStart(threadSMSReceive));
            SMSreceive.Start();
            // Execute thread (to receive SMS) in order to prevent the application from freezing (while waiting for received SMS.)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
