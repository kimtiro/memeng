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
    public partial class petlist : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public petlist()
        {
            InitializeComponent();
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

        private void button7_Click(object sender, EventArgs e)
        {
            new addpet().Show();
            this.Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
     
        }
        private void DisplayAllPet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayAllPet");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "pet");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void petlist_Load(object sender, EventArgs e)
        {
            DisplayAllPet();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeletePet");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayAllPet();


            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdatePet");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@ownername", textBox2.Text);
                cmd.Parameters.AddWithValue("@petname", textBox9.Text);
                cmd.Parameters.AddWithValue("@birthdate", textBox10.Text);
                cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                cmd.Parameters.AddWithValue("@illness", textBox11.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayAllPet();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            comboBox2.Text = " ";
            textBox11.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ownername"].FormattedValue.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["petname"].FormattedValue.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["birthdate"].FormattedValue.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["gender"].FormattedValue.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["illness"].FormattedValue.ToString();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeletePet");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayAllPet();

            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }
    }
}
