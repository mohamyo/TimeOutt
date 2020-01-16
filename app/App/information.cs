using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class information : Form
    {
        public information()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
       }

        private void button1_Click(object sender, EventArgs e)
        {
            Home_page a = new Home_page();
            a.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
