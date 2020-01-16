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
    public partial class Home_page : Form
    {
        public Home_page()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            log_in SignUp = new log_in();
            SignUp.Show();
            Hide();

        }
        private void button2_Click(object sender, EventArgs e)
        {

            sign_up LogIn = new sign_up();
            LogIn.Show();
            this.Hide();
        }

           private void button3_Click(object sender, EventArgs e)
        {
            delete deleteA = new delete();
            deleteA.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_page_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            information g = new information();
            g.Show();




        }
    }
}
