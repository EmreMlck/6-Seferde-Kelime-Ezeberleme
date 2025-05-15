using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class Uygulama_Ana_Ekran : Form
    {
        public string kullaniciAdi { get; set; }
        public Uygulama_Ana_Ekran()
        {
            InitializeComponent();
        }

        private void Uygulama_Ana_Ekran_Load(object sender, EventArgs e)
        {
            labelUstteAdGosterim.Text = "Kullanıcı: " +kullaniciAdi;
        }

        private void anaEkranKullaniciGosterimi_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
