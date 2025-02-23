using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public partial class registrationForm : Form
    {
        string connectionString = "Server=localhost;Database=dora_pizza;Uid=root;Pwd=;SslMode=None;";

        public registrationForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string address = txtAddress.Text;
            string phoneNo = txtPhoneNo.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate required fields
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Validate Email (Address)
            if (!IsValidEmail(address))  // Here address is used as email
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Validate Phone Number
            if (!IsValidPhoneNumber(phoneNo))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO users (full_name, address, phone_no, username, password) VALUES (@FullName, @Address, @PhoneNo, @Username, @Password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Address", address); // Address is used as email
                        cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful!");

                        // Go to Login Page
                        this.Hide(); // Hide the current registration form
                        loginForm loginForm = new loginForm(); // Assuming you have a LoginForm class
                        loginForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btBacktoLogin_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNo)
        {
            // Example: Only allow numeric phone numbers with at least 10 digits (you can adjust this rule as needed)
            if (string.IsNullOrWhiteSpace(phoneNo)) return false;

            // Ensure it contains only digits and has a reasonable length (like 10-15 digits)
            return phoneNo.All(char.IsDigit) && phoneNo.Length >= 10 && phoneNo.Length <= 15;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Hide the Registration Form
            loginForm loginForm = new loginForm(); // Create a new instance of LoginForm
            loginForm.Show(); // Show the Login Form
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
