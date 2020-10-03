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
    public partial class AddVet : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public AddVet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }

        private void AddVet_Load(object sender, EventArgs e)
        {
            autoBookNumber();
            DisplayVet();
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from vet");
            cmd.Connection = con;
            textBox1.Text = "V00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void DisplayVet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayVet");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "vet");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertVet");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@contactnum", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@birthdate", textBox5.Text);
                cmd.Parameters.AddWithValue("@gender", textBox6.Text);
                cmd.Parameters.AddWithValue("@university ", textBox7.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayVet();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void ClearInput(){
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear(); 
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["contactnum"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["birthdate"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["gender"].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["university"].FormattedValue.ToString();

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateVet");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@contactnum", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@birthdate", textBox5.Text);
                cmd.Parameters.AddWithValue("@gender", textBox6.Text);
                cmd.Parameters.AddWithValue("@university ", textBox7.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayVet();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteVet");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayVet();
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
