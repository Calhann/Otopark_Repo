using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
    internal class Navigatör
    {
        public class Pusula
        {
            public static void ProgramKapama()
            {
                DialogResult result = MessageBox.Show("Uygulamadan Çıkmak İstediğinize Emin Misiniz ", "Çıkış", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            /*public static void AnaMenü(Form ŞuAndkiForm)
            {
                AnaMenü AnaMenü = new YöneticiAnaMenü();
                AnaMenü.Show();
                ŞuAndkiForm.Hide();
            }*/


            public static void HedefFormuAç(Form ŞuAnkiForm, Form HedeFrom)
            {
                ŞuAnkiForm.Hide();
                HedeFrom.Show();
            }
        }


    }
}
