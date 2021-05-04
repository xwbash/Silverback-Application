using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorillaWear
{
    public partial class Form6 : Form
    {
       
        public Form6()
        {
            this.CenterToScreen();
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();

            if (gunaCheckBox1.Checked)
            {
                string adress;
                string CreditCardInfo;
                adress = adres.text;
                CreditCardInfo = "Card No: " + cardno.Text + "CCV: " + ccv.Text + "Date: " + date.Text;
                f.Ok(adress);
                this.Close();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://shrib.com/#Nehemiah4qnELB8");
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
