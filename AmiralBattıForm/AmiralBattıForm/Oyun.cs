using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiralBattıForm
{
    public class Oyun
    {
        int id;
        int oyunID;
        int skor;
        DateTime tarih;
        public Oyun()
        {

        }
        public Oyun(int id, int skor, DateTime tarih)
        {
            this.id = id;
            this.skor = skor;
            this.tarih = tarih;
        }

        public Oyun(int id, int oyunID, int skor, DateTime tarih)
        {
            this.id = id;
            this.oyunID = oyunID;
            this.skor = skor;
            this.tarih = tarih;
        }

        public int Id { get => id; set => id = value; }
        public int OyunID { get => oyunID; set => oyunID = value; }
        public int Skor { get => skor; set => skor = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
    }
  
}
