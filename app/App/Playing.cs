using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.IO;
namespace App
{
    public partial class Playing : Form
    {

        /*   private TcpClient client;
           public StreamReader STR;
           public StreamWriter STW;
           public string recieve;
           public String TextToSend;
           public String Adress; 
           private TcpListener listener;
           */
        private int value;
        public String MyUserName;
        public String VsPlayer;
        private String MyUserNameGander;
        private String VsPlayerGander;
        private int numpicPlayer1;
        private int numpicPlayer2;
        private Random rndPlayer1;
        private Random rndCardFile;
        private int rndCardInt;
        private int tourn;
        private int count;
        private SqlConnection sqlcon;

        public Playing(String MyUserName, String VsPlayer)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.MyUserName = MyUserName;
            this.VsPlayer = VsPlayer;
            label1.Text = VsPlayer;
            palyer1.Text = MyUserName;
            value = 0;
            tourn = 0;
            count = 1;
            rndPlayer1 = new Random();
            rndCardFile = new Random();

            sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Waseem\Desktop\DB\usersDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from [Table] Where username = '" + MyUserName + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl1 = new DataTable();
            sda1.Fill(dtbl1);
            if (dtbl1.Rows.Count >= 1)
            {
                MyUserNameGander = (dtbl1.Rows[0])["Gander"].ToString();
            }
            query = "Select * from [Table] Where username = '" + VsPlayer + "'";
            sda1 = new SqlDataAdapter(query, sqlcon);
            dtbl1 = new DataTable();
            sda1.Fill(dtbl1);
            if (dtbl1.Rows.Count >= 1)
            {
                VsPlayerGander = (dtbl1.Rows[0])["Gander"].ToString();
            }
            ///----
            if (MyUserNameGander == "male")
            {
                pictureBox1.Image = Properties.Resources.male;

            }
            else if (MyUserNameGander == "female") {
                pictureBox1.Image = Properties.Resources.femal;

            }
            ///------
            if (VsPlayerGander == "male")
            {
                player2.Image=Properties.Resources.male;
                
            }
            else if (VsPlayerGander == "female")
            {
                player2.Image = Properties.Resources.femal;

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Text = (value + 1).ToString();
            value++;
            if (value == 10)
            {
                UpdatePoint();
                value = 0;
                if (tourn == 1)
                {
                    tourn = 0;
                    numpicPlayer2 = rndPlayer1.Next(1, 14);
                    choosCard(numpicPlayer2);
                    tourn = 0;
                    texting.Text = VsPlayer + " your tourn";
                }
               else if (tourn == 0)
                {
                    tourn = 1;
                    numpicPlayer1 = rndPlayer1.Next(1, 14);
                    choosCard(numpicPlayer1);
                    texting.Text = MyUserName + " your tourn ";
                }
            }

         }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            value = 0;
            timer1.Start();

            if (tourn == 0) {
                numpicPlayer1 = rndPlayer1.Next(1, 14);
                choosCard(numpicPlayer1);
                //numpicPlayer1 = rndPlayer1.Next(1, 13);
                //pictureBox2.ImageLocation = string.Format(@"card\{0}.jpeg", numpicPlayer1);
                tourn = 1;
                texting.Text =MyUserName+" your tourn ";
            }

           else if (tourn == 1)
            {

                numpicPlayer2 = rndPlayer1.Next(1, 14);
                choosCard(numpicPlayer2);
               // numpicPlayer2 = rndPlayer1.Next(1, 13);
                //pictureBox2.ImageLocation = string.Format(@"card\{0}.jpeg", numpicPlayer2);
                tourn = 0;
                texting.Text = VsPlayer+ " your tourn" ;

            }
            if (count % 2 == 0) { 
             UpdatePoint();
            }
            count++;
            TheWinnerIS();

        }
        private void UpdatePoint()
        {
            if (numpicPlayer1 > numpicPlayer2) {
                button2.Text = (int.Parse(button2.Text) + 2).ToString();
            }
            if (numpicPlayer1 < numpicPlayer2)
            {
                button3.Text = (int.Parse(button3.Text) + 2).ToString();
            }
            if (numpicPlayer1 == numpicPlayer2) {
                button2.Text = (int.Parse(button2.Text) + 1).ToString();
                button3.Text = (int.Parse(button3.Text) + 1).ToString();
            }
        }

      
        private void TheWinnerIS() {
            if (int.Parse(button3.Text) >= 20 && int.Parse(button2.Text) >= 20)
            {
                timer1.Stop();
                this.Hide();
                TheWiner w = new TheWiner(MyUserName, VsPlayer,2);
                w.Show();

            }
            else if (int.Parse(button2.Text) >= 20)
            {
                timer1.Stop();
                this.Hide();
                TheWiner w = new TheWiner(MyUserName, VsPlayer,0);
                w.Show();
            }
            else if (int.Parse(button3.Text) >= 20)
            {
                timer1.Stop();
                this.Hide();
                TheWiner w = new TheWiner(VsPlayer, MyUserName, 1);
                w.Show();
            }
            
        }
        private void  choosCard(int num) {
            rndCardInt = rndCardFile.Next(1, 5);
            pictureBox2.ImageLocation = string.Format(@"{0}\{1}.JPG", rndCardInt, num);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            game n = new game(MyUserName);
            this.Close();
            n.Show();
        }

        //////////////game start:
        private void button5_Click_1(object sender, EventArgs e)
        {
            button5.Hide();
            timer1.Start();
            numpicPlayer1 = rndPlayer1.Next(1, 14);
            choosCard(numpicPlayer1);
            //pictureBox2.ImageLocation = string.Format(@"card\{0}.jpeg", numpicPlayer1);
            tourn = 1;
            texting.Text = MyUserName + " your tourn ";
            count++;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Playing_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

     

        
    }

    /*


    private void button2_Click(object sender, EventArgs e)
    {
       ///
         listener = new TcpListener(IPAddress.Any, int.Parse("8088"));
        listener.Start(); 
        client = listener.AcceptTcpClient();
        STR = new StreamReader(client.GetStream());
        STW = new StreamWriter(client.GetStream());
        STW.AutoFlush = true;

        backgroundWorker1.RunWorkerAsync();
        backgroundWorker2.WorkerSupportsCancellation = true;


    }


    private void button3_Click(object sender, EventArgs e)
    {
        client = new TcpClient();
        IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse("169.254.247.106"), int.Parse("8088"));

        try
        {
            client.Connect(IpEnd);

            if (client.Connected)
            {
                textBox1.AppendText("Connected to server" + "\n");
                STW = new StreamWriter(client.GetStream());
                STR = new StreamReader(client.GetStream());
                STW.AutoFlush = true;
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        while (client.Connected)
        {
            try
            {
                recieve = STR.ReadLine();
                this.textBox1.Invoke(new MethodInvoker(delegate ()
                {
                    textBox1.AppendText("author: " + recieve + "\n");
                }));
                recieve = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }

    private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
    {

    }

    /*private void send_Click(object sender, EventArgs e)
    {
        if (send.Text != "")
        {
            TextToSend = send.Text;
            backgroundWorker2.RunWorkerAsync();
        }
        send.Text = "";
    }*/
}
