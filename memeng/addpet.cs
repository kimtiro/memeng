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
    public partial class addpet : Form
    {
        public addpet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new adminlandingpage().Show();
            this.Hide();
        }
    }
}
