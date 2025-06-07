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
}
}
