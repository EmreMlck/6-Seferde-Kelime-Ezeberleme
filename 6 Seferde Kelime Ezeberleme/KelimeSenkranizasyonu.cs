using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public static class KelimeSenkranizasyonu
    {
        static string connectionString = "Server=DESKTOP-57KV21F;Database=kelimeEzberleme;User Id=veritabani;Password=070901;";

        public static List<Kelime> TumKelimeleriGetir()
        {
            var kelimeler = new List<Kelime>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sorgu = "SELECT trKelimeAdi, ingKelimeAdi, kategoriId, resim FROM Kelimeler";
                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kelimeler.Add(new Kelime
                        {
                            trKelimeAdi = reader["trKelimeAdi"] == DBNull.Value ? "" : reader["trKelimeAdi"].ToString(),
                            ingKelimeAdi = reader["ingKelimeAdi"] == DBNull.Value ? "" : reader["ingKelimeAdi"].ToString(),
                            kategoriId = reader["kategoriId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["kategoriId"]),
                            resim = reader["resim"] == DBNull.Value ? "" : reader["resim"].ToString()

                        });
                    }
                }
            }
            return kelimeler;
        }


        public static void JsonDosyasiniGuncelle(List<Kelime> kelimeler)
        {

            try
            {
                string json = JsonConvert.SerializeObject(kelimeler, Formatting.Indented);
                File.WriteAllText("sozluk.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("JSON dosyası güncellenemedi: " + ex.Message);
            }

    }
        public static List<Kelime> KullaniciKelimeleriniGetir(int aktifKullaniciId)
        {
            var kelimeler = new List<Kelime>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sorgu = @"SELECT kk.kullaniciKelimeleriId, kk.kullaniciId, kk.kelimeId, kk.dogruSayisi, kk.sonDogruTarihi, kk.ogrenildiMi,
                                k.trKelimeAdi, k.ingKelimeAdi, k.kategoriId, k.resim
                         FROM KullaniciKelimeleri kk
                         INNER JOIN Kelimeler k ON kk.kelimeId = k.kelimeId
                         WHERE kk.kullaniciId = @kullaniciId";
                using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", aktifKullaniciId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kelimeler.Add(new Kelime
                            {
                                kullaniciKelimeId = reader["kullaniciKelimeleriId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["kullaniciKelimeleriId"]),
                                kullaniciId = reader["kullaniciId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["kullaniciId"]),
                                kelimeId = reader["kelimeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["kelimeId"]),
                                dogruSayisi = reader["dogruSayisi"] == DBNull.Value ? 0 : Convert.ToInt32(reader["dogruSayisi"]),
                                sonDogruTarihi = reader["sonDogruTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["sonDogruTarihi"]),
                                ogrenildiMi = reader["ogrenildiMi"] == DBNull.Value ? false : Convert.ToBoolean(reader["ogrenildiMi"]),
                                trKelimeAdi = reader["trKelimeAdi"] == DBNull.Value ? "" : reader["trKelimeAdi"].ToString(),
                                ingKelimeAdi = reader["ingKelimeAdi"] == DBNull.Value ? "" : reader["ingKelimeAdi"].ToString(),
                                kategoriId = reader["kategoriId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["kategoriId"]),
                                resim = reader["resim"] == DBNull.Value ? "" : reader["resim"].ToString()
                            });
                        }
                    }
                }
            }
            return kelimeler;
        }
        public static void KullaniciKelimeleriniVeritabaninaYansit(List<KullaniciKelimeDurumu> kelimeler)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var kelime in kelimeler)
                {
                    string kontrolSorgu = "SELECT COUNT(*) FROM KullaniciKelimeleri WHERE kullaniciKelimeleriId = @kullaniciKelimeleriId";
                    using (SqlCommand kontrolCmd = new SqlCommand(kontrolSorgu, conn))
                    {
                        kontrolCmd.Parameters.AddWithValue("@kullaniciKelimeleriId", kelime.kullaniciKelimeId);
                        int count = (int)kontrolCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // Güncelle
                            string updateSorgu = @"UPDATE KullaniciKelimeleri SET 
                        kullaniciId = @kullaniciId,
                        kelimeId = @kelimeId,
                        dogruSayisi = @dogruSayisi,
                        sonDogruTarihi = @sonDogruTarihi,
                        ogrenildiMi = @ogrenildiMi,
                        digerTestTarihi = @digerTestTarihi
                        WHERE kullaniciKelimeleriId = @kullaniciKelimeleriId";
                            using (SqlCommand updateCmd = new SqlCommand(updateSorgu, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@kullaniciId", kelime.kullaniciId);
                                updateCmd.Parameters.AddWithValue("@kelimeId", kelime.kelimeId);
                                updateCmd.Parameters.AddWithValue("@dogruSayisi", kelime.dogruSayisi);
                                updateCmd.Parameters.AddWithValue("@sonDogruTarihi", (object)kelime.sonDogruTarihi ?? DBNull.Value);
                                updateCmd.Parameters.AddWithValue("@ogrenildiMi", kelime.ogrenildiMi);
                                updateCmd.Parameters.AddWithValue("@digerTestTarihi", (object)kelime.digerTestTarihi ?? DBNull.Value);
                                updateCmd.Parameters.AddWithValue("@kullaniciKelimeleriId", kelime.kullaniciKelimeId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Ekle
                            string insertSorgu = @"INSERT INTO KullaniciKelimeleri 
                        (kullaniciKelimeleriId, kullaniciId, kelimeId, dogruSayisi, sonDogruTarihi, ogrenildiMi, digerTestTarihi)
                        VALUES (@kullaniciKelimeleriId, @kullaniciId, @kelimeId, @dogruSayisi, @sonDogruTarihi, @ogrenildiMi, @digerTestTarihi)";
                            using (SqlCommand insertCmd = new SqlCommand(insertSorgu, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@kullaniciKelimeleriId", kelime.kullaniciKelimeId);
                                insertCmd.Parameters.AddWithValue("@kullaniciId", kelime.kullaniciId);
                                insertCmd.Parameters.AddWithValue("@kelimeId", kelime.kelimeId);
                                insertCmd.Parameters.AddWithValue("@dogruSayisi", kelime.dogruSayisi);
                                insertCmd.Parameters.AddWithValue("@sonDogruTarihi", (object)kelime.sonDogruTarihi ?? DBNull.Value);
                                insertCmd.Parameters.AddWithValue("@ogrenildiMi", kelime.ogrenildiMi);
                                insertCmd.Parameters.AddWithValue("@digerTestTarihi", (object)kelime.digerTestTarihi ?? DBNull.Value);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }


    }
}
