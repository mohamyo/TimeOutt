using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void delete_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home_page home = new Home_page();
            home.Show();
            this.Close();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            string query = "Select * from [Table] Where email = '" + textBox1.Text.Trim() + "' and pass = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                 query = "delete from [Table] Where username = '" + textBox1.Text.Trim() + "' and pass = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, sqlcon);
                SDA.SelectCommand.ExecuteNonQuery();
                 MessageBox.Show("your account deleted from the system!!!"); 
            }
            else {
                    MessageBox.Show("the email or password is not corected!!!"); 
                }
            sqlcon.Close();
            DeleteFrinds();
            DeleteLevel();

        }
        private void DeleteFrinds() {
            sqlcon.Open();
            string query1 = "DELETE FROM [Frinds] WHERE username1 = '" + textBox1.Text.Trim()+ "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();

            string query2 = "DELETE FROM [Frinds] WHERE username2 = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query2, sqlcon);
            sda1.SelectCommand.ExecuteNonQuery();

            sqlcon.Close();
        }
        private void DeleteLevel() {
            sqlcon.Open();
            string query1 = "DELETE FROM [level] WHERE username = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();

                       sqlcon.Close();

        }
    }
}
