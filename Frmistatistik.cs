using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaTakipSistemi
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        FrmSqlBağlantı bgl = new FrmSqlBağlantı();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            toplamHasta();
            YasOrtalama();
            KadınSayı();
            ErkekSayı();
            ExSayı();
        }
        private void toplamHasta()
        {
            SqlCommand toplam = new SqlCommand("select count(*) from tbl_HastaBilgi2",bgl.baglan());
            SqlDataReader dr =  toplam.ExecuteReader();
            while(dr.Read())
            {
              lblToplamHasta.Text = dr[0].ToString();
            }
           
        }
        private void YasOrtalama()
        {
            SqlCommand YasOrtalama = new SqlCommand("select avg(hYas)from tbl_HastaBilgi2", bgl.baglan());
            SqlDataReader dr = YasOrtalama.ExecuteReader();
            while (dr.Read())
            {
                lblYasOrtalama.Text = dr[0].ToString();
            }

        }
        private void KadınSayı()
        {
            SqlCommand KadınSayı = new SqlCommand("select count(*) from tbl_HastaBilgi2 where hCinsiyet = 'Kadın'", bgl.baglan());
            SqlDataReader dr = KadınSayı.ExecuteReader();
            while (dr.Read())
            {
                lblKadınSayı.Text = dr[0].ToString();
            }

        }
        private void ErkekSayı()
        {
            SqlCommand ErkekSayı = new SqlCommand("select count(*) from tbl_HastaBilgi2 where hCinsiyet = 'Erkek'", bgl.baglan());
            SqlDataReader dr = ErkekSayı.ExecuteReader();
            while (dr.Read())
            {
                lblErkekSayı.Text = dr[0].ToString();
            }

        }
        private void ExSayı()
        {
            SqlCommand ExSayı = new SqlCommand("select count(*) from tbl_HastaBilgi2 where hExMi = 1", bgl.baglan());
            SqlDataReader dr = ExSayı.ExecuteReader();
            while (dr.Read())
            {
                lblExSayı.Text = dr[0].ToString();
            }

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
