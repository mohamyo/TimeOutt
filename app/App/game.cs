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
    public partial class game : Form
    {
        private string MyUsername;
        private SqlConnection sqlcon ;

        public game(string MyUsername)
        {
            this.MyUsername = MyUsername;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            label1.Text = "HI " + MyUsername;
            sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from [level] Where username = '"+ MyUsername + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                label2.Text = "your level is :" + (dtbl.Rows[0])["level"].ToString();
            }
             query = "Select * from [Frinds] Where username2 = '" + MyUsername + "' and re = '" + 0 + "'";
             sda = new SqlDataAdapter(query, sqlcon);
             dtbl = new DataTable();
             sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                label3.Text = dtbl.Rows.Count.ToString();
            }
            else {
                button4.Hide();
            }
        }
     
        private void button3_Click(object sender, EventArgs e)
        {
            AddPlayer p = new AddPlayer(MyUsername);
            p.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindFrinds a = new FindFrinds(MyUsername);
            a.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestFrinds re = new RequestFrinds(MyUsername);
            re.ShowDialog();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_page h = new Home_page();
            h.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void game_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
