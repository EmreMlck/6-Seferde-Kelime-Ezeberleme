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
        private bool ilkAcilis = true;
        public AyarlarModülü()
        {
            InitializeComponent();
            this.Load += Ayarlar_Load;
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            numericSoruSayisi.Minimum = 5;
            numericSoruSayisi.Maximum = 10;
            numericSoruSayisi.Value = KullanıcıAyarları.Ayarlar.SoruSayisi;
            ilkAcilis = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            if (ilkAcilis) return; 
            KullanıcıAyarları.Ayarlar.SoruSayisi = (int)numericSoruSayisi.Value;


        }

    }
}
