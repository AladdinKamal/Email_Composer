using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Email_Composer
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Select();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\tEmail Composer v1.2\n\n This program currently supports google and yahoo accounts only.");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text.Contains("@Example.com"))
                textBox4.Clear();
            if (darkModeToolStripMenuItem.Selected == true)
            {
                textBox4.ForeColor = Color.White;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "Account@Example.com";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "XxxxxxxX")
                textBox5.Clear();
            if (darkModeToolStripMenuItem.Selected == true)
            {
                textBox5.ForeColor = Color.White;
            }
            else
            {
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                textBox5.ForeColor = Color.Gray;
                textBox5.Text = "XxxxxxxX";
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("@Example.com"))
                textBox1.Clear();
            if (darkModeToolStripMenuItem.Selected == true)
            {
                textBox1.ForeColor = Color.White;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Account1@Example.com ; Account2@Example.com";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Some fields are empty, please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!textBox1.Text.Contains("@") || !textBox4.Text.Contains("@") || !textBox1.Text.Contains(".") || !textBox4.Text.Contains("."))
            {
                MessageBox.Show("Sender or recipients accounts are incorrect", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    button1.Enabled = false;
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(textBox4.Text);
                    message.Subject = textBox2.Text;
                    message.Body = textBox3.Text;
                    foreach (string s in textBox1.Text.Trim().Split(';'))
                    {
                        message.To.Add(s);
                    }
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new NetworkCredential(textBox4.Text, textBox5.Text);

                    if (textBox4.Text.Contains("gmail") || textBox4.Text.Contains("Gmail"))
                    {
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                    }
                    else if (textBox4.Text.Contains("yahoo") || textBox4.Text.Contains("Yahoo"))
                    {
                        client.Host = "smtp.mail.yahoo.com";
                        client.Port = 465;
                    }
                    else
                    {
                        MessageBox.Show("Only gmail and yahoo accounts are supported.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button1.Enabled = true;
                        return;
                    }

                    client.EnableSsl = true;
                    client.Send(message);
                    MessageBox.Show("Message was sent successfully", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("\tThere was an error sending the message.\nPlease make sure you entered account information correctly.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    button1.Enabled = true;
                }
            }
        }

        private void lightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darkModeToolStripMenuItem.Checked = false;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label1.BackColor = SystemColors.Control;
            label2.BackColor = SystemColors.Control;
            label3.BackColor = SystemColors.Control;
            label4.BackColor = SystemColors.Control;
            label5.BackColor = SystemColors.Control;
            button1.ForeColor = Color.Black;
            button1.BackColor = SystemColors.Control;
            if (textBox1.Text.Contains("@Example.com"))
                textBox1.ForeColor = Color.Gray;
            else
                textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;
            if (textBox4.Text.Contains("@Example.com"))
                textBox4.ForeColor = Color.Gray;
            else
                textBox4.ForeColor = Color.Black;
            if (textBox5.Text == "XxxxxxxX")
                textBox5.ForeColor = Color.Gray;
            else
                textBox5.ForeColor = Color.Black;
            textBox1.BackColor = SystemColors.Window;
            textBox2.BackColor = SystemColors.Window;
            textBox3.BackColor = SystemColors.Window;
            textBox4.BackColor = SystemColors.Window;
            textBox5.BackColor = SystemColors.Window;
            modeToolStripMenuItem.ForeColor = Color.Black;
            modeToolStripMenuItem.BackColor = SystemColors.Control;
            lightModeToolStripMenuItem.ForeColor = Color.Black;
            darkModeToolStripMenuItem.ForeColor = Color.Black;
            lightModeToolStripMenuItem.BackColor = SystemColors.Control;
            darkModeToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.ForeColor = Color.Black;
            aboutToolStripMenuItem.BackColor = SystemColors.Control;
            exitToolStripMenuItem1.ForeColor = Color.Black;
            exitToolStripMenuItem1.BackColor = SystemColors.Control;
            groupBox1.ForeColor = Color.Black;
            groupBox1.BackColor = SystemColors.Control;
            panel1.BackColor = SystemColors.Control;
            menuStrip1.BackColor = SystemColors.Control;
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightModeToolStripMenuItem.Checked = false;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            label2.BackColor = Color.Black;
            label3.BackColor = Color.Black;
            label4.BackColor = Color.Black;
            label5.BackColor = Color.Black;
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Black;
            if (textBox1.Text.Contains("@Example.com"))
                textBox1.ForeColor = Color.Gray;
            else
                textBox1.ForeColor = Color.White;
            textBox2.ForeColor = Color.White;
            textBox3.ForeColor = Color.White;
            if (textBox4.Text.Contains("@Example.com"))
                textBox4.ForeColor = Color.Gray;
            else
                textBox4.ForeColor = Color.White;
            if (textBox5.Text == "XxxxxxxX")
                textBox5.ForeColor = Color.Gray;
            else
                textBox5.ForeColor = Color.White;
            textBox1.BackColor = Color.Black;
            textBox2.BackColor = Color.Black;
            textBox3.BackColor = Color.Black;
            textBox4.BackColor = Color.Black;
            textBox5.BackColor = Color.Black;
            modeToolStripMenuItem.ForeColor = Color.White;
            modeToolStripMenuItem.BackColor = Color.Black;
            lightModeToolStripMenuItem.ForeColor = Color.White;
            darkModeToolStripMenuItem.ForeColor = Color.White;
            lightModeToolStripMenuItem.BackColor = Color.Black;
            darkModeToolStripMenuItem.BackColor = Color.Black;
            aboutToolStripMenuItem.ForeColor = Color.White;
            aboutToolStripMenuItem.BackColor = Color.Black;
            exitToolStripMenuItem1.ForeColor = Color.White;
            exitToolStripMenuItem1.BackColor = Color.Black;
            groupBox1.ForeColor = Color.White;
            groupBox1.BackColor = Color.Black;
            panel1.BackColor = Color.Black;
            menuStrip1.BackColor = Color.Black;
        }
    }
}
