using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class Kelimeler : Form
    {
        private string kullaniciAdi;
        private int kullaniciId;
        public Kelimeler(string kullaniciAdi , int aktifKullaniciId)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.kullaniciId = aktifKullaniciId;
            dataGridKelimeler.CellContentClick += dataGridView1_CellContentClick;

            // Kolonları burada ekleyin, sadece bir kez!
            dataGridKelimeler.AutoGenerateColumns = false;
            dataGridKelimeler.Columns.Clear();

            dataGridKelimeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ingKelimeAdi",
                HeaderText = "İngilizce",
                Name = "ingKelimeAdi"
            });
            dataGridKelimeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "trKelimeAdi",
                HeaderText = "Türkçe",
                Name = "trKelimeAdi"
            });
            dataGridKelimeler.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "kategoriAdi",
                HeaderText = "Kategoriler",
                Name = "kategoriAdi"
            });
            dataGridKelimeler.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Sil",
                Name = "Sil",
                Text = "Sil",
                UseColumnTextForButtonValue = true
            });
        }


        private void Kelimeler_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-57KV21F;Database=kelimeEzberleme;User Id=veritabani;Password=070901;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sorgu = @"SELECT K.ingKelimeAdi, K.trKelimeAdi, kat.kategoriAdi 
                 FROM Kelimeler K 
                 LEFT JOIN kelimeKategori kat ON K.kategoriId = kat.kategoriId";

                SqlDataAdapter dataAd = new SqlDataAdapter(sorgu, conn);
                DataTable dtable = new DataTable();
                dataAd.Fill(dtable);
                dataGridKelimeler.DataSource = dtable;
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridKelimeler.Columns["Sil"].Index && e.RowIndex >= 0)
            {
                // Satır geçerli mi kontrolü
                if (e.RowIndex < 0 || e.RowIndex >= dataGridKelimeler.Rows.Count)
                    return;
                if (dataGridKelimeler.Rows[e.RowIndex].IsNewRow)
                    return;

                string ingKelime = dataGridKelimeler.Rows[e.RowIndex].Cells[0].Value?.ToString();
                string trKelime = dataGridKelimeler.Rows[e.RowIndex].Cells[1].Value?.ToString();

                if (string.IsNullOrEmpty(ingKelime) || string.IsNullOrEmpty(trKelime))
                    return;

                var result = MessageBox.Show($"{ingKelime} / {trKelime} silinsin mi?", "Onay", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // 1. Veritabanından sil
                    string connectionString = "Server=DESKTOP-57KV21F;Database=kelimeEzberleme;User Id=veritabani;Password=070901;";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sorgu = "DELETE FROM Kelimeler WHERE ingKelimeAdi = @ing AND trKelimeAdi = @tr";
                        using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                        {
                            cmd.Parameters.AddWithValue("@ing", ingKelime);
                            cmd.Parameters.AddWithValue("@tr", trKelime);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 2. JSON'dan sil
                    string jsonDosyaYolu = @"C:\Users\Ercüment Kocaoğlu\Source\Repos\6-Seferde-Kelime-Ezeberleme\6 Seferde Kelime Ezeberleme\sozluk.json";
                    if (File.Exists(jsonDosyaYolu))
                    {
                        var eskiJson = File.ReadAllText(jsonDosyaYolu);
                        var kelimeler = JsonConvert.DeserializeObject<List<Kelime>>(eskiJson) ?? new List<Kelime>();
                        kelimeler.RemoveAll(k =>
                            (k.trKelimeAdi == trKelime && k.ingKelimeAdi == ingKelime) ||
                            (k.trKelimeAdi == ingKelime && k.ingKelimeAdi == trKelime)
                        );
                        var yeniJson = JsonConvert.SerializeObject(kelimeler, Formatting.Indented);
                        File.WriteAllText(jsonDosyaYolu, yeniJson);
                    }

                    // Event tetiklenmesini engelle
                    dataGridKelimeler.CellContentClick -= dataGridView1_CellContentClick;
                    Kelimeler_Load(null, null); // Tabloyu güncelle
                    dataGridKelimeler.CellContentClick += dataGridView1_CellContentClick;
                }
            }
        }

        private void butonGirisGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran KelimelerdenAnaEkrana =  new Uygulama_Ana_Ekran(kullaniciAdi , kullaniciId );
            KelimelerdenAnaEkrana.FormClosed += (s, args) => this.Close();
            KelimelerdenAnaEkrana.Show();
        }

        private void buttonSenkranizazyon_Click(object sender, EventArgs e)
        {
            // 1. Veritabanındaki tüm kelimeleri çek
            List<Kelime> dbKelimeler = KelimeSenkranizasyonu.TumKelimeleriGetir();

            // 2. Eski JSON'u oku
            string jsonDosyaYolu = @"C:\Users\Ercüment Kocaoğlu\Source\Repos\6-Seferde-Kelime-Ezeberleme\6 Seferde Kelime Ezeberleme\sozluk.json";


            MessageBox.Show("Senkronizasyon tamamlandı!");
            List<Kelime> eskiJsonKelimeler = new List<Kelime>();
            if (File.Exists(jsonDosyaYolu))
            {
                string eskiJson = File.ReadAllText(jsonDosyaYolu);
                eskiJsonKelimeler = JsonConvert.DeserializeObject<List<Kelime>>(eskiJson) ?? new List<Kelime>();
            }

            // 3. Resim URL'lerini koru
            foreach (var dbKelime in dbKelimeler)
            {
                var eski = eskiJsonKelimeler.FirstOrDefault(j =>
                    j.trKelimeAdi == dbKelime.trKelimeAdi &&
                    j.ingKelimeAdi == dbKelime.ingKelimeAdi);

                if (eski != null && !string.IsNullOrEmpty(eski.resim))
                {
                    dbKelime.resim = eski.resim;
                    dbKelime.kelimeId = eski.kelimeId;
                }
            }

            var ayarlar = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            string yeniJson = JsonConvert.SerializeObject(dbKelimeler, ayarlar);
            File.WriteAllText(jsonDosyaYolu, yeniJson);

            MessageBox.Show("JSON dosyası veritabanı ile tamamen senkronize edildi!");
        }
    }
}
