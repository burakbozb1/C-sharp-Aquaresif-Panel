﻿namespace AquaResifPanel
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.lblHos = new System.Windows.Forms.Label();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.btnUrunMain = new System.Windows.Forms.Button();
            this.btnKatMain = new System.Windows.Forms.Button();
            this.btnStandartTeklif = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTumSiparisler = new System.Windows.Forms.Button();
            this.btnOzelTeklif = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSiparisGoruntule = new System.Windows.Forms.Button();
            this.pcbYeniSiparis = new System.Windows.Forms.PictureBox();
            this.btnSiparisOlustur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbYeniSiparis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHos
            // 
            this.lblHos.AutoSize = true;
            this.lblHos.BackColor = System.Drawing.Color.Transparent;
            this.lblHos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHos.ForeColor = System.Drawing.Color.White;
            this.lblHos.Location = new System.Drawing.Point(33, 243);
            this.lblHos.Name = "lblHos";
            this.lblHos.Size = new System.Drawing.Size(109, 24);
            this.lblHos.TabIndex = 0;
            this.lblHos.Text = "Hoşgeldiniz";
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.BackColor = System.Drawing.Color.Transparent;
            this.lblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.ForeColor = System.Drawing.Color.White;
            this.lblKullanici.Location = new System.Drawing.Point(33, 281);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(25, 24);
            this.lblKullanici.TabIndex = 1;
            this.lblKullanici.Text = "...";
            // 
            // btnUrunMain
            // 
            this.btnUrunMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunMain.Location = new System.Drawing.Point(283, 122);
            this.btnUrunMain.Name = "btnUrunMain";
            this.btnUrunMain.Size = new System.Drawing.Size(453, 45);
            this.btnUrunMain.TabIndex = 2;
            this.btnUrunMain.Text = "Ürünler";
            this.btnUrunMain.UseVisualStyleBackColor = true;
            this.btnUrunMain.Click += new System.EventHandler(this.btnUrunMain_Click);
            // 
            // btnKatMain
            // 
            this.btnKatMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKatMain.Location = new System.Drawing.Point(283, 71);
            this.btnKatMain.Name = "btnKatMain";
            this.btnKatMain.Size = new System.Drawing.Size(453, 45);
            this.btnKatMain.TabIndex = 3;
            this.btnKatMain.Text = "Kategoriler";
            this.btnKatMain.UseVisualStyleBackColor = true;
            this.btnKatMain.Click += new System.EventHandler(this.btnKatMain_Click);
            // 
            // btnStandartTeklif
            // 
            this.btnStandartTeklif.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStandartTeklif.Location = new System.Drawing.Point(283, 173);
            this.btnStandartTeklif.Name = "btnStandartTeklif";
            this.btnStandartTeklif.Size = new System.Drawing.Size(453, 45);
            this.btnStandartTeklif.TabIndex = 4;
            this.btnStandartTeklif.Text = "Standart Teklif Hazırla";
            this.btnStandartTeklif.UseVisualStyleBackColor = true;
            this.btnStandartTeklif.Click += new System.EventHandler(this.btnStandartTeklif_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(283, 271);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(452, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tüm Teklifler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTumSiparisler
            // 
            this.btnTumSiparisler.Enabled = false;
            this.btnTumSiparisler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumSiparisler.Location = new System.Drawing.Point(283, 320);
            this.btnTumSiparisler.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTumSiparisler.Name = "btnTumSiparisler";
            this.btnTumSiparisler.Size = new System.Drawing.Size(453, 45);
            this.btnTumSiparisler.TabIndex = 6;
            this.btnTumSiparisler.Text = "Siparişler";
            this.btnTumSiparisler.UseVisualStyleBackColor = true;
            // 
            // btnOzelTeklif
            // 
            this.btnOzelTeklif.Enabled = false;
            this.btnOzelTeklif.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOzelTeklif.Location = new System.Drawing.Point(283, 222);
            this.btnOzelTeklif.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOzelTeklif.Name = "btnOzelTeklif";
            this.btnOzelTeklif.Size = new System.Drawing.Size(453, 45);
            this.btnOzelTeklif.TabIndex = 7;
            this.btnOzelTeklif.Text = "Özel Teklif Oluştur";
            this.btnOzelTeklif.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnSiparisGoruntule
            // 
            this.btnSiparisGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisGoruntule.Location = new System.Drawing.Point(283, 418);
            this.btnSiparisGoruntule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSiparisGoruntule.Name = "btnSiparisGoruntule";
            this.btnSiparisGoruntule.Size = new System.Drawing.Size(453, 45);
            this.btnSiparisGoruntule.TabIndex = 6;
            this.btnSiparisGoruntule.Text = "Sipariş Görüntüle";
            this.btnSiparisGoruntule.UseVisualStyleBackColor = true;
            this.btnSiparisGoruntule.Click += new System.EventHandler(this.btnSiparisGoruntule_Click);
            // 
            // pcbYeniSiparis
            // 
            this.pcbYeniSiparis.Image = ((System.Drawing.Image)(resources.GetObject("pcbYeniSiparis.Image")));
            this.pcbYeniSiparis.Location = new System.Drawing.Point(33, 323);
            this.pcbYeniSiparis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pcbYeniSiparis.Name = "pcbYeniSiparis";
            this.pcbYeniSiparis.Size = new System.Drawing.Size(206, 206);
            this.pcbYeniSiparis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbYeniSiparis.TabIndex = 9;
            this.pcbYeniSiparis.TabStop = false;
            this.pcbYeniSiparis.Click += new System.EventHandler(this.pcbYeniSiparis_Click);
            // 
            // btnSiparisOlustur
            // 
            this.btnSiparisOlustur.Enabled = false;
            this.btnSiparisOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisOlustur.Location = new System.Drawing.Point(283, 369);
            this.btnSiparisOlustur.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiparisOlustur.Name = "btnSiparisOlustur";
            this.btnSiparisOlustur.Size = new System.Drawing.Size(453, 45);
            this.btnSiparisOlustur.TabIndex = 6;
            this.btnSiparisOlustur.Text = "Sipariş Oluştur";
            this.btnSiparisOlustur.UseVisualStyleBackColor = true;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(772, 576);
            this.Controls.Add(this.pcbYeniSiparis);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOzelTeklif);
            this.Controls.Add(this.btnSiparisGoruntule);
            this.Controls.Add(this.btnSiparisOlustur);
            this.Controls.Add(this.btnTumSiparisler);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStandartTeklif);
            this.Controls.Add(this.btnKatMain);
            this.Controls.Add(this.btnUrunMain);
            this.Controls.Add(this.lblKullanici);
            this.Controls.Add(this.lblHos);
            this.DoubleBuffered = true;
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aquaresif Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnaForm_FormClosed);
            this.Load += new System.EventHandler(this.AnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbYeniSiparis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHos;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.Button btnUrunMain;
        private System.Windows.Forms.Button btnKatMain;
        private System.Windows.Forms.Button btnStandartTeklif;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTumSiparisler;
        private System.Windows.Forms.Button btnOzelTeklif;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSiparisGoruntule;
        private System.Windows.Forms.PictureBox pcbYeniSiparis;
        private System.Windows.Forms.Button btnSiparisOlustur;
    }
}