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
    public partial class Form5 : Form
    {
        static string constring = "Data Source=DESKTOP-2ELKNEJ\\SQLEXPRESS;Initial Catalog=kullanici_data;Integrated Security=True; MultipleActiveResultSets=True";
        SqlConnection connect = new SqlConnection(constring);
        public Form5()
        {
            SqlCommand command;

            InitializeComponent();
            this.CenterToScreen();
            connect.Open();
            command = new SqlCommand("select * from satin_gecmis where kullanici_nick='"+Form3.id_login+"'", connect);
            SqlDataAdapter sda = new SqlDataAdapter("select * from satin_gecmis where kullanici_nick='" + Form3.id_login + "'", connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row["ayaknumara"].ToString());
                listBox2.Items.Add(row["fiyat"].ToString());
                listBox3.Items.Add(row["adres"].ToString());
                listBox4.Items.Add(row["urun_id"].ToString());
            }

            
            
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
