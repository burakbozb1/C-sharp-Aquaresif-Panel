namespace AquaResifPanel
{
    partial class tekliflerFormu
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
            this.btnTeklifAra = new System.Windows.Forms.Button();
            this.rdbMusteriAdi = new System.Windows.Forms.RadioButton();
            this.rdbTeklifNo = new System.Windows.Forms.RadioButton();
            this.grpMusteriAd = new System.Windows.Forms.GroupBox();
            this.txtMusteriAdiAra = new System.Windows.Forms.TextBox();
            this.grpTeklifNo = new System.Windows.Forms.GroupBox();
            this.txtTeklifNoAra = new System.Windows.Forms.TextBox();
            this.rdbTarih = new System.Windows.Forms.RadioButton();
            this.grpTarih = new System.Windows.Forms.GroupBox();
            this.lstTeklifler = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKonu = new System.Windows.Forms.TextBox();
            this.txtGsm = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtIlgiliKisi = new System.Windows.Forms.TextBox();
            this.txtTeslimSuresi = new System.Windows.Forms.TextBox();
            this.txtOdemeSekli = new System.Windows.Forms.TextBox();
            this.txtTeslimYeri = new System.Windows.Forms.TextBox();
            this.txtMusteri = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToplamFiyat = new System.Windows.Forms.Label();
            this.lblTeklifVeren = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTeklifNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtListelenenler = new System.Windows.Forms.DataGridView();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunCikar = new System.Windows.Forms.Button();
            this.btnTeklifGuncelle = new System.Windows.Forms.Button();
            this.btnTeklifSil = new System.Windows.Forms.Button();
            this.grpMusteriAd.SuspendLayout();
            this.grpTeklifNo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListelenenler)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTeklifAra
            // 
            this.btnTeklifAra.Location = new System.Drawing.Point(336, 83);
            this.btnTeklifAra.Name = "btnTeklifAra";
            this.btnTeklifAra.Size = new System.Drawing.Size(242, 65);
            this.btnTeklifAra.TabIndex = 0;
            this.btnTeklifAra.Text = "Ara";
            this.btnTeklifAra.UseVisualStyleBackColor = true;
            this.btnTeklifAra.Click += new System.EventHandler(this.btnTeklifAra_Click);
            // 
            // rdbMusteriAdi
            // 
            this.rdbMusteriAdi.AutoSize = true;
            this.rdbMusteriAdi.Location = new System.Drawing.Point(92, 83);
            this.rdbMusteriAdi.Name = "rdbMusteriAdi";
            this.rdbMusteriAdi.Size = new System.Drawing.Size(172, 21);
            this.rdbMusteriAdi.TabIndex = 1;
            this.rdbMusteriAdi.TabStop = true;
            this.rdbMusteriAdi.Text = "Müşteri adına göre ara";
            this.rdbMusteriAdi.UseVisualStyleBackColor = true;
            this.rdbMusteriAdi.CheckedChanged += new System.EventHandler(this.rdbMusteriAdi_CheckedChanged);
            // 
            // rdbTeklifNo
            // 
            this.rdbTeklifNo.AutoSize = true;
            this.rdbTeklifNo.Location = new System.Drawing.Point(92, 125);
            this.rdbTeklifNo.Name = "rdbTeklifNo";
            this.rdbTeklifNo.Size = new System.Drawing.Size(199, 21);
            this.rdbTeklifNo.TabIndex = 2;
            this.rdbTeklifNo.TabStop = true;
            this.rdbTeklifNo.Text = "Teklif numarasına göre ara";
            this.rdbTeklifNo.UseVisualStyleBackColor = true;
            this.rdbTeklifNo.CheckedChanged += new System.EventHandler(this.rdbTeklifNo_CheckedChanged);
            // 
            // grpMusteriAd
            // 
            this.grpMusteriAd.Controls.Add(this.txtMusteriAdiAra);
            this.grpMusteriAd.Location = new System.Drawing.Point(92, 229);
            this.grpMusteriAd.Name = "grpMusteriAd";
            this.grpMusteriAd.Size = new System.Drawing.Size(200, 119);
            this.grpMusteriAd.TabIndex = 3;
            this.grpMusteriAd.TabStop = false;
            this.grpMusteriAd.Text = "Müşteri Adı";
            // 
            // txtMusteriAdiAra
            // 
            this.txtMusteriAdiAra.Location = new System.Drawing.Point(15, 48);
            this.txtMusteriAdiAra.Name = "txtMusteriAdiAra";
            this.txtMusteriAdiAra.Size = new System.Drawing.Size(168, 22);
            this.txtMusteriAdiAra.TabIndex = 5;
            this.txtMusteriAdiAra.TextChanged += new System.EventHandler(this.txtMusteriAdiAra_TextChanged);
            // 
            // grpTeklifNo
            // 
            this.grpTeklifNo.Controls.Add(this.txtTeklifNoAra);
            this.grpTeklifNo.Location = new System.Drawing.Point(188, 210);
            this.grpTeklifNo.Name = "grpTeklifNo";
            this.grpTeklifNo.Size = new System.Drawing.Size(200, 119);
            this.grpTeklifNo.TabIndex = 3;
            this.grpTeklifNo.TabStop = false;
            this.grpTeklifNo.Text = "Teklif No";
            // 
            // txtTeklifNoAra
            // 
            this.txtTeklifNoAra.Location = new System.Drawing.Point(16, 48);
            this.txtTeklifNoAra.Name = "txtTeklifNoAra";
            this.txtTeklifNoAra.Size = new System.Drawing.Size(168, 22);
            this.txtTeklifNoAra.TabIndex = 5;
            this.txtTeklifNoAra.TextChanged += new System.EventHandler(this.txtMusteriAdiAra_TextChanged);
            // 
            // rdbTarih
            // 
            this.rdbTarih.AutoSize = true;
            this.rdbTarih.Location = new System.Drawing.Point(92, 167);
            this.rdbTarih.Name = "rdbTarih";
            this.rdbTarih.Size = new System.Drawing.Size(128, 21);
            this.rdbTarih.TabIndex = 4;
            this.rdbTarih.TabStop = true;
            this.rdbTarih.Text = "Tarihe göre ara";
            this.rdbTarih.UseVisualStyleBackColor = true;
            this.rdbTarih.CheckedChanged += new System.EventHandler(this.rdbTarih_CheckedChanged);
            // 
            // grpTarih
            // 
            this.grpTarih.Location = new System.Drawing.Point(298, 187);
            this.grpTarih.Name = "grpTarih";
            this.grpTarih.Size = new System.Drawing.Size(195, 200);
            this.grpTarih.TabIndex = 3;
            this.grpTarih.TabStop = false;
            this.grpTarih.Text = "Tarih";
            // 
            // lstTeklifler
            // 
            this.lstTeklifler.FormattingEnabled = true;
            this.lstTeklifler.ItemHeight = 16;
            this.lstTeklifler.Location = new System.Drawing.Point(92, 461);
            this.lstTeklifler.Name = "lstTeklifler";
            this.lstTeklifler.Size = new System.Drawing.Size(257, 292);
            this.lstTeklifler.TabIndex = 5;
            this.lstTeklifler.SelectedIndexChanged += new System.EventHandler(this.lstTeklifler_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKonu);
            this.panel1.Controls.Add(this.txtGsm);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtIlgiliKisi);
            this.panel1.Controls.Add(this.txtTeslimSuresi);
            this.panel1.Controls.Add(this.txtOdemeSekli);
            this.panel1.Controls.Add(this.txtTeslimYeri);
            this.panel1.Controls.Add(this.txtMusteri);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblToplamFiyat);
            this.panel1.Controls.Add(this.lblTeklifVeren);
            this.panel1.Controls.Add(this.lblTarih);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTeklifNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(607, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 265);
            this.panel1.TabIndex = 6;
            // 
            // txtKonu
            // 
            this.txtKonu.Location = new System.Drawing.Point(132, 213);
            this.txtKonu.Name = "txtKonu";
            this.txtKonu.Size = new System.Drawing.Size(195, 22);
            this.txtKonu.TabIndex = 1;
            // 
            // txtGsm
            // 
            this.txtGsm.Location = new System.Drawing.Point(132, 177);
            this.txtGsm.Name = "txtGsm";
            this.txtGsm.Size = new System.Drawing.Size(195, 22);
            this.txtGsm.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(132, 143);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // txtIlgiliKisi
            // 
            this.txtIlgiliKisi.Location = new System.Drawing.Point(132, 101);
            this.txtIlgiliKisi.Name = "txtIlgiliKisi";
            this.txtIlgiliKisi.Size = new System.Drawing.Size(195, 22);
            this.txtIlgiliKisi.TabIndex = 1;
            // 
            // txtTeslimSuresi
            // 
            this.txtTeslimSuresi.Location = new System.Drawing.Point(596, 101);
            this.txtTeslimSuresi.Name = "txtTeslimSuresi";
            this.txtTeslimSuresi.Size = new System.Drawing.Size(195, 22);
            this.txtTeslimSuresi.TabIndex = 1;
            // 
            // txtOdemeSekli
            // 
            this.txtOdemeSekli.Location = new System.Drawing.Point(596, 60);
            this.txtOdemeSekli.Name = "txtOdemeSekli";
            this.txtOdemeSekli.Size = new System.Drawing.Size(195, 22);
            this.txtOdemeSekli.TabIndex = 1;
            // 
            // txtTeslimYeri
            // 
            this.txtTeslimYeri.Location = new System.Drawing.Point(596, 21);
            this.txtTeslimYeri.Name = "txtTeslimYeri";
            this.txtTeslimYeri.Size = new System.Drawing.Size(195, 22);
            this.txtTeslimYeri.TabIndex = 1;
            // 
            // txtMusteri
            // 
            this.txtMusteri.Location = new System.Drawing.Point(132, 58);
            this.txtMusteri.Name = "txtMusteri";
            this.txtMusteri.Size = new System.Drawing.Size(195, 22);
            this.txtMusteri.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(473, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Toplam Fiyat";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(473, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Teklif Veren";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Konu";
            // 
            // lblToplamFiyat
            // 
            this.lblToplamFiyat.AutoSize = true;
            this.lblToplamFiyat.Location = new System.Drawing.Point(593, 216);
            this.lblToplamFiyat.Name = "lblToplamFiyat";
            this.lblToplamFiyat.Size = new System.Drawing.Size(41, 17);
            this.lblToplamFiyat.TabIndex = 0;
            this.lblToplamFiyat.Text = "Tarih";
            // 
            // lblTeklifVeren
            // 
            this.lblTeklifVeren.AutoSize = true;
            this.lblTeklifVeren.Location = new System.Drawing.Point(593, 182);
            this.lblTeklifVeren.Name = "lblTeklifVeren";
            this.lblTeklifVeren.Size = new System.Drawing.Size(41, 17);
            this.lblTeklifVeren.TabIndex = 0;
            this.lblTeklifVeren.Text = "Tarih";
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(593, 148);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(41, 17);
            this.lblTarih.TabIndex = 0;
            this.lblTarih.Text = "Tarih";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tarih";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "GSM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(473, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Teslim Süresi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "E-Mail";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(473, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ödeme Şekli";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "İlgili Kişi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(473, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Teslim Yeri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Müşteri";
            // 
            // lblTeklifNo
            // 
            this.lblTeklifNo.AutoSize = true;
            this.lblTeklifNo.Location = new System.Drawing.Point(129, 24);
            this.lblTeklifNo.Name = "lblTeklifNo";
            this.lblTeklifNo.Size = new System.Drawing.Size(20, 17);
            this.lblTeklifNo.TabIndex = 0;
            this.lblTeklifNo.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teklif No:";
            // 
            // dtListelenenler
            // 
            this.dtListelenenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListelenenler.Location = new System.Drawing.Point(440, 461);
            this.dtListelenenler.Name = "dtListelenenler";
            this.dtListelenenler.RowHeadersWidth = 51;
            this.dtListelenenler.RowTemplate.Height = 24;
            this.dtListelenenler.Size = new System.Drawing.Size(1129, 182);
            this.dtListelenenler.TabIndex = 7;
            this.dtListelenenler.SelectionChanged += new System.EventHandler(this.dtListelenenler_SelectionChanged);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Location = new System.Drawing.Point(440, 420);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(156, 23);
            this.btnUrunEkle.TabIndex = 8;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnUrunCikar
            // 
            this.btnUrunCikar.Location = new System.Drawing.Point(681, 420);
            this.btnUrunCikar.Name = "btnUrunCikar";
            this.btnUrunCikar.Size = new System.Drawing.Size(213, 23);
            this.btnUrunCikar.TabIndex = 9;
            this.btnUrunCikar.Text = "Ürün Çıkar";
            this.btnUrunCikar.UseVisualStyleBackColor = true;
            this.btnUrunCikar.Click += new System.EventHandler(this.btnUrunCikar_Click);
            // 
            // btnTeklifGuncelle
            // 
            this.btnTeklifGuncelle.Location = new System.Drawing.Point(440, 662);
            this.btnTeklifGuncelle.Name = "btnTeklifGuncelle";
            this.btnTeklifGuncelle.Size = new System.Drawing.Size(741, 54);
            this.btnTeklifGuncelle.TabIndex = 10;
            this.btnTeklifGuncelle.Text = "Teklifi Güncelle";
            this.btnTeklifGuncelle.UseVisualStyleBackColor = true;
            this.btnTeklifGuncelle.Click += new System.EventHandler(this.btnTeklifGuncelle_Click);
            // 
            // btnTeklifSil
            // 
            this.btnTeklifSil.Location = new System.Drawing.Point(1203, 662);
            this.btnTeklifSil.Name = "btnTeklifSil";
            this.btnTeklifSil.Size = new System.Drawing.Size(366, 54);
            this.btnTeklifSil.TabIndex = 11;
            this.btnTeklifSil.Text = "Teklifi Sil";
            this.btnTeklifSil.UseVisualStyleBackColor = true;
            this.btnTeklifSil.Click += new System.EventHandler(this.btnTeklifSil_Click);
            // 
            // tekliflerFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1674, 728);
            this.Controls.Add(this.btnTeklifSil);
            this.Controls.Add(this.btnTeklifGuncelle);
            this.Controls.Add(this.btnUrunCikar);
            this.Controls.Add(this.btnUrunEkle);
            this.Controls.Add(this.dtListelenenler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstTeklifler);
            this.Controls.Add(this.grpTeklifNo);
            this.Controls.Add(this.rdbTarih);
            this.Controls.Add(this.grpTarih);
            this.Controls.Add(this.grpMusteriAd);
            this.Controls.Add(this.rdbTeklifNo);
            this.Controls.Add(this.rdbMusteriAdi);
            this.Controls.Add(this.btnTeklifAra);
            this.Name = "tekliflerFormu";
            this.Text = "tekliflerFormu";
            this.Load += new System.EventHandler(this.tekliflerFormu_Load);
            this.grpMusteriAd.ResumeLayout(false);
            this.grpMusteriAd.PerformLayout();
            this.grpTeklifNo.ResumeLayout(false);
            this.grpTeklifNo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListelenenler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTeklifAra;
        private System.Windows.Forms.RadioButton rdbMusteriAdi;
        private System.Windows.Forms.RadioButton rdbTeklifNo;
        private System.Windows.Forms.GroupBox grpMusteriAd;
        private System.Windows.Forms.GroupBox grpTeklifNo;
        private System.Windows.Forms.RadioButton rdbTarih;
        private System.Windows.Forms.GroupBox grpTarih;
        private System.Windows.Forms.TextBox txtMusteriAdiAra;
        private System.Windows.Forms.TextBox txtTeklifNoAra;
        private System.Windows.Forms.ListBox lstTeklifler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTeklifNo;
        private System.Windows.Forms.TextBox txtKonu;
        private System.Windows.Forms.TextBox txtGsm;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtIlgiliKisi;
        private System.Windows.Forms.TextBox txtMusteri;
        private System.Windows.Forms.TextBox txtTeslimSuresi;
        private System.Windows.Forms.TextBox txtOdemeSekli;
        private System.Windows.Forms.TextBox txtTeslimYeri;
        private System.Windows.Forms.Label lblToplamFiyat;
        private System.Windows.Forms.Label lblTeklifVeren;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DataGridView dtListelenenler;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunCikar;
        private System.Windows.Forms.Button btnTeklifGuncelle;
        private System.Windows.Forms.Button btnTeklifSil;
    }
}