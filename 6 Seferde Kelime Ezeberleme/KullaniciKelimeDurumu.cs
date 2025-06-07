using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

public class KullaniciKelimeDurumu
{
    public int kullaniciKelimeId { get; set; }
    public int kullaniciId { get; set; }
    public int kelimeId { get; set; }
    public int dogruSayisi { get; set; }
    public DateTime? sonDogruTarihi { get; set; }
    public bool ogrenildiMi { get; set; }
    public DateTime? digerTestTarihi { get; set; }

    public static void DogruCevaplariVeritabanindaGuncelle(List<int> dogruKullaniciKelimeIdler, string connectionString)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            foreach (var id in dogruKullaniciKelimeIdler)
            {
                using (var cmd = new SqlCommand("UPDATE KullaniciKelimeleri SET dogruSayisi = dogruSayisi + 1, sonDogruTarihi = @tarih WHERE kullaniciKelimeleriId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

public static class KullaniciKelimeDurumuHelper
{
    public static void KullaniciKelimeleriJsonGuncelle(string connectionString, string jsonDosyaYolu)
    {
        try
        {
            var liste = new List<KullaniciKelimeDurumu>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT kullaniciKelimeleriId, kullaniciId, kelimeId, dogruSayisi, sonDogruTarihi, ogrenildiMi, digerTestTarihi FROM KullaniciKelimeleri", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new KullaniciKelimeDurumu
                        {
                            kullaniciKelimeId = reader.GetInt32(0),
                            kullaniciId = reader.GetInt32(1),
                            kelimeId = reader.GetInt32(2),
                            dogruSayisi = reader.GetInt32(3),
                            sonDogruTarihi = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            ogrenildiMi = reader.GetBoolean(5),
                            digerTestTarihi = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6)
                        });
                    }
                }
            }
            File.WriteAllText(jsonDosyaYolu, JsonConvert.SerializeObject(liste, Formatting.Indented));
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("JSON güncelleme hatası: " + ex.Message);
        }
    }

}



