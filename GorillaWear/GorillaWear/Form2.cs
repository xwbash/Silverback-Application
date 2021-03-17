using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GorillaWear
{
    public partial class Form2 : Form
    {
        
        int sayac = 0;
        public Form2()
        {
            
            
            this.CenterToScreen();
            InitializeComponent();
            this.BackColor = Color.Black;
            // Make the background color of form display transparently.
            this.TransparencyKey = BackColor;
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 83)
            {
                Form From1 = new Form1();
                From1.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
