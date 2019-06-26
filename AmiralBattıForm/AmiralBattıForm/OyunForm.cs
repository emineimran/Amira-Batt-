using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AmiralBattıForm
{
    public partial class gameoverPB : Form
    {   İslemler isl=new İslemler();
        int skor = 0;
        int sayac = 0;
        Button btn;
        private int atisHakki = 60;
        int x, y;
        int[,] alan = new int[10, 10];
        int control;
        char[,] ekran = new char[10, 10];
        private string path;
        SoundPlayer player = new SoundPlayer();
       
        public gameoverPB(Oyuncu oyuncu,Oyun oyun)
        {
            InitializeComponent();
            kazandınızGrupBox.Visible = false;
            oyun.Id = oyuncu.OyuncuID;
            isl.Oyuncu=oyuncu;
            isl.AktifOyuncu = oyun;
            label3.Text = isl.Oyuncu.KullaniciAdi;
            isl.AktifOyuncu.Tarih = DateTime.Now; 
        }

        private void OyunForm_Load(object sender, EventArgs e)
        {
            isl.OyuncuVeriTabanınaBağlan(false);
            isl.OyunVeriTabanınaBağlan(false);
            isl.OyunlariYükle();
            for (int i = 0; i < alan.GetLength(0); i++)
            {
                for (int j = 0; j < alan.GetLength(1); j++)
                {
                    alan[i, j] = 0;
                }

            }

            for (int i = 0; i < ekran.GetLength(0); i++)
            {
                for (int j = 0; j < ekran.GetLength(1); j++)
                {
                    ekran[i, j] = '|';

                }
            }

            Random rnd = new Random();
            int gr, gc;
            //1 numaralı gemi tek karelik(4 tane)
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    gr = rnd.Next(1, alan.GetLength(0) - 1);
                    gc = rnd.Next(1, alan.GetLength(1) - 1);
                    control = alan[gr, gc] + alan[gr + 1, gc] + alan[gr - 1, gc] + alan[gr, gc + 1] + alan[gr, gc - 1];

                } while (control != 0);

                alan[gr, gc] = 1;

            }

            //2 numaralı gemi iki karelik(3 tane)
            for (int i = 0; i < 3; i++)
            {
                if (rnd.Next(0, 50) > 25)
                {

                    do
                    {
                        gr = rnd.Next(0, alan.GetLength(0) - 1);
                        gc = rnd.Next(1, alan.GetLength(1) - 2);
                        control = alan[gr, gc] + alan[gr, gc + 1];
                    } while (control != 0);

                    alan[gr, gc] = 2;
                    alan[gr, gc + 1] = 2;

                }
                else
                {

                    do
                    {
                        gr = rnd.Next(0, alan.GetLength(0) - 2);
                        gc = rnd.Next(1, alan.GetLength(1) - 1);
                        control = alan[gr, gc] + alan[gr + 1, gc];
                    } while (control != 0);

                    alan[gr, gc] = 2;
                    alan[gr + 1, gc] = 2;
                }
            }

            //3 numaralı gemi üç karelik(2 tane)
            for (int i = 0; i < 2; i++)
            {
                if (rnd.Next(0, 50) > 25)
                {
                    do
                    {
                        gr = rnd.Next(0, alan.GetLength(0) - 1);
                        gc = rnd.Next(1, alan.GetLength(1) - 3);
                        control = alan[gr, gc] + alan[gr, gc + 1] + alan[gr, gc + 2];
                    } while (control != 0);

                    alan[gr, gc] = 3;
                    alan[gr, gc + 1] = 3;
                    alan[gr, gc + 2] = 3;
                }
                else
                {

                    do
                    {
                        gr = rnd.Next(0, alan.GetLength(0) - 3);
                        gc = rnd.Next(1, alan.GetLength(1) - 1);
                        control = alan[gr, gc] + alan[gr + 1, gc] + alan[gr + 2, gc];
                    } while (control != 0);

                    alan[gr, gc] = 3;
                    alan[gr + 1, gc] = 3;
                    alan[gr + 2, gc] = 3;

                }
            }

            //4 numaralı gemi iki karelik(1 tane)

            if (rnd.Next(0, 50) > 25)
            {

                do
                {
                    gr = rnd.Next(0, alan.GetLength(0) - 1);
                    gc = rnd.Next(1, alan.GetLength(1) - 4);

                    control = alan[gr, gc] + alan[gr, gc + 1] + alan[gr, gc + 2] + alan[gr, gc + 3];
                } while (control != 0);

                alan[gr, gc] = 4;
                alan[gr, gc + 1] = 4;
                alan[gr, gc + 2] = 4;
                alan[gr, gc + 3] = 4;
            }
            else
            {
                do
                {
                    gr = rnd.Next(0, alan.GetLength(0) - 4);
                    gc = rnd.Next(1, alan.GetLength(1) - 1);

                    control = alan[gr, gc] + alan[gr + 1, gc] + alan[gr + 2, gc] + alan[gr + 3, gc];
                } while (control != 0);

                alan[gr, gc] = 4;
                alan[gr + 1, gc] = 4;
                alan[gr + 2, gc] = 4;
                alan[gr + 3, gc] = 4;

            }
            //for (int i = 0; i < alan.GetLength(0); i++)
            //{
            //    for (int j = 0; j < alan.GetLength(1); j++)
            //    {
            //        Button btn = new Button();
            //        btn.Height = 30;
            //        btn.Width = 30;

            //        btn.BackColor = Color.Blue;
            //        btn.Text = alan[i, j].ToString();
            //        flowLayoutPanel1.Controls.Add(btn);

            //    }
            //    Label lbl = new Label();
            //    lbl.Text = " /n";

            //}
            //while (atisHakki != 0)
            //{


            for (int i = 0; i < ekran.GetLength(0); i++)
            {
                for (int j = 0; j < ekran.GetLength(1); j++)
                {
                    btn = new Button();
                    btn.Height = 30;
                    btn.Width = 30;
                    btn.FlatStyle = FlatStyle.Flat;

                    btn.Click += new EventHandler(Btn_Click);

                    if (ekran[i, j] == '|')
                    {
                        btn.BackColor = Color.LightSeaGreen;
                        btn.Text = "";
                        flowLayoutPanel1.Controls.Add(btn);
                    }



                    else if (ekran[i, j] == 'X')
                    {
                        btn.BackColor = Color.DarkRed;
                        btn.Text = ekran[i, j].ToString();
                        flowLayoutPanel1.Controls.Add(btn);
                    }
                    else
                    {

                        btn.BackColor = Color.Green;
                        btn.Text = ekran[i, j].ToString();
                        flowLayoutPanel1.Controls.Add(btn);
                    }

                   

                }
            }
        }

        private void KapatPB_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Oyundan çıkmak istediğinize emin misiniz?", "Çıkış",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SesAcPB_Click(object sender, EventArgs e)
        {
            player.Play();
           
        }

        private void Btn_Click(object sender, EventArgs e)
        {

            atisHakkiLabel.Text = atisHakki.ToString();
            if (atisHakki != 0)
            {
                btn = (Button)sender;
                y = btn.Top / 36;
                x = btn.Left / 36;
                if (btn.Top == 3)
                {
                    y = 0;
                }

                if (btn.Left == 3)
                {
                    x = 0;
                }

                if (alan[x, y] != 0)
                {
                    ekran[x, y] = 'X';
                    sayac++;
                    skor += 100;
                }
                else
                {
                    ekran[x, y] = 'Q';
                    atisHakki--;
                    skor -= 20;

                }

                if (ekran[x, y] == 'X')
                {
                    btn.BackColor = Color.Transparent;
                    btn.Image = ımageList1.Images[7];

                    path = @"C:\Users\lenovo\Downloads\Sound effects\sesler(wav)\başarılıAtış.wav";
                    player.SoundLocation = path;
             
                }

                else
                {
                    path = @"C:\Users\lenovo\Downloads\Sound effects\sesler(wav)\boşAtış.wav";
                    player.SoundLocation = path;
                    
                }



                if (sayac == 20)
                {
                    player.Stop();
                    path = @"C:\Users\lenovo\Downloads\Sound effects\sesler(wav)\winner.wav";
                    player.SoundLocation = path;
                    atis.Visible = false;
                    atisHakkiLabel.Visible = false;
                    sesAcPB.Visible = false;
                    puanLabel.Text = skor.ToString();
                    seskapat.Visible = false; gameover.Visible = false;
                    kazandınızGrupBox.Visible = true;
                    
                }

                if (atisHakki == 0 && sayac != 20)
                {
                    seskapat.Visible = false;
                    atis.Visible = false;
                    sesAcPB.Visible = false;
                    this.BackColor=Color.Black;
                    pictureBox2.Visible = false;
                    atisHakkiLabel.Visible = false;
                    sesAcPB.Visible = false;
                    puanLabel.Text = skor.ToString();
                    kazandınızGrupBox.Visible = true;
                    player.Stop();
                    path = @"C:\Users\lenovo\Downloads\Sound effects\sesler(wav)\gameOver.wav";
                    player.SoundLocation = path;
                
               
                   
          
                    Oyun yeniOyun = new Oyun(isl.Oyuncu.OyuncuID, skor, DateTime.Now);
                    isl.SkorEkle(yeniOyun);


                }









            }
        }
    }
}