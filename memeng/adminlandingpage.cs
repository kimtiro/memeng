﻿using System;
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
    public partial class adminlandingpage : Form
    {
        public adminlandingpage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new inventory().Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new AddVet().Show();
            this.Hide();
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void adminlandingpage_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new trigger().Show();
            this.Hide();
        }
    }
}
