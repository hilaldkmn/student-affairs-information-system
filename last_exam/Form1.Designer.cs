namespace last_exam
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dagit_buton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.siniflar_listbox = new System.Windows.Forms.CheckedListBox();
            this.secilen_kontenjan = new System.Windows.Forms.Label();
            this.toplam_ogrenci = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(333, 519);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(333, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Excel Dosyasını Aç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sınıfların Listesi";
            // 
            // dagit_buton
            // 
            this.dagit_buton.Enabled = false;
            this.dagit_buton.Location = new System.Drawing.Point(363, 465);
            this.dagit_buton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dagit_buton.Name = "dagit_buton";
            this.dagit_buton.Size = new System.Drawing.Size(200, 57);
            this.dagit_buton.TabIndex = 3;
            this.dagit_buton.Text = "Rasgele Dağıt";
            this.dagit_buton.UseVisualStyleBackColor = true;
            this.dagit_buton.Click += new System.EventHandler(this.dagit_buton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 539);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 57);
            this.button3.TabIndex = 4;
            this.button3.Text = "Programı Kapat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // siniflar_listbox
            // 
            this.siniflar_listbox.FormattingEnabled = true;
            this.siniflar_listbox.Location = new System.Drawing.Point(363, 76);
            this.siniflar_listbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.siniflar_listbox.Name = "siniflar_listbox";
            this.siniflar_listbox.Size = new System.Drawing.Size(200, 327);
            this.siniflar_listbox.TabIndex = 5;
            this.siniflar_listbox.SelectedIndexChanged += new System.EventHandler(this.kontenjan_degistir);
            this.siniflar_listbox.SelectedValueChanged += new System.EventHandler(this.kontenjan_degistir);
            // 
            // secilen_kontenjan
            // 
            this.secilen_kontenjan.AutoSize = true;
            this.secilen_kontenjan.ForeColor = System.Drawing.Color.Red;
            this.secilen_kontenjan.Location = new System.Drawing.Point(397, 436);
            this.secilen_kontenjan.Name = "secilen_kontenjan";
            this.secilen_kontenjan.Size = new System.Drawing.Size(122, 17);
            this.secilen_kontenjan.TabIndex = 6;
            this.secilen_kontenjan.Text = "Seçilen Kontenjan";
            // 
            // toplam_ogrenci
            // 
            this.toplam_ogrenci.AutoSize = true;
            this.toplam_ogrenci.ForeColor = System.Drawing.Color.Red;
            this.toplam_ogrenci.Location = new System.Drawing.Point(123, 608);
            this.toplam_ogrenci.Name = "toplam_ogrenci";
            this.toplam_ogrenci.Size = new System.Drawing.Size(106, 17);
            this.toplam_ogrenci.TabIndex = 7;
            this.toplam_ogrenci.Text = "Toplam öğrenci";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 634);
            this.Controls.Add(this.toplam_ogrenci);
            this.Controls.Add(this.secilen_kontenjan);
            this.Controls.Add(this.siniflar_listbox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dagit_buton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dagit_buton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox siniflar_listbox;
        private System.Windows.Forms.Label secilen_kontenjan;
        private System.Windows.Forms.Label toplam_ogrenci;
    }
}

