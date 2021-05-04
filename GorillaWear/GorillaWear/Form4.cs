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
using System.Net.Mail;
namespace GorillaWear
{

    public partial class Form4 : Form
    {
        string isim_soyisim;
        static string constring = "Data Source=DESKTOP-2ELKNEJ\\SQLEXPRESS;Initial Catalog=kullanici_data;Integrated Security=True; MultipleActiveResultSets=True";
        SqlConnection connect = new SqlConnection(constring);

        public static bool is_visible = false;
        public Form4()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            guna2PictureBox1.Visible = is_visible;
            label1.Visible = is_visible;
            label2.Visible = is_visible;
            bunifuFlatButton1.Visible = false;
            if(is_visible)
            {
                bunifuFlatButton1.Visible = true;
                label3.Visible = false;
                label2.Text = ""+Form1.add_bucket_size;
                label1.Text = "" + Form1.nameofproduct;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void mailsend(String Zaman, string adress)
        {
            string Subject = ("Hello welcome to our team! Become a silverback! \n We take your order and we will be send you soon \n Order Time ; "+ Zaman + " \n Your adress ; "+ adress + " \n Product ID; "+ Form1.urun_id + " \n Price; "+ Form1.price+"$ \n Thank you for shopping with us!.");
            
            MailMessage eposta = new MailMessage();
            eposta.From = new MailAddress("deanwandsamw4ever@gmail.com");
            eposta.To.Add(Form1.mail);
            eposta.Subject = "Your purchase has been confirmed";
            eposta.Body = Subject;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("","");
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(eposta);





        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {


            Form newForm = new Form6();
            newForm.Show();
            this.Hide();


            //SizeShoe
            //Form1.nameofproduct
            //Form1.price
            //Form1.ulke
            //Form1.city
            //Form3.id_login

        }
        public void Ok(string adress)
        {
            mailsend(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), adress);
            Form1.StockDurumu -= 1;
            guna2PictureBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
            bunifuFlatButton1.Visible = false;

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string kayit = "insert into satin_gecmis(ayaknumara,fiyat,kullanici_nick,adres,urun_id) values('" + Form1.add_bucket_size + "','" + Form1.price + "','" + Form3.id_login + "','" + adress + "','" + Form1.urun_id + "')";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.ExecuteNonQuery();

                SqlCommand command;
                SqlDataReader reader;
                command = new SqlCommand("select isim, soyisim from isim  where nickname='" + Form3.id_login + "'", connect);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isim_soyisim = reader.GetString(0) + " " + reader.GetString(1);
                }
                kayit = "insert into adminside_orders(tarih,isim_soyisim,adres,urun_id,numara,mail) values(@tarih,@isim_soyisim,@adres,@urun_id,@numara,@mail)";
                komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                komut.Parameters.AddWithValue("@isim_soyisim", isim_soyisim);
                komut.Parameters.AddWithValue("@adres", adress);
                komut.Parameters.AddWithValue("@urun_id", Form1.urun_id);
                komut.Parameters.AddWithValue("@numara", Form1.add_bucket_size);
                komut.Parameters.AddWithValue("@mail", Form1.mail);


                //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',@'" + isim_soyisim + "','" + Form1.adres + "','" + Form1.mail+ "','" + Form1.urun_id + "'"+Form1.add_bucket_size+

            }
            catch (Exception hata)
            {
                MessageBox.Show("hata" + hata.Message);
            }
        }
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
