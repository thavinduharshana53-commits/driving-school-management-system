using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpassword.Text;

            if (username == "admin" && password == "123")
            {
                Form2 mm = new Form2();
                mm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("check your password or username");
                txtuser.Clear();
                txtpassword.Clear();
            }
        }

        private void shpass_CheckedChanged(object sender, EventArgs e)
        {
            if (shpass.Checked)
            {
                txtpassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;
            }
        }
    }
}
