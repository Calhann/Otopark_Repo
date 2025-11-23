using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
    internal class Veriİşle
    {
       public readonly static string  Bağlatı_Cümlesi = "Data Source=DESKTOP-V8KUQNR\\SQLEXPRESS;Initial Catalog=OTOPARK;Integrated Security=True;";
        //ERKİN EV Sql 

        public static class ŞifreŞifreleyici
        {
            public static string Hash(string password) 
            {
                using (SHA256 Sifre256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(password);
                    byte[] hash = Sifre256.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }

            }
            
            public static bool Verify(string password, string storedHash)
            {
                string hashOfInput = Hash(password); 
                return hashOfInput == storedHash;
            }
        }

        public static bool Yönetici_Giris(string sifre, string Kullanıcı_Adı) 
        {
            try
            {
                using (SqlConnection Bağlantı = new SqlConnection(Bağlatı_Cümlesi))
                {
                    Bağlantı.Open();

                    SqlCommand komut = new SqlCommand("SELECT PasswordHash FROM YONETİCİ WHERE AdSoyad=@AdSoyad", Bağlantı);
                    komut.Parameters.AddWithValue("@AdSoyad", Kullanıcı_Adı);

                    using (SqlDataReader okuyucu = komut.ExecuteReader())
                    {
                        if (okuyucu.Read())
                        {
                            
                            byte[] dbHashBytes = (byte[])okuyucu["PasswordHash"];

                            
                            string dbHash = Convert.ToBase64String(dbHashBytes);

                            
                            if (ŞifreŞifreleyici.Verify(sifre, dbHash))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message); return false; 
            }
            finally 
            {
            }
        }
    }
}
