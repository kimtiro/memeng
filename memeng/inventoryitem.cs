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
    public partial class inventoryitem : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public inventoryitem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new inventory().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }
        private void autoBookNumber()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) + 1 from items");
            cmd.Connection = con;
            textBox1.Text = "I00000" + cmd.ExecuteScalar().ToString();
            con.Close();
        }
        private void DisplayAllItems()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DisplayAllItems");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "items");
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }


        private void ClearInput()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertItems");
                cmd.Connection = con;
                //  cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@qty", textBox2.Text);
                cmd.Parameters.AddWithValue("@arrival", textBox3.Text);
                cmd.Parameters.AddWithValue("@price", textBox4.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();

                DisplayAllItems();
                ClearInput();
                autoBookNumber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void inventoryitem_Load(object sender, EventArgs e)
        {
            autoBookNumber();
            DisplayAllItems();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteItems");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                ClearInput();
                DisplayAllItems();
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
