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

namespace AmiralBattıForm
{
    public partial class Form1 : Form
    {
        private int j = 0;
        private Oyuncu oyuncu = new Oyuncu();
        Oyun aktifOyuncu = new Oyun();
        SqlConnection conn;
      
        SqlDataAdapter daSkorlar;
        private SqlCommandBuilder cbSkorlar;
        DataSet ds; İslemler isl=new İslemler();
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            topsFLP.Visible = false;

        }
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisForm g = new GirisForm();
            g.ShowDialog();
        }

        private void yeniOyuncuPB_Click(object sender, EventArgs e)
        {
            Form yo = new YeniOyuncuForm();
            yo.ShowDialog();
        }

        private void oynaPB_Click(object sender, EventArgs e)
        {

            gameoverPB of = new gameoverPB(oyuncu,aktifOyuncu);
            of.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (i % 2 == 0)
            {
                oynaPB.Visible = false;
                label1.Text = "Amiral Battı oyunu 10'ar gemilik donanma yapılan bir  deniz savaşı oyunudur.\nButonlara tıklayarak düşman gemilerinin yerini tek tek tespit edip hepsini \nsulara gömmelisiniz!";
                i++;
            }
            else
            {
                oynaPB.Visible = true;
                label1.Text = "";
                i++;
            }
        }
        private void kapatPB_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Kapat", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            HakkımızdaForm hf = new HakkımızdaForm();
            hf.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isl.OyuncuVeriTabanınaBağlan(false);
            isl.OyunculariYükle();
            isl.OyunVeriTabanınaBağlan(false);
            isl.OyunlariYükle();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TopPB_Click(object sender, EventArgs e)
        {
           
            j++;
            if (j%2!=0)
            {
                pictureBox3.Visible = false;
                topsFLP.Visible = true;
                string ConnStr = @"Data Source=DESKTOP-PIUMP9C;Initial Catalog=Oyuncular;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn = new SqlConnection(ConnStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    ds = new DataSet("Oyunlarım");
                    conn.Close();
                }
                string sql = $"Select TOP 5 Oyuncular.KullaniciAdi,Oyun.Skor FROM Oyun INNER JOIN Oyuncular ON " +
                             $"Oyun.ID=Oyuncular.ID ORDER BY SKOR DESC;";
                daSkorlar = new SqlDataAdapter(sql, conn);
                try
                {
                    ds.Tables["Oyun"].Clear();
                }
                catch { }

                daSkorlar.Fill(ds, "Oyun");
                cbSkorlar = new SqlCommandBuilder(daSkorlar);
                Label topLabel=new Label();
                topLabel.BackColor = Color.Transparent;
                topLabel.ForeColor = Color.DarkBlue;
                
                topLabel.Font=new Font("Segoe Print",12,FontStyle.Bold);
                topLabel.Text = "    TOP 5";
                topsFLP.Controls.Add(topLabel);
                topsFLP.Controls.Add(new Label()); topsFLP.Controls.Add(new Label()); topsFLP.Controls.Add(new Label());


                for (int k = 0; k < 5; k++)
                {   Label l=new Label();
                    l.BackColor = Color.Transparent;
                    l.ForeColor = Color.LightSkyBlue;
                   l.Font = new Font("Segoe Print", 10, FontStyle.Bold);
                    l.Text = ds.Tables["Oyun"].Rows[k][0].ToString();
                    Label skor = new Label();
                    skor.BackColor = Color.Transparent;
                    skor.ForeColor = Color.OrangeRed;
                    skor.Text = ds.Tables["Oyun"].Rows[k][1].ToString();
                    topsFLP.Controls.Add(l);
                    topsFLP.Controls.Add(skor);
                }
                
            }
            else
            {
                pictureBox3.Visible = true;
                topsFLP.Visible = false;
            }
         

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
