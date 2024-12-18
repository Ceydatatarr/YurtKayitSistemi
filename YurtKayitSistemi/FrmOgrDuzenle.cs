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

namespace YurtKayitSistemi
{
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id, ad, soyad, TC, telefon, dogum, bolum;
         public string mail, odano, veliad, velitel, adres;

        SqlBaglantim bgl = new SqlBaglantim();


        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Öğrenci Silme 

            SqlCommand komutsil = new SqlCommand("delete from Ogrenci where ogrid=@k1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@k1", TxtOgrid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
         

            // Odanın Aktif Öğrenci Sayısını Azaltma

            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

       

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2,OgrSoyad=@p3,OgrTC=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelefon=@p11,OgrVeliAdres=@p12 where Ogrid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtOgrid.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MskTC.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTelefon.Text);
                komut.Parameters.AddWithValue("@p6", MskDogum.Text);
                komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
                komut.Parameters.AddWithValue("@p8", TxtMail.Text);
                komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", MskVeliTelefon.Text);
                komut.Parameters.AddWithValue("@p12", RchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi");
               
            }
            catch (Exception)
            {
                MessageBox.Show("Hata, yeniden deneyin");

            }

        }




        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            Ogrenci ogrenci = new Ogrenci
            {
                Id = id,
                Ad = ad,
                Soyad = soyad,
                Telefon = telefon,
                TC1 = TC,
                Dogum = dogum,
                Bolum = bolum,
                Mail = mail,
                Odano = odano,
                Veliad = veliad,
                Velitel = velitel,
                Adres = adres,
            };
            TxtOgrid.Text = ogrenci.Id.ToString();
            TxtOgrAd.Text = ogrenci.Ad;
            TxtOgrSoyad.Text = ogrenci.Soyad;
            MskTC.Text = ogrenci.TC1;
            MskOgrTelefon.Text = ogrenci.Telefon;
            MskDogum.Text = ogrenci.Dogum;
            CmbBolum.Text = ogrenci.Bolum;
            TxtMail.Text = ogrenci.Mail;
            CmbOdaNo.Text = ogrenci.Odano;
            TxtVeliAdSoyad.Text = ogrenci.Veliad;
            MskVeliTelefon.Text = ogrenci.Velitel;
            RchAdres.Text = ogrenci.Adres;



            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());

            }
            bgl.baglanti().Close();


            SqlCommand komut2 = new SqlCommand("Select OdaNo From Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());

            }
            bgl.baglanti().Close();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
