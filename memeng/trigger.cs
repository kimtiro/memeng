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
    public partial class trigger : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=memeng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        public trigger()
        {
            InitializeComponent();
        }

        private void trigger_Load(object sender, EventArgs e)
        {
            DisplayVet();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }
    }
}
