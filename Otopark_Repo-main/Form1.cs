using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Otopark
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string pythonPath = @"C:\Python312\python.exe"; // Gerçek python.exe yolu
            string scriptPath = @"C:\Users\Lab10-Ogrenci09\Desktop\Otopark_Repo-main\opencv2.py";

            var psi = new ProcessStartInfo()
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\"", // Script yolunu tırnak içine al
                UseShellExecute = false,          // Çıktıları almak için false
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true        ,
                WorkingDirectory = @"C:\Users\Lab10-Ogrenci09\Desktop\Otopark_Repo-main" // Scriptin olduğu klasör

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
    }
}
