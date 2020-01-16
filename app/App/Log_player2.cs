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
    public partial class Log_player2 : Form
    {
        private String myusrenmae;
        private String VsPlayer;
        public Log_player2(String myusrenmae, String VsPlayer)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.VsPlayer = VsPlayer;
            this.myusrenmae = myusrenmae;
            label2.Text = VsPlayer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from [Table] Where username = '" + VsPlayer + "' and pass = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count >= 1)
            {
                Playing p = new Playing(myusrenmae, VsPlayer);
                p.Show();
                this.Close();
            }
            else {

                MessageBox.Show("Check your password");

            }
        }

        private void Log_player2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Show();

        }
    }
}
