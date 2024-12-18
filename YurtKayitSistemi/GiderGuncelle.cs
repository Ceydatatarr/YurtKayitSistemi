using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public class GiderGuncelle:GıderIslemi
    {
        public GiderGuncelle(SqlConnection connection) : base(connection) { }
        public override void Guncelle(Dictionary<string, string> giderDegerleri)
        {
            try
            {
                string sorgu = "update Giderler set Elektrik=@p1, Su=@p2, DogalGaz=@p3, internet=@p4, Gıda=@p5, Personel=@p6, Diger=@p7 where Odemeid=@p8";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@p1", giderDegerleri["Elektrik"]);
                komut.Parameters.AddWithValue("@p2", giderDegerleri["Su"]);
                komut.Parameters.AddWithValue("@p3", giderDegerleri["DogalGaz"]);
                komut.Parameters.AddWithValue("@p4", giderDegerleri["Internet"]);
                komut.Parameters.AddWithValue("@p5", giderDegerleri["Gida"]);
                komut.Parameters.AddWithValue("@p6", giderDegerleri["Personel"]);
                komut.Parameters.AddWithValue("@p7", giderDegerleri["Diger"]);
                komut.Parameters.AddWithValue("@p8", giderDegerleri["Giderid"]);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Giderler başarıyla güncellendi.");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
            
            
            }
        }
        




        }











    }

