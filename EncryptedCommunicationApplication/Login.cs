using MySql.Data.MySqlClient;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        // If login button was clicked, execute below indented code
        {
            MySqlConnection connectionSQL = new MySqlConnection("server=127.0.0.1;database=databaseapplication;uid=root;password=backdoor");
            // Configure SQL connection 
            connectionSQL.Open();
            // Open connection to configured database

            string stringQueryUserID = "SELECT userID FROM user WHERE username = @username and password = @password";
            // String query that selects user ID from users with username/password that matches input

            MySqlCommand querySQLUserID = new MySqlCommand(stringQueryUserID, connectionSQL);
            // Create query using string

            querySQLUserID.Parameters.AddWithValue("@username", richTextBox1.Text);
            querySQLUserID.Parameters.AddWithValue("@password", richTextBox2.Text);
            // Configure username and password inputs for query (username, and password)

            if(querySQLUserID.ExecuteScalar() != null)
            // If a user exists with the username, and password inputted (within the user table, located in the database) then execute the below indented code
            {
                Home home = new Home();
                this.Hide();
                // Close current window
                home.Show();
                // Display home window
            }
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
