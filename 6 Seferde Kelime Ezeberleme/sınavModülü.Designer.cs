namespace _6_Seferde_Kelime_Ezeberleme
{
    partial class sınavModülü
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tekrarQuiz = new System.Windows.Forms.Button();
            this.gunlukQuiz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rBD = new System.Windows.Forms.RadioButton();
            this.rBC = new System.Windows.Forms.RadioButton();
            this.rBB = new System.Windows.Forms.RadioButton();
            this.rBA = new System.Windows.Forms.RadioButton();
            this.labelSoru = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rBD1 = new System.Windows.Forms.RadioButton();
            this.rBC1 = new System.Windows.Forms.RadioButton();
            this.rBB1 = new System.Windows.Forms.RadioButton();
            this.rBA1 = new System.Windows.Forms.RadioButton();
            this.labelSoru1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.labelSayac = new System.Windows.Forms.Label();
            this.buttonSonraki = new System.Windows.Forms.Button();
            this.buttonSonraki1 = new System.Windows.Forms.Button();
            this.pictureBoxSoruResmi = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSoruResmi)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 452);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Highlight;
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.tekrarQuiz);
            this.tabPage1.Controls.Add(this.gunlukQuiz);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quizler";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(646, 363);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "Geri";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tekrarQuiz
            // 
            this.tekrarQuiz.BackColor = System.Drawing.Color.LightGray;
            this.tekrarQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tekrarQuiz.Location = new System.Drawing.Point(264, 269);
            this.tekrarQuiz.Name = "tekrarQuiz";
            this.tekrarQuiz.Size = new System.Drawing.Size(255, 115);
            this.tekrarQuiz.TabIndex = 2;
            this.tekrarQuiz.Text = "Tekrar Quizi";
            this.tekrarQuiz.UseVisualStyleBackColor = false;
            this.tekrarQuiz.Click += new System.EventHandler(this.tekrarQuiz_Click);
            // 
            // gunlukQuiz
            // 
            this.gunlukQuiz.BackColor = System.Drawing.Color.LightGray;
            this.gunlukQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunlukQuiz.Location = new System.Drawing.Point(264, 125);
            this.gunlukQuiz.Name = "gunlukQuiz";
            this.gunlukQuiz.Size = new System.Drawing.Size(255, 114);
            this.gunlukQuiz.TabIndex = 1;
            this.gunlukQuiz.Text = "Günlük Quiz";
            this.gunlukQuiz.UseVisualStyleBackColor = false;
            this.gunlukQuiz.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(297, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUİZLER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Highlight;
            this.tabPage2.Controls.Add(this.pictureBoxSoruResmi);
            this.tabPage2.Controls.Add(this.buttonSonraki);
            this.tabPage2.Controls.Add(this.labelSayac);
            this.tabPage2.Controls.Add(this.rBD);
            this.tabPage2.Controls.Add(this.rBC);
            this.tabPage2.Controls.Add(this.rBB);
            this.tabPage2.Controls.Add(this.rBA);
            this.tabPage2.Controls.Add(this.labelSoru);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Günlük Quiz";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // rBD
            // 
            this.rBD.AutoSize = true;
            this.rBD.Location = new System.Drawing.Point(111, 356);
            this.rBD.Name = "rBD";
            this.rBD.Size = new System.Drawing.Size(130, 26);
            this.rBD.TabIndex = 4;
            this.rBD.TabStop = true;
            this.rBD.Text = "radioButton4";
            this.rBD.UseVisualStyleBackColor = true;
            // 
            // rBC
            // 
            this.rBC.AutoSize = true;
            this.rBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBC.Location = new System.Drawing.Point(111, 298);
            this.rBC.Name = "rBC";
            this.rBC.Size = new System.Drawing.Size(130, 26);
            this.rBC.TabIndex = 3;
            this.rBC.TabStop = true;
            this.rBC.Text = "radioButton3";
            this.rBC.UseVisualStyleBackColor = true;
            // 
            // rBB
            // 
            this.rBB.AutoSize = true;
            this.rBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBB.Location = new System.Drawing.Point(111, 242);
            this.rBB.Name = "rBB";
            this.rBB.Size = new System.Drawing.Size(130, 26);
            this.rBB.TabIndex = 2;
            this.rBB.TabStop = true;
            this.rBB.Text = "radioButton2";
            this.rBB.UseVisualStyleBackColor = true;
            // 
            // rBA
            // 
            this.rBA.AutoSize = true;
            this.rBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBA.Location = new System.Drawing.Point(111, 183);
            this.rBA.Name = "rBA";
            this.rBA.Size = new System.Drawing.Size(130, 26);
            this.rBA.TabIndex = 1;
            this.rBA.TabStop = true;
            this.rBA.Text = "radioButton1";
            this.rBA.UseVisualStyleBackColor = true;
            // 
            // labelSoru
            // 
            this.labelSoru.AutoSize = true;
            this.labelSoru.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSoru.Location = new System.Drawing.Point(303, 53);
            this.labelSoru.Name = "labelSoru";
            this.labelSoru.Size = new System.Drawing.Size(126, 46);
            this.labelSoru.TabIndex = 0;
            this.labelSoru.Text = "label2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Highlight;
            this.tabPage3.Controls.Add(this.buttonSonraki1);
            this.tabPage3.Controls.Add(this.rBD1);
            this.tabPage3.Controls.Add(this.rBC1);
            this.tabPage3.Controls.Add(this.rBB1);
            this.tabPage3.Controls.Add(this.rBA1);
            this.tabPage3.Controls.Add(this.labelSoru1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 426);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tekrar Quizi";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // rBD1
            // 
            this.rBD1.AutoSize = true;
            this.rBD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBD1.Location = new System.Drawing.Point(111, 323);
            this.rBD1.Name = "rBD1";
            this.rBD1.Size = new System.Drawing.Size(130, 26);
            this.rBD1.TabIndex = 9;
            this.rBD1.TabStop = true;
            this.rBD1.Text = "radioButton4";
            this.rBD1.UseVisualStyleBackColor = true;
            // 
            // rBC1
            // 
            this.rBC1.AutoSize = true;
            this.rBC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBC1.Location = new System.Drawing.Point(111, 260);
            this.rBC1.Name = "rBC1";
            this.rBC1.Size = new System.Drawing.Size(130, 26);
            this.rBC1.TabIndex = 8;
            this.rBC1.TabStop = true;
            this.rBC1.Text = "radioButton3";
            this.rBC1.UseVisualStyleBackColor = true;
            // 
            // rBB1
            // 
            this.rBB1.AutoSize = true;
            this.rBB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBB1.Location = new System.Drawing.Point(111, 203);
            this.rBB1.Name = "rBB1";
            this.rBB1.Size = new System.Drawing.Size(130, 26);
            this.rBB1.TabIndex = 7;
            this.rBB1.TabStop = true;
            this.rBB1.Text = "radioButton2";
            this.rBB1.UseVisualStyleBackColor = true;
            // 
            // rBA1
            // 
            this.rBA1.AutoSize = true;
            this.rBA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rBA1.Location = new System.Drawing.Point(111, 146);
            this.rBA1.Name = "rBA1";
            this.rBA1.Size = new System.Drawing.Size(130, 26);
            this.rBA1.TabIndex = 6;
            this.rBA1.TabStop = true;
            this.rBA1.Text = "radioButton1";
            this.rBA1.UseVisualStyleBackColor = true;
            // 
            // labelSoru1
            // 
            this.labelSoru1.AutoSize = true;
            this.labelSoru1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSoru1.Location = new System.Drawing.Point(317, 62);
            this.labelSoru1.Name = "labelSoru1";
            this.labelSoru1.Size = new System.Drawing.Size(126, 46);
            this.labelSoru1.TabIndex = 5;
            this.labelSoru1.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelSayac
            // 
            this.labelSayac.Location = new System.Drawing.Point(509, 3);
            this.labelSayac.Name = "labelSayac";
            this.labelSayac.Size = new System.Drawing.Size(275, 38);
            this.labelSayac.TabIndex = 6;
            this.labelSayac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSayac.Click += new System.EventHandler(this.labelSayac_Click);
            // 
            // buttonSonraki
            // 
            this.buttonSonraki.BackColor = System.Drawing.Color.LightGray;
            this.buttonSonraki.Location = new System.Drawing.Point(552, 356);
            this.buttonSonraki.Name = "buttonSonraki";
            this.buttonSonraki.Size = new System.Drawing.Size(161, 33);
            this.buttonSonraki.TabIndex = 7;
            this.buttonSonraki.Text = "Sonraki Soru";
            this.buttonSonraki.UseVisualStyleBackColor = false;
            this.buttonSonraki.Click += new System.EventHandler(this.buttonSonraki_Click);
            // 
            // buttonSonraki1
            // 
            this.buttonSonraki1.BackColor = System.Drawing.Color.LightGray;
            this.buttonSonraki1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSonraki1.Location = new System.Drawing.Point(564, 350);
            this.buttonSonraki1.Name = "buttonSonraki1";
            this.buttonSonraki1.Size = new System.Drawing.Size(161, 33);
            this.buttonSonraki1.TabIndex = 10;
            this.buttonSonraki1.Text = "Sonraki Soru";
            this.buttonSonraki1.UseVisualStyleBackColor = false;
            // 
            // pictureBoxSoruResmi
            // 
            this.pictureBoxSoruResmi.Location = new System.Drawing.Point(98, 6);
            this.pictureBoxSoruResmi.Name = "pictureBoxSoruResmi";
            this.pictureBoxSoruResmi.Size = new System.Drawing.Size(199, 136);
            this.pictureBoxSoruResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSoruResmi.TabIndex = 8;
            this.pictureBoxSoruResmi.TabStop = false;
            // 
            // sınavModülü
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "sınavModülü";
            this.Text = "Form2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSoruResmi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gunlukQuiz;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button tekrarQuiz;
        private System.Windows.Forms.Label labelSoru;
        private System.Windows.Forms.RadioButton rBD;
        private System.Windows.Forms.RadioButton rBC;
        private System.Windows.Forms.RadioButton rBB;
        private System.Windows.Forms.RadioButton rBA;
        private System.Windows.Forms.RadioButton rBD1;
        private System.Windows.Forms.RadioButton rBC1;
        private System.Windows.Forms.RadioButton rBB1;
        private System.Windows.Forms.RadioButton rBA1;
        private System.Windows.Forms.Label labelSoru1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelSayac;
        private System.Windows.Forms.Button buttonSonraki;
        private System.Windows.Forms.Button buttonSonraki1;
        private System.Windows.Forms.PictureBox pictureBoxSoruResmi;
    }
}