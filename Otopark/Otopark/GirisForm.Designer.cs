namespace Otopark
{
    partial class GirisForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtŞifre = new System.Windows.Forms.TextBox();
            this.lblGiriş = new System.Windows.Forms.Label();
            this.lblŞifre = new System.Windows.Forms.Label();
            this.lblKullanıcıAdı = new System.Windows.Forms.Label();
            this.cbŞifreGöster = new System.Windows.Forms.CheckBox();
            this.txtKullanıcıAdı = new System.Windows.Forms.TextBox();
            this.btnGirişYap = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtŞifre);
            this.panel1.Controls.Add(this.lblGiriş);
            this.panel1.Controls.Add(this.lblŞifre);
            this.panel1.Controls.Add(this.lblKullanıcıAdı);
            this.panel1.Controls.Add(this.cbŞifreGöster);
            this.panel1.Controls.Add(this.txtKullanıcıAdı);
            this.panel1.Controls.Add(this.btnGirişYap);
            this.panel1.Location = new System.Drawing.Point(224, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 314);
            this.panel1.TabIndex = 22;
            // 
            // txtŞifre
            // 
            this.txtŞifre.Location = new System.Drawing.Point(191, 143);
            this.txtŞifre.Name = "txtŞifre";
            this.txtŞifre.Size = new System.Drawing.Size(127, 20);
            this.txtŞifre.TabIndex = 12;
            // 
            // lblGiriş
            // 
            this.lblGiriş.AutoSize = true;
            this.lblGiriş.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGiriş.Location = new System.Drawing.Point(235, 9);
            this.lblGiriş.Name = "lblGiriş";
            this.lblGiriş.Size = new System.Drawing.Size(83, 31);
            this.lblGiriş.TabIndex = 19;
            this.lblGiriş.Text = "Giriş ";
            // 
            // lblŞifre
            // 
            this.lblŞifre.AutoSize = true;
            this.lblŞifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblŞifre.Location = new System.Drawing.Point(110, 145);
            this.lblŞifre.Name = "lblŞifre";
            this.lblŞifre.Size = new System.Drawing.Size(75, 20);
            this.lblŞifre.TabIndex = 13;
            this.lblŞifre.Text = "Şifreniz:";
            // 
            // lblKullanıcıAdı
            // 
            this.lblKullanıcıAdı.AutoSize = true;
            this.lblKullanıcıAdı.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanıcıAdı.Location = new System.Drawing.Point(51, 89);
            this.lblKullanıcıAdı.Name = "lblKullanıcıAdı";
            this.lblKullanıcıAdı.Size = new System.Drawing.Size(134, 20);
            this.lblKullanıcıAdı.TabIndex = 11;
            this.lblKullanıcıAdı.Text = "Kullanıcı Adınız:";
            // 
            // cbŞifreGöster
            // 
            this.cbŞifreGöster.AutoSize = true;
            this.cbŞifreGöster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbŞifreGöster.Location = new System.Drawing.Point(191, 171);
            this.cbŞifreGöster.Name = "cbŞifreGöster";
            this.cbŞifreGöster.Size = new System.Drawing.Size(109, 20);
            this.cbŞifreGöster.TabIndex = 13;
            this.cbŞifreGöster.Text = "Şifreyi Göster ";
            this.cbŞifreGöster.UseVisualStyleBackColor = true;
            this.cbŞifreGöster.CheckedChanged += new System.EventHandler(this.cbŞifreGöster_CheckedChanged);
            // 
            // txtKullanıcıAdı
            // 
            this.txtKullanıcıAdı.Location = new System.Drawing.Point(191, 87);
            this.txtKullanıcıAdı.Name = "txtKullanıcıAdı";
            this.txtKullanıcıAdı.Size = new System.Drawing.Size(127, 20);
            this.txtKullanıcıAdı.TabIndex = 10;
            // 
            // btnGirişYap
            // 
            this.btnGirişYap.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnGirişYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGirişYap.Location = new System.Drawing.Point(369, 235);
            this.btnGirişYap.Name = "btnGirişYap";
            this.btnGirişYap.Size = new System.Drawing.Size(85, 27);
            this.btnGirişYap.TabIndex = 14;
            this.btnGirişYap.Text = "Giriş Yap ";
            this.btnGirişYap.UseVisualStyleBackColor = false;
            this.btnGirişYap.Click += new System.EventHandler(this.btnGirişYap_Click);
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Name = "GirisForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtŞifre;
        private System.Windows.Forms.Label lblGiriş;
        private System.Windows.Forms.Label lblŞifre;
        private System.Windows.Forms.Label lblKullanıcıAdı;
        private System.Windows.Forms.CheckBox cbŞifreGöster;
        private System.Windows.Forms.TextBox txtKullanıcıAdı;
        private System.Windows.Forms.Button btnGirişYap;
    }
}

