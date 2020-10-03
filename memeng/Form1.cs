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
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"); public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new UserRegistration().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new donation().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new adoptionuser().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(*) from users where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'");
            cmd.Connection = con;
            // cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                User.Firstname = textBox2.Text;
                new userlandingpage().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials!!!");
            }
            con.Close();
            User.Firstname = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            new adminlandingpage().Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            User.Firstname = textBox2.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
