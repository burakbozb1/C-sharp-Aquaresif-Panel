namespace AquaResifPanel
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
            this.lblHos.Location = new System.Drawing.Point(44, 299);
            this.lblHos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHos.Name = "lblHos";
            this.lblHos.Size = new System.Drawing.Size(140, 29);
            this.lblHos.TabIndex = 0;
            this.lblHos.Text = "Hoşgeldiniz";
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.BackColor = System.Drawing.Color.Transparent;
            this.lblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.ForeColor = System.Drawing.Color.White;
            this.lblKullanici.Location = new System.Drawing.Point(44, 346);
            this.lblKullanici.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(31, 29);
            this.lblKullanici.TabIndex = 1;
            this.lblKullanici.Text = "...";
            // 
            // btnUrunMain
            // 
            this.btnUrunMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrunMain.Location = new System.Drawing.Point(377, 160);
            this.btnUrunMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnUrunMain.Name = "btnUrunMain";
            this.btnUrunMain.Size = new System.Drawing.Size(604, 55);
            this.btnUrunMain.TabIndex = 2;
            this.btnUrunMain.Text = "Ürünler";
            this.btnUrunMain.UseVisualStyleBackColor = true;
            this.btnUrunMain.Click += new System.EventHandler(this.btnUrunMain_Click);
            // 
            // btnKatMain
            // 
            this.btnKatMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKatMain.Location = new System.Drawing.Point(377, 87);
            this.btnKatMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnKatMain.Name = "btnKatMain";
            this.btnKatMain.Size = new System.Drawing.Size(604, 55);
            this.btnKatMain.TabIndex = 3;
            this.btnKatMain.Text = "Kategoriler";
            this.btnKatMain.UseVisualStyleBackColor = true;
            this.btnKatMain.Click += new System.EventHandler(this.btnKatMain_Click);
            // 
            // btnStandartTeklif
            // 
            this.btnStandartTeklif.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStandartTeklif.Location = new System.Drawing.Point(377, 237);
            this.btnStandartTeklif.Margin = new System.Windows.Forms.Padding(4);
            this.btnStandartTeklif.Name = "btnStandartTeklif";
            this.btnStandartTeklif.Size = new System.Drawing.Size(604, 55);
            this.btnStandartTeklif.TabIndex = 4;
            this.btnStandartTeklif.Text = "Standart Teklif Hazırla";
            this.btnStandartTeklif.UseVisualStyleBackColor = true;
            this.btnStandartTeklif.Click += new System.EventHandler(this.btnStandartTeklif_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(379, 398);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(603, 55);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tüm Teklifler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTumSiparisler
            // 
            this.btnTumSiparisler.Enabled = false;
            this.btnTumSiparisler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTumSiparisler.Location = new System.Drawing.Point(377, 480);
            this.btnTumSiparisler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTumSiparisler.Name = "btnTumSiparisler";
            this.btnTumSiparisler.Size = new System.Drawing.Size(604, 55);
            this.btnTumSiparisler.TabIndex = 6;
            this.btnTumSiparisler.Text = "Siparişler";
            this.btnTumSiparisler.UseVisualStyleBackColor = true;
            // 
            // btnOzelTeklif
            // 
            this.btnOzelTeklif.Enabled = false;
            this.btnOzelTeklif.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOzelTeklif.Location = new System.Drawing.Point(377, 320);
            this.btnOzelTeklif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOzelTeklif.Name = "btnOzelTeklif";
            this.btnOzelTeklif.Size = new System.Drawing.Size(604, 55);
            this.btnOzelTeklif.TabIndex = 7;
            this.btnOzelTeklif.Text = "Özel Teklif Oluştur";
            this.btnOzelTeklif.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(44, 87);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnSiparisGoruntule
            // 
            this.btnSiparisGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparisGoruntule.Location = new System.Drawing.Point(377, 556);
            this.btnSiparisGoruntule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSiparisGoruntule.Name = "btnSiparisGoruntule";
            this.btnSiparisGoruntule.Size = new System.Drawing.Size(604, 55);
            this.btnSiparisGoruntule.TabIndex = 6;
            this.btnSiparisGoruntule.Text = "Sipariş Görüntüle";
            this.btnSiparisGoruntule.UseVisualStyleBackColor = true;
            this.btnSiparisGoruntule.Click += new System.EventHandler(this.btnSiparisGoruntule_Click);
            // 
            // pcbYeniSiparis
            // 
            this.pcbYeniSiparis.Image = ((System.Drawing.Image)(resources.GetObject("pcbYeniSiparis.Image")));
            this.pcbYeniSiparis.Location = new System.Drawing.Point(44, 398);
            this.pcbYeniSiparis.Name = "pcbYeniSiparis";
            this.pcbYeniSiparis.Size = new System.Drawing.Size(275, 254);
            this.pcbYeniSiparis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbYeniSiparis.TabIndex = 9;
            this.pcbYeniSiparis.TabStop = false;
            this.pcbYeniSiparis.Click += new System.EventHandler(this.pcbYeniSiparis_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1029, 709);
            this.Controls.Add(this.pcbYeniSiparis);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOzelTeklif);
            this.Controls.Add(this.btnSiparisGoruntule);
            this.Controls.Add(this.btnTumSiparisler);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStandartTeklif);
            this.Controls.Add(this.btnKatMain);
            this.Controls.Add(this.btnUrunMain);
            this.Controls.Add(this.lblKullanici);
            this.Controls.Add(this.lblHos);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}