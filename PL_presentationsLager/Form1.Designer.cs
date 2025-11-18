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
            btnRaderaKategori = new Button();
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
            dgvAvsnitt = new DataGridView();
            button4 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel8 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPodcasts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAvsnitt).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 0;
            label1.Text = "Kategori Namn";
            // 
            // txtKategoriNamn
            // 
            txtKategoriNamn.Location = new Point(3, 24);
            txtKategoriNamn.Name = "txtKategoriNamn";
            txtKategoriNamn.Size = new Size(100, 23);
            txtKategoriNamn.TabIndex = 1;
            // 
            // btnSkapaKategori
            // 
            btnSkapaKategori.Location = new Point(3, 65);
            btnSkapaKategori.Name = "btnSkapaKategori";
            btnSkapaKategori.Size = new Size(100, 23);
            btnSkapaKategori.TabIndex = 2;
            btnSkapaKategori.Text = "Skapa kategori";
            btnSkapaKategori.UseVisualStyleBackColor = true;
            btnSkapaKategori.Click += btnSkapaKategori_Click;
            // 
            // btnHamtaKategorier
            // 
            btnHamtaKategorier.Location = new Point(199, 6);
            btnHamtaKategorier.Name = "btnHamtaKategorier";
            btnHamtaKategorier.Size = new Size(100, 23);
            btnHamtaKategorier.TabIndex = 3;
            btnHamtaKategorier.Text = "Visa alla";
            btnHamtaKategorier.UseVisualStyleBackColor = true;
            btnHamtaKategorier.Click += btnHamtaKategorier_Click;
            // 
            // lstKategorier
            // 
            lstKategorier.Dock = DockStyle.Fill;
            lstKategorier.FormattingEnabled = true;
            lstKategorier.ItemHeight = 15;
            lstKategorier.Location = new Point(0, 0);
            lstKategorier.Name = "lstKategorier";
            lstKategorier.Size = new Size(311, 295);
            lstKategorier.TabIndex = 4;
            lstKategorier.SelectedIndexChanged += lstKategorier_SelectedIndexChanged;
            // 
            // btnRaderaKategori
            // 
            btnRaderaKategori.Location = new Point(199, 65);
            btnRaderaKategori.Name = "btnRaderaKategori";
            btnRaderaKategori.Size = new Size(100, 23);
            btnRaderaKategori.TabIndex = 5;
            btnRaderaKategori.Text = "Radera ";
            btnRaderaKategori.UseVisualStyleBackColor = true;
            btnRaderaKategori.Click += btnRaderaKategori_Click;
            // 
            // dgvPodcasts
            // 
            dgvPodcasts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPodcasts.Dock = DockStyle.Fill;
            dgvPodcasts.Location = new Point(0, 0);
            dgvPodcasts.Name = "dgvPodcasts";
            dgvPodcasts.Size = new Size(417, 295);
            dgvPodcasts.TabIndex = 13;
            dgvPodcasts.CellContentClick += dgvPodcasts_CellContentClick;
            // 
            // btnHamtaRss
            // 
            btnHamtaRss.Location = new Point(915, 16);
            btnHamtaRss.Name = "btnHamtaRss";
            btnHamtaRss.Size = new Size(118, 31);
            btnHamtaRss.TabIndex = 12;
            btnHamtaRss.Text = "Hämta RSS";
            btnHamtaRss.UseVisualStyleBackColor = true;
            btnHamtaRss.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(309, 65);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 11;
            button2.Text = "Radera";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(207, 65);
            button1.Name = "button1";
            button1.Size = new Size(96, 23);
            button1.TabIndex = 10;
            button1.Text = "Uppdatera";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnHamtaAllaPodcasts
            // 
            btnHamtaAllaPodcasts.Location = new Point(105, 65);
            btnHamtaAllaPodcasts.Name = "btnHamtaAllaPodcasts";
            btnHamtaAllaPodcasts.Size = new Size(96, 23);
            btnHamtaAllaPodcasts.TabIndex = 9;
            btnHamtaAllaPodcasts.Text = "Visa alla podcasts";
            btnHamtaAllaPodcasts.UseVisualStyleBackColor = true;
            btnHamtaAllaPodcasts.Click += btnHamtaAllaPodcasts_Click;
            // 
            // btnSkapaPodcast
            // 
            btnSkapaPodcast.Location = new Point(3, 65);
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
            cbKategorier.Location = new Point(101, 42);
            cbKategorier.Name = "cbKategorier";
            cbKategorier.Size = new Size(100, 23);
            cbKategorier.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 42);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "Kategori:";
            // 
            // txtPodcastUrl
            // 
            txtPodcastUrl.Location = new Point(68, 21);
            txtPodcastUrl.Name = "txtPodcastUrl";
            txtPodcastUrl.Size = new Size(841, 23);
            txtPodcastUrl.TabIndex = 6;
            txtPodcastUrl.TextChanged += txtPodcastUrl_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 24);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "RSS-URL:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 10);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 0;
            label2.Text = "Podcast namn:";
            // 
            // txtPodcastNamn
            // 
            txtPodcastNamn.Location = new Point(101, 10);
            txtPodcastNamn.Name = "txtPodcastNamn";
            txtPodcastNamn.Size = new Size(100, 23);
            txtPodcastNamn.TabIndex = 1;
            // 
            // dgvAvsnitt
            // 
            dgvAvsnitt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvsnitt.Dock = DockStyle.Fill;
            dgvAvsnitt.Location = new Point(0, 0);
            dgvAvsnitt.Name = "dgvAvsnitt";
            dgvAvsnitt.Size = new Size(312, 295);
            dgvAvsnitt.TabIndex = 14;
            dgvAvsnitt.CellContentClick += dgvAvsnitt_CellContentClick;
            // 
            // button4
            // 
            button4.Location = new Point(3, 65);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 3;
            button4.Text = "Visa avsnitt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 0, 1);
            tableLayoutPanel1.Controls.Add(panel6, 1, 1);
            tableLayoutPanel1.Controls.Add(panel7, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 2, 0);
            tableLayoutPanel1.Controls.Add(panel2, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 116);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3718586F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75.62814F));
            tableLayoutPanel1.Size = new Size(1058, 398);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnHamtaKategorier);
            panel4.Controls.Add(btnRaderaKategori);
            panel4.Controls.Add(btnSkapaKategori);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(txtKategoriNamn);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(311, 91);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(lstKategorier);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 100);
            panel5.Name = "panel5";
            panel5.Size = new Size(311, 295);
            panel5.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(dgvPodcasts);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(320, 100);
            panel6.Name = "panel6";
            panel6.Size = new Size(417, 295);
            panel6.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Controls.Add(button2);
            panel7.Controls.Add(txtPodcastNamn);
            panel7.Controls.Add(button1);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(btnHamtaAllaPodcasts);
            panel7.Controls.Add(cbKategorier);
            panel7.Controls.Add(btnSkapaPodcast);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(320, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(417, 91);
            panel7.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(743, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 91);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvAvsnitt);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(743, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 295);
            panel2.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Controls.Add(label3);
            panel8.Controls.Add(btnHamtaRss);
            panel8.Controls.Add(txtPodcastUrl);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(1058, 74);
            panel8.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1058, 514);
            Controls.Add(panel8);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPodcasts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAvsnitt).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtKategoriNamn;
        private Button btnSkapaKategori;
        private Button btnHamtaKategorier;
        private ListBox lstKategorier;
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
        private DataGridView dgvAvsnitt;
        private Button button4;
        private Button btnRaderaKategori;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel8;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel1;
        private Panel panel2;
    }
}
