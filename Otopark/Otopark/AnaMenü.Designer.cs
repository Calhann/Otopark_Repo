namespace Otopark
{
    partial class AnaMenü
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOturumKapa = new System.Windows.Forms.Button();
            this.lblMeraba = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.lblProfilAd = new System.Windows.Forms.Label();
            this.btnProfil = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOturumKapa
            // 
            this.btnOturumKapa.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnOturumKapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOturumKapa.Location = new System.Drawing.Point(180, 272);
            this.btnOturumKapa.Name = "btnOturumKapa";
            this.btnOturumKapa.Size = new System.Drawing.Size(200, 39);
            this.btnOturumKapa.TabIndex = 23;
            this.btnOturumKapa.Text = "Oturumunuzu Kapayın";
            this.btnOturumKapa.UseVisualStyleBackColor = false;
            this.btnOturumKapa.Click += new System.EventHandler(this.btnOturumKapa_Click);
            // 
            // lblMeraba
            // 
            this.lblMeraba.AutoSize = true;
            this.lblMeraba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMeraba.Location = new System.Drawing.Point(107, 162);
            this.lblMeraba.Name = "lblMeraba";
            this.lblMeraba.Size = new System.Drawing.Size(98, 24);
            this.lblMeraba.TabIndex = 20;
            this.lblMeraba.Text = "Merhaba:";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(168, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(200, 159);
            this.pb.TabIndex = 22;
            this.pb.TabStop = false;
            // 
            // lblProfilAd
            // 
            this.lblProfilAd.AutoSize = true;
            this.lblProfilAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProfilAd.Location = new System.Drawing.Point(203, 162);
            this.lblProfilAd.Name = "lblProfilAd";
            this.lblProfilAd.Size = new System.Drawing.Size(0, 24);
            this.lblProfilAd.TabIndex = 19;
            // 
            // btnProfil
            // 
            this.btnProfil.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnProfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProfil.Location = new System.Drawing.Point(164, 225);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(231, 41);
            this.btnProfil.TabIndex = 21;
            this.btnProfil.Text = "Profilinizi Görünteleyin ";
            this.btnProfil.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnProfil);
            this.panel1.Controls.Add(this.btnOturumKapa);
            this.panel1.Controls.Add(this.lblProfilAd);
            this.panel1.Controls.Add(this.lblMeraba);
            this.panel1.Controls.Add(this.pb);
            this.panel1.Location = new System.Drawing.Point(69, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 389);
            this.panel1.TabIndex = 24;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1085, 229);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(906, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kamera Seçiniz:";
            // 
            // AnaMenü
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 1011);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Name = "AnaMenü";
            this.Text = "AnaMenü";
            this.Load += new System.EventHandler(this.AnaMenü_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOturumKapa;
        private System.Windows.Forms.Label lblMeraba;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label lblProfilAd;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}