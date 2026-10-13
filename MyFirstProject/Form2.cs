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
    public partial class Form2 : Form
    {
        Controls.UserControlstudent st = new Controls.UserControlstudent();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Controls.UserControlpay pay = new Controls.UserControlpay();

            panel2.Controls.Clear();
            panel2.Controls.Add(pay);
            pay.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You Realy Want To Exit","EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(st);
            st.Dock = DockStyle.Fill;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Controls.UserControlinstructor ins = new Controls.UserControlinstructor();

            panel2.Controls.Clear();
            panel2.Controls.Add(ins);
            ins.Dock = DockStyle.Fill;
           
        }

        private void darsh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Controls.UserControlcourse cor = new Controls.UserControlcourse();

            panel2.Controls.Clear();
            panel2.Controls.Add(cor);
            cor.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void but_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
        }
    }
}
