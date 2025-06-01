namespace _6_Seferde_Kelime_Ezeberleme
{
    partial class Wordle
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
            this.butonWordleGeri = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.TableLayoutPanel();
            this.butonWordle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butonWordleGeri
            // 
            this.butonWordleGeri.BackColor = System.Drawing.Color.DimGray;
            this.butonWordleGeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonWordleGeri.Location = new System.Drawing.Point(502, 519);
            this.butonWordleGeri.Name = "butonWordleGeri";
            this.butonWordleGeri.Size = new System.Drawing.Size(131, 43);
            this.butonWordleGeri.TabIndex = 11;
            this.butonWordleGeri.Text = "GERİ";
            this.butonWordleGeri.UseVisualStyleBackColor = false;
            this.butonWordleGeri.Click += new System.EventHandler(this.butonBasarimGeri_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnCount = 3;
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.8189F));
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.1811F));
            this.tableGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableGrid.Location = new System.Drawing.Point(139, 137);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.RowCount = 2;
            this.tableGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.77578F));
            this.tableGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.22422F));
            this.tableGrid.Size = new System.Drawing.Size(377, 263);
            this.tableGrid.TabIndex = 12;
            this.tableGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // butonWordle
            // 
            this.butonWordle.AutoSize = true;
            this.butonWordle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.butonWordle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butonWordle.Location = new System.Drawing.Point(264, 460);
            this.butonWordle.Name = "butonWordle";
            this.butonWordle.Size = new System.Drawing.Size(155, 60);
            this.butonWordle.TabIndex = 13;
            this.butonWordle.Text = "KONTROL";
            this.butonWordle.UseVisualStyleBackColor = false;
            this.butonWordle.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(164, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 52);
            this.label1.TabIndex = 14;
            this.label1.Text = " 🏆WORDLE 🏆";
            // 
            // Wordle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(673, 597);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butonWordle);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.butonWordleGeri);
            this.Name = "Wordle";
            this.Text = "Wordle";
            this.Load += new System.EventHandler(this.Wordle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butonWordleGeri;
        private System.Windows.Forms.TableLayoutPanel tableGrid;
        private System.Windows.Forms.Button butonWordle;
        private System.Windows.Forms.Label label1;
    }
}