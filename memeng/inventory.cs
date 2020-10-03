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
    public partial class inventory : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public inventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
          
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from medicines");
            cmd.Connection = con;
            textBox1.Text = "M00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void DisplayAllMedicines()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayAllMedicines");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "medicines");
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
        private void button2_Click(object sender, EventArgs e)
        {
            new inventoryitem().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertMedicines");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@qty", textBox2.Text);
                cmd.Parameters.AddWithValue("@arrival", textBox3.Text);
                cmd.Parameters.AddWithValue("@expiration", textBox4.Text);
                cmd.Parameters.AddWithValue("@price", textBox5.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayAllMedicines();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            DisplayAllMedicines();
            autoBookNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteMedicines");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayAllMedicines();
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
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
        }
    }
}
