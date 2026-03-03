using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=AIKI\\SQLEXPRESS;Initial Catalog=CollegeDB; TrustServerCertificate=True;Integrated Security=True;";
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                MessageBox.Show("Connection Succesful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed:" + ex.Message);
            }

        }
    }
}
