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
    public partial class UserControlpay : UserControl
    {
        public UserControlpay()
        {
            InitializeComponent();
            displaypay();
            fillcmb1();
            fillcm2();
           
        }

        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\thavi\OneDrive\Documents\myDschool.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        public void displaypay()
        {
            cn.Open();
            string se = "SELECT * FROM payment";
            SqlDataAdapter ada = new SqlDataAdapter(se,cn);
            SqlCommandBuilder cb = new SqlCommandBuilder(ada);
            DataSet ds = new DataSet();
            ada.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            cn.Close();
        }

        public void fillcmb1()
        {
            cn.Open();
            SqlCommand sc = new SqlCommand("SELECT Stu_id FROM Dstudent",cn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sc;
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Stu_id";
            cn.Close();
        }

        public void fillcm2()
        {
            cn.Open();
            SqlCommand co = new SqlCommand("SELECT Course_Name,Course_Fee FROM course",cn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = co;
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Course_Name";

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Course_Fee";
            cn.Close();
        }

        private void UserControlpay_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 14, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("tahoma",14,FontStyle.Regular);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand sql = new SqlCommand("INSERT INTO payment(student_Id,course_name,course_fee,payment_date) VALUES(@si,@cn,@cf,@pd)",cn);

            sql.Parameters.AddWithValue("@si",comboBox1.Text);
            sql.Parameters.AddWithValue("@cn", comboBox2.Text);
            sql.Parameters.AddWithValue("@cf", comboBox3.Text);
            sql.Parameters.AddWithValue("@pd", dateTimePicker2.Value);

            sql.ExecuteNonQuery();
            cn.Close();
            displaypay();

            MessageBox.Show("Record saved successfully !");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker2.Value = DateTime.Today;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand sql = new SqlCommand("UPDATE payment SET course_name = @cn, course_fee = @cf, payment_date = @pd WHERE student_Id = @si ", cn);

            sql.Parameters.AddWithValue("@si", comboBox1.Text);
            sql.Parameters.AddWithValue("@cn", comboBox2.Text);
            sql.Parameters.AddWithValue("@cf", comboBox3.Text);
            sql.Parameters.AddWithValue("@pd", dateTimePicker2.Value);

            sql.ExecuteNonQuery();
            cn.Close();
            displaypay();

            MessageBox.Show("Record updated successfully !");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["student_Id"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["course_name"].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["course_fee"].Value.ToString();
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["payment_date"].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand sql = new SqlCommand("DELETE FROM payment WHERE student_Id = @si ", cn);

            sql.Parameters.AddWithValue("@si", comboBox1.Text);
            sql.ExecuteNonQuery();
            cn.Close();
            displaypay();

            MessageBox.Show("Record deleted successfully !");
        }
    }
}
