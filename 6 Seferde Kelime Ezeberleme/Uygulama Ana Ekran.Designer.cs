namespace _6_Seferde_Kelime_Ezeberleme
{
    partial class Uygulama_Ana_Ekran
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
            this.labelUstteAdGosterim = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUstteAdGosterim
            // 
            this.labelUstteAdGosterim.AutoSize = true;
            this.labelUstteAdGosterim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUstteAdGosterim.Location = new System.Drawing.Point(12, 9);
            this.labelUstteAdGosterim.Name = "labelUstteAdGosterim";
            this.labelUstteAdGosterim.Size = new System.Drawing.Size(52, 18);
            this.labelUstteAdGosterim.TabIndex = 0;
            this.labelUstteAdGosterim.Text = "label1";
            this.labelUstteAdGosterim.Click += new System.EventHandler(this.label1_Click);
            // 
            // Uygulama_Ana_Ekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelUstteAdGosterim);
            this.Name = "Uygulama_Ana_Ekran";
            this.Text = "Uygulama_Ana_Ekran";
            this.Load += new System.EventHandler(this.Uygulama_Ana_Ekran_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUstteAdGosterim;
    }
}