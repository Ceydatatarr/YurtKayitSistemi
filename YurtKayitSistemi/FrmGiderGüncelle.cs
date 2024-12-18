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
    public partial class FrmGiderGüncelle : Form
    {
        private SqlConnection baglanti;
        private GiderGuncelle giderGuncelle;
        public FrmGiderGüncelle()
        {
            InitializeComponent();
            
            baglanti = new SqlConnection(@"Data Source=DESKTOP-C\SQLEXPRESS;Initial Catalog=YurtKayit;Integrated Security=True;Encrypt=False");
            giderGuncelle = new GiderGuncelle(baglanti);
        }
        public string elektrik, su, dogalgaz, gida, diger, internet, personel, id;

        //SqlBaglantim bgl = new SqlBaglantim();

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            


            Dictionary<string, string> giderVerileri = new Dictionary<string, string>()
            {
                { "Elektrik", TxtElektrik.Text },
                { "Su", TxtSu.Text },
                { "DogalGaz", TxtDogalgaz.Text },
                { "Internet", TxtInternet.Text },
                { "Gida", TxtGida.Text },
                { "Personel", TxtPersonel.Text },
                { "Diger", TxtDiger.Text },
                { "Giderid", TxtGiderid.Text },
            };
            GıderIslemi giderGuncelle = new GiderGuncelle(baglanti);
            giderGuncelle.Guncelle(giderVerileri);
        }
        
          
          
          
          
          private void TxtGiderid_Click(object sender, EventArgs e)
        {

        }

        private void FrmGiderGüncelle_Load(object sender, EventArgs e)
        {
            
            TxtGiderid.Text = id;
            TxtElektrik.Text= elektrik; 
            TxtGida.Text= gida;
            TxtSu.Text = su;
            TxtPersonel.Text= personel;
            TxtInternet.Text= internet; 
            TxtDogalgaz.Text= dogalgaz;
            TxtDiger.Text= diger;
        }
    }
}
