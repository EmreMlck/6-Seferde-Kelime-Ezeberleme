using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _6_Seferde_Kelime_Ezeberleme
{
    internal class KelimeYukleyici
    {
        public static List<Kelime> KelimeleriYukle(string dosyaYolu)
        {
            try
            {

                string json = File.ReadAllText(@"C:\Users\Ercüment Kocaoğlu\Source\Repos\6-Seferde-Kelime-Ezeberleme\6 Seferde Kelime Ezeberleme\sozluk.json");
                var liste = JsonConvert.DeserializeObject<List<Kelime>>(json);
                return liste ?? new List<Kelime>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kelime dosyası okunamadı: " + ex.Message);
                return new List<Kelime>();
            }

        }
        public static void VeritabaniIleJsonuSenkronizeEt(List<Kelime> veritabaniKelimeleri, string jsonDosyaYolu)
        {
            string json = JsonConvert.SerializeObject(veritabaniKelimeleri, Formatting.Indented);
            File.WriteAllText(jsonDosyaYolu, json);
        }
        // Tekrar quizine uygun kelimeleri seçen fonksiyon
        
        public static List<Kelime> TekrarQuizKelimeleriSec(List<Kelime> sozluk, List<KullaniciKelimeDurumu> kullaniciDurum)
        {
            // 1. Kullanıcıya ait 6 kez doğru bilinmeyen kelimeleri bul
            var tekrarKelimeleri = (from kelime in sozluk
                                    join durum in kullaniciDurum on kelime.kelimeId equals durum.kelimeId
                                    where durum.dogruSayisi < 6
                                    orderby durum.dogruSayisi, durum.sonDogruTarihi ?? DateTime.MinValue
                                    select kelime).ToList();


            // 2. 10 kelime seç (varsa)
            var random = new Random();
            return tekrarKelimeleri.OrderBy(x => random.Next()).Take(10).ToList();
        }
        public static List<KullaniciKelimeDurumu> KullaniciKelimeleriniYukle(string dosyaYolu)
        {
            try
            {
                string json = File.ReadAllText(@"C:\Users\Ercüment Kocaoğlu\Source\Repos\6-Seferde-Kelime-Ezeberleme\6 Seferde Kelime Ezeberleme\kullanici_kelimeleri.json");
                var liste = JsonConvert.DeserializeObject<List<KullaniciKelimeDurumu>>(json);
                return liste ?? new List<KullaniciKelimeDurumu>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı kelime dosyası okunamadı: " + ex.Message);
                return new List<KullaniciKelimeDurumu>();
            }
        }

    }
}
