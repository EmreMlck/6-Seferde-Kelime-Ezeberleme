using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class KelimeEkleme : Form
    {
        string kullaniciAdi;
        public KelimeEkleme(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }

        private void KelimeEkleme_Load(object sender, EventArgs e)
        {
            
            string connectionString = "Server=EMREMLCK\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";
            
            List<Kategori> kategoriler = new List<Kategori>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT kategoriId, kategoriAdi FROM kelimeKategori", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()) 
                {
                    kategoriler.Add(new Kategori()
                    {
                        kategoriId = (int)reader["kategoriId"],
                        kategoriAdi = reader["kategoriAdi"].ToString()
                    });

                }
            }
            comboBoxKelimeKategori.DataSource = kategoriler;
            comboBoxKelimeKategori.DisplayMember = "kategoriAdi";
            comboBoxKelimeKategori.ValueMember = "kategoriId";
        }
        private async Task<string> UnsplashResimGetir(string kelime)
        {
            string accessKey = "q8satxSntbbgpXxUlC3Mt5WKhJi87dbrvPFIpocOCxo";  
            string url = $"https://api.unsplash.com/search/photos?query={kelime}&client_id={accessKey}&per_page=1";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(jsonString);
                    if (json.results.Count > 0)
                    {
                        return json.results[0].urls.small.ToString();
                    }
                }
            }
            return null;
        }


        private void textBoxTurkceEkle_TextChanged(object sender, EventArgs e)
        {

        }

        private async void butonKelimeEkle_ClickAsync(object sender, EventArgs e)
        {
            if (comboBoxKelimeKategori.SelectedItem == null)
            {
                MessageBox.Show("Kategori kısmı boş bırakılamaz!");
                return;
            }

            string tr = textBoxTurkceEkle.Text.Trim();
            string en = textBoxIngEkle.Text.Trim();
            int kategoriId = (int)comboBoxKelimeKategori.SelectedValue;

            if (!string.IsNullOrEmpty(tr) && !string.IsNullOrEmpty(en))
            {
                string resim = await UnsplashResimGetir(en);  

                VeritabanıKelimeEkleme dbEkleme = new VeritabanıKelimeEkleme();
                dbEkleme.kelimeEkleme(tr, en, resim, kategoriId);
            }
            else
            {
                MessageBox.Show("Kutucuklar Boş Bırakılamaz!");
            }

            textBoxTurkceEkle.Text = "";
            textBoxIngEkle.Text = "";
        }



        private void butonGirisGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran anaEkranaGec = new Uygulama_Ana_Ekran(kullaniciAdi);
            anaEkranaGec.FormClosed += (s, args) => this.Close();
            anaEkranaGec.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dbJsonEkle = new Form1();
            dbJsonEkle.JsondanDbyeAktar();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
