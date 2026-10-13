using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyFirstProject.Controls
{
    public partial class UserControlcourse : UserControl
    {
        public UserControlcourse()
        {
            InitializeComponent();
            Displaydata();
            FillComboBox();
        }

        SqlConnection net = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\thavi\OneDrive\Documents\myDschool.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        

        public void Displaydata()
        {
            net.Open();
            string qur = "SELECT * FROM course";
            SqlDataAdapter add = new SqlDataAdapter(qur, net);
            SqlCommandBuilder bull = new SqlCommandBuilder(add);
            DataSet ds = new DataSet();
            add.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            net.Close();
        }

        public void FillComboBox()
        {
                net.Open();
                SqlCommand cm = new SqlCommand ("SELECT Ins_name FROM Dinstructor",net);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cm;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Ins_name";
                net.Close();
        }

        private void UserControlcourse_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 14, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("tahoma", 14, FontStyle.Regular);
        }

        private void button2_Click(object sender, EventArgs e)
        {
                net.Open();
                SqlCommand com = new SqlCommand("INSERT INTO course(Course_id,Course_Name,Course_Fee,Instructor,Duration)VALUES(@cid,@cn,@cf,@in,@du)",net);

                com.Parameters.AddWithValue("@cid", textBox3.Text);
                com.Parameters.AddWithValue("@cn", textBox1.Text);
                com.Parameters.AddWithValue("@cf", textBox2.Text);
                com.Parameters.AddWithValue("@in", comboBox2.Text);
                com.Parameters.AddWithValue("@du", comboBox1.Text);

                com.ExecuteNonQuery();
                net.Close();
                Displaydata();
                MessageBox.Show("Record saved successfully!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
                int id = int.Parse(textBox3.Text);

                net.Open();
                SqlCommand com = new SqlCommand("DELETE FROM course WHERE Course_id = @cid", net);

                com.Parameters.AddWithValue("@cid",id);

                com.ExecuteNonQuery();
                net.Close();
                Displaydata();
                MessageBox.Show("Record deleted successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_id"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_Name"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Course_Fee"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Instructor"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Duration"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                net.Open();
                SqlCommand sc = new SqlCommand("UPDATE course SET Course_Name = @cn, Course_Fee = @cf, Instructor = @in, Duration = @du WHERE Course_id = @id", net);

                sc.Parameters.AddWithValue("@id", textBox3.Text);
                sc.Parameters.AddWithValue("@cn", textBox1.Text);
                sc.Parameters.AddWithValue("@cf", textBox2.Text);
                sc.Parameters.AddWithValue("@in", comboBox2.Text);
                sc.Parameters.AddWithValue("@du", comboBox1.Text);

                sc.ExecuteNonQuery();
                net.Close();
                Displaydata();
                MessageBox.Show("Record updated successfully!");
        }
    }
}
