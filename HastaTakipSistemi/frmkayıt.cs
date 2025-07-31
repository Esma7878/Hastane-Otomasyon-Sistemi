using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaTakipSistemi
{
    public partial class frmkayıt : Form
    {
        public frmkayıt()
        {
            InitializeComponent();
        }
        FrmSqlBağlantı bgl = new FrmSqlBağlantı();
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKAYIT_Click(object sender, EventArgs e)
        {
            if(txtKullanıcıAdi.Text != "" && txtŞifre.Text !="" )
            {
                SqlCommand kayit = new SqlCommand("kayitOl",bgl.baglan());
                kayit.CommandType = CommandType.StoredProcedure;
                kayit.Parameters.AddWithValue("kullanıcıAdı",txtKullanıcıAdi.Text);
                kayit.Parameters.AddWithValue("sifre",txtŞifre.Text);
                kayit.ExecuteNonQuery();
                MessageBox.Show("Kayıt İşlemi Başarılı","Kayıt Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmkayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
