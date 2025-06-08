using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using static _6_Seferde_Kelime_Ezeberleme.KullanıcıAyarları;
using System.Data.SqlTypes;

namespace _6_Seferde_Kelime_Ezeberleme
{
    internal class SinavYonetici
    {
        private List<Soru> Sorular;
        private int SoruIndex = 0;
        public int totalDogru = 0;
        private readonly List<int> _dogruCevaplananKullaniciKelimeIdler = new List<int>();
        public int ToplamSoruSayisi => Sorular.Count;
        public List<int> DogruCevaplananKullaniciKelimeIdler => _dogruCevaplananKullaniciKelimeIdler;
        private int kullaniciId;

        public Soru GuncelSoru => SoruIndex < Sorular.Count ? Sorular[SoruIndex] : null;

        public SinavYonetici(List<Kelime> kelimeler, int aktifKullaniciId)
        {
            this.kullaniciId = aktifKullaniciId;
            var rnd = new Random();
            var secilenler = kelimeler.OrderBy(x => rnd.Next()).Take(Ayarlar.SoruSayisi).ToList();
            _dogruCevaplananKullaniciKelimeIdler.Clear();
            Sorular = secilenler.Select(k => new Soru(k, kelimeler)).ToList();

            // --- BURAYA EKLE ---
            string jsonPath = "kullanici_kelimeleri.json";
            var json = File.ReadAllText(jsonPath);
            var kullaniciKelimeleri = JsonConvert.DeserializeObject<List<KullaniciKelimeDurumu>>(json);

            // Sadece aktif kullanıcıya ait olanlar:
            var aktifKullaniciKelimeleri = kullaniciKelimeleri.Where(x => x.kullaniciId == aktifKullaniciId).ToList();
            // ... önceki kodlar ...
            bool yeniKelimeEklendi = false;
            foreach (var kelime in kelimeler)
            {
                var eslesen = aktifKullaniciKelimeleri.FirstOrDefault(x => x.kelimeId == kelime.kelimeId);
                if (eslesen != null)
                {
                    kelime.kullaniciKelimeId = eslesen.kullaniciKelimeId;
                }
                else
                {
                    // Eksikse otomatik ekle
                    var yeni = new KullaniciKelimeDurumu
                    {
                        kullaniciKelimeId = kullaniciKelimeleri.Any() ? kullaniciKelimeleri.Max(x => x.kullaniciKelimeId) + 1 : 1,
                        kullaniciId = aktifKullaniciId,
                        kelimeId = kelime.kelimeId,
                        dogruSayisi = 0,
                        sonDogruTarihi = null,
                        ogrenildiMi = false,
                        digerTestTarihi = null
                    };
                    kullaniciKelimeleri.Add(yeni);
                    kelime.kullaniciKelimeId = yeni.kullaniciKelimeId;
                    yeniKelimeEklendi = true;
                }
            }
            // Sadece döngü bittikten sonra dosyaya yaz!
            if (yeniKelimeEklendi)
            {
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(kullaniciKelimeleri, Formatting.Indented));
            }
  
        }


        public void CevabiDegerlendir(string secilen)
        {
            var soru = GuncelSoru;
            if (soru == null) return;

            bool dogru = secilen == soru.DogruSecenek;
            if (dogru)
            {
                totalDogru++;
                if (soru.DogruKelime != null)
                {
                    soru.DogruKelime.dogruSayisi++;
                    soru.DogruKelime.sonDogruTarihi = DateTime.Now;
                }
                _dogruCevaplananKullaniciKelimeIdler.Add(soru.DogruKelime.kullaniciKelimeId);
            }
            SoruIndex++;
        }




        public bool SinavBittiMi()
        {
            return SoruIndex >= Sorular.Count;
        }

        public void DogruCevaplananlariGuncelle(List<int> dogruCevaplananKullaniciKelimeIdler)
        {
            string jsonPath = "kullanici_kelimeleri.json";
            // 1. Dosyayı bir kez oku ve listeyi al
            var kelimeListesi = JsonConvert.DeserializeObject<List<KullaniciKelimeDurumu>>(File.ReadAllText(jsonPath));

            // 2. Sadece güncellenecek id'ler üzerinde dön
            foreach (int id in dogruCevaplananKullaniciKelimeIdler)
            {
                var kelime = kelimeListesi.FirstOrDefault(x => x.kullaniciKelimeId == id);
                if (kelime != null)
                {
                    kelime.dogruSayisi++;
                    kelime.sonDogruTarihi = DateTime.Now; // Tarihi güncelle

                    if (kelime.dogruSayisi >= 6)
                    {
                        kelime.ogrenildiMi = true;
                    }
                }
            }

            // 3. Güncellenmiş listeyi tekrar JSON dosyasına yaz
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(kelimeListesi, Formatting.Indented));
        }



        public void SinavSonuGuncelle(List<Kelime> kelimeListesi)
        {
            try
            {
                // Doğru cevaplanan kullaniciKelimeId'leri al
                var guncellenecekIdler = DogruCevaplananKullaniciKelimeIdler;

                // JSON dosyasını oku (tüm kullanıcı kelimeleri)
                string jsonPath = @"C:\Users\Ercüment Kocaoğlu\Source\Repos\6-Seferde-Kelime-Ezeberleme\6 Seferde Kelime Ezeberleme\kullanici_kelimeleri.json";

                var tumKullaniciKelimeleri = JsonConvert.DeserializeObject<List<KullaniciKelimeDurumu>>(File.ReadAllText(jsonPath));

                foreach (int id in guncellenecekIdler)
                {
                    var kelime = tumKullaniciKelimeleri.FirstOrDefault(x => x.kullaniciKelimeId == id);
                    if (kelime != null)
                    {
                        kelime.dogruSayisi++;
                        kelime.sonDogruTarihi = DateTime.Now;
                        if (kelime.dogruSayisi >= 6)
                            kelime.ogrenildiMi = true;

                        // digerTestTarihi güncelleme
                        switch (kelime.dogruSayisi)
                        {
                            case 1:
                                kelime.digerTestTarihi = DateTime.Now.AddDays(1);
                                break;
                            case 2:
                                kelime.digerTestTarihi = DateTime.Now.AddDays(7);
                                break;
                            case 3:
                                kelime.digerTestTarihi = DateTime.Now.AddMonths(1);
                                break;
                            case 4:
                                kelime.digerTestTarihi = DateTime.Now.AddMonths(3);
                                break;
                            case 5:
                                kelime.digerTestTarihi = DateTime.Now.AddMonths(6);
                                break;
                            case 6:
                                kelime.digerTestTarihi = DateTime.Now.AddYears(1);
                                break;
                            default:
                                kelime.digerTestTarihi = null;
                                break;
                        }
                    }
                }

                // Güncellenmiş listeyi tekrar JSON dosyasına yaz
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(tumKullaniciKelimeleri, Formatting.Indented));
                KelimeSenkranizasyonu.KullaniciKelimeleriniVeritabaninaYansit(tumKullaniciKelimeleri);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sınav sonu güncelleme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}

