using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Otopark.Navigatör;

namespace Otopark
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VeriDoğrulaVeTasarım.Sifre.Yıldızla(txtŞifre);
        }

        private void cbŞifreGöster_CheckedChanged(object sender, EventArgs e)
        {
            if (cbŞifreGöster.Checked)
            {
                
                 VeriDoğrulaVeTasarım.Sifre.GörünürYap(txtŞifre);
            }
            else { VeriDoğrulaVeTasarım.Sifre.Yıldızla(txtŞifre); }
        }

        private void btnGirişYap_Click(object sender, EventArgs e)
        {
            string kullanıcıAdı = txtKullanıcıAdı.Text.Trim();
            string sifre = txtŞifre.Text.Trim();

            if (Veriİşle.Yönetici_Giris(sifre, kullanıcıAdı))
            {
                MessageBox.Show("Giriş başarılı");
                AnaMenü ProfilAd = new AnaMenü(txtKullanıcıAdı.Text);
                Pusula.HedefFormuAç(this, new AnaMenü(txtKullanıcıAdı.Text));

            }
            else
            {
                MessageBox.Show("Giriş Yapılamadı", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
