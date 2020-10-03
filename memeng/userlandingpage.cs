using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memeng
{
    public partial class userlandingpage : Form
    {
        public userlandingpage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new managepet().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new adoption().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new donation().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void userlandingpage_Load(object sender, EventArgs e)
        {
            label2.Text = User.Firstname;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
