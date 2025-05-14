namespace _6_Seferde_Kelime_Ezeberleme
{
    partial class Form1
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
            this.butonGiris = new System.Windows.Forms.Button();
            this.butonKayit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHosGeldiniz = new System.Windows.Forms.TabPage();
            this.butonSifre = new System.Windows.Forms.Button();
            this.tabGiris = new System.Windows.Forms.TabPage();
            this.checkBoxGirisSifreGoster = new System.Windows.Forms.CheckBox();
            this.butonGirisGeri = new System.Windows.Forms.Button();
            this.butonGirisYap = new System.Windows.Forms.Button();
            this.labelUyeGiris = new System.Windows.Forms.Label();
            this.textBoxGirisSifre = new System.Windows.Forms.TextBox();
            this.textBoxGirisAd = new System.Windows.Forms.TextBox();
            this.labelGirisSifre = new System.Windows.Forms.Label();
            this.labelGirisKullaniciAd = new System.Windows.Forms.Label();
            this.tabKayit = new System.Windows.Forms.TabPage();
            this.checkBoxKayitSifreGoster = new System.Windows.Forms.CheckBox();
            this.butonKayitOl = new System.Windows.Forms.Button();
            this.butonKayitGeri = new System.Windows.Forms.Button();
            this.textBoxKayitSifre = new System.Windows.Forms.TextBox();
            this.textBoxKayitAd = new System.Windows.Forms.TextBox();
            this.labelKayitSifre = new System.Windows.Forms.Label();
            this.labelKayitKullaniciAd = new System.Windows.Forms.Label();
            this.labelUyeKaydi = new System.Windows.Forms.Label();
            this.tabSifreUnuttum = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butonSifreGonder = new System.Windows.Forms.Button();
            this.textBoxSifreMail = new System.Windows.Forms.TextBox();
            this.butonSifreGeri = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabHosGeldiniz.SuspendLayout();
            this.tabGiris.SuspendLayout();
            this.tabKayit.SuspendLayout();
            this.tabSifreUnuttum.SuspendLayout();
            this.SuspendLayout();
            // 
            // butonGiris
            // 
            this.butonGiris.BackColor = System.Drawing.Color.LightGray;
            this.butonGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonGiris.Location = new System.Drawing.Point(183, 200);
            this.butonGiris.Name = "butonGiris";
            this.butonGiris.Size = new System.Drawing.Size(168, 62);
            this.butonGiris.TabIndex = 0;
            this.butonGiris.Text = "GİRİŞ";
            this.butonGiris.UseVisualStyleBackColor = false;
            this.butonGiris.Click += new System.EventHandler(this.button1_Click);
            // 
            // butonKayit
            // 
            this.butonKayit.BackColor = System.Drawing.Color.LightGray;
            this.butonKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonKayit.Location = new System.Drawing.Point(183, 291);
            this.butonKayit.Name = "butonKayit";
            this.butonKayit.Size = new System.Drawing.Size(168, 62);
            this.butonKayit.TabIndex = 1;
            this.butonKayit.Text = "KAYIT OL";
            this.butonKayit.UseVisualStyleBackColor = false;
            this.butonKayit.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(118, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "HOŞ GELDİNİZ";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHosGeldiniz);
            this.tabControl.Controls.Add(this.tabGiris);
            this.tabControl.Controls.Add(this.tabKayit);
            this.tabControl.Controls.Add(this.tabSifreUnuttum);
            this.tabControl.Location = new System.Drawing.Point(49, 37);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(548, 478);
            this.tabControl.TabIndex = 3;
            // 
            // tabHosGeldiniz
            // 
            this.tabHosGeldiniz.Controls.Add(this.butonSifre);
            this.tabHosGeldiniz.Controls.Add(this.butonKayit);
            this.tabHosGeldiniz.Controls.Add(this.label1);
            this.tabHosGeldiniz.Controls.Add(this.butonGiris);
            this.tabHosGeldiniz.Location = new System.Drawing.Point(4, 25);
            this.tabHosGeldiniz.Name = "tabHosGeldiniz";
            this.tabHosGeldiniz.Padding = new System.Windows.Forms.Padding(3);
            this.tabHosGeldiniz.Size = new System.Drawing.Size(540, 449);
            this.tabHosGeldiniz.TabIndex = 0;
            this.tabHosGeldiniz.Text = "Hoş Geldiniz";
            this.tabHosGeldiniz.UseVisualStyleBackColor = true;
            this.tabHosGeldiniz.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // butonSifre
            // 
            this.butonSifre.BackColor = System.Drawing.Color.DimGray;
            this.butonSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonSifre.Location = new System.Drawing.Point(183, 378);
            this.butonSifre.Name = "butonSifre";
            this.butonSifre.Size = new System.Drawing.Size(168, 44);
            this.butonSifre.TabIndex = 3;
            this.butonSifre.Text = "Şifremi Unutum";
            this.butonSifre.UseVisualStyleBackColor = false;
            this.butonSifre.Click += new System.EventHandler(this.butonSifre_Click);
            // 
            // tabGiris
            // 
            this.tabGiris.Controls.Add(this.checkBoxGirisSifreGoster);
            this.tabGiris.Controls.Add(this.butonGirisGeri);
            this.tabGiris.Controls.Add(this.butonGirisYap);
            this.tabGiris.Controls.Add(this.labelUyeGiris);
            this.tabGiris.Controls.Add(this.textBoxGirisSifre);
            this.tabGiris.Controls.Add(this.textBoxGirisAd);
            this.tabGiris.Controls.Add(this.labelGirisSifre);
            this.tabGiris.Controls.Add(this.labelGirisKullaniciAd);
            this.tabGiris.Location = new System.Drawing.Point(4, 25);
            this.tabGiris.Name = "tabGiris";
            this.tabGiris.Padding = new System.Windows.Forms.Padding(3);
            this.tabGiris.Size = new System.Drawing.Size(540, 449);
            this.tabGiris.TabIndex = 1;
            this.tabGiris.Text = "Giriş";
            this.tabGiris.UseVisualStyleBackColor = true;
            this.tabGiris.Click += new System.EventHandler(this.tabGiris_Click);
            // 
            // checkBoxGirisSifreGoster
            // 
            this.checkBoxGirisSifreGoster.AutoSize = true;
            this.checkBoxGirisSifreGoster.Location = new System.Drawing.Point(399, 307);
            this.checkBoxGirisSifreGoster.Name = "checkBoxGirisSifreGoster";
            this.checkBoxGirisSifreGoster.Size = new System.Drawing.Size(18, 17);
            this.checkBoxGirisSifreGoster.TabIndex = 8;
            this.checkBoxGirisSifreGoster.UseVisualStyleBackColor = true;
            this.checkBoxGirisSifreGoster.CheckedChanged += new System.EventHandler(this.butonGirisSifreGoster_CheckedChanged);
            // 
            // butonGirisGeri
            // 
            this.butonGirisGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonGirisGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonGirisGeri.Location = new System.Drawing.Point(420, 381);
            this.butonGirisGeri.Name = "butonGirisGeri";
            this.butonGirisGeri.Size = new System.Drawing.Size(92, 37);
            this.butonGirisGeri.TabIndex = 5;
            this.butonGirisGeri.Text = "Geri ";
            this.butonGirisGeri.UseVisualStyleBackColor = false;
            this.butonGirisGeri.Click += new System.EventHandler(this.butonGirisGeri_Click);
            // 
            // butonGirisYap
            // 
            this.butonGirisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butonGirisYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonGirisYap.Location = new System.Drawing.Point(39, 370);
            this.butonGirisYap.Name = "butonGirisYap";
            this.butonGirisYap.Size = new System.Drawing.Size(141, 48);
            this.butonGirisYap.TabIndex = 6;
            this.butonGirisYap.Text = "GİRİŞ YAP";
            this.butonGirisYap.UseVisualStyleBackColor = true;
            this.butonGirisYap.Click += new System.EventHandler(this.butonGirisYap_Click);
            // 
            // labelUyeGiris
            // 
            this.labelUyeGiris.AutoSize = true;
            this.labelUyeGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUyeGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUyeGiris.Location = new System.Drawing.Point(31, 119);
            this.labelUyeGiris.Name = "labelUyeGiris";
            this.labelUyeGiris.Size = new System.Drawing.Size(244, 48);
            this.labelUyeGiris.TabIndex = 4;
            this.labelUyeGiris.Text = "ÜYE GİRİŞİ";
            this.labelUyeGiris.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxGirisSifre
            // 
            this.textBoxGirisSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxGirisSifre.Location = new System.Drawing.Point(200, 307);
            this.textBoxGirisSifre.Name = "textBoxGirisSifre";
            this.textBoxGirisSifre.ShortcutsEnabled = false;
            this.textBoxGirisSifre.Size = new System.Drawing.Size(217, 30);
            this.textBoxGirisSifre.TabIndex = 3;
            this.textBoxGirisSifre.TextChanged += new System.EventHandler(this.textBoxGirisSifre_TextChanged);
            // 
            // textBoxGirisAd
            // 
            this.textBoxGirisAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxGirisAd.Location = new System.Drawing.Point(200, 247);
            this.textBoxGirisAd.Name = "textBoxGirisAd";
            this.textBoxGirisAd.ShortcutsEnabled = false;
            this.textBoxGirisAd.Size = new System.Drawing.Size(217, 30);
            this.textBoxGirisAd.TabIndex = 2;
            // 
            // labelGirisSifre
            // 
            this.labelGirisSifre.AutoSize = true;
            this.labelGirisSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGirisSifre.Location = new System.Drawing.Point(122, 308);
            this.labelGirisSifre.Name = "labelGirisSifre";
            this.labelGirisSifre.Size = new System.Drawing.Size(72, 29);
            this.labelGirisSifre.TabIndex = 1;
            this.labelGirisSifre.Text = "Şifre:";
            // 
            // labelGirisKullaniciAd
            // 
            this.labelGirisKullaniciAd.AutoSize = true;
            this.labelGirisKullaniciAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGirisKullaniciAd.Location = new System.Drawing.Point(34, 248);
            this.labelGirisKullaniciAd.Name = "labelGirisKullaniciAd";
            this.labelGirisKullaniciAd.Size = new System.Drawing.Size(160, 29);
            this.labelGirisKullaniciAd.TabIndex = 0;
            this.labelGirisKullaniciAd.Text = "Kullanıcı Adı:";
            // 
            // tabKayit
            // 
            this.tabKayit.Controls.Add(this.checkBoxKayitSifreGoster);
            this.tabKayit.Controls.Add(this.butonKayitOl);
            this.tabKayit.Controls.Add(this.butonKayitGeri);
            this.tabKayit.Controls.Add(this.textBoxKayitSifre);
            this.tabKayit.Controls.Add(this.textBoxKayitAd);
            this.tabKayit.Controls.Add(this.labelKayitSifre);
            this.tabKayit.Controls.Add(this.labelKayitKullaniciAd);
            this.tabKayit.Controls.Add(this.labelUyeKaydi);
            this.tabKayit.Location = new System.Drawing.Point(4, 25);
            this.tabKayit.Name = "tabKayit";
            this.tabKayit.Padding = new System.Windows.Forms.Padding(3);
            this.tabKayit.Size = new System.Drawing.Size(540, 449);
            this.tabKayit.TabIndex = 2;
            this.tabKayit.Text = "Kayıt ";
            this.tabKayit.UseVisualStyleBackColor = true;
            // 
            // checkBoxKayitSifreGoster
            // 
            this.checkBoxKayitSifreGoster.AutoSize = true;
            this.checkBoxKayitSifreGoster.Location = new System.Drawing.Point(400, 301);
            this.checkBoxKayitSifreGoster.Name = "checkBoxKayitSifreGoster";
            this.checkBoxKayitSifreGoster.Size = new System.Drawing.Size(18, 17);
            this.checkBoxKayitSifreGoster.TabIndex = 12;
            this.checkBoxKayitSifreGoster.UseVisualStyleBackColor = true;
            this.checkBoxKayitSifreGoster.CheckedChanged += new System.EventHandler(this.checkBoxKayitSifreGoster_CheckedChanged);
            // 
            // butonKayitOl
            // 
            this.butonKayitOl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butonKayitOl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonKayitOl.Location = new System.Drawing.Point(40, 368);
            this.butonKayitOl.Name = "butonKayitOl";
            this.butonKayitOl.Size = new System.Drawing.Size(141, 48);
            this.butonKayitOl.TabIndex = 11;
            this.butonKayitOl.Text = "KAYIT OL";
            this.butonKayitOl.UseVisualStyleBackColor = true;
            this.butonKayitOl.Click += new System.EventHandler(this.butonKayitOl_Click);
            // 
            // butonKayitGeri
            // 
            this.butonKayitGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonKayitGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonKayitGeri.Location = new System.Drawing.Point(422, 379);
            this.butonKayitGeri.Name = "butonKayitGeri";
            this.butonKayitGeri.Size = new System.Drawing.Size(93, 37);
            this.butonKayitGeri.TabIndex = 10;
            this.butonKayitGeri.Text = "Geri ";
            this.butonKayitGeri.UseVisualStyleBackColor = false;
            this.butonKayitGeri.Click += new System.EventHandler(this.butonKayitGeri_Click);
            // 
            // textBoxKayitSifre
            // 
            this.textBoxKayitSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxKayitSifre.Location = new System.Drawing.Point(201, 301);
            this.textBoxKayitSifre.Name = "textBoxKayitSifre";
            this.textBoxKayitSifre.ShortcutsEnabled = false;
            this.textBoxKayitSifre.Size = new System.Drawing.Size(217, 30);
            this.textBoxKayitSifre.TabIndex = 9;
            // 
            // textBoxKayitAd
            // 
            this.textBoxKayitAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxKayitAd.Location = new System.Drawing.Point(201, 241);
            this.textBoxKayitAd.Name = "textBoxKayitAd";
            this.textBoxKayitAd.ShortcutsEnabled = false;
            this.textBoxKayitAd.Size = new System.Drawing.Size(217, 30);
            this.textBoxKayitAd.TabIndex = 8;
            this.textBoxKayitAd.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // labelKayitSifre
            // 
            this.labelKayitSifre.AutoSize = true;
            this.labelKayitSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKayitSifre.Location = new System.Drawing.Point(123, 302);
            this.labelKayitSifre.Name = "labelKayitSifre";
            this.labelKayitSifre.Size = new System.Drawing.Size(72, 29);
            this.labelKayitSifre.TabIndex = 7;
            this.labelKayitSifre.Text = "Şifre:";
            // 
            // labelKayitKullaniciAd
            // 
            this.labelKayitKullaniciAd.AutoSize = true;
            this.labelKayitKullaniciAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKayitKullaniciAd.Location = new System.Drawing.Point(35, 242);
            this.labelKayitKullaniciAd.Name = "labelKayitKullaniciAd";
            this.labelKayitKullaniciAd.Size = new System.Drawing.Size(160, 29);
            this.labelKayitKullaniciAd.TabIndex = 6;
            this.labelKayitKullaniciAd.Text = "Kullanıcı Adı:";
            // 
            // labelUyeKaydi
            // 
            this.labelUyeKaydi.AutoSize = true;
            this.labelUyeKaydi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUyeKaydi.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUyeKaydi.Location = new System.Drawing.Point(32, 116);
            this.labelUyeKaydi.Name = "labelUyeKaydi";
            this.labelUyeKaydi.Size = new System.Drawing.Size(243, 48);
            this.labelUyeKaydi.TabIndex = 5;
            this.labelUyeKaydi.Text = "ÜYE KAYDI";
            this.labelUyeKaydi.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabSifreUnuttum
            // 
            this.tabSifreUnuttum.Controls.Add(this.label3);
            this.tabSifreUnuttum.Controls.Add(this.label2);
            this.tabSifreUnuttum.Controls.Add(this.butonSifreGonder);
            this.tabSifreUnuttum.Controls.Add(this.textBoxSifreMail);
            this.tabSifreUnuttum.Controls.Add(this.butonSifreGeri);
            this.tabSifreUnuttum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabSifreUnuttum.Location = new System.Drawing.Point(4, 25);
            this.tabSifreUnuttum.Name = "tabSifreUnuttum";
            this.tabSifreUnuttum.Padding = new System.Windows.Forms.Padding(3);
            this.tabSifreUnuttum.Size = new System.Drawing.Size(540, 449);
            this.tabSifreUnuttum.TabIndex = 3;
            this.tabSifreUnuttum.Text = "Şifremi Unuttum";
            this.tabSifreUnuttum.UseVisualStyleBackColor = true;
            this.tabSifreUnuttum.Click += new System.EventHandler(this.tabSifreUnuttum_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(36, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 48);
            this.label3.TabIndex = 16;
            this.label3.Text = "ŞİFRE SIFIRLAMA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(39, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "E-posta:";
            // 
            // butonSifreGonder
            // 
            this.butonSifreGonder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butonSifreGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonSifreGonder.Location = new System.Drawing.Point(44, 338);
            this.butonSifreGonder.Name = "butonSifreGonder";
            this.butonSifreGonder.Size = new System.Drawing.Size(141, 48);
            this.butonSifreGonder.TabIndex = 14;
            this.butonSifreGonder.Text = "GÖNDER";
            this.butonSifreGonder.UseVisualStyleBackColor = true;
            this.butonSifreGonder.Click += new System.EventHandler(this.butonSifreGonder_Click);
            // 
            // textBoxSifreMail
            // 
            this.textBoxSifreMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSifreMail.Location = new System.Drawing.Point(44, 271);
            this.textBoxSifreMail.Name = "textBoxSifreMail";
            this.textBoxSifreMail.ShortcutsEnabled = false;
            this.textBoxSifreMail.Size = new System.Drawing.Size(217, 30);
            this.textBoxSifreMail.TabIndex = 13;
            this.textBoxSifreMail.TextChanged += new System.EventHandler(this.textBoxSifreMail_TextChanged);
            this.textBoxSifreMail.Enter += new System.EventHandler(this.textBoxSifreMail_Enter);
            this.textBoxSifreMail.Leave += new System.EventHandler(this.textBoxSifreMail_Leave);
            // 
            // butonSifreGeri
            // 
            this.butonSifreGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonSifreGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonSifreGeri.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butonSifreGeri.Location = new System.Drawing.Point(418, 349);
            this.butonSifreGeri.Name = "butonSifreGeri";
            this.butonSifreGeri.Size = new System.Drawing.Size(93, 37);
            this.butonSifreGeri.TabIndex = 11;
            this.butonSifreGeri.Text = "Geri ";
            this.butonSifreGeri.UseVisualStyleBackColor = false;
            this.butonSifreGeri.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 666);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.tabControl.ResumeLayout(false);
            this.tabHosGeldiniz.ResumeLayout(false);
            this.tabHosGeldiniz.PerformLayout();
            this.tabGiris.ResumeLayout(false);
            this.tabGiris.PerformLayout();
            this.tabKayit.ResumeLayout(false);
            this.tabKayit.PerformLayout();
            this.tabSifreUnuttum.ResumeLayout(false);
            this.tabSifreUnuttum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butonGiris;
        private System.Windows.Forms.Button butonKayit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabHosGeldiniz;
        private System.Windows.Forms.TabPage tabGiris;
        private System.Windows.Forms.TabPage tabKayit;
        private System.Windows.Forms.Button butonSifre;
        private System.Windows.Forms.Label labelUyeGiris;
        private System.Windows.Forms.TextBox textBoxGirisSifre;
        private System.Windows.Forms.TextBox textBoxGirisAd;
        private System.Windows.Forms.Label labelGirisSifre;
        private System.Windows.Forms.Label labelGirisKullaniciAd;
        private System.Windows.Forms.Label labelUyeKaydi;
        private System.Windows.Forms.TextBox textBoxKayitSifre;
        private System.Windows.Forms.TextBox textBoxKayitAd;
        private System.Windows.Forms.Label labelKayitSifre;
        private System.Windows.Forms.Label labelKayitKullaniciAd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSifreUnuttum;
        private System.Windows.Forms.Button butonGirisGeri;
        private System.Windows.Forms.Button butonKayitGeri;
        private System.Windows.Forms.Button butonSifreGeri;
        private System.Windows.Forms.Button butonGirisYap;
        private System.Windows.Forms.Button butonKayitOl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butonSifreGonder;
        private System.Windows.Forms.TextBox textBoxSifreMail;
        private System.Windows.Forms.CheckBox checkBoxGirisSifreGoster;
        private System.Windows.Forms.CheckBox checkBoxKayitSifreGoster;
    }
}

