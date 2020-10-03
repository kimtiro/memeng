using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace memeng
{
    public partial class UserRegistration : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            autoBookNumber();
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from users");
            cmd.Connection = con;
            textBox12.Text = "P00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUser");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox12.Text);
                cmd.Parameters.AddWithValue("@lastName", textBox1.Text);
                cmd.Parameters.AddWithValue("@firstName", textBox2.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@birthdate", textBox3.Text);
                cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                cmd.Parameters.AddWithValue("@contactnum", textBox6.Text);
                cmd.Parameters.AddWithValue("@username", textBox7.Text);
                cmd.Parameters.AddWithValue("@password ",textBox8.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                autoBookNumber();
   
                new userlandingpage().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
               
            }
        }
    }
}
