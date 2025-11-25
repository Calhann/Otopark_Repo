using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Otopark
{//fghdfg
    public partial class AnaMenü : Form
    {
        public AnaMenü()
        {
            InitializeComponent();
        }
        private string YPkullaniciAdi;
        public AnaMenü(string kullaniciAdi)
        {
            InitializeComponent();
            YPkullaniciAdi = kullaniciAdi;
        }
        private void AnaMenü_Load(object sender, EventArgs e)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Python bağlantısı bekleniyor...");

            Socket client = server.AcceptSocket();
            Console.WriteLine("Python bağlandı!");

            byte[] buffer = new byte[1024];

            while (true)
            {
                int size = client.Receive(buffer);
                string plate = Encoding.UTF8.GetString(buffer, 0, size).Trim();

                if (!string.IsNullOrEmpty(plate))
                {
                    Console.WriteLine("Gelen plaka: " + plate);
                  
                    if (Veriİşle.PLAKA_KONTROL(plate.Trim())) { MessageBox.Show("Başarılı"); } else { MessageBox.Show("Başarısız"); }
                    // burada UI günceller veya veritabanına kaydedersin
                    
                }
            }

            string pythonPath = @"C:\Users\Lab10-Ogrenci09\AppData\Local\Programs\Python\Python310\python.exe"; // Gerçek python.exe yolu
            string scriptPath = @"C:\Users\Lab10-Ogrenci09\Desktop\Otopark_Repo-main\Otopark\Otopark\opencv2.py";

            var psi = new ProcessStartInfo()
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\"", // Script yolunu tırnak içine al
                UseShellExecute = false,          // Çıktıları almak için false
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = @"C:\Users\Lab10-Ogrenci09\Desktop\Otopark_Repo-main\Otopark\Otopark" // Scriptin olduğu klasör

            };

            try
            {
                using (var process = Process.Start(psi))
                {

                    process.WaitForExit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
           
        }

        private void btnOturumKapa_Click(object sender, EventArgs e)
        {
            Navigatör.Pusula.HedefFormuAç(this, new GirisForm());
        }
    }
}
