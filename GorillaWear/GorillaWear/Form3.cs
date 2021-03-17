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
    
    public partial class Form3 : Form
    {
        static string constring = "Data Source=DESKTOP-2ELKNEJ\\SQLEXPRESS;Initial Catalog=kullanici_data;Integrated Security=True";
        SqlConnection connect = new SqlConnection(constring);

        public static string password_login, id_login;
        public Form3()
        {
            InitializeComponent();
            guna2GradientPanel2.Visible = false;
            this.CenterToScreen();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            password_login = guna2TextBox2.Text;
            id_login= guna2TextBox3.Text;
            
            connect.Open();
            SqlCommand command;
            SqlDataReader reader;

            command = new SqlCommand("select * from kullanici_id, sifreler where kullanici_adi='" + id_login+ "' and sifre='"+password_login+"'", connect);
            reader = command.ExecuteReader();

            if(reader.Read())
            {
                Form From2 = new Form2();
                From2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hata");
            }
            connect.Close();

        }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2GradientPanel2.Visible = true;
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                } 
                string kayit = "insert into kullanici_id(kullanici_adi) values(@kullanici_adi)";
                SqlCommand komut = new SqlCommand(kayit,connect);
                komut.Parameters.AddWithValue("@kullanici_adi", guna2TextBox1.Text);
                komut.ExecuteNonQuery();

                kayit = "insert into isim(isim,soyisim) values(@isim,@soyisim)";
                komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@isim", guna2TextBox9.Text);
                komut.Parameters.AddWithValue("@soyisim", guna2TextBox8.Text);
                komut.ExecuteNonQuery();


                kayit = "insert into adres(mail,ulke,city) values(@mail,@ulke,@city)";
                komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@mail", guna2TextBox5.Text);
                komut.Parameters.AddWithValue("@ulke", guna2TextBox7.Text);
                komut.Parameters.AddWithValue("@city", guna2TextBox6.Text);
                komut.ExecuteNonQuery();

                kayit = "insert into sifreler(sifre) values(@sifre)";
                komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@sifre", guna2TextBox4.Text);
                komut.ExecuteNonQuery();

                kayit = "insert into isim(nickname) values(@nickname)";
                komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@nickname", guna2TextBox1.Text);
                komut.ExecuteNonQuery();


                connect.Close();
                MessageBox.Show("Eklendi");
            }
            catch(Exception hata)
            {
                MessageBox.Show("hata" + hata.Message);
            }
                guna2GradientPanel2.Visible = false;
        }
        /*
         * guna2TextBox9 == NAME
         * guna2TextBox8 == Surname
         * guna2TextBox1 == ID
         * guna2TextBox4 == Password
         * guna2TextBox5 == E-Mail
         * guna2TextBox7 == Country
         * guna2TextBox6 == City
         */
    }
}
