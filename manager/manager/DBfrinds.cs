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

namespace manager
{
    public partial class DBfrinds : Form
    {
        SqlConnection sqlcon;
        public DBfrinds()
        {
            InitializeComponent();
            sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.ColumnCount = 2;
            dataGridView1.MultiSelect = false;
            dataGridView1.Columns[0].Name = "username1";
            dataGridView1.Columns[1].Name = "username2";
            string query = "Select * from [Frinds] ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            int i = 0;
            foreach (DataRow row in dtbl.Rows)
            {
                if (row["re"].Equals(true))
                {
                    dataGridView1.Rows.Add(row["username1"], row["username2"]);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                if (row["re"].Equals(false)) {
                    dataGridView1.Rows.Add(row["username1"], row["username2"]);
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                i++;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            sqlcon.Open();
            string query = "DELETE FROM [Frinds] WHERE username1 = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() + "'and username2 = '" + dataGridView1.Rows[index].Cells[0].Value.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();
            query = "DELETE FROM [Frinds] WHERE username1 = '" + dataGridView1.Rows[index].Cells[0].Value.ToString() + "'and username2 = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() + "'"; ;
            sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();
            dataGridView1.Rows.RemoveAt(index);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
