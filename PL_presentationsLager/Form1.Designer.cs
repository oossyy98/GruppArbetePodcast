namespace PL_presentationsLager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtKategoriNamn = new TextBox();
            btnSkapaKategori = new Button();
            btnHamtaKategorier = new Button();
            lstKategorier = new ListBox();
            panel1 = new Panel();
            btnRaderaKategori = new Button();
            panel2 = new Panel();
            dgvPodcasts = new DataGridView();
            btnHamtaRss = new Button();
            button2 = new Button();
            button1 = new Button();
            btnHamtaAllaPodcasts = new Button();
            btnSkapaPodcast = new Button();
            cbKategorier = new ComboBox();
            label4 = new Label();
            txtPodcastUrl = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtPodcastNamn = new TextBox();
            panel3 = new Panel();
            dgvAvsnitt = new DataGridView();
            button4 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPodcasts).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvsnitt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 20);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Kategori Namn";
            // 
            // txtKategoriNamn
            // 
            txtKategoriNamn.Location = new Point(3, 43);
            txtKategoriNamn.Name = "txtKategoriNamn";
            txtKategoriNamn.Size = new Size(100, 23);
            txtKategoriNamn.TabIndex = 1;
            // 
            // btnSkapaKategori
            // 
            btnSkapaKategori.Location = new Point(0, 127);
            btnSkapaKategori.Name = "btnSkapaKategori";
            btnSkapaKategori.Size = new Size(100, 23);
            btnSkapaKategori.TabIndex = 2;
            btnSkapaKategori.Text = "Skapa kategori";
            btnSkapaKategori.UseVisualStyleBackColor = true;
            btnSkapaKategori.Click += btnSkapaKategori_Click;
            // 
            // btnHamtaKategorier
            // 
            btnHamtaKategorier.Location = new Point(248, 127);
            btnHamtaKategorier.Name = "btnHamtaKategorier";
            btnHamtaKategorier.Size = new Size(100, 23);
            btnHamtaKategorier.TabIndex = 3;
            btnHamtaKategorier.Text = "Hämta alla";
            btnHamtaKategorier.UseVisualStyleBackColor = true;
            btnHamtaKategorier.Click += btnHamtaKategorier_Click;
            // 
            // lstKategorier
            // 
            lstKategorier.FormattingEnabled = true;
            lstKategorier.ItemHeight = 15;
            lstKategorier.Location = new Point(3, 224);
            lstKategorier.Name = "lstKategorier";
            lstKategorier.Size = new Size(345, 154);
            lstKategorier.TabIndex = 4;
            lstKategorier.SelectedIndexChanged += lstKategorier_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRaderaKategori);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lstKategorier);
            panel1.Controls.Add(txtKategoriNamn);
            panel1.Controls.Add(btnHamtaKategorier);
            panel1.Controls.Add(btnSkapaKategori);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 378);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // btnRaderaKategori
            // 
            btnRaderaKategori.Location = new Point(248, 195);
            btnRaderaKategori.Name = "btnRaderaKategori";
            btnRaderaKategori.Size = new Size(100, 23);
            btnRaderaKategori.TabIndex = 5;
            btnRaderaKategori.Text = "Radera ";
            btnRaderaKategori.UseVisualStyleBackColor = true;
            btnRaderaKategori.Click += btnRaderaKategori_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnHamtaRss);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(btnHamtaAllaPodcasts);
            panel2.Controls.Add(btnSkapaPodcast);
            panel2.Controls.Add(cbKategorier);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtPodcastUrl);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtPodcastNamn);
            panel2.Location = new Point(369, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(376, 378);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // dgvPodcasts
            // 
            dgvPodcasts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodcasts.Location = new Point(360, 441);
            dgvPodcasts.Name = "dgvPodcasts";
            dgvPodcasts.Size = new Size(627, 154);
            dgvPodcasts.TabIndex = 13;
            dgvPodcasts.CellContentClick += dgvPodcasts_CellContentClick;
            // 
            // btnHamtaRss
            // 
            btnHamtaRss.Location = new Point(106, 127);
            btnHamtaRss.Name = "btnHamtaRss";
            btnHamtaRss.Size = new Size(96, 23);
            btnHamtaRss.TabIndex = 12;
            btnHamtaRss.Text = "Hämta RSS";
            btnHamtaRss.UseVisualStyleBackColor = true;
            btnHamtaRss.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(106, 185);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 11;
            button2.Text = "Radera";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(4, 185);
            button1.Name = "button1";
            button1.Size = new Size(96, 23);
            button1.TabIndex = 10;
            button1.Text = "Uppdatera";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnHamtaAllaPodcasts
            // 
            btnHamtaAllaPodcasts.Location = new Point(3, 156);
            btnHamtaAllaPodcasts.Name = "btnHamtaAllaPodcasts";
            btnHamtaAllaPodcasts.Size = new Size(96, 23);
            btnHamtaAllaPodcasts.TabIndex = 9;
            btnHamtaAllaPodcasts.Text = "Visa alla podcasts";
            btnHamtaAllaPodcasts.UseVisualStyleBackColor = true;
            btnHamtaAllaPodcasts.Click += btnHamtaAllaPodcasts_Click;
            // 
            // btnSkapaPodcast
            // 
            btnSkapaPodcast.Location = new Point(4, 127);
            btnSkapaPodcast.Name = "btnSkapaPodcast";
            btnSkapaPodcast.Size = new Size(96, 23);
            btnSkapaPodcast.TabIndex = 5;
            btnSkapaPodcast.Text = "Skapa podcast";
            btnSkapaPodcast.UseVisualStyleBackColor = true;
            btnSkapaPodcast.Click += btnSkapaPodcast_Click;
            // 
            // cbKategorier
            // 
            cbKategorier.FormattingEnabled = true;
            cbKategorier.Location = new Point(96, 89);
            cbKategorier.Name = "cbKategorier";
            cbKategorier.Size = new Size(100, 23);
            cbKategorier.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 92);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "Kategori:";
            // 
            // txtPodcastUrl
            // 
            txtPodcastUrl.Location = new Point(96, 48);
            txtPodcastUrl.Name = "txtPodcastUrl";
            txtPodcastUrl.Size = new Size(100, 23);
            txtPodcastUrl.TabIndex = 6;
            txtPodcastUrl.TextChanged += txtPodcastUrl_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 51);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "RSS-URL:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 15);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 0;
            label2.Text = "Podcast namn:";
            // 
            // txtPodcastNamn
            // 
            txtPodcastNamn.Location = new Point(96, 12);
            txtPodcastNamn.Name = "txtPodcastNamn";
            txtPodcastNamn.Size = new Size(100, 23);
            txtPodcastNamn.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvAvsnitt);
            panel3.Controls.Add(button4);
            panel3.Location = new Point(751, 117);
            panel3.Name = "panel3";
            panel3.Size = new Size(340, 273);
            panel3.TabIndex = 6;
            // 
            // dgvAvsnitt
            // 
            dgvAvsnitt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvsnitt.Location = new Point(6, 119);
            dgvAvsnitt.Name = "dgvAvsnitt";
            dgvAvsnitt.Size = new Size(342, 150);
            dgvAvsnitt.TabIndex = 14;
            // 
            // button4
            // 
            button4.Location = new Point(3, 22);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 3;
            button4.Text = "Visa avsnitt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 699);
            Controls.Add(dgvPodcasts);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPodcasts).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvsnitt).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtKategoriNamn;
        private Button btnSkapaKategori;
        private Button btnHamtaKategorier;
        private ListBox lstKategorier;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private TextBox txtPodcastNamn;
        private Label label4;
        private TextBox txtPodcastUrl;
        private Label label3;
        private DataGridView dgvPodcasts;
        private Button btnHamtaRss;
        private Button button2;
        private Button button1;
        private Button btnHamtaAllaPodcasts;
        private Button btnSkapaPodcast;
        private ComboBox cbKategorier;
        private Panel panel3;
        private DataGridView dgvAvsnitt;
        private Button button4;
        private Button btnRaderaKategori;
    }
}
