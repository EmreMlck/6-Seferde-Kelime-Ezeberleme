﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace _6_Seferde_Kelime_Ezeberleme
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabKayit;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            textBoxGirisSifre.PasswordChar = '*'; // yazılan karakterler * ile gösterilecek.
            textBoxKayitSifre.PasswordChar = '*';
        

            textBoxSifreMail.Text = "....@gmail.com";
            textBoxSifreMail.ForeColor = Color.Gray;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabGiris; // Giris'e çift basinca Giris Tab'ını açılan penceremiz yapacak
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void butonSifre_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabSifreUnuttum;
        }

        private void butonGirisGeri_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabHosGeldiniz;
            textBoxGirisAd.Text = "";
            textBoxGirisSifre.Text = "";
        }

        private void butonKayitGeri_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabHosGeldiniz;
            textBoxKayitAd.Text = "";
            textBoxKayitSifre.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabHosGeldiniz;           
            textBoxSifreMail.Text = "....@gmail.com";
            
        }

        private void butonGirisYap_Click(object sender, EventArgs e)
        {
            string ad = textBoxGirisAd.Text.Trim();
            string sifre = textBoxGirisSifre.Text.Trim(); 

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=EmreMlck\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciGiris", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@kullaniciAdi", ad);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int kullaniciId = (int)reader["kullaniciId"];
                            string jsonDosyaYolu = "kullanici_kelimeleri.json";

                            // JSON dosyasını oluştur
                            VeritabanıKelimeEkleme.VeritabaniKelimeEklemeHelper.KullaniciKelimeJsonOlustur(kullaniciId, connectionString, jsonDosyaYolu);

                            string kullaniciAdi = reader["kullaniciAdi"].ToString();

                            reader.Close(); // <-- Bunu ekle!

                            // Tüm kelimeleri çek
                            List<int> kelimeIdler = new List<int>();
                            using (SqlCommand kelimeCmd = new SqlCommand("SELECT kelimeId FROM Kelimeler", conn))
                            using (SqlDataReader kelimeReader = kelimeCmd.ExecuteReader())
                            {
                                while (kelimeReader.Read())
                                    kelimeIdler.Add(kelimeReader.GetInt32(0));
                            }

                            // Her kelime için KullaniciKelimeleri tablosuna ekle (varsa hata verirse try-catch ile geç)
                            foreach (var kelimeId in kelimeIdler)
                            {
                                try
                                {
                                    using (SqlCommand ekleCmd = new SqlCommand("INSERT INTO KullaniciKelimeleri (kullaniciId, kelimeId, dogruSayisi, sonDogruTarihi, ogrenildiMi, digerTestTarihi) VALUES (@kullaniciId, @kelimeId, 0, NULL, 0, NULL)", conn))
                                    {
                                        ekleCmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                        ekleCmd.Parameters.AddWithValue("@kelimeId", kelimeId);
                                        ekleCmd.ExecuteNonQuery();
                                    }
                                }
                                catch {  }
                            }

                            this.Hide();
                            Uygulama_Ana_Ekran anaEkran = new Uygulama_Ana_Ekran(kullaniciAdi, kullaniciId);
                            anaEkran.FormClosed += (s, args) => this.Close();
                            anaEkran.Show();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }                     
        }

        public void JsondanDbyeAktar()
        {
            var json = File.ReadAllText("sozluk.json");
            var sozluk = JsonConvert.DeserializeObject<List<KelimeJson>>(json);

            string connectionString = "Server=EmreMlck\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    foreach (var kelime in sozluk)
                    {
                        string sqlDb = "INSERT INTO Kelimeler (trKelimeAdi, ingKelimeAdi, resim, kategoriId) VALUES(@tr, @en, @resim, @kategoriId)";
                        using (SqlCommand cmd = new SqlCommand(sqlDb, conn))
                        {
                            cmd.Parameters.AddWithValue("@tr", kelime.trKelimeAdi);
                            cmd.Parameters.AddWithValue("@en", kelime.ingKelimeAdi);
                            cmd.Parameters.AddWithValue("@resim", kelime.resim);
                            cmd.Parameters.AddWithValue("@kategoriId", kelime.kategoriId);

                            cmd.ExecuteNonQuery();

                        }
                    }
                    MessageBox.Show("50 kelime başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // UNIQUE hataları
                    {
                        MessageBox.Show("Bu kelime zaten var, eklenemez!");
                    }
                    else
                    {
                        MessageBox.Show("Hata oluştu.");
                    }
                }

            }
        }
            
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabGiris_Click(object sender, EventArgs e)
        {

        }

        private void butonSifreGonder_Click(object sender, EventArgs e)
        {
            String email = textBoxSifreMail.Text.Trim();

            if (email == "....@gmail.com" || !email.Contains("@gmail.com") || email.StartsWith("@") || email.Length < 12 || !email.EndsWith(".com"))
            {
                MessageBox.Show("Lütfen geçerli bir mail adresi giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;            
            }

            MessageBox.Show("Mail yollandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBoxSifreMail_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSifreMail.Text == "....gmail.com")
            {
                textBoxSifreMail.Text = "";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxGirisSifre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void butonGirisSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGirisSifreGoster.Checked)
            {
                textBoxGirisSifre.PasswordChar = '\0'; // eğer işaretliyse şifre karakter olarak gözükür
            }
            else
            {
                textBoxGirisSifre.PasswordChar = '*'; // işaretli değilse * olarak gözükür
            }
        }

        private void tabSifreUnuttum_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxKayitSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxKayitSifreGoster.Checked)
            {
                textBoxKayitSifre.PasswordChar = '\0';
                
            }
            else
            {
                textBoxKayitSifre.PasswordChar = '*';
            }
        }

        private void textBoxSifreMail_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBoxSifreMail_Enter(object sender, EventArgs e)
        {
            if (textBoxSifreMail.Text== "....@gmail.com")
                textBoxSifreMail.Text = "";
        }

        private void butonKayitOl_Click(object sender, EventArgs e)
        {
            string ad = textBoxKayitAd.Text;
            string sifre = textBoxKayitSifre.Text;

            string connectionString = "Server=EmreMlck\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciKayit", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@kullaniciAdi", ad);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int kullaniciId = (int)reader["kullaniciId"];
                            string kullaniciAdi = reader["kullaniciAdi"].ToString();

                            reader.Close(); 

                            
                            List<int> kelimeIdler = new List<int>(); // Tüm kelimeler çekilecek
                            using (SqlCommand kelimeCmd = new SqlCommand("SELECT kelimeId FROM Kelimeler", conn))
                            using (SqlDataReader kelimeReader = kelimeCmd.ExecuteReader())
                            {
                                while (kelimeReader.Read())
                                    kelimeIdler.Add(kelimeReader.GetInt32(0));
                            }

                            
                            foreach (var kelimeId in kelimeIdler) // Her kelime için KullaniciKelimeleri tablosuna eklenecek
                            {
                                using (SqlCommand ekleCmd = new SqlCommand("INSERT INTO KullaniciKelimeleri (kullaniciId, kelimeId, dogruSayisi, sonDogruTarihi, ogrenildiMi, digerTestTarihi) VALUES (@kullaniciId, @kelimeId, 0, NULL, 0, NULL)", conn))
                                {
                                    ekleCmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                    ekleCmd.Parameters.AddWithValue("@kelimeId", kelimeId);
                                    ekleCmd.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show($"Kayıt Başarılı. Kullanıcı ID: {kullaniciId}");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt başarısız...");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);                     
                    }
                }
            }

        }

        private void textBoxGirisAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void butonAnaEkranCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

    }
}
