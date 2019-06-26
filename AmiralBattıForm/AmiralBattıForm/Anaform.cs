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

namespace AmiralBattıForm
{
    public partial class Anaform : Form
    {
        private int j = 0;
        private Oyuncu oyuncu = new Oyuncu();
        Oyun aktifOyuncu = new Oyun();
        SqlConnection conn;
        private SqlDataAdapter daOyuncular;
        SqlDataAdapter daSkorlar;
        private SqlCommandBuilder cbOyuncular, cbSkorlar;
        DataSet ds; İslemler isl = new İslemler();
        İslemler islem=new İslemler();
        int i = 0;

        public Anaform(Oyuncu aktifoyuncu, Oyun o)
        {
            InitializeComponent();
            o.Id = aktifoyuncu.OyuncuID;
            this.islem.Oyuncu = aktifoyuncu;
            this.islem.AktifOyuncu = o;
            o.Id = aktifoyuncu.OyuncuID;
            label1.Text = islem.Oyuncu.KullaniciAdi;
           
        }

        private void Anaform_Load(object sender, EventArgs e)
        {
            isl.OyuncuVeriTabanınaBağlan(false);
            isl.OyunculariYükle();
            isl.OyunVeriTabanınaBağlan(false);
            isl.OyunlariYükle();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void oynaPB_Click(object sender, EventArgs e)
        {
            gameoverPB of = new gameoverPB(islem.Oyuncu,islem.AktifOyuncu);
            of.ShowDialog();
        }

        private void nasilPB_Click(object sender, EventArgs e)
        {
            if (i % 2 == 0)
            {
                oynaPB.Visible = false;
                label2.Text =
                    "Amiral Battı oyunu 10'ar gemilik donanma yapılan bir  deniz savaşı oyunudur.\nButonlara tıklayarak düşman gemilerinin yerini tek tek tespit edip hepsini \nsulara gömmelisiniz!";

                i++;
            }
            else
            {
                oynaPB.Visible = true;
                label2.Text = "";
                i++;
            }
        }

        private void kapatPB_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GuncelleveSilForm gs = new GuncelleveSilForm(islem.Oyuncu);
            gs.ShowDialog();
        }

        private void skorPB_Click(object sender, EventArgs e)
        {
            Skorlar s = new Skorlar(islem.AktifOyuncu);


            s.Show();
        }

        
    }
}