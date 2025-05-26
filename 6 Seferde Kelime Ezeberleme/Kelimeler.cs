using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class Kelimeler : Form
    {
        private string kullaniciAdi;
        public Kelimeler(string kullaniciAdi)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
        }

        private void Kelimeler_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=EMREMLCK\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sorgu = @"SELECT K.ingKelimeAdi, K.trKelimeAdi, kat.kategoriAdi 
                         FROM Kelimeler K 
                         JOIN kelimeKategori kat ON K.kategoriId = kat.kategoriId";

                SqlDataAdapter dataAd = new SqlDataAdapter(sorgu, conn);
                DataTable dtable = new DataTable();
                dataAd.Fill(dtable);
                dataGridKelimeler.DataSource = dtable;
            }
            dataGridKelimeler.Columns[0].HeaderText = "İngilizce";
            dataGridKelimeler.Columns[1].HeaderText = "Türkçe";
            dataGridKelimeler.Columns[2].HeaderText = "Kategoriler";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void butonGirisGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran KelimelerdenAnaEkrana =  new Uygulama_Ana_Ekran(kullaniciAdi);
            KelimelerdenAnaEkrana.FormClosed += (s, args) => this.Close();
            KelimelerdenAnaEkrana.Show();
        }
    }
}
