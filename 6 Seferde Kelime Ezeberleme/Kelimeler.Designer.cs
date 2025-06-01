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
            this.dataGridKelimeler.Location = new System.Drawing.Point(25, 23);
            this.dataGridKelimeler.Name = "dataGridKelimeler";
            this.dataGridKelimeler.ReadOnly = true;
            this.dataGridKelimeler.RowHeadersWidth = 51;
            this.dataGridKelimeler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridKelimeler.RowTemplate.Height = 24;
            this.dataGridKelimeler.Size = new System.Drawing.Size(625, 451);
            this.dataGridKelimeler.TabIndex = 0;
            this.dataGridKelimeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // butonGirisGeri
            // 
            this.butonGirisGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonGirisGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonGirisGeri.Location = new System.Drawing.Point(569, 538);
            this.butonGirisGeri.Name = "butonGirisGeri";
            this.butonGirisGeri.Size = new System.Drawing.Size(92, 37);
            this.butonGirisGeri.TabIndex = 6;
            this.butonGirisGeri.Text = "Geri ";
            this.butonGirisGeri.UseVisualStyleBackColor = false;
            this.butonGirisGeri.Click += new System.EventHandler(this.butonGirisGeri_Click);
            // 
            // Kelimeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(673, 597);
            this.Controls.Add(this.butonGirisGeri);
            this.Controls.Add(this.dataGridKelimeler);
            this.Name = "Kelimeler";
            this.Text = "Kelimeler";
            this.Load += new System.EventHandler(this.Kelimeler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKelimeler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridKelimeler;
        private System.Windows.Forms.Button butonGirisGeri;
    }
}