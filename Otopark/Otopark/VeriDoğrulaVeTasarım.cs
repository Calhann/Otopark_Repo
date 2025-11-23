using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
    internal class VeriDoğrulaVeTasarım
    {   public class Sifre
        {
            public static void Yıldızla(TextBox txtSifre)
            {


                txtSifre.PasswordChar = '*';
            }
            public static void GörünürYap(TextBox txtSifre)
            {
                txtSifre.PasswordChar = '\0';
                
            }
        }
    }
}
