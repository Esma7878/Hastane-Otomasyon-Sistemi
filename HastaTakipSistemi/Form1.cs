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
namespace HastaTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FrmSqlBağlantı bgl = new FrmSqlBağlantı();
        private void btnkayıt_Click(object sender, EventArgs e)
        {
            frmkayıt fr = new frmkayıt();
            fr.Show();
        }


        private void btnGiriş_Click(object sender, EventArgs e)
        {
            if (txtKulaAdi.Text != "" && txtŞifre.Text != "")
            {
                SqlCommand giris = new SqlCommand("girisYap", bgl.baglan());
                giris.CommandType = CommandType.StoredProcedure;
                giris.Parameters.AddWithValue("kullanıcıAdı", txtKulaAdi.Text);
                giris.Parameters.AddWithValue("sifre", txtŞifre.Text);
                SqlDataReader dr = giris.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giriş İşlemi Başarılı", "Giriş İşlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAnasayfa fr = new frmAnasayfa();
                    this.Hide();
                    fr.Show();
                    
                        
                }
                else
                {
                    MessageBox.Show("Giriş İşlemi Başarısız", "Giriş İşlemi Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
