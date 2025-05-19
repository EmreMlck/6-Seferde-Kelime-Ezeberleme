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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class KelimeEkleme : Form
    {
        public KelimeEkleme()
        {
            InitializeComponent();
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

        private void textBoxTurkceEkle_TextChanged(object sender, EventArgs e)
        {

        }

        private void butonKelimeEkle_Click(object sender, EventArgs e)
        {
            string tr = textBoxTurkceEkle.Text.Trim();
            string en = textBoxIngEkle.Text.Trim();
            int kategoriId = (int)comboBoxKelimeKategori.SelectedValue;
            
            if(comboBoxKelimeKategori == null)
            {
                MessageBox.Show("Kategori kısmı boş bırakılamaz!");
                return;
            }

            if (!string.IsNullOrEmpty(tr) && !string.IsNullOrEmpty(en))
            {
                VeritabanıKelimeEkleme dbEkleme = new VeritabanıKelimeEkleme();
                dbEkleme.kelimeEkleme(tr, en, kategoriId);
                
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
            Uygulama_Ana_Ekran anaEkranaGec = new Uygulama_Ana_Ekran();
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
