using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Seferde_Kelime_Ezeberleme
{
    internal class Soru
    {
        public Kelime DogruKelime { get; set; }
        public List<string> Secenekler { get; set; }
        public string DogruSecenek => DogruKelime.trKelimeAdi;

        public Soru(Kelime dogruKelime, List<Kelime> tumKelimeler)
        {
            DogruKelime = dogruKelime;
            Secenekler = new List<string> { dogruKelime.trKelimeAdi };

            // Yanlış cevaplar
            var yanlislar = tumKelimeler
                .Where(k => k.trKelimeAdi != dogruKelime.trKelimeAdi)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .Select(k => k.trKelimeAdi)
                .ToList();

            Secenekler = yanlislar.Append(DogruSecenek)
                                  .OrderBy(x => Guid.NewGuid())
                                  .ToList();

            Secenekler = Secenekler.OrderBy(x => Guid.NewGuid()).ToList(); // Şıkları karıştır
        }
    }

}
