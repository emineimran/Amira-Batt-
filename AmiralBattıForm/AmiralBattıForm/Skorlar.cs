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
    public partial class Skorlar : Form
    {
       
        İslemler i= new İslemler();
        public Skorlar(Oyun aktif)
        {
            InitializeComponent();
            this.i.AktifOyuncu = aktif;
        }

        private void Skorlar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = i.OyuncununSkorlarınıListele(i.AktifOyuncu.Id);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["OyunID"].Visible = false;
           
        }
    }
}
