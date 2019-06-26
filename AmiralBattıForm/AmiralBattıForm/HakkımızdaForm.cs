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
    public partial class HakkımızdaForm : Form
    {
        public HakkımızdaForm()
        {
            InitializeComponent();
        }

        private void HakkımızdaForm_Load(object sender, EventArgs e)
        {
            hakkimizdaLabel.Text =
                "2019 yılında en yeni bilgisayar teknolojilerini kullanarak oyuncularına dünya\nstandartlarında çözümler sunmak ilkesiyle yola çıkan emineimran.net,\nDünya ve Türkiye’ye, en büyük oyun firmalarından biri olmayı hedeflemiştir.\n" +
                "Misyonumuz sanal gerçekliği arttırarak oyun oynama zevkini doruklarda yaşatmaktır."; 

        }

        private void HakkimizdaLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
