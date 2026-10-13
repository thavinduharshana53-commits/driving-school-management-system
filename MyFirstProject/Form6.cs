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
    public partial class cours : Form
    {
        public cours()
        {
            InitializeComponent();
        }

        private void input1_Click(object sender, EventArgs e)
        {
            Form2 pa = new Form2();
            pa.Show();
            this.Hide();
        }

        private void cours_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 14, FontStyle.Regular);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void but_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
