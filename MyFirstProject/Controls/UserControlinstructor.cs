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
    public partial class UserControlinstructor : UserControl
    {
        public UserControlinstructor()
        {
            InitializeComponent();
            DisplayTable();
        }

        SqlConnection sc = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\thavi\OneDrive\Documents\myDschool.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public void DisplayTable()
        {
            {
                sc.Open();
                string qu = "SELECT * FROM Dinstructor";
                SqlDataAdapter ad = new SqlDataAdapter(qu, sc);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            sc.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gen = string.Empty;

            if (radioButton1.Checked)
            {
               gen = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gen = radioButton2.Text;
            }

                sc.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Dinstructor(Ins_no, Ins_Name, Date_of_Birth, Address, Gender, Tel_number) VALUES (@id, @iname, @birth, @add, @ge, @cn)", sc);

                com.Parameters.AddWithValue("@id", textBox5.Text);
                com.Parameters.AddWithValue("@iname", textBox4.Text);
                com.Parameters.AddWithValue("@birth", dateTimePicker2.Value);
                com.Parameters.AddWithValue("@add", textBox3.Text);
                com.Parameters.AddWithValue("@ge", gen);
                com.Parameters.AddWithValue("@cn", textBox2.Text);

                com.ExecuteNonQuery();
                sc.Close();
                DisplayTable();
                MessageBox.Show("Record saved successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";
            dateTimePicker2.Value = DateTime.Today;
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox2.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

                int id = int.Parse(textBox5.Text);
          
                sc.Open();
                SqlCommand co = new SqlCommand("DELETE FROM Dinstructor WHERE Ins_no = @id ", sc);

                co.Parameters.AddWithValue("@id", id);

                co.ExecuteNonQuery();
                sc.Close();
                DisplayTable();
                MessageBox.Show("Record deleted successfully!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gen = string.Empty;

            if (radioButton1.Checked)
            {
                Gen = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                Gen = radioButton2.Text;
            }

                sc.Open();
                SqlCommand up = new SqlCommand("UPDATE Dinstructor SET Ins_Name = @name, Date_of_Birth = @dob, Address = @add, Gender = @gen, Tel_number = @num WHERE Ins_no = @ide", sc);

                up.Parameters.AddWithValue("@ide", textBox5.Text);
                up.Parameters.AddWithValue("@name", textBox4.Text);
                up.Parameters.AddWithValue("@dob", dateTimePicker2.Value);
                up.Parameters.AddWithValue("@add", textBox3.Text);
                up.Parameters.AddWithValue("@gen", Gen);
                up.Parameters.AddWithValue("@num", textBox2.Text);

                up.ExecuteNonQuery();
                sc.Close();
                DisplayTable();
                MessageBox.Show("Record updated successfully!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Ins_no"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Ins_name"].Value.ToString();
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["Date_of_birth"].Value.ToString());
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();

            string gen = dataGridView1.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
            if (gen == "Male")
            {
                radioButton1.Checked = true;
            }
            else 
            {
                radioButton1.Checked = true;
            }

            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Tel_number"].Value.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
   