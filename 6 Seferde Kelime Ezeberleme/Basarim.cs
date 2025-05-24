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
    
    public partial class Basarim : Form
    {
        private string kullaniciAdi;
        public Basarim(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }

        private void Basarim_Load(object sender, EventArgs e)
        {
            
        }

        private void butonBasarimGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran BasarimdanAnaEkrana = new Uygulama_Ana_Ekran(kullaniciAdi);
            BasarimdanAnaEkrana.FormClosed += (s, args) => this.Close();
            BasarimdanAnaEkrana.Show();
        }
    }
}
