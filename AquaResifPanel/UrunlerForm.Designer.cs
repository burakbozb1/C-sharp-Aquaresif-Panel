namespace AquaResifPanel
{
    partial class UrunlerForm
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
            this.cmbKategoriAdi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstUrunler = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGuncelAd = new System.Windows.Forms.TextBox();
            this.txtGuncelAciklama = new System.Windows.Forms.TextBox();
            this.txtGuncelFiyat = new System.Windows.Forms.TextBox();
            this.txtGuncelMarka = new System.Windows.Forms.TextBox();
            this.btnUrunGuncelle = new System.Windows.Forms.Button();
            this.cmbGuncelKat = new System.Windows.Forms.ComboBox();
            this.lblGuncelId = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbUrunKategori = new System.Windows.Forms.ComboBox();
            this.txtUrunAd = new System.Windows.Forms.TextBox();
            this.txtUrunAciklama = new System.Windows.Forms.TextBox();
            this.txtUrunFiyat = new System.Windows.Forms.TextBox();
            this.txtUrunMarka = new System.Windows.Forms.TextBox();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbKategoriAdi
            // 
            this.cmbKategoriAdi.FormattingEnabled = true;
            this.cmbKategoriAdi.Location = new System.Drawing.Point(148, 78);
            this.cmbKategoriAdi.Name = "cmbKategoriAdi";
            this.cmbKategoriAdi.Size = new System.Drawing.Size(121, 21);
            this.cmbKategoriAdi.TabIndex = 0;
            this.cmbKategoriAdi.SelectedIndexChanged += new System.EventHandler(this.cmbKategoriAdi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kategori Adı:";
            // 
            // lstUrunler
            // 
            this.lstUrunler.FormattingEnabled = true;
            this.lstUrunler.Location = new System.Drawing.Point(148, 142);
            this.lstUrunler.Name = "lstUrunler";
            this.lstUrunler.Size = new System.Drawing.Size(120, 95);
            this.lstUrunler.TabIndex = 2;
            this.lstUrunler.SelectedIndexChanged += new System.EventHandler(this.lstUrunler_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ürün Listele";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ürün Güncelle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ürün İd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ürün Kategorisi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ürün Adı";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ürün Açıklaması";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ürün Fiyatı";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Ürün Markası";
            // 
            // txtGuncelAd
            // 
            this.txtGuncelAd.Location = new System.Drawing.Point(513, 139);
            this.txtGuncelAd.Name = "txtGuncelAd";
            this.txtGuncelAd.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelAd.TabIndex = 6;
            // 
            // txtGuncelAciklama
            // 
            this.txtGuncelAciklama.Location = new System.Drawing.Point(513, 164);
            this.txtGuncelAciklama.Name = "txtGuncelAciklama";
            this.txtGuncelAciklama.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelAciklama.TabIndex = 6;
            // 
            // txtGuncelFiyat
            // 
            this.txtGuncelFiyat.Location = new System.Drawing.Point(513, 193);
            this.txtGuncelFiyat.Name = "txtGuncelFiyat";
            this.txtGuncelFiyat.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelFiyat.TabIndex = 6;
            // 
            // txtGuncelMarka
            // 
            this.txtGuncelMarka.Location = new System.Drawing.Point(513, 221);
            this.txtGuncelMarka.Name = "txtGuncelMarka";
            this.txtGuncelMarka.Size = new System.Drawing.Size(100, 20);
            this.txtGuncelMarka.TabIndex = 6;
            // 
            // btnUrunGuncelle
            // 
            this.btnUrunGuncelle.Location = new System.Drawing.Point(513, 265);
            this.btnUrunGuncelle.Name = "btnUrunGuncelle";
            this.btnUrunGuncelle.Size = new System.Drawing.Size(100, 23);
            this.btnUrunGuncelle.TabIndex = 7;
            this.btnUrunGuncelle.Text = "Ürün Güncelle";
            this.btnUrunGuncelle.UseVisualStyleBackColor = true;
            this.btnUrunGuncelle.Click += new System.EventHandler(this.btnUrunGuncelle_Click);
            // 
            // cmbGuncelKat
            // 
            this.cmbGuncelKat.FormattingEnabled = true;
            this.cmbGuncelKat.Location = new System.Drawing.Point(513, 111);
            this.cmbGuncelKat.Name = "cmbGuncelKat";
            this.cmbGuncelKat.Size = new System.Drawing.Size(100, 21);
            this.cmbGuncelKat.TabIndex = 8;
            // 
            // lblGuncelId
            // 
            this.lblGuncelId.AutoSize = true;
            this.lblGuncelId.Location = new System.Drawing.Point(510, 78);
            this.lblGuncelId.Name = "lblGuncelId";
            this.lblGuncelId.Size = new System.Drawing.Size(16, 13);
            this.lblGuncelId.TabIndex = 9;
            this.lblGuncelId.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(693, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "ÜrünEkle";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(693, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Ürün Kategorisi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(693, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Ürün Adı";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(693, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ürün Açıklaması";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(693, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Ürün Fiyatı";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(693, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Ürün Markası";
            // 
            // cmbUrunKategori
            // 
            this.cmbUrunKategori.FormattingEnabled = true;
            this.cmbUrunKategori.Location = new System.Drawing.Point(799, 106);
            this.cmbUrunKategori.Name = "cmbUrunKategori";
            this.cmbUrunKategori.Size = new System.Drawing.Size(121, 21);
            this.cmbUrunKategori.TabIndex = 11;
            // 
            // txtUrunAd
            // 
            this.txtUrunAd.Location = new System.Drawing.Point(799, 139);
            this.txtUrunAd.Name = "txtUrunAd";
            this.txtUrunAd.Size = new System.Drawing.Size(121, 20);
            this.txtUrunAd.TabIndex = 12;
            // 
            // txtUrunAciklama
            // 
            this.txtUrunAciklama.Location = new System.Drawing.Point(799, 164);
            this.txtUrunAciklama.Name = "txtUrunAciklama";
            this.txtUrunAciklama.Size = new System.Drawing.Size(121, 20);
            this.txtUrunAciklama.TabIndex = 12;
            // 
            // txtUrunFiyat
            // 
            this.txtUrunFiyat.Location = new System.Drawing.Point(799, 193);
            this.txtUrunFiyat.Name = "txtUrunFiyat";
            this.txtUrunFiyat.Size = new System.Drawing.Size(121, 20);
            this.txtUrunFiyat.TabIndex = 12;
            // 
            // txtUrunMarka
            // 
            this.txtUrunMarka.Location = new System.Drawing.Point(799, 219);
            this.txtUrunMarka.Name = "txtUrunMarka";
            this.txtUrunMarka.Size = new System.Drawing.Size(121, 20);
            this.txtUrunMarka.TabIndex = 12;
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Location = new System.Drawing.Point(799, 265);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(121, 23);
            this.btnUrunEkle.TabIndex = 13;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.Location = new System.Drawing.Point(148, 265);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(120, 23);
            this.btnUrunSil.TabIndex = 14;
            this.btnUrunSil.Text = "Ürün Sil";
            this.btnUrunSil.UseVisualStyleBackColor = true;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // UrunlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 393);
            this.Controls.Add(this.btnUrunSil);
            this.Controls.Add(this.btnUrunEkle);
            this.Controls.Add(this.txtUrunMarka);
            this.Controls.Add(this.txtUrunFiyat);
            this.Controls.Add(this.txtUrunAciklama);
            this.Controls.Add(this.txtUrunAd);
            this.Controls.Add(this.cmbUrunKategori);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblGuncelId);
            this.Controls.Add(this.cmbGuncelKat);
            this.Controls.Add(this.btnUrunGuncelle);
            this.Controls.Add(this.txtGuncelMarka);
            this.Controls.Add(this.txtGuncelFiyat);
            this.Controls.Add(this.txtGuncelAciklama);
            this.Controls.Add(this.txtGuncelAd);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstUrunler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKategoriAdi);
            this.Name = "UrunlerForm";
            this.Text = "Urunler";
            this.Load += new System.EventHandler(this.UrunlerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKategoriAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstUrunler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGuncelAd;
        private System.Windows.Forms.TextBox txtGuncelAciklama;
        private System.Windows.Forms.TextBox txtGuncelFiyat;
        private System.Windows.Forms.TextBox txtGuncelMarka;
        private System.Windows.Forms.Button btnUrunGuncelle;
        private System.Windows.Forms.ComboBox cmbGuncelKat;
        private System.Windows.Forms.Label lblGuncelId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbUrunKategori;
        private System.Windows.Forms.TextBox txtUrunAd;
        private System.Windows.Forms.TextBox txtUrunAciklama;
        private System.Windows.Forms.TextBox txtUrunFiyat;
        private System.Windows.Forms.TextBox txtUrunMarka;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunSil;
    }
}