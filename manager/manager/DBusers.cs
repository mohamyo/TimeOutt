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
    public partial class DBusers : Form
    {
        SqlConnection sqlcon;
        int NumOfUsers;
        public DBusers()
        {
            InitializeComponent();
            sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mohamyo\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "username";
            dataGridView1.Columns[2].Name = "email";
            dataGridView1.MultiSelect = false;
            string query = "Select * from [Table] ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            NumOfUsers = dtbl.Rows.Count;
            button3.Text = "there is :" + NumOfUsers + " users in the data base ";

            foreach (DataRow row in dtbl.Rows) {
                dataGridView1.Rows.Add(row["id"], row["username"], row["email"]);                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentCell.RowIndex;
            sqlcon.Open();
            string query = query = "delete from [Table] Where username = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();
            query = query = "delete from [Frinds] Where username1 = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() + "'";
            sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();
            query = "DELETE FROM [Frinds] WHERE username1 = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() + "'or username2 = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() + "'";
            sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();
            query = "DELETE FROM [level] WHERE username = '" + dataGridView1.Rows[index].Cells[1].Value.ToString() +"'";
            sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand.ExecuteNonQuery();
            sqlcon.Close();
            NumOfUsers = NumOfUsers - 1;
            dataGridView1.Rows.RemoveAt(index);
            button3.Text = "there is :" + NumOfUsers + " users in the data base ";

        }

        private void DBusers_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
  
        }
    }
}
