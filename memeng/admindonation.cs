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
    public partial class admindonation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public admindonation()
        {
            InitializeComponent();
        }

        private void admindonation_Load(object sender, EventArgs e)
        {
            DisplayAllDonation();
            autoBookNumber();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            new petownercs().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new petlist().Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new inventory().Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            new shelter().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new admindonation().Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            new adoption().Show();
            this.Hide();
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from donation");
            cmd.Connection = con;
            textBox1.Text = "D00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void DisplayAllDonation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayAllDonation");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "donation");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertDonation");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@address", textBox3.Text);
                cmd.Parameters.AddWithValue("@contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@amount", textBox5.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayAllDonation();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteDonation");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayAllDonation();
                ClearInput();
                autoBookNumber();


            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }
    }
}
