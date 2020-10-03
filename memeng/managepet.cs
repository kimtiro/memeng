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
    public partial class managepet : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public managepet()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new userlandingpage().Show();
            this.Hide();
        }

        private void managepet_Load(object sender, EventArgs e)
        {
            DisplayPet();
            autoBookNumber();
            textBox2.Text = User.Firstname;
        }
        private void DisplayPet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayPet");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ownername", textBox2.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "pet");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from pet");
            cmd.Connection = con;
            textBox1.Text = "P00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertPet");
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
               
                DisplayPet();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
   

        private void button2_Click(object sender, EventArgs e)
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
                DisplayPet();
                 ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                DisplayPet();
                autoBookNumber();


            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }
        private void ClearInput()
        {
            textBox1.Clear();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DisplayPet();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
