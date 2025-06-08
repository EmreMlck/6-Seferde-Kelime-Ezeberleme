using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace _6_Seferde_Kelime_Ezeberleme
{
    internal class VeritabanıKelimeEkleme
    {
        string connectionString = "Server=DESKTOP-57KV21F;Database=kelimeEzberleme;User Id=veritabani;Password=070901;";
        public void kelimeEkleme(string tr, string en, string resim, int kategoriId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    string eklenecek = "INSERT INTO Kelimeler(trKelimeAdi, ingKelimeAdi, resim, kategoriId) " +
                     "OUTPUT INSERTED.kelimeId " +
                     "VALUES(@tr, @en, @resim, @kategoriId)";
                    using (SqlCommand cmd = new SqlCommand(eklenecek, conn))
                    {
                        cmd.Parameters.AddWithValue("@tr", tr);
                        cmd.Parameters.AddWithValue("@en", en);
                        cmd.Parameters.AddWithValue("@resim", resim);
                        cmd.Parameters.AddWithValue("@kategoriId", kategoriId);
                        int yeniKelimeId = Convert.ToInt32(cmd.ExecuteScalar());
                        
                        try
                        {
                            string jsonDosyaYolu = @"C:\Users\Ercüment Kocaoğlu\Source\Repos\6-Seferde-Kelime-Ezeberleme\6 Seferde Kelime Ezeberleme\sozluk.json";
                            List<Kelime> guncelKelimelerListesi = new List<Kelime>();

                            if (File.Exists(jsonDosyaYolu))
                            {
                                string eskiJson = File.ReadAllText(jsonDosyaYolu);
                                guncelKelimelerListesi = JsonConvert.DeserializeObject<List<Kelime>>(eskiJson) ?? new List<Kelime>();
                            }

                            guncelKelimelerListesi.Add(new Kelime
                            {
                                trKelimeAdi = tr,
                                ingKelimeAdi = en,
                                resim = resim,
                                kategoriId = kategoriId,
                                kelimeId = yeniKelimeId
                            });

                            string json = JsonConvert.SerializeObject(guncelKelimelerListesi, Formatting.Indented);
                            File.WriteAllText(jsonDosyaYolu, json);
                            MessageBox.Show(jsonDosyaYolu);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("JSON dosyası yazılamadı: " + ex.Message);
                        }

                        MessageBox.Show("Kelime, Kategori ve Resim URL'si Eklendi!");


                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // UNIQUE hataları
                    {
                        MessageBox.Show("Bu kelime zaten var, eklenemez!");
                    }
                    else
                    {
                        MessageBox.Show("Hata oluştu." + ex.Message);
                    }
                }
            }
        }
        public static class VeritabaniKelimeEklemeHelper
        {
            public static void KullaniciKelimeJsonOlustur(int kullaniciId, string connectionString, string jsonDosyaYolu)
            {
                // 1. Tüm kelimeleri veritabanından çek
                List<int> tumKelimeIdler = new List<int>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT kelimeId FROM Kelimeler", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tumKelimeIdler.Add(reader.GetInt32(0));
                        }
                    }
                }

                // 2. Kullanıcıya ait mevcut kelimeleri çek (varsa)
                HashSet<int> kullaniciKelimeIdSet = new HashSet<int>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT kelimeId FROM KullaniciKelimeleri WHERE kullaniciId = @kullaniciId", conn))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                kullaniciKelimeIdSet.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }

                // 3. Eksik olan kelimeler için KullaniciKelimeDurumu nesneleri oluştur
                List<KullaniciKelimeDurumu> kullaniciKelimeleri = new List<KullaniciKelimeDurumu>();
                foreach (var kelimeId in tumKelimeIdler)
                {
                    if (!kullaniciKelimeIdSet.Contains(kelimeId))
                    {
                        kullaniciKelimeleri.Add(new KullaniciKelimeDurumu
                        {
                            kullaniciId = kullaniciId,
                            kelimeId = kelimeId,
                            dogruSayisi = 0,
                            sonDogruTarihi = null,
                            ogrenildiMi = false,
                            digerTestTarihi = null
                        });
                    }
                }

                // 4. JSON dosyasına yaz
                string json = JsonConvert.SerializeObject(kullaniciKelimeleri, Formatting.Indented);
                File.WriteAllText(jsonDosyaYolu, json);
            }
        }
    }

}



