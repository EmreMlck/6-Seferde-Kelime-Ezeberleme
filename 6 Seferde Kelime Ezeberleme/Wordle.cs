using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class Wordle : Form
    {
        private string kullaniciAdi;
        private string kelime;
        private int kelimeUzunluk;
        private int uzunlukTahmin;
        private int aktifSatir = 0;
        private int kullaniciId;


        List<string> tumTahminler = new List<string>();

        TextBox[,] GridOlusturma;
       

        public Wordle(string kullaniciAdi, int aktifKullaniciId)
        {
            InitializeComponent();
            this.kullaniciAdi = kullaniciAdi;
            this.kullaniciId = aktifKullaniciId;
        }

        private void Wordle_Load(object sender, EventArgs e)
        {
            GridOlustur(6);
        }

        private void butonBasarimGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uygulama_Ana_Ekran WordleAnaEkrana = new Uygulama_Ana_Ekran(kullaniciAdi,kullaniciId );
            WordleAnaEkrana.FormClosed += (s, args) => this.Close();
            WordleAnaEkrana.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        
        }
        private void GridOlustur(int uzunlukTahminDegiskeni)
        {
            string connectionString = "Server=DESKTOP-57KV21F;Database=kelimeEzberleme;User Id=veritabani;Password=070901;";
            kelime = "";
            kelimeUzunluk = 0;
            uzunlukTahmin = uzunlukTahminDegiskeni;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sorgu = "SELECT TOP 1 trKelimeAdi FROM Kelimeler ORDER BY NEWID()"; // kelimeyi rastgele çekicez 

                    using (SqlCommand cmd = new SqlCommand(sorgu, conn))
                    {
                        object sonuc = cmd.ExecuteScalar(); // Executescalar object tipinde veri döndürecek
                        if (sonuc != null)
                        {
                            kelime = sonuc.ToString().Trim();
                            kelimeUzunluk = kelime.Length;
                        }
                        else
                        {
                            MessageBox.Show("Veritabanında kelime yok!");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata alındı: " + ex.Message);
                    return;
                }
            }

            tableGrid.Controls.Clear();
            tableGrid.ColumnCount = kelimeUzunluk; // kolon olacak
            tableGrid.RowCount = uzunlukTahmin; // sütun olacak --> 6
            tableGrid.ColumnStyles.Clear();
            tableGrid.RowStyles.Clear();

            for (int i = 0; i < kelimeUzunluk; i++)
                tableGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / kelimeUzunluk)); // kelime uzunluğuna göre kolon boyutu esnek olarak değişir

            for (int i = 0; i < uzunlukTahminDegiskeni; i++)
                tableGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 120f / uzunlukTahminDegiskeni));

            GridOlusturma = new TextBox[uzunlukTahminDegiskeni, kelimeUzunluk];

            for (int satir = 0; satir < uzunlukTahminDegiskeni; satir++)
            {
                for (int sütun = 0; sütun < kelimeUzunluk; sütun++)
                {
                    TextBox metin = new TextBox(); 
                    metin.MaxLength = 1; // kutucuğa maks 1 harf
                    metin.Dock = DockStyle.Fill;
                    metin.TextAlign = HorizontalAlignment.Center;
                    metin.Font = new Font("Calibri", 20, FontStyle.Bold);
                    metin.BackColor = Color.White;
                    metin.CharacterCasing = CharacterCasing.Upper;
                    GridOlusturma[satir, sütun] = metin;
                    tableGrid.Controls.Add(metin, sütun, satir);
                    metin.KeyPress += TextBox_KeyPress;
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // sayı girilirse iptal etmek için
                MessageBox.Show("Sadece harf girişi yapılabilir!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (aktifSatir >= uzunlukTahmin) // aktif satır 0 dan başladığı için eşitlik de olacak
            {
                MessageBox.Show("Tahmin hakkınız kalmadı!");
                return;
            }

            StringBuilder kelimeyiTahmin = new StringBuilder();

            for (int sutun = 0; sutun < kelimeUzunluk; sutun++)
            {
                string kutuHarf = GridOlusturma[aktifSatir, sutun].Text;

                if (string.IsNullOrWhiteSpace(kutuHarf))
                {
                    MessageBox.Show("Boş kutucuk bırakılamaz!");
                    return;
                }

                kelimeyiTahmin.Append(kutuHarf);
            }

            string tahmin = kelimeyiTahmin.ToString().ToUpper();
            tumTahminler.Add(tahmin);

            if (tahmin.Equals(kelime.ToUpper(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Doğru tahmin yaptınız, TEBRİKLER!");
                for(int i = aktifSatir; i < uzunlukTahmin; i++)
                {
                    SatirKapat(i, true); // yeşil
                }
                
            }
            else
            {
                MessageBox.Show("Yanlış tahmin, tekrar deneyin.");
                SatirKapat(aktifSatir, false); // gri
                MessageBox.Show(kelime);
                aktifSatir++;
            }
        }

        private void SatirKapat(int satirNo, bool dogruMu) 
        {
            for(int sutun = 0; sutun < kelimeUzunluk; sutun++)
            {
                GridOlusturma[satirNo, sutun].ReadOnly = true;
                GridOlusturma[satirNo, sutun].BackColor = dogruMu ? Color.Green : Color.Gray;
            }
        }

    }
}
