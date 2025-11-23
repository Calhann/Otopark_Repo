using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
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
            lblProfilAd.Text = "Hoş Geldiniz" + YPkullaniciAdi +"Bey";
        }

        private void btnOturumKapa_Click(object sender, EventArgs e)
        {
            Navigatör.Pusula.HedefFormuAç(this, new GirisForm());
        }
    }
}
