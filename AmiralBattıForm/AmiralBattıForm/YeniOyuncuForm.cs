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
    public partial class YeniOyuncuForm : Form
    {   Oyuncu oyuncu=new Oyuncu();
        İslemler islem=new İslemler();
        int kişiInd = 0;
        int kişiId;
        public YeniOyuncuForm()
        {
            InitializeComponent();
            kaydetButton.ForeColor = Color.DarkBlue;
            cikisButton.ForeColor = Color.DarkBlue;
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

        private void KaydetButton_Click(object sender, EventArgs e)
        {
           
            bool cins = true;
            if (kadinRB.Checked == true)
            {
                cins = true;
                ErkekRB.Enabled = false;
            }
            else if (ErkekRB.Checked == true)
            {
                cins = false;
                kadinRB.Enabled = false;
            }
            islem.OyuncuEkle(new Oyuncu(adTxt.Text, SoyadTxt.Text, dateTimePicker1.Value, cins, emailTxt.Text, kullaniciTxt.Text, sifreTxt.Text));

            MessageBox.Show("Kaydetme işlemi başarılı...\n" +
                            $"Kullanıcı adı:{kullaniciTxt.Text}\nŞifre:{sifreTxt.Text}", "Kaydet", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            adTxt.Clear(); SoyadTxt.Clear();dateTimePicker1.ResetText();emailTxt.Clear();sifreTxt.Clear();kullaniciTxt.Clear();
            kadinRB.Checked = false;
            ErkekRB.Checked = false;

        }

        private void YeniOyuncuForm_Load(object sender, EventArgs e)
        {
            islem.OyuncuVeriTabanınaBağlan(false);
            islem.OyunculariYükle();
            sifreTxt.PasswordChar = '*';
        }
    }
}
