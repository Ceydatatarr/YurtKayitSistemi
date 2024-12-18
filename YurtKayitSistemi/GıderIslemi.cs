using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YurtKayitSistemi
{
   public abstract class GıderIslemi
    {
        protected SqlConnection baglanti;

        public GıderIslemi(SqlConnection connection)
        {
            baglanti = connection;
        }
        public abstract void Guncelle(Dictionary<string, string> giderDegerleri);


    }
}
