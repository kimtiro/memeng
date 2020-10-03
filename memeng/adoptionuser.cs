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
    public partial class adoptionuser : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public adoptionuser()
        {
            InitializeComponent();
        }

        private void adoptionuser_Load(object sender, EventArgs e)
        {
            DisplayAllDonation();
        }
        private void DisplayAllDonation()
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

        private void button3_Click(object sender, EventArgs e)
        {
            new adoptionuser().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
