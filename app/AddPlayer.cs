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
    public partial class AddPlayer : Form
    {
        String MyUserName;
        SqlConnection sqlcon;
        public AddPlayer(String MyUserName)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.MyUserName = MyUserName;
            sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from [Frinds] Where (username1 = '" + MyUserName + "' or username2 = '" + MyUserName + "') and re = '" + 1 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            int x = 0;
            if (dtbl.Rows.Count >= 1)
            {
                foreach (DataRow row in dtbl.Rows)
                {

                    if (row["username1"].ToString() != MyUserName && row["re"].ToString() == "True")
                    {
                        listBox1.Items.Add(row["username1"].ToString());
                        x++;
                    }
                    else if (row["username1"].ToString() == MyUserName && row["re"].ToString() == "True")
                    {

                        listBox1.Items.Add(row["username2"].ToString());
                        x++;
                    }
                }
            }
            else
            {
                MessageBox.Show("no frinds played with him..");
                button1.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                String s = listBox1.SelectedItem.ToString();
                
                Log_player2 p = new Log_player2(MyUserName, s);
                p.Show();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            game g = new game(MyUserName);
            g.Show();
        }
    }
}
