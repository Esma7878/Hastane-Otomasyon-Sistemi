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
using HastaTakipSistemi;

namespace HastaTakipSistemi
{
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }
        FrmSqlBağlantı bgl = new FrmSqlBağlantı();
        private object txtBolum;

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            Listele();
            durumDoldur();
            bolumDoldur();
        }
        private void Listele()
        {
            SqlCommand Liste = new SqlCommand("Listele", bgl.baglan());
            SqlDataAdapter da = new SqlDataAdapter(Liste);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }
        private void durumDoldur()
        {
            SqlCommand durum = new SqlCommand("durumDoldur",bgl.baglan());
            SqlDataAdapter da = new SqlDataAdapter(durum);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtDurum.DataSource = dt;
            txtDurum.DisplayMember = "durumAD";
            txtDurum.ValueMember = "hDurum";

        }
        private void bolumDoldur()
        {
            SqlCommand bolum = new SqlCommand("bolumDoldur", bgl.baglan());
            SqlDataAdapter da = new SqlDataAdapter(bolum);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtBölüm.DataSource = dt;
            txtBölüm.DisplayMember = "bolumAD";
            txtBölüm.ValueMember = "bolumID";

        }



        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKAYDET_Click(object sender, EventArgs e)
        {

        }

        private void btnLİSTELE_Click(object sender, EventArgs e)
        {

        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtLİSTELE_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtTEL.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtYAŞ.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtCinsiyet.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtŞikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtTarih.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            txtDurum.SelectedValue = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            txtBölüm.SelectedValue = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            lbEx.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();









        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbEvet_CheckedChanged(object sender, EventArgs e)
        {
          if(rbEvet.Checked == true)
            {
                lbEx.Text = "True";
            }
          else 
            { 
                lbEx.Text = "False"; 
            }
        }

        private void lbEx_TextChanged(object sender, EventArgs e)
        {
            if(lbEx.Text == "True")
            {
                rbEvet.Checked = true;
            }
            else
            {
                rbHayır.Checked= true;
            }
        }

        private void txtKAYDET_Click(object sender, EventArgs e)
        {
            if(txtAD.Text !="" && txtDurum.Text != "" && txtŞikayet.Text != "" && txtSoyad.Text != ""&& txtBölüm.Text != "" && txtCinsiyet.Text != "" && txtYAŞ.Text != "" && txtTC.Text != "" && txtTEL.Text != "")
            {
                kaydet();
            }
            else
            {
              MessageBox.Show("Lütfen İlgili Tüm Alanları Doldurunuz.","Kayıt Başarısız",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void kaydet()
        {
            SqlCommand kaydet = new SqlCommand("kaydet", bgl.baglan());
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("ad", txtAD.Text.ToString());
            kaydet.Parameters.AddWithValue("soyad",txtSoyad.Text.ToString());
            kaydet.Parameters.AddWithValue("tc", txtTC.Text.ToString());
            kaydet.Parameters.AddWithValue("tel", txtTEL.Text);
            kaydet.Parameters.AddWithValue("yas", int.Parse(txtYAŞ.Text.ToString()));
            kaydet.Parameters.AddWithValue("cins", txtCinsiyet.Text.ToString());
            kaydet.Parameters.AddWithValue("sikayet", txtŞikayet.Text.ToString());
            if (string.IsNullOrWhiteSpace(txtTarih.Text))
            {
                kaydet.Parameters.AddWithValue("tarih", DateTime.Now);
            }
            else
            {
                kaydet.Parameters.AddWithValue("tarih", DateTime.Parse(txtTarih.Text));
            }

            kaydet.Parameters.AddWithValue("durum", txtDurum.SelectedValue);
            kaydet.Parameters.AddWithValue("bolum", txtBölüm.SelectedValue);
            if (lbEx.Text == "True")
            {
                kaydet.Parameters.AddWithValue("ex", 1);
            }
            else
            {
                kaydet.Parameters.AddWithValue("ex", 0);
            }
            kaydet.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Eklendi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void txtAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSİL_Click(object sender, EventArgs e)
        {
            sil();
        }
        private void sil()
        {
            DialogResult dr = MessageBox.Show($"{txtID.Text} numaralı kayıt silinecek. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
            SqlCommand sil = new SqlCommand("sil", bgl.baglan());
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("id",int.Parse(txtID.Text));
            sil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Silindi.", "Kayıt Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }

        }

        private void txtGÜNCELLE_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{txtID.Text} numaralı kayıt güncellenecek. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
              guncelle();
            }
               
        
        }
        private void guncelle()
        {
            SqlCommand guncelle = new SqlCommand("guncelle", bgl.baglan());
            guncelle.CommandType = CommandType.StoredProcedure;
            guncelle.Parameters.AddWithValue("id", int.Parse(txtID.Text));
            guncelle.Parameters.AddWithValue("ad", txtAD.Text.ToString());
            guncelle.Parameters.AddWithValue("soyad", txtSoyad.Text.ToString());
            guncelle.Parameters.AddWithValue("tc", txtTC.Text.ToString());
            guncelle.Parameters.AddWithValue("tel", txtTEL.Text);
            guncelle.Parameters.AddWithValue("yas", int.Parse(txtYAŞ.Text.ToString()));
            guncelle.Parameters.AddWithValue("cins", txtCinsiyet.Text.ToString());
            guncelle.Parameters.AddWithValue("sikayet", txtŞikayet.Text.ToString());
            if (string.IsNullOrWhiteSpace(txtTarih.Text))
            {
                guncelle.Parameters.AddWithValue("tarih", DateTime.Now);
            }
            else
            {
                guncelle.Parameters.AddWithValue("tarih", DateTime.Parse(txtTarih.Text));
            }

            guncelle.Parameters.AddWithValue("durum", txtDurum.SelectedValue);
            guncelle.Parameters.AddWithValue("bolum", txtBölüm.SelectedValue);
            if (lbEx.Text == "True")
            {
                guncelle.Parameters.AddWithValue("ex", 1);
            }
            else
            {
                guncelle.Parameters.AddWithValue("ex", 0);
            }
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }
        private void temizle()
        {
            txtAD.Text = "";
            txtBölüm.Text = "";
            txtCinsiyet.Text = "";
            txtDurum.Text = "";
            txtID.Text = "";
            txtŞikayet.Text = "";
            txtSoyad.Text = "";
            txtTarih.Text = "";
            txtTC.Text = "";
            txtTEL.Text = "";
            txtYAŞ.Text = "";
            rbHayır.Checked = true;
            lbEx.Text = "False";

        }

        private void txtFORMUTEMİZLE_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void txtİSTATİSTİKLER_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }
    }
}



 