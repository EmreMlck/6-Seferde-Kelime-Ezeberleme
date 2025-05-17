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
    public partial class KelimeEkleme : Form
    {
        public KelimeEkleme()
        {
            InitializeComponent();
        }

        private void KelimeEkleme_Load(object sender, EventArgs e)
        {

        }

        private void textBoxTurkceEkle_TextChanged(object sender, EventArgs e)
        {

        }

        private void butonKelimeEkle_Click(object sender, EventArgs e)
        {
            string en = textBoxTurkceEkle.Text.Trim();
            string tr = textBoxIngEkle.Text.Trim();

            if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(tr))
            {
                VeritabanıKelimeEkleme dbEkleme = new VeritabanıKelimeEkleme();
                dbEkleme.kelimeEkleme(en, tr);
                
            }
            else
            {
                MessageBox.Show("Kutucuklar Boş Bırakılamaz!");
            }

            textBoxTurkceEkle.Text = "";
            textBoxIngEkle.Text = "";
        }

        private void butonGirisGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran anaEkranaGec = new Uygulama_Ana_Ekran();
            anaEkranaGec.FormClosed += (s, args) => this.Close();
            anaEkranaGec.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dbJsonEkle = new Form1();
            dbJsonEkle.JsondanDbyeAktar();
        }
    }
}
