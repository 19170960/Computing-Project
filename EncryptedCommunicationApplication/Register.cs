using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Messaging;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;

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
            int userID = 0;
            // Define unique user ID
            MySqlConnection connectionSQLQuery = new MySqlConnection("server=127.0.0.1;database=databaseapplication;uid=root;password=backdoor");
            // Configure SQL connection to MySQL database, using credentials and address
            connectionSQLQuery.Open();
            // Open SQL connection
            string stringQuerySELECT = "SELECT userID from user";
            MySqlCommand querySQLSELECT = new MySqlCommand(stringQuerySELECT, connectionSQLQuery);
            // Create query using the query string
            MySqlDataReader readerQuery = querySQLSELECT.ExecuteReader();
            while (readerQuery.Read() == true)
            {
                userID += 1;
                // Increment userID by 1, each time a user is added (ensuring all users have a unique ID.)
            }
            MySqlConnection connectionSQLInsert = new MySqlConnection("server=127.0.0.1;database=databaseapplication;uid=root;password=backdoor");
            // Configure SQL connection to MySQL database, using credentials and address
            connectionSQLInsert.Open();
            // Open SQL connection
            string stringQueryINSERT = "INSERT INTO user(userID, username, password) VALUES (@userID, @username, @password)";
            // Create string containing query that inserts values into user table
            MySqlCommand querySQLINSERT = new MySqlCommand(stringQueryINSERT, connectionSQLInsert);
            // Create query using the query string
            querySQLINSERT.Parameters.AddWithValue("@userID", userID);
            // Input userID value that is unique for each user, by adding one to the userID each time a user is added to the system.
            querySQLINSERT.Parameters.AddWithValue("@username", richTextBox1.Text);
            querySQLINSERT.Parameters.AddWithValue("@password", richTextBox2.Text);
            // Add inputted values to insert query, so they are inputted within user table

            querySQLINSERT.ExecuteNonQuery();
            // Execute the query, inserting the inputted values

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
