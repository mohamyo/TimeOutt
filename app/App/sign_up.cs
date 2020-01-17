using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace App
{
    public partial class sign_up : Form
    {
        public sign_up()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Home_page hom = new Home_page();
            hom.Show();
            this.Hide();

            
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Waseem\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            String email1 = textBox1.Text;
            String pass2 = textBox2.Text;
            String username2 = textBox3.Text;
            if (email1 != "" && pass2 != "" && username2 != "")
            {
                string query = "Select * from [Table] Where username = '" + textBox3.Text.Trim() + "' and pass = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count >= 1)
                {
                    MessageBox.Show("your account in the system!!!"); ;

                }
                else
                {
                    string G = comboBox1.SelectedItem.ToString();
                    sqlcon.Open();
                    query = "INSERT INTO [Table](email,pass,username,Gander) VALUES ('" + email1 + "','" + pass2 + "','" + username2 + "','" + G + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, sqlcon);
                    SDA.SelectCommand.ExecuteNonQuery();
                    query = "INSERT INTO [level](username,level) VALUES ('" + username2 + "','" + 0 + "')";
                    SDA = new SqlDataAdapter(query, sqlcon);
                    SDA.SelectCommand.ExecuteNonQuery();
                    sqlcon.Close();
                    Application.OpenForms[0].Show();
                    this.Close();


                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
