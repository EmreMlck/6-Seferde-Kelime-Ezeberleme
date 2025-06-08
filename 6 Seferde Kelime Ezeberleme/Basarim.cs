using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using _6_Seferde_Kelime_Ezeberleme;



namespace _6_Seferde_Kelime_Ezeberleme
{

    public partial class Basarim : Form
    {
        private List<Kelime> kelimeler;
        private List<Kategori> kategoriler;
        private List<KullaniciKelime> kullaniciKelimeleri;


        private string sozlukJsonPath = "sozluk.json";
        private string kullaniciKelimeJsonPath = "kullanici_kelimeleri.json";

        private string kullaniciAdi;
        private int kullaniciId;
        public Basarim(string kullaniciAdi, int aktifKullaniciId)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.kullaniciId = aktifKullaniciId;
        }

        private void Basarim_Load(object sender, EventArgs e)
        {
            // JSON dosyalarını oku
            kelimeler = JsonConvert.DeserializeObject<List<Kelime>>(File.ReadAllText(sozlukJsonPath));
            kategoriler = KategoriGetirFromSql();
            kullaniciKelimeleri = JsonConvert.DeserializeObject<List<KullaniciKelime>>(File.ReadAllText(kullaniciKelimeJsonPath));


            if (chart1.ChartAreas.Count == 0)
            {
                chart1.ChartAreas.Add(new ChartArea("Default"));
            }
            // chart güncelleme
            GuncelleChart();
        }
        private List<Kategori> KategoriGetirFromSql()
        {
            List<Kategori> kategoriListesi = new List<Kategori>();
            string connectionString = "Server=EmreMlck\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT kategoriId, kategoriAdi FROM kelimeKategori"; 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kategoriListesi.Add(new Kategori()
                            {
                                kategoriId = reader.GetInt32(0),
                                kategoriAdi = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return kategoriListesi;
        }
        private void GuncelleChart()
        {

            var kelimeKategoriMap = new Dictionary<int, int>();
            foreach (var k in kelimeler)
            {
                if (!kelimeKategoriMap.ContainsKey(k.kelimeId))
                {
                    kelimeKategoriMap[k.kelimeId] = k.kategoriId;
                }
                else
                {
                    
                    kelimeKategoriMap[k.kelimeId] = k.kategoriId; 
                }
            }


            var kategoriMap = kategoriler.ToDictionary(k => k.kategoriId, k => k.kategoriAdi);

            // tüm kategorileri baştan 0'la doldurulur
            var kategoriDogruSayilari = new Dictionary<int, int>();
            foreach (var kategori in kategoriler)
            {
                kategoriDogruSayilari[kategori.kategoriId] = 0;
            }

            
            foreach (var kk in kullaniciKelimeleri)
            {

                if (kelimeKategoriMap.TryGetValue(kk.kelimeId, out int kategoriId))
                {
                    if (!kategoriDogruSayilari.ContainsKey(kategoriId))
                        kategoriDogruSayilari[kategoriId] = 0;

                    kategoriDogruSayilari[kategoriId] += kk.dogruSayisi;
                }
            }

            // Grafik ayarlarımız
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Kategori";
            chart1.ChartAreas[0].AxisY.Title = "Doğru Sayısı";

            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart1.ChartAreas[0].AxisX.Interval = 1; 
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 8;


            Series series = new Series
            {
                Name = "DogruSayilari",
                Color = Color.CornflowerBlue,
                ChartType = SeriesChartType.Column
            };
            chart1.Series.Add(series);

            // grafiğe veri eklenir
            foreach (var item in kategoriDogruSayilari)
            {
                string kategoriAdi = kategoriMap.ContainsKey(item.Key) ? kategoriMap[item.Key] : "Bilinmeyen";
                series.Points.AddXY(kategoriAdi, item.Value);
            }

            chart1.Invalidate();
        }

        
        public void DogruSayisiGuncelle(int kelimeId, int yeniDogruSayisi)
        {
            var kk = kullaniciKelimeleri.FirstOrDefault(k => k.kelimeId == kelimeId);
            if (kk != null)
            {
                kk.dogruSayisi = yeniDogruSayisi;
            }
            else
            {
                
                kullaniciKelimeleri.Add(new KullaniciKelime
                {
                    kullaniciKelimeId = kullaniciKelimeleri.Count + 1,
                    kullaniciId = this.kullaniciId,
                    kelimeId = kelimeId,
                    dogruSayisi = yeniDogruSayisi,
                    ogrenildiMi = false,
                    sonDogruTarihi = DateTime.Now,
                    digerTestTarihi = null
                });
            }

            // chart'ı tekrar güncelleriz
            GuncelleChart();
        }
   
    private void butonBasarimGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran BasarimdanAnaEkrana = new Uygulama_Ana_Ekran(kullaniciAdi, kullaniciId);
            BasarimdanAnaEkrana.FormClosed += (s, args) => this.Close();
            BasarimdanAnaEkrana.Show();
        }

    }
}
