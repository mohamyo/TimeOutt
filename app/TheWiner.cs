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
    public partial class TheWiner : Form
    {
        private string Winner;
        private String Winner2;
        private SqlConnection sqlcon ;
        private string le;
        private int x;
       
        public TheWiner(String Winner1,String Winner2,int x)
        {
            this.x = x;
            this.StartPosition = FormStartPosition.CenterScreen;

            if (x == 0||x==1)
            {
                this.Winner = Winner1;
                this.Winner2 = Winner2;
                InitializeComponent();
                label2.Text = Winner;
                sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
                sqlcon.Open();
                string query = "Select * from [level] Where username = '" + Winner1 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count >= 1)
                {
                    le = (dtbl.Rows[0])["level"].ToString();
                }

                query = "UPDATE  [level] set level='" + (int.Parse(le) + 1) + "' WHERE username = '" + Winner + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, sqlcon);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();
            }
            
            else if (x == 2)
            {
                Winner = Winner1;
                this.Winner2 = Winner2;
                InitializeComponent();
                label2.Text = Winner + " and " + Winner2;
                /////---player1:
                sqlcon.Open();
                string query = "Select * from [level] WHERE username = '" + Winner + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count >= 1)
                {
                    le = (dtbl.Rows[0])["level"].ToString();
                }

                query = "UPDATE  [level] set level='" + int.Parse(le) + "' WHERE username = '" + Winner + "')";
                SqlDataAdapter SDA = new SqlDataAdapter(query, sqlcon);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();
                /////---player2:

                sqlcon.Open();
                query = "Select * from [level] Where username = '" + Winner2 + "'";
                sda = new SqlDataAdapter(query, sqlcon);
                dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count >= 1)
                {
                    le = (dtbl.Rows[0])["level"].ToString();
                }

                query = "UPDATE  [level] set level='" + int.Parse(le) + "' WHERE username = '" + Winner2 + "')";
                SDA = new SqlDataAdapter(query, sqlcon);
                SDA.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();

            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                Playing y = new Playing(Winner, Winner2);
                y.Show();
            }
            else if (x == 1)
            {
                Playing y = new Playing(Winner2, Winner);
                y.Show();
            }
            else if (x == 2) {
                Playing y = new Playing(Winner, Winner2);

            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                game y = new game(Winner);
                y.Show();
            }
            else if (x == 1)
            {
                game y = new game(Winner2);
                y.Show();
            }
            else if (x == 2)
            {
                game y = new game(Winner);
                y.Show();
            }
            this.Close();
        }
    }
}
