using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AmiralBattıForm
{
    public class Oyuncu : IComparable
    {
        private string ad, soyad, kullaniciAdi, sifre, email;
        private DateTime dogumTarihi;
        private bool cinsiyet;
        private int oyuncuID;
        public Oyuncu(string ad, string soyad, DateTime dogumTarihi, bool cinsiyet, string email, string kullaniciAdi, string sifre)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
            this.email = email;
            this.dogumTarihi = dogumTarihi;
            this.cinsiyet = cinsiyet;

        }
        public Oyuncu(int id, string ad, string soyad, DateTime dogumTarihi, bool cinsiyet, string email, string kullaniciAdi, string sifre)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
            this.email = email;
            this.dogumTarihi = dogumTarihi;
            this.cinsiyet = cinsiyet;
            this.OyuncuID = id;
        }
        public Oyuncu()
        {

        }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string KullaniciAdi { get => kullaniciAdi; set => kullaniciAdi = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DogumTarihi { get => dogumTarihi; set => dogumTarihi = value; }
        public bool Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public int OyuncuID { get => oyuncuID; set => oyuncuID = value; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
