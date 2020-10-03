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
    public partial class AddShelter : Form
    {
        public AddShelter()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new shelter().Show();
            this.Hide();
        }
    }
}
