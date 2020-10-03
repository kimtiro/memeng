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
    
    public partial class donation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public donation()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void donation_Load(object sender, EventArgs e)
        {
            DisplayAllDonation();
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

    }
}
