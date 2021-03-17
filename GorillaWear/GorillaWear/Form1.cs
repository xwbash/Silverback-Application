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
    
    public partial class Form1 : Form
    {
        public static string price;
        public static string mail;
        public static string adres;
        public static string urun_id;
        public static string add_bucket_size;
        SqlCommand command,command2;
        SqlDataReader reader,reader2;
        public static string nameofproduct;
        static string constring = "Data Source=DESKTOP-2ELKNEJ\\SQLEXPRESS;Initial Catalog=kullanici_data;Integrated Security=True; MultipleActiveResultSets=True";
        SqlConnection connect = new SqlConnection(constring);
        public static int StockDurumu;
        public Form1()
        {
            InitializeComponent();
            
            connect.Open();
            command = new SqlCommand("select urun_isim from stock", connect);
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                label3.Text = reader.GetString(0);
                nameofproduct = label3.Text;
            }
            
            command = new SqlCommand("select urun_id from stock", connect);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                urun_id = reader.GetString(0);

            }
            command = new SqlCommand("select ulke,city from adres", connect);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                adres = reader.GetString(0) + " " +reader.GetString(1);

            }
            command = new SqlCommand("select stock from stock", connect);
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                label6.Text = reader.GetString(0);
            }
            command2 = new SqlCommand("select price from stock", connect);
            reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                label8.Text = reader2.GetString(0);
            }

            command = new SqlCommand("select ID from kullanici_id where kullanici_adi='" + Form3.id_login + "'", connect);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                command2 = new SqlCommand("select isim,soyisim from isim where ID='" + reader.GetInt32(0) + "'", connect);
                reader2 = command2.ExecuteReader();
                if(reader2.Read())
                {
                    command = new SqlCommand("select mail from adres where ID='"+reader.GetInt32(0)+"'", connect);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        mail = reader.GetString(0);
                    }
                    string isim_soyisim = reader2.GetString(0) + " " + reader2.GetString(1);
                    label1.Text = isim_soyisim;
                }

            }
            else
            {
                MessageBox.Show("hata");
            }


            

            connect.Close();
            StockDurumu = Convert.ToInt32(label6.Text);
            
            gunaTransfarantPictureBox2.Visible = false;
            gunaTransfarantPictureBox1.Visible = true;
            gunaTransfarantPictureBox3.Visible = false;
            guna2GradientTileButton1.Enabled = false;
            
            Timer timer = new Timer();
            timer.Interval = (1 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            price = label8.Text;
            connect.Open();
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            
            label6.Text = "" + StockDurumu;
            string kayit = "update stock set stock='" + StockDurumu + "' where ID='" + 1 + "'";
            SqlCommand komut = new SqlCommand(kayit, connect);
            komut.Parameters.AddWithValue("@stock", label6.Text);
            komut.ExecuteNonQuery();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            gunaTransfarantPictureBox2.Visible = false;
            gunaTransfarantPictureBox1.Visible = true;
            gunaTransfarantPictureBox3.Visible = false;
        }

        private void gunaTransfarantPictureBox2_Click(object sender, EventArgs e)
        {

        }
        //label6.Text = ""+StockDurumu;

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            gunaTransfarantPictureBox2.Visible = true;
            gunaTransfarantPictureBox1.Visible = false;
            gunaTransfarantPictureBox3.Visible = false;
        }

        private void gunaTransfarantPictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            gunaTransfarantPictureBox3.Visible = true;
            gunaTransfarantPictureBox2.Visible = false;
            gunaTransfarantPictureBox1.Visible = false;
        }
        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            
            add_bucket_size = bunifuDropdown1.selectedValue;
            Form4.is_visible = true;
            


            if(StockDurumu > 1)
            {
                
            }
            else
            {
                guna2GradientTileButton1.Enabled = false;
            }


        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            if(StockDurumu > 1)
            {
                guna2GradientTileButton1.Enabled = true;
                
            }
            /*else
            {
                guna2GradientTileButton1.Enabled = false;
                StockDurumu--;
            }*/


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.24protein.com/us/gorilla-wear-melbourne-s-l-hooded-t-shirt.html"); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://www.24protein.com/us/gorilla-wear-williams-longsleeve.html");

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.24protein.com/us/gorilla-wear-boston-short-sleeve-hoodie.html"); 
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Form From5 = new Form5();
            From5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form From3 = new Form4();
            From3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
