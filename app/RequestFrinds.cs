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
    public partial class RequestFrinds : Form
    {
        String MYUsername;
        SqlConnection sqlcon;
        public RequestFrinds(String MYUsername)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.MYUsername = MYUsername;
            InitializeComponent();
             sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query1 = "Select * from [Frinds] Where username2 = '" + MYUsername + "' and re = '" + 0 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                foreach (DataRow row in dtbl.Rows)
                {
                    listBox1.Items.Add(row["username1"].ToString());
                }
            }
            else {
                MessageBox.Show("you not have any frinds request..");

            }

        }


        private void yes_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0) {
                String s = listBox1.SelectedItem.ToString();
                sqlcon.Open();
                String query = "INSERT INTO [Frinds](username1,username2,re) VALUES ('" + s + "','" + MYUsername + "','" + 1 + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, sqlcon);
                SDA.SelectCommand.ExecuteNonQuery();
                int x = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(x);
                string query1 = "DELETE FROM [Frinds] WHERE username1 = '" + s + "'and username2 = '" + MYUsername + "'and re = '" +0 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
                sda.SelectCommand.ExecuteNonQuery();

                string query2 = "DELETE FROM [Frinds] WHERE username1 = '" + MYUsername + "'and username2 = '" + s + "'and re = '" +0 + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query2, sqlcon);
                sda1.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();


            }
        }

        private void no_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            if (x >= 0)
            {
                String s = listBox1.SelectedItem.ToString();

                listBox1.Items.RemoveAt(x);
                sqlcon.Open();
                string query1 = "DELETE FROM [Frinds] WHERE username1 = '" + s + "'and username2 = '" + MYUsername + "'and re = '" + 0 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
                sda.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RequestFrinds_Load(object sender, EventArgs e)
        {

        }

        private void backToGame_Click(object sender, EventArgs e)
        {
            this.Close();
            game ga = new game(MYUsername);
            ga.Show();
        }
    }
}
