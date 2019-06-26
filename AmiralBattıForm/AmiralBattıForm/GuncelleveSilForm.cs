using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmiralBattıForm
{
    public partial class GuncelleveSilForm : Form
    {   Oyuncu oyuncu=new Oyuncu();
        İslemler islem=new İslemler();
        private int kisiID=0;
        public GuncelleveSilForm(Oyuncu aktifoyuncu)
        {
            InitializeComponent();
         
            this.oyuncu = aktifoyuncu;
            silButton.ForeColor = Color.DarkBlue;
            cikisButton.ForeColor = Color.DarkBlue;
            guncelleButton.ForeColor = Color.DarkBlue;
            sifreTxt.PasswordChar = '*';
        }
        public void OyuncuGöster()
        {
            DataRow kisi = islem.OyuncuGetir(oyuncu);

            kisiID = ((int)kisi["Id"]);

            idTxt.Text = kisiID.ToString();
            idTxt.ReadOnly = true;
            adTxt.Text = (string)kisi["Ad"];
            SoyadTxt.Text = (string)kisi["Soyad"];
            dateTimePicker1.Value = (DateTime)kisi["DogumTarihi"];
            emailTxt.Text = (string)kisi["E-mail"];

            kullaniciTxt.Text = (string)kisi["KullaniciAdi"];
            sifreTxt.Text = (string)kisi["Sifre"];
        }
        private void GuncelleveSilForm_Load(object sender, EventArgs e)
        {
            islem.OyuncuVeriTabanınaBağlan(false);
            islem.OyunculariYükle();
            OyuncuGöster();
        }

        private void GuncelleButton_Click(object sender, EventArgs e)
        {
            bool cins = true;
            if (kadinRB.Checked == true)
            {
                ErkekRB.Checked = false;
                cins = true;
            }
            else if (ErkekRB.Checked == true)
            {
                cins = false;

            }
            bool islemSonuc = islem.OyuncuGuncelle(new Oyuncu(int.Parse(idTxt.Text), adTxt.Text, SoyadTxt.Text, dateTimePicker1.Value, cins, emailTxt.Text, kullaniciTxt.Text, sifreTxt.Text));

            if (islemSonuc)
                MessageBox.Show("Güncelleme işlemi başarılı...", "Güncelleme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show("Güncelleme işlemi başarısız...", "Güncelleme", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void SilButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Kişiyi silmedne önce varsa telefonlarını siliyoruz, yok FK engeller
                //bool islemSonuc = oyuncu.KişininTelefonlarınıSil(kişiId);

                bool islemSonuc = islem.OyuncuSil(int.Parse(idTxt.Text));

                if (islemSonuc)
                { MessageBox.Show("Kayıt başarıyla silindi...", "Silme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                    Form1 f=new Form1();
                    f.ShowDialog();
                }
             
                else
                    MessageBox.Show("Kayıt silinemedi...", "Silme", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        private void CikisButton_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {
            idTxt.ReadOnly = true;
        }
    }
}
