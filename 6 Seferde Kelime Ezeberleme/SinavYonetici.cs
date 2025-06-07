using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using static _6_Seferde_Kelime_Ezeberleme.KullanıcıAyarları;

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
                    File.WriteAllText(jsonPath, JsonConvert.SerializeObject(kullaniciKelimeleri, Formatting.Indented));
                }
            }
        }


        public void CevabiDegerlendir(string secilen)
        {
            if (GuncelSoru == null)
                return;

            if (secilen != null &&
                (secilen.Trim().ToLower() == GuncelSoru.DogruKelime.trKelimeAdi.Trim().ToLower() ||
                 secilen.Trim().ToLower() == GuncelSoru.DogruKelime.ingKelimeAdi.Trim().ToLower()))
            {
                totalDogru++;
                // Sadece bir kez ekle
                if (!_dogruCevaplananKullaniciKelimeIdler.Contains(GuncelSoru.DogruKelime.kullaniciKelimeId))
                    _dogruCevaplananKullaniciKelimeIdler.Add(GuncelSoru.DogruKelime.kullaniciKelimeId);
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
            var json = File.ReadAllText(jsonPath);
            var kelimeListesi = JsonConvert.DeserializeObject<List<KullaniciKelimeDurumu>>(json);

            foreach (int id in dogruCevaplananKullaniciKelimeIdler)
            {
                var kelime = kelimeListesi.FirstOrDefault(x => x.kullaniciKelimeId == id);
                if (kelime != null)
                {
                    kelime.dogruSayisi += 1;
                    kelime.sonDogruTarihi = DateTime.Now  ;

                    // Eğer doğru sayısı 6 veya fazlaysa, öğrenildi olarak işaretle
                    if (kelime.dogruSayisi >= 6)
                    {
                        kelime.ogrenildiMi = true;
                    }
                }
            }

            // Güncellenmiş listeyi tekrar JSON dosyasına yaz
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(kelimeListesi, Formatting.Indented));
        }


        public void SinavSonuGuncelle()
        {
            try
            {
                // 1. Doğru cevaplanan kullaniciKelimeId'leri al
                var guncellenecekIdler = DogruCevaplananKullaniciKelimeIdler;

                // 2. Kontrol için göster
                MessageBox.Show("Güncellenecek ID'ler: " + string.Join(",", guncellenecekIdler), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Güncelleme işlemini burada yap
                // KullaniciKelimeDurumuHelper.KullaniciKelimeleriJsonGuncelle(guncellenecekIdler, ...);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sınav sonu güncelleme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

