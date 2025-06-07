namespace _6_Seferde_Kelime_Ezeberleme
{
    partial class Kelimeler
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
            this.dataGridKelimeler = new System.Windows.Forms.DataGridView();
            this.butonGirisGeri = new System.Windows.Forms.Button();
            this.buttonSenkranizazyon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKelimeler)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridKelimeler
            // 
            this.dataGridKelimeler.AllowUserToAddRows = false;
            this.dataGridKelimeler.AllowUserToDeleteRows = false;
            this.dataGridKelimeler.AllowUserToResizeColumns = false;
            this.dataGridKelimeler.AllowUserToResizeRows = false;
            this.dataGridKelimeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridKelimeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridKelimeler.Location = new System.Drawing.Point(19, 19);
            this.dataGridKelimeler.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridKelimeler.Name = "dataGridKelimeler";
            this.dataGridKelimeler.ReadOnly = true;
            this.dataGridKelimeler.RowHeadersWidth = 51;
            this.dataGridKelimeler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridKelimeler.RowTemplate.Height = 24;
            this.dataGridKelimeler.Size = new System.Drawing.Size(469, 366);
            this.dataGridKelimeler.TabIndex = 0;
            this.dataGridKelimeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // butonGirisGeri
            // 
            this.butonGirisGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonGirisGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonGirisGeri.Location = new System.Drawing.Point(427, 437);
            this.butonGirisGeri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butonGirisGeri.Name = "butonGirisGeri";
            this.butonGirisGeri.Size = new System.Drawing.Size(69, 30);
            this.butonGirisGeri.TabIndex = 6;
            this.butonGirisGeri.Text = "Geri ";
            this.butonGirisGeri.UseVisualStyleBackColor = false;
            this.butonGirisGeri.Click += new System.EventHandler(this.butonGirisGeri_Click);
            // 
            // buttonSenkranizazyon
            // 
            this.buttonSenkranizazyon.BackColor = System.Drawing.Color.DimGray;
            this.buttonSenkranizazyon.Location = new System.Drawing.Point(19, 437);
            this.buttonSenkranizazyon.Name = "buttonSenkranizazyon";
            this.buttonSenkranizazyon.Size = new System.Drawing.Size(113, 30);
            this.buttonSenkranizazyon.TabIndex = 7;
            this.buttonSenkranizazyon.Text = "Senkronize Et";
            this.buttonSenkranizazyon.UseVisualStyleBackColor = false;
            this.buttonSenkranizazyon.Click += new System.EventHandler(this.buttonSenkranizazyon_Click);
            // 
            // Kelimeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(505, 485);
            this.Controls.Add(this.buttonSenkranizazyon);
            this.Controls.Add(this.butonGirisGeri);
            this.Controls.Add(this.dataGridKelimeler);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Kelimeler";
            this.Text = "Kelimeler";
            this.Load += new System.EventHandler(this.Kelimeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKelimeler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridKelimeler;
        private System.Windows.Forms.Button butonGirisGeri;
        private System.Windows.Forms.Button buttonSenkranizazyon;
    }
}