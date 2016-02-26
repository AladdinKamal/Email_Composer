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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\tEmail Composer v1.0\n\n This program current supports google and yahoo accounts only.");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Account@Example.com")
                textBox4.Clear();
            textBox4.ForeColor = Color.Black;
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
            textBox5.ForeColor = Color.Black;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                textBox5.ForeColor = Color.Gray;
                textBox5.Text = "XxxxxxxX";
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
                    foreach (string s in textBox1.Text.Split(';'))
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
    }
}
