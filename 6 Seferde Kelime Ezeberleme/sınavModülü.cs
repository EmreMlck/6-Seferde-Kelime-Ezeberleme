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
        int soruSayisi = KullanıcıAyarları.Ayarlar.SoruSayisi;


        public sınavModülü(string kullaniciAdi, int aktifKullaniciId, int soruSayisi)
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
            
            var tumKelimeler = KelimeYukleyici.KelimeleriYukle("C:\\Users\\HP\\Source\\Repos\\6-Seferde-Kelime-Ezeberleme\\6 Seferde Kelime Ezeberleme\\sozluk.json");

            
            var kullaniciKelimeleri = KelimeYukleyici.KullaniciKelimeleriniYukle("kullanici_kelimeleri.json");



            
            var kullaniciKelimeIdleri = kullaniciKelimeleri
                .Where(k => k.kullaniciId == kullaniciId)
                .Select(k => k.kelimeId)
                .ToList();

            
            kelimeListesi = tumKelimeler
                .Where(k => kullaniciKelimeIdleri.Contains(k.kelimeId))
                .ToList();
            
            if (kelimeListesi == null || kelimeListesi.Count == 0)
            {
                MessageBox.Show("Çalışılacak kelime bulunamadı. Lütfen önce kelime ekleyin veya filtreleri kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); 
                return;
            }


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
                sinav.SinavSonuGuncelle(this.kelimeListesi); 
                MessageBox.Show($"Sınav Bitti! Doğru: {sinav.totalDogru} / {sinav.ToplamSoruSayisi}");
                string connectionString = "Server=EmreMlck\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";
                KullaniciKelimeDurumuHelper.KullaniciKelimeleriJsonGuncelle(
      connectionString,
      "C:\\Users\\HP\\Source\\Repos\\6-Seferde-Kelime-Ezeberleme\\6 Seferde Kelime Ezeberleme\\kullanici_kelimeleri.json",
      kelimeListesi, 
      kullaniciId    
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

            // Önceki seçimlerimizi temizlemek için
            rBA.Checked = false;
            rBB.Checked = false;
            rBC.Checked = false;
            rBD.Checked = false;

            
            timer1.Stop(); // sure ayarımız
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
