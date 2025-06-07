using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _6_Seferde_Kelime_Ezeberleme.KullanıcıAyarları;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class AyarlarModülü : Form
    {
        public AyarlarModülü()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            numericSoruSayisi.Minimum = 5;
            numericSoruSayisi.Maximum = 10;
            numericSoruSayisi.Value = Ayarlar.SoruSayisi;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            Ayarlar.SoruSayisi = (int)numericSoruSayisi.Value;
           

        }

    }
}
