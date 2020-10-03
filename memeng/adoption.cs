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
    public partial class adoption : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public adoption()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new userlandingpage().Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new petownercs().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new petlist().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new inventory().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            new shelter().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from adoption");
            cmd.Connection = con;
            textBox1.Text = "D00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void DisplayAllAdoption()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayAllAdoption");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "adoption");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void ClearInput()
        {
            textBox1.Clear();
            comboBox1.Text =" ";
            comboBox3.Text = " ";
            textBox4.Clear();
            textBox5.Clear();
        }
        private void adoption_Load(object sender, EventArgs e)
        {
            DisplayAllAdoption();
            autoBookNumber();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertAdoption");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@date", textBox5.Text);
           
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayAllAdoption();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteAdoption");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayAllAdoption();
                ClearInput();
                autoBookNumber();


            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
        }
    }
}
