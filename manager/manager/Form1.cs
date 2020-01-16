using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBfrinds frinds = new DBfrinds();
            frinds.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBusers users = new DBusers();
            users.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBlevels level = new DBlevels();
            level.ShowDialog();
        }

        private void יציאה_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
