using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Composer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email Composer v0.2");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "Account@Example.com";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                textBox5.ForeColor = Color.Gray;
                textBox5.Text = "Password";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Account@Example.com")
                textBox4.Clear();
            textBox4.ForeColor = Color.Black;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Password")
                textBox5.Clear();
            textBox5.ForeColor = Color.Black;
        }
    }
}
