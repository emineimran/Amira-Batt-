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
    class İslemler
    {
        private Oyuncu oyuncu = new Oyuncu();
        Oyun aktifOyuncu = new Oyun();
        SqlConnection conn, conn2;
        private SqlDataAdapter daOyuncular;
        SqlDataAdapter daSkorlar;
        private SqlCommandBuilder cbOyuncular, cbSkorlar;
        DataSet ds;

        public İslemler()
        {

        }
        public İslemler(Oyuncu oyuncu, Oyun aktifOyuncu)
        {
            this.Oyuncu = oyuncu;
            this.AktifOyuncu = aktifOyuncu;
        }

        public Oyuncu Oyuncu
        {
            get => oyuncu;
            set => oyuncu = value;
        }

        public Oyun AktifOyuncu
        {
            get => aktifOyuncu;
            set => aktifOyuncu = value;
        }

        public bool OyuncuVeriTabanınaBağlan(bool info)
        {

            string ConnStr =
                @"Data Source=DESKTOP-PIUMP9C;Initial Catalog=Oyuncular;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnStr);
            conn.Open();

            if (info)
                MessageBox.Show(
                    "Database:" + conn.Database + "\n" +
                    "Data Source:" + conn.DataSource + "\n" +
                    "Server Version:" + conn.ServerVersion);

            if (conn.State == ConnectionState.Open)
            {
                ds = new DataSet("Oyuncularım");


                conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool OyunVeriTabanınaBağlan(bool info)
        {

            string ConnStr =
                @"Data Source=DESKTOP-PIUMP9C;Initial Catalog=Oyuncular;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn2 = new SqlConnection(ConnStr);
            conn.Open();

            if (info)
                MessageBox.Show(
                    "Database:" + conn2.Database + "\n" +
                    "Data Source:" + conn2.DataSource + "\n" +
                    "Server Version:" + conn2.ServerVersion);

            if (conn2.State == ConnectionState.Open)
            {
                ds = new DataSet("Oyunlarım");


                conn2.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void VeriTabanıKapat()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public bool OyuncuEkle(Oyuncu o)
        {

            DataRow dataRow = ds.Tables["Oyuncular"].NewRow();
            dataRow["Ad"] = o.Ad;
            dataRow["Soyad"] = o.Soyad;
            dataRow["DogumTarihi"] = o.DogumTarihi;
            dataRow["Cinsiyet"] = o.Cinsiyet;
            dataRow["E-mail"] = o.Email;
            dataRow["KullaniciAdi"] = o.KullaniciAdi;
            dataRow["Sifre"] = o.Sifre;


            try
            {
                ds.Tables["Oyuncular"].Rows.Add(dataRow);
                daOyuncular.Update(ds, "Oyuncular");
                ds.Tables["Oyuncular"].AcceptChanges();

                int sonKayıtİndeks = ds.Tables["Oyuncular"].Rows.Count - 1;
                ds.Tables["Oyuncular"].Rows[sonKayıtİndeks]["ID"] = SonEklenenKayıtID();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }

        public bool OyunculariYükle()
        {
            try
            {
                string sql = " Select * from Oyuncular";
                daOyuncular = new SqlDataAdapter(sql, conn);

                daOyuncular.Fill(ds, "Oyuncular");

                //Rows.Find yöntemini kullanmak için gerekli PK belirlenmeli
                DataColumn[] dcPk = new DataColumn[1];
                // Set Primary Key
                dcPk[0] = ds.Tables["Oyuncular"].Columns["ID"];
                dcPk[0].AutoIncrement = true;
                dcPk[0].AllowDBNull = false;
                ds.Tables["Oyuncular"].PrimaryKey = dcPk;

                cbOyuncular = new SqlCommandBuilder(daOyuncular);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
        public bool OyunlariYükle()
        {
            try
            {
                string sql = " Select * from Oyun";
                daSkorlar = new SqlDataAdapter(sql, conn2);

                daSkorlar.Fill(ds, "Oyun");

                //Rows.Find yöntemini kullanmak için gerekli PK belirlenmeli
                DataColumn[] dcPk = new DataColumn[1];
                // Set Primary Key
                dcPk[0] = ds.Tables["Oyun"].Columns["OyunID"];
                dcPk[0].AutoIncrement = true;
                dcPk[0].AllowDBNull = false;
                ds.Tables["Oyun"].PrimaryKey = dcPk;

                cbSkorlar = new SqlCommandBuilder(daSkorlar);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

        }
        public Oyuncu OyuncuGiris(string kulAdi, string sfr)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string sql;
            sql = $"Select * from Oyuncular where KullaniciAdi Like '{kulAdi}' AND Sifre Like '{sfr}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable aramaSonucu = new DataTable();

            aramaSonucu.Load(reader);

            conn.Close();
            if (aramaSonucu.Rows.Count == 1)
            {
                Oyuncu yeniKisi = new Oyuncu((int) aramaSonucu.Rows[0][0], (string) aramaSonucu.Rows[0]["Ad"],
                    (string) aramaSonucu.Rows[0]["Soyad"], (DateTime) aramaSonucu.Rows[0]["DogumTarihi"],
                    (bool) aramaSonucu.Rows[0]["Cinsiyet"], (string) aramaSonucu.Rows[0]["E-mail"],
                    (string) aramaSonucu.Rows[0]["KullaniciAdi"], (string) aramaSonucu.Rows[0]["Sifre"]);
                return yeniKisi;
            }

            Oyuncu bos = new Oyuncu();
            bos.OyuncuID = -1;
            return bos;

        }

        public bool Giris(Oyuncu o)
        {
            if (o.OyuncuID != -1)
            {
                return true;
            }

            return false;
        }

        public DataRow OyuncuGetir(Oyuncu o)
        {
            DataRow r = ds.Tables["Oyuncular"].Rows.Find(o.OyuncuID);
            return r;
        }

        public int SonEklenenKayıtID()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            string sql;
            sql = $"Select Max(ID) from Oyuncular";
            SqlCommand cmd = new SqlCommand(sql, conn);
            return (int) cmd.ExecuteScalar();


        }
        public bool OyuncuSil(int ID)
        {
            try
            {

                DataRow[] rows = ds.Tables["Oyuncular"].Select("ID=" + ID);
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    //ds.Tables["Öğrenciler"].Rows.Remove(rows[0]);

                    daOyuncular.Update(ds, "Oyuncular");
                    ds.Tables["Oyuncular"].AcceptChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return false;
        }
        public bool OyuncuGuncelle(Oyuncu o)
        {

            try
            {

                DataRow dataRow = ds.Tables["Oyuncular"].Rows.Find(o.OyuncuID);

                if (dataRow != null)
                {
                    dataRow.BeginEdit();
                    dataRow["Ad"] = o.Ad;
                    dataRow["Soyad"] = o.Soyad;
                    dataRow["DogumTarihi"] = o.DogumTarihi;
                    dataRow["Cinsiyet"] = o.Cinsiyet;
                    dataRow["E-mail"] = o.Email;
                    dataRow["KullaniciAdi"] = o.KullaniciAdi;
                    dataRow["Sifre"] = o.Sifre;
                    dataRow.EndEdit();

                    daOyuncular.Update(ds, "Oyuncular");
                    ds.Tables["Oyuncular"].AcceptChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return false;
        }
        public DataTable OyuncununSkorlarınıListele(int oyuncuId)
        {
            string ConnStr = @"Data Source=DESKTOP-PIUMP9C;Initial Catalog=Oyuncular;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnStr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                ds = new DataSet("Oyunlarım");
                conn.Close();
            }
            string sql = $"Select* from Oyun  Where ID={oyuncuId};";
            daSkorlar = new SqlDataAdapter(sql, conn);
            try
            {
                ds.Tables["Oyun"].Clear();
            }
            catch { }
            daSkorlar.Fill(ds, "Oyun");
            DataColumn[] dcPk = new DataColumn[1];
            dcPk[0] = ds.Tables["Oyun"].Columns["OyunID"];
            dcPk[0].AutoIncrement = true;
            dcPk[0].AllowDBNull = false;
            ds.Tables["Oyun"].PrimaryKey = dcPk;
            cbSkorlar = new SqlCommandBuilder(daSkorlar);
            return ds.Tables["Oyun"];
        }
        public bool SkorEkle(Oyun t)
        {
            DataRow dataRow = ds.Tables["Oyun"].NewRow();
            dataRow["ID"] = t.Id;
            dataRow["Tarih"] = t.Tarih;
            dataRow["Skor"] = t.Skor;

            try
            {
                ds.Tables["Oyun"].Rows.Add(dataRow);
                daSkorlar.Update(ds, "Oyun");
                ds.Tables["Oyun"].AcceptChanges();
                int sonKayıtİndeks = ds.Tables["Oyun"].Rows.Count - 1;
                ds.Tables["Oyun"].Rows[sonKayıtİndeks]["ID"] = OyunSonEklenenKayıtID();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        public int OyunSonEklenenKayıtID()
        {
            if (conn2.State == ConnectionState.Closed)
                conn2.Open();

            string sql;
            sql = $"Select Max(ID) from Oyun";
            SqlCommand cmd = new SqlCommand(sql, conn2);
            return (int)cmd.ExecuteScalar();


        }
        public bool SkorSil(int ID)
        {
            try
            {
                DataRow dataRow = ds.Tables["Oyun"].Rows.Find(aktifOyuncu.Id);
                if (dataRow != null)
                {
                    dataRow.Delete();

                    daSkorlar.Update(ds, "Oyun");
                    ds.Tables["Oyun"].AcceptChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return false;
        }

       

        /*public Oyuncu OyuncuOluştur(int id)
      {
          DataRow row = ds.Tables["Oyuncular"].Rows.Find(id);
          if (row != null)
          {
              Oyuncu yeniKisi = new Oyuncu((int)row[0], (string)row["Ad"], (string)row["Soyad"], (DateTime)row["DogumTarihi"],
                  (bool)row["Cinsiyet"], (string)row["E-mail"], (string)row["KullaniciAdi"], (string)row["Sifre"]);
              return yeniKisi;
          }

          return null;
      }

      public int OyuncuSırasıBul(int id)
      {
          DataRow row = ds.Tables["Oyuncular"].Rows.Find(id);
          if (row != null)
          {
              return ds.Tables["Oyuncular"].Rows.IndexOf(row);
          }

          return -1;
      }
      public DataRow OyuncuGetir(int i)
      {
          DataRow r = ds.Tables["Oyuncular"].Rows[i];


          return r;
      }


      public int OyuncuSayısı()
      {
          return ds.Tables["Oyuncular"].Rows.Count;
      }

      public DataTable OyuncuAra(string aramaMetni)
      {
          if (conn.State == ConnectionState.Closed)
              conn.Open();

          string sql;
          sql = $"Select * from Oyuncular where Ad Like '%{aramaMetni}%' OR Soyad Like '%{aramaMetni}%' OR KullaniciAdi Like '%{aramaMetni}%'";
          SqlCommand cmd = new SqlCommand(sql, conn);
          SqlDataReader reader = cmd.ExecuteReader();
          DataTable aramaSonucu = new DataTable();

          aramaSonucu.Load(reader);

          conn.Close();
          return aramaSonucu;
      }
      public bool kisiGuncelle(Oyuncu o)
      {
          if (conn.State == ConnectionState.Closed)
              conn.Open();

          string sql = $"Update Kisiler Set Ad='{o.Ad}', Soyad='{o.Soyad}' Where ID={o.OyuncuID};";

          SqlCommand cmd = new SqlCommand(sql, conn);

          if (cmd.ExecuteNonQuery() == 1)
              return true;
          else
              return false;
      }
      */
    }
}
