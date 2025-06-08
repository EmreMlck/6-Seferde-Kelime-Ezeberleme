using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace _6_Seferde_Kelime_Ezeberleme
{
    public class Kelime
    {
        [JsonProperty("trKelimeAdi")]
        public string trKelimeAdi { get; set; }
        
        [JsonProperty("ingKelimeAdi")]
        public string ingKelimeAdi { get; set; }

        [JsonProperty("kategoriId")]
        public int kategoriId { get; set; }

        [JsonProperty("resim")]
        public string resim { get; set; }

        [JsonProperty("kelimeId", DefaultValueHandling = DefaultValueHandling.Include)]
        public int kelimeId { get; set; }

        public int kullaniciId { get; set; }

        public int dogruSayisi { get; set; }=0;
        public DateTime? sonDogruTarihi { get; set; }
        public int kullaniciKelimeId { get; set; }
        public bool ogrenildiMi { get; set; }


    }



}
