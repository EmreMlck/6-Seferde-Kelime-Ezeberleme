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
    public partial class sınavModülü : Form
    {
        private string kullaniciAdi;
        private List<Kelime> kelimeListesi;
        private SinavYonetici sinav;
        int kalanSure = 20;
        private int kullaniciId;


        public sınavModülü(string kullaniciAdi, int aktifKullaniciId)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.kullaniciId = aktifKullaniciId;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            kelimeListesi = KelimeYukleyici.KelimeleriKullaniciDurumuylaYukle(
     "sozluk.json",
     "kullanici_kelimeleri.json",
     kullaniciId
 );
            if (kelimeListesi == null || !kelimeListesi.Any())
            {
                MessageBox.Show("Kelime listesi boş veya geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sinav = new SinavYonetici(kelimeListesi ,kullaniciId);
            SonrakiSoruyuGoster();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            kelimeListesi = KelimeYukleyici.KelimeleriYukle("sozluk.json");
            gunlukQuiz.Enabled = kelimeListesi.Count >= 10;
        }

        private void tekrarQuiz_Click(object sender, EventArgs e)
        {
                kelimeListesi = KelimeYukleyici.KelimeleriYukle("sozluk.json");
                if (kelimeListesi == null || !kelimeListesi.Any())
                {
                     MessageBox.Show("Kelime listesi boş veya geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            // Tekrar quizine uygun kelimeleri seç

            var kullaniciDurum = KelimeYukleyici.KullaniciKelimeleriniYukle("kullanici_kelimeleri.json");
            var quizKelimeleri = KelimeYukleyici.TekrarQuizKelimeleriSec(kelimeListesi, kullaniciDurum);
            if (quizKelimeleri == null || !quizKelimeleri.Any())
            {
                MessageBox.Show("Tekrar quizine uygun kelime bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sinav = new SinavYonetici(quizKelimeleri ,  kullaniciId );
             tabControl1.SelectedTab = tabPage2;
             SonrakiSoruyuGoster();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kalanSure--;
            labelSayac.Text = "Kalan Süre : " + kalanSure;

            if (kalanSure == 0)
            {
                timer1.Stop();
                sinav.CevabiDegerlendir(null);
                SonrakiSoruyuGoster();
            }

        }

        private void labelSayac_Click(object sender, EventArgs e)
        {

        }
        private void SonrakiSoruyuGoster()
        {
            if (sinav.SinavBittiMi())
            {
                timer1.Stop();
                sinav.SinavSonuGuncelle(this.kelimeListesi); // <-- BURAYA EKLE
                MessageBox.Show($"Sınav Bitti! Doğru: {sinav.totalDogru} / {sinav.ToplamSoruSayisi}");
                string connectionString = "Server=DESKTOP-57KV21F;Database=kelimeEzberleme;User Id=veritabani;Password=070901;";
                KullaniciKelimeDurumuHelper.KullaniciKelimeleriJsonGuncelle(
      connectionString,
      "C:\\Users\\Ercüment Kocaoğlu\\Source\\Repos\\6-Seferde-Kelime-Ezeberleme\\6 Seferde Kelime Ezeberleme\\kullanici_kelimeleri.json",
      kelimeListesi, // sınavda kullanılan ve güncellenen kelime listesi
      kullaniciId    // aktif kullanıcı id
  );
                tabControl1.SelectedTab = tabPage1;
                return;
            }


            var soru = sinav.GuncelSoru;
            labelSoru.Text = soru.DogruKelime.ingKelimeAdi;

            if (!string.IsNullOrEmpty(soru.DogruKelime.resim))
            {
                pictureBoxSoruResmi.Load(soru.DogruKelime.resim);
            }
            else
            {
                pictureBoxSoruResmi.Image = null; 
            }

            var secenekler = soru.Secenekler;

            rBA.Text = secenekler[0];
            rBB.Text = secenekler[1];
            rBC.Text = secenekler[2];
            rBD.Text = secenekler[3];

            // Önceki seçimleri temizle
            rBA.Checked = false;
            rBB.Checked = false;
            rBC.Checked = false;
            rBD.Checked = false;

            // Zamanlayıcı ve süre ayarı
            timer1.Stop();
            kalanSure = 20;
            labelSayac.Text = "Kalan Süre : " + kalanSure;
            timer1.Start();
        }
        private void SecenekTiklandi(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            sinav.CevabiDegerlendir(btn.Text);
            SonrakiSoruyuGoster();
        }

        private void buttonSonraki_Click(object sender, EventArgs e)
        {
            if (sinav == null)
            {
                  MessageBox.Show("Lütfen önce sınavı başlatın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
             }

              string secilen = null;
             if (rBA.Checked) secilen = rBA.Text;
             else if (rBB.Checked) secilen = rBB.Text;
             else if (rBC.Checked) secilen = rBC.Text;
              else if (rBD.Checked) secilen = rBD.Text;

    if (secilen == null)
    {
        MessageBox.Show("Lütfen bir seçenek seçin.");
        return;
    }

    sinav.CevabiDegerlendir(secilen);
    SonrakiSoruyuGoster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Uygulama_Ana_Ekran anaEkran = new Uygulama_Ana_Ekran(kullaniciAdi , kullaniciId);
      
        }
    }
}
