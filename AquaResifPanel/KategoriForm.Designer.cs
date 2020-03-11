namespace AquaResifPanel
{
    partial class KategoriForm
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
            this.lstKategoriler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKatId = new System.Windows.Forms.Label();
            this.txtKatAdi = new System.Windows.Forms.TextBox();
            this.btnKatGuncelle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYeniKatAdi = new System.Windows.Forms.TextBox();
            this.btnKatEkle = new System.Windows.Forms.Button();
            this.btnKatSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstKategoriler
            // 
            this.lstKategoriler.FormattingEnabled = true;
            this.lstKategoriler.Location = new System.Drawing.Point(47, 85);
            this.lstKategoriler.Name = "lstKategoriler";
            this.lstKategoriler.Size = new System.Drawing.Size(198, 251);
            this.lstKategoriler.TabIndex = 0;
            this.lstKategoriler.SelectedIndexChanged += new System.EventHandler(this.lstKategoriler_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tüm Kategoriler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategori Düzenle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kategori Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Yeni Kategori Adı";
            // 
            // lblKatId
            // 
            this.lblKatId.AutoSize = true;
            this.lblKatId.Location = new System.Drawing.Point(401, 85);
            this.lblKatId.Name = "lblKatId";
            this.lblKatId.Size = new System.Drawing.Size(16, 13);
            this.lblKatId.TabIndex = 3;
            this.lblKatId.Text = "...";
            // 
            // txtKatAdi
            // 
            this.txtKatAdi.Location = new System.Drawing.Point(404, 116);
            this.txtKatAdi.Name = "txtKatAdi";
            this.txtKatAdi.Size = new System.Drawing.Size(100, 20);
            this.txtKatAdi.TabIndex = 4;
            // 
            // btnKatGuncelle
            // 
            this.btnKatGuncelle.Location = new System.Drawing.Point(404, 166);
            this.btnKatGuncelle.Name = "btnKatGuncelle";
            this.btnKatGuncelle.Size = new System.Drawing.Size(100, 23);
            this.btnKatGuncelle.TabIndex = 5;
            this.btnKatGuncelle.Text = "Kategori Güncelle";
            this.btnKatGuncelle.UseVisualStyleBackColor = true;
            this.btnKatGuncelle.Click += new System.EventHandler(this.btnKatGuncelle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kategori Ekle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(603, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Kategori Adı";
            // 
            // txtYeniKatAdi
            // 
            this.txtYeniKatAdi.Location = new System.Drawing.Point(697, 82);
            this.txtYeniKatAdi.Name = "txtYeniKatAdi";
            this.txtYeniKatAdi.Size = new System.Drawing.Size(100, 20);
            this.txtYeniKatAdi.TabIndex = 8;
            // 
            // btnKatEkle
            // 
            this.btnKatEkle.Location = new System.Drawing.Point(697, 166);
            this.btnKatEkle.Name = "btnKatEkle";
            this.btnKatEkle.Size = new System.Drawing.Size(100, 23);
            this.btnKatEkle.TabIndex = 9;
            this.btnKatEkle.Text = "Kategori Ekle";
            this.btnKatEkle.UseVisualStyleBackColor = true;
            this.btnKatEkle.Click += new System.EventHandler(this.btnKatEkle_Click);
            // 
            // btnKatSil
            // 
            this.btnKatSil.Location = new System.Drawing.Point(47, 366);
            this.btnKatSil.Name = "btnKatSil";
            this.btnKatSil.Size = new System.Drawing.Size(198, 23);
            this.btnKatSil.TabIndex = 10;
            this.btnKatSil.Text = "Seçili Kategoriyi Sil";
            this.btnKatSil.UseVisualStyleBackColor = true;
            this.btnKatSil.Click += new System.EventHandler(this.btnKatSil_Click);
            // 
            // KategoriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 450);
            this.Controls.Add(this.btnKatSil);
            this.Controls.Add(this.btnKatEkle);
            this.Controls.Add(this.txtYeniKatAdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnKatGuncelle);
            this.Controls.Add(this.txtKatAdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblKatId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstKategoriler);
            this.Name = "KategoriForm";
            this.Text = "KategoriForm";
            this.Load += new System.EventHandler(this.KategoriForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstKategoriler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKatId;
        private System.Windows.Forms.TextBox txtKatAdi;
        private System.Windows.Forms.Button btnKatGuncelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYeniKatAdi;
        private System.Windows.Forms.Button btnKatEkle;
        private System.Windows.Forms.Button btnKatSil;
    }
}