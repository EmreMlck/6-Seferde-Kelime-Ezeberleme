using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class Uygulama_Ana_Ekran : Form
    {
        public string kullaniciAdi { get; set; }
        public Uygulama_Ana_Ekran(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }

        private void Uygulama_Ana_Ekran_Load(object sender, EventArgs e)
        {      
            
        }

        private void anaEkranKullaniciGosterimi_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void butonAnaEkranCikis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 girisFormu = new Form1();
            girisFormu.Show();
           
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
           
        }

        private void butonGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            KelimeEkleme kelimeEklemeyeGec = new KelimeEkleme(kullaniciAdi);
            kelimeEklemeyeGec.FormClosed += (s, args) => this.Close();
            kelimeEklemeyeGec.Show();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Basarim basarimaGec = new Basarim(kullaniciAdi);
            basarimaGec.FormClosed += (s, args) => this.Close();
            basarimaGec.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Uygulama_Ana_Ekran_Activated(object sender, EventArgs e)
        {
            labelUstteAdGosterim.Text = "👋 Hoş Geldin " +kullaniciAdi;
        }
    }
}
