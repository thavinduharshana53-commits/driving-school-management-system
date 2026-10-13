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
    public partial class UserControlstudent : UserControl
    {
        public UserControlstudent()
        {
            InitializeComponent();
            DisplayTable();
        }

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\thavi\OneDrive\Documents\myDschool.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public void DisplayTable()
        {
            
                con.Open();
                string query = "SELECT * FROM Dstudent";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                SqlCommandBuilder bui = new SqlCommandBuilder(ada);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string gen  = string.Empty;

            if ( radioButton1.Checked)
            {
                gen = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gen = radioButton2.Text;
            }

                con.Open();
                SqlCommand co = new SqlCommand("INSERT INTO Dstudent(Stu_id, Stu_name, Date_of_birth, Address, Gender, Tel_number) VALUES(@sti, @sname, @dob, @address, @gender, @tnum)", con);

                co.Parameters.AddWithValue("@sti", textBox5.Text);
                co.Parameters.AddWithValue("@sname",  textBox4.Text);
                co.Parameters.AddWithValue("@dob", dateTimePicker2.Value);
                co.Parameters.AddWithValue("@address", textBox3.Text);
                co.Parameters.AddWithValue("@gender", gen);
                co.Parameters.AddWithValue("@tnum",  textBox2.Text);

                co.ExecuteNonQuery();
                con.Close();
                DisplayTable();
                MessageBox.Show("Record saved successfully!");   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            dateTimePicker2.Value = DateTime.Today;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox2.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
                con.Open();
                SqlCommand co = new SqlCommand("DELETE FROM Dstudent WHERE Stu_id = @ide", con);

                co.Parameters.AddWithValue("@ide", textBox5.Text);

                co.ExecuteNonQuery();
                con.Close();
                DisplayTable();

                MessageBox.Show("Record deleted successfully!"); 
        }

        private void button1_Click(object sender, EventArgs e)
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

                con.Open();
                SqlCommand co = new SqlCommand("UPDATE Dstudent SET Stu_name = @sname , Date_of_birth = @dob, Address = @address, Gender = @gender, Tel_number = @tnum WHERE Stu_id = @ide ", con);

                co.Parameters.AddWithValue("@ide", textBox5.Text);
                co.Parameters.AddWithValue("@sname", textBox4.Text);
                co.Parameters.AddWithValue("@dob", dateTimePicker2.Value);
                co.Parameters.AddWithValue("@address", textBox3.Text);
                co.Parameters.AddWithValue("@gender", gen);
                co.Parameters.AddWithValue("@tnum", textBox2.Text);

                co.ExecuteNonQuery();
                con.Close();
                DisplayTable();
                MessageBox.Show("Record updated successfully!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Stu_id"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["Stu_name"].Value.ToString();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }
    }
}
