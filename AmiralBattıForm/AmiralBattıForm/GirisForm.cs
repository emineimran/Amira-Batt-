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
    public partial class GirisForm : Form
    {
        private int hak = 3;
    İslemler islem=new İslemler();
        public GirisForm()
        {
        
            InitializeComponent(); 
        }

        private void SifreGosterCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (sifreGosterCheck.Checked == false)
            {
                sifreTxt.PasswordChar = '*';
            }
            else
            {
                sifreTxt.PasswordChar = char.Parse("\0");
            }
        }

        private void SifreTxt_TextChanged(object sender, EventArgs e)
        {
            if (sifreGosterCheck.Checked == false)
            {
                sifreTxt.PasswordChar = '*';
            }

        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
          islem.OyuncuVeriTabanınaBağlan(false);
            islem.OyunculariYükle();
        }

        private void KapatPB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            GirisEnter();
        }

        private void GirisEnter()
        {
            string ka = kullaniciAditxt.Text.Trim().ToLower();
            string sifre = sifreTxt.Text.Trim().ToLower();

            DateTime dogumTarihi = DateTime.Now;
            bool aramasonuc;

            islem.Oyuncu = islem.OyuncuGiris(ka, sifre);
            aramasonuc = islem.Giris(islem.Oyuncu);


            if (aramasonuc == true)
            {
                MessageBox.Show("Giriş Başarılı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                islem.AktifOyuncu.Id = islem.Oyuncu.OyuncuID;
                Anaform a = new Anaform(islem.Oyuncu, islem.AktifOyuncu);
                a.ShowDialog();


            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış...", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hak--;
            }
            if (hak == 0)
            {
                MessageBox.Show("Tüm haklarınız bitti...");
                this.Close();
            }

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form yo = new YeniOyuncuForm();
            yo.ShowDialog();
        }

       
    }
}
