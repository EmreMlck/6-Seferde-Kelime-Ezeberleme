﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using _6_Seferde_Kelime_Ezeberleme;
using System.Linq;
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
    public static void KullaniciKelimeleriJsonGuncelle(
        string connectionString,
        string jsonPath,
        List<Kelime> kelimeListesi,
        int kullaniciId)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            foreach (var kelime in kelimeListesi)
            {
                var cmd = new SqlCommand(
                    @"UPDATE KullaniciKelimeleri 
                      SET dogruSayisi=@dogruSayisi, 
                          sonDogruTarihi=@sonDogruTarihi, 
                          ogrenildiMi=@ogrenildiMi 
                      WHERE kullaniciKelimeleriId=@kullaniciKelimeleriId AND kullaniciId=@kullaniciId", conn);

                cmd.Parameters.AddWithValue("@dogruSayisi", kelime.dogruSayisi);
                cmd.Parameters.AddWithValue("@sonDogruTarihi", (object)kelime.sonDogruTarihi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ogrenildiMi", kelime.ogrenildiMi);
                cmd.Parameters.AddWithValue("@kullaniciKelimeleriId", kelime.kullaniciKelimeId);
                cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}



