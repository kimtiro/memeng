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
    public partial class petownercs : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public petownercs()
        {
            InitializeComponent();
        }

        private void petownercs_Load(object sender, EventArgs e)
        {
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayUsers");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "users");
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateUser");
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
                cmd.Parameters.AddWithValue("@password ", textBox8.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayUsers();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                textBox12.Text = dataGridView2.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells["lastName"].FormattedValue.ToString();
                textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["firstName"].FormattedValue.ToString();
                comboBox1.Text = dataGridView2.Rows[e.RowIndex].Cells["gender"].FormattedValue.ToString();
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["birthdate"].FormattedValue.ToString();
                textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["contactnum"].FormattedValue.ToString();
                textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
                textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();

            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox12.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
            textBox3.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
            textBox4.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[5].Value.ToString();
            textBox6.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[6].Value.ToString();
            textBox7.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[7].Value.ToString();
            textBox8.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[8].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteUser");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox12.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayUsers();

            }
            catch (Exception f)
            {
                con.Close();
                MessageBox.Show(f.Message);
            }
        }
    }
}
