namespace _6_Seferde_Kelime_Ezeberleme
{
    partial class Basarim
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
            this.butonBasarimGeri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butonBasarimGeri
            // 
            this.butonBasarimGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonBasarimGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonBasarimGeri.Location = new System.Drawing.Point(506, 509);
            this.butonBasarimGeri.Name = "butonBasarimGeri";
            this.butonBasarimGeri.Size = new System.Drawing.Size(131, 43);
            this.butonBasarimGeri.TabIndex = 10;
            this.butonBasarimGeri.Text = "GERİ";
            this.butonBasarimGeri.UseVisualStyleBackColor = false;
            this.butonBasarimGeri.Click += new System.EventHandler(this.butonBasarimGeri_Click);
            // 
            // Basarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(673, 597);
            this.Controls.Add(this.butonBasarimGeri);
            this.Name = "Basarim";
            this.Text = "Basarim";
            this.Load += new System.EventHandler(this.Basarim_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butonBasarimGeri;
    }
}