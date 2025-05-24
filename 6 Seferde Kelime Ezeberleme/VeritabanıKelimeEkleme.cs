using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_Seferde_Kelime_Ezeberleme
{
    internal class VeritabanıKelimeEkleme
    {
        string connectionString = "Server=EMREMLCK\\SQLEXPRESS;Database=kelimeEzberleme;User Id=emremlck;Password=12345;";
        public void kelimeEkleme(string tr, string en, string resim, int kategoriId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    string eklenecek = "INSERT INTO Kelimeler(trKelimeAdi, ingKelimeAdi, resim, kategoriId) VALUES(@tr, @en, @resim, @kategoriId)";
                    using (SqlCommand cmd = new SqlCommand(eklenecek, conn))
                    {
                        cmd.Parameters.AddWithValue("@tr", tr);
                        cmd.Parameters.AddWithValue("@en", en);
                        cmd.Parameters.AddWithValue("@resim", resim);
                        cmd.Parameters.AddWithValue("@kategoriId", kategoriId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kelime, Kategori ve Resim URL'si Eklendi!");
                    }
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
    }
}
