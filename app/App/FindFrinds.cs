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
    public partial class FindFrinds : Form
    {
        String MyUserName;
        public FindFrinds(String MyUserName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MyUserName = MyUserName;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            string username2 = textBox1.Text;
            string query = "Select * from [Table] Where username = '" + username2 +"'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl1 = new DataTable();
            sda1.Fill(dtbl1);
            if (!(dtbl1.Rows.Count >= 1))
            {
                MessageBox.Show("the user name is not in the system....");
            }
            
            else
            {
                string query1 = "Select * from [Frinds] Where username2 = '" + username2 + "' and re = '" + 1 + "'and username1='" + MyUserName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count >= 1)
                {
                    //אתם חברים מזמן
                    MessageBox.Show("You are already friends....");
                }
                else
                {
                    query1 = "Select * from [Frinds] Where username1 = '" + username2 + "' and re = '" + 1 +"'and username2='"+MyUserName+ "'";
                    sda = new SqlDataAdapter(query1, sqlcon);
                    dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count >= 1)
                    {
                        //אתם חברים מזמן
                        MessageBox.Show("You are already friends....");
                    }
                    else
                    {
                        query1 = "Select * from [Frinds] Where username2 = '" + username2 + "' and re = '" + 0 + "'and username1='"+MyUserName+"'";
                        sda = new SqlDataAdapter(query1, sqlcon);
                        dtbl = new DataTable();
                        sda.Fill(dtbl);
                        if (dtbl.Rows.Count >= 1)
                        {
                            //שלחתה לו בקשה בעבר...
                            MessageBox.Show("Sent him a request in the past (waiting to confirm)...");
                        }
                        else
                        {
                            ///נבדוק אם הוא שלח לך...
                            query1 = "Select * from [Frinds] Where username1 = '" + username2 + "' and re = '" + 0 + "'and username2='" + MyUserName + "'";
                            sda = new SqlDataAdapter(query1, sqlcon);
                            dtbl = new DataTable();
                            sda.Fill(dtbl);
                            if (dtbl.Rows.Count >= 1)
                            {
                                ///הוא כן שלח
                                sqlcon.Open();
                                query1 = "INSERT INTO [Frinds](username1,username2,re) VALUES ('" + MyUserName + "','" + username2 + "','" + 1 + "')";
                                SqlDataAdapter SDA = new SqlDataAdapter(query1, sqlcon);
                                SDA.SelectCommand.ExecuteNonQuery();
                                query1 = "delete from [Frinds] Where username1 = '" + MyUserName + "'and username2 = '" + username2 + "'and re = '" + 0 + "'";
                                SDA = new SqlDataAdapter(query1, sqlcon);
                                SDA.SelectCommand.ExecuteNonQuery();
                                query1 = "delete from [Frinds] Where username1 = '" + username2 + "'and username2 = '" + MyUserName +  "'and re = '" +0+"' ";
                                SDA = new SqlDataAdapter(query1, sqlcon);
                                SDA.SelectCommand.ExecuteNonQuery();
                                sqlcon.Close();
                            }
                            else
                            {//הוא לא שלח...
                                sqlcon.Open();
                                query1 = "INSERT INTO [Frinds](username1,username2,re) VALUES ('" + MyUserName + "','" + username2 + "','" + 0 + "')";
                                SqlDataAdapter SDA = new SqlDataAdapter(query1, sqlcon);
                                SDA.SelectCommand.ExecuteNonQuery();
                                sqlcon.Close();
                            }
                        }
                    }
                }
            }///end else
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string username2 = textBox1.Text;
            string query1 = "Select * from [Frinds] Where username1 = '" + MyUserName + "' and re = '" + 0 + "'and username2='" + username2 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            /////------
            string query22 = "Select * from [Frinds] Where username1 = '" + MyUserName + "' and re = '" + 1 + "'and username2='" + username2 + "'";
            SqlDataAdapter sda22 = new SqlDataAdapter(query22, sqlcon);
            DataTable dtbl22 = new DataTable();
            sda22.Fill(dtbl22);
            /////------
            string query222 = "Select * from [Frinds] Where username1 = '" + username2 + "' and re = '" + 1 + "'and username2='" + MyUserName + "'";
            SqlDataAdapter sda222 = new SqlDataAdapter(query222, sqlcon);
            DataTable dtbl222 = new DataTable();
            sda222.Fill(dtbl222);
            /////------

            string query21 = "Select * from [Frinds] Where username1 = '" + username2 + "' and re = '" + 0 + "'and username2='" + MyUserName + "'";
            SqlDataAdapter sda21 = new SqlDataAdapter(query21, sqlcon);
            DataTable dtbl21 = new DataTable();
            sda21.Fill(dtbl21);
            /////------

            if ((dtbl22.Rows.Count >= 1) || (dtbl222.Rows.Count >= 1)) {
                MessageBox.Show("you have delete this frinds....");
                sqlcon.Open();
                query1 = "DELETE FROM [Frinds] WHERE username1 = '" + username2 + "'and username2 = '" + MyUserName + "'";
                sda = new SqlDataAdapter(query1, sqlcon);
                sda.SelectCommand.ExecuteNonQuery();
                string query2 = "DELETE FROM [Frinds] WHERE username1 = '" + MyUserName + "'and username2 = '" + username2 + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query2, sqlcon);
                sda1.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();
            }
            
         else   if ((dtbl21.Rows.Count >= 1)) {
                MessageBox.Show("this username send you a request frinds but you dont accepted him....");

               
            }
             else  if (dtbl.Rows.Count>=1) {
                MessageBox.Show("the user dont accept you, and we canceled sending frinds....");
                sqlcon.Open();
                string query2 = "DELETE FROM [Frinds] WHERE username1 = '" + MyUserName + "'and username2 = '" + username2 + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query2, sqlcon);
                sda1.SelectCommand.ExecuteNonQuery();
                sqlcon.Close();

            }
         else   if (!(dtbl22.Rows.Count >= 1) && !(dtbl222.Rows.Count >= 1))
            {
                MessageBox.Show("No frind like this name in your list....");

            }
          
        
        }

        private void FindFrinds_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowFrindList frindslist1 = new ShowFrindList(MyUserName);
            frindslist1.ShowDialog();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            game ga = new game(MyUserName);
            ga.Show();
        }
    }
}
