namespace AquaResifPanel
{
    partial class siparisOlusturFormu
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTeklifNo = new System.Windows.Forms.TextBox();
            this.btnTeklifGetir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSilikonRengi = new System.Windows.Forms.ComboBox();
            this.chcTumuExCl = new System.Windows.Forms.CheckBox();
            this.chcOnExCl = new System.Windows.Forms.CheckBox();
            this.chcSolExCl = new System.Windows.Forms.CheckBox();
            this.chcSagExCl = new System.Windows.Forms.CheckBox();
            this.chcArkaExCl = new System.Windows.Forms.CheckBox();
            this.chcTabanExCl = new System.Windows.Forms.CheckBox();
            this.rtxAciklama = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSiparisOlustur = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobilyaRengi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobilyaTipi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teklif No";
            // 
            // txtTeklifNo
            // 
            this.txtTeklifNo.Location = new System.Drawing.Point(217, 71);
            this.txtTeklifNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTeklifNo.Name = "txtTeklifNo";
            this.txtTeklifNo.Size = new System.Drawing.Size(202, 20);
            this.txtTeklifNo.TabIndex = 1;
            // 
            // btnTeklifGetir
            // 
            this.btnTeklifGetir.Location = new System.Drawing.Point(470, 69);
            this.btnTeklifGetir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTeklifGetir.Name = "btnTeklifGetir";
            this.btnTeklifGetir.Size = new System.Drawing.Size(88, 27);
            this.btnTeklifGetir.TabIndex = 2;
            this.btnTeklifGetir.Text = "Teklif Getir";
            this.btnTeklifGetir.UseVisualStyleBackColor = true;
            this.btnTeklifGetir.Click += new System.EventHandler(this.btnTeklifGetir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Silikon Rengi";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbSilikonRengi
            // 
            this.cmbSilikonRengi.FormattingEnabled = true;
            this.cmbSilikonRengi.Items.AddRange(new object[] {
            "Şeffaf",
            "Siyah"});
            this.cmbSilikonRengi.Location = new System.Drawing.Point(217, 123);
            this.cmbSilikonRengi.Name = "cmbSilikonRengi";
            this.cmbSilikonRengi.Size = new System.Drawing.Size(202, 21);
            this.cmbSilikonRengi.TabIndex = 3;
            // 
            // chcTumuExCl
            // 
            this.chcTumuExCl.AutoSize = true;
            this.chcTumuExCl.Location = new System.Drawing.Point(217, 184);
            this.chcTumuExCl.Name = "chcTumuExCl";
            this.chcTumuExCl.Size = new System.Drawing.Size(135, 19);
            this.chcTumuExCl.TabIndex = 4;
            this.chcTumuExCl.Text = "Tamamı ExtraClear";
            this.chcTumuExCl.UseVisualStyleBackColor = true;
            this.chcTumuExCl.CheckedChanged += new System.EventHandler(this.chcTumuExCl_CheckedChanged);
            // 
            // chcOnExCl
            // 
            this.chcOnExCl.AutoSize = true;
            this.chcOnExCl.Location = new System.Drawing.Point(217, 224);
            this.chcOnExCl.Name = "chcOnExCl";
            this.chcOnExCl.Size = new System.Drawing.Size(134, 19);
            this.chcOnExCl.TabIndex = 4;
            this.chcOnExCl.Text = "Ön Cam ExtraClear";
            this.chcOnExCl.UseVisualStyleBackColor = true;
            this.chcOnExCl.CheckedChanged += new System.EventHandler(this.chcOnExCl_CheckedChanged);
            // 
            // chcSolExCl
            // 
            this.chcSolExCl.AutoSize = true;
            this.chcSolExCl.Location = new System.Drawing.Point(217, 303);
            this.chcSolExCl.Name = "chcSolExCl";
            this.chcSolExCl.Size = new System.Drawing.Size(136, 19);
            this.chcSolExCl.TabIndex = 4;
            this.chcSolExCl.Text = "Sol Cam ExtraClear";
            this.chcSolExCl.UseVisualStyleBackColor = true;
            this.chcSolExCl.CheckedChanged += new System.EventHandler(this.chcSolExCl_CheckedChanged);
            // 
            // chcSagExCl
            // 
            this.chcSagExCl.AutoSize = true;
            this.chcSagExCl.Location = new System.Drawing.Point(217, 343);
            this.chcSagExCl.Name = "chcSagExCl";
            this.chcSagExCl.Size = new System.Drawing.Size(140, 19);
            this.chcSagExCl.TabIndex = 4;
            this.chcSagExCl.Text = "Sağ Cam ExtraClear";
            this.chcSagExCl.UseVisualStyleBackColor = true;
            this.chcSagExCl.CheckedChanged += new System.EventHandler(this.chcSagExCl_CheckedChanged);
            // 
            // chcArkaExCl
            // 
            this.chcArkaExCl.AutoSize = true;
            this.chcArkaExCl.Location = new System.Drawing.Point(217, 261);
            this.chcArkaExCl.Name = "chcArkaExCl";
            this.chcArkaExCl.Size = new System.Drawing.Size(142, 19);
            this.chcArkaExCl.TabIndex = 4;
            this.chcArkaExCl.Text = "Arka Cam ExtraClear";
            this.chcArkaExCl.UseVisualStyleBackColor = true;
            this.chcArkaExCl.CheckedChanged += new System.EventHandler(this.chcArkaExCl_CheckedChanged);
            // 
            // chcTabanExCl
            // 
            this.chcTabanExCl.AutoSize = true;
            this.chcTabanExCl.Location = new System.Drawing.Point(217, 383);
            this.chcTabanExCl.Name = "chcTabanExCl";
            this.chcTabanExCl.Size = new System.Drawing.Size(156, 19);
            this.chcTabanExCl.TabIndex = 4;
            this.chcTabanExCl.Text = "Taban Camı ExtraClear";
            this.chcTabanExCl.UseVisualStyleBackColor = true;
            this.chcTabanExCl.CheckedChanged += new System.EventHandler(this.chcTabanExCl_CheckedChanged);
            // 
            // rtxAciklama
            // 
            this.rtxAciklama.Location = new System.Drawing.Point(217, 553);
            this.rtxAciklama.Name = "rtxAciklama";
            this.rtxAciklama.Size = new System.Drawing.Size(341, 127);
            this.rtxAciklama.TabIndex = 5;
            this.rtxAciklama.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "ExtraClear Cam Seçimi";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 556);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Açıklama";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSiparisOlustur
            // 
            this.btnSiparisOlustur.Location = new System.Drawing.Point(217, 700);
            this.btnSiparisOlustur.Name = "btnSiparisOlustur";
            this.btnSiparisOlustur.Size = new System.Drawing.Size(341, 43);
            this.btnSiparisOlustur.TabIndex = 6;
            this.btnSiparisOlustur.Text = "Sipariş Oluştur";
            this.btnSiparisOlustur.UseVisualStyleBackColor = true;
            this.btnSiparisOlustur.Click += new System.EventHandler(this.btnSiparisOlustur_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 445);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mobilya Rengi";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtMobilyaRengi
            // 
            this.txtMobilyaRengi.Location = new System.Drawing.Point(217, 445);
            this.txtMobilyaRengi.Name = "txtMobilyaRengi";
            this.txtMobilyaRengi.Size = new System.Drawing.Size(202, 20);
            this.txtMobilyaRengi.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 487);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mobilya Tipi";
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtMobilyaTipi
            // 
            this.txtMobilyaTipi.Location = new System.Drawing.Point(217, 484);
            this.txtMobilyaTipi.Name = "txtMobilyaTipi";
            this.txtMobilyaTipi.Size = new System.Drawing.Size(202, 20);
            this.txtMobilyaTipi.TabIndex = 7;
            // 
            // siparisOlusturFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 766);
            this.Controls.Add(this.txtMobilyaTipi);
            this.Controls.Add(this.txtMobilyaRengi);
            this.Controls.Add(this.btnSiparisOlustur);
            this.Controls.Add(this.rtxAciklama);
            this.Controls.Add(this.chcArkaExCl);
            this.Controls.Add(this.chcTabanExCl);
            this.Controls.Add(this.chcSagExCl);
            this.Controls.Add(this.chcSolExCl);
            this.Controls.Add(this.chcOnExCl);
            this.Controls.Add(this.chcTumuExCl);
            this.Controls.Add(this.cmbSilikonRengi);
            this.Controls.Add(this.btnTeklifGetir);
            this.Controls.Add(this.txtTeklifNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "siparisOlusturFormu";
            this.Text = "siparisOlusturFormu";
            this.Load += new System.EventHandler(this.siparisOlusturFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeklifNo;
        private System.Windows.Forms.Button btnTeklifGetir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSilikonRengi;
        private System.Windows.Forms.CheckBox chcTumuExCl;
        private System.Windows.Forms.CheckBox chcOnExCl;
        private System.Windows.Forms.CheckBox chcSolExCl;
        private System.Windows.Forms.CheckBox chcSagExCl;
        private System.Windows.Forms.CheckBox chcArkaExCl;
        private System.Windows.Forms.CheckBox chcTabanExCl;
        private System.Windows.Forms.RichTextBox rtxAciklama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSiparisOlustur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMobilyaRengi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMobilyaTipi;
    }
}