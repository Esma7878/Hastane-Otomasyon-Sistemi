using System.Data.SqlClient;
namespace HastaTakipSistemi
{
    public class FrmSqlBağlantı
    {
        string adres = "Server=LAPTOP-89NDG9B2;Database=db_HastaneYönetim;Integrated Security=True;TrustServerCertificate=True;";
        
        public SqlConnection baglan()
        {
            SqlConnection   baglanti = new SqlConnection(adres);
            baglanti.Open();
            return baglanti;
        }

    }
}
