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
            txtKategoriNamn = new TextBox();
            btnSkapaKategori = new Button();
            lstKategorier = new ListBox();
            btnRaderaKategori = new Button();
            btnRaderaPodcast = new Button();
            btnUppdateraPodcast = new Button();
            btnSkapaPodcast = new Button();
            cbKategorier = new ComboBox();
            label4 = new Label();
            txtPodcastUrl = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtPodcastNamn = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            btnUppdateraKategori = new Button();
            label1 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            lstPodcast = new ListBox();
            panel7 = new Panel();
            panel1 = new Panel();
            lblPubliceringsdatum = new Label();
            lblPubliceringsdatumText = new Label();
            lblTitel = new Label();
            lblTitelText = new Label();
            panel2 = new Panel();
            txtBeskrivning = new TextBox();
            lstAvsnitt = new ListBox();
            panel8 = new Panel();
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
            // txtKategoriNamn
            // 
            txtKategoriNamn.Location = new Point(4, 40);
            txtKategoriNamn.Margin = new Padding(4, 5, 4, 5);
            txtKategoriNamn.Name = "txtKategoriNamn";
            txtKategoriNamn.Size = new Size(141, 31);
            txtKategoriNamn.TabIndex = 1;
            // 
            // btnSkapaKategori
            // 
            btnSkapaKategori.Location = new Point(4, 108);
            btnSkapaKategori.Margin = new Padding(4, 5, 4, 5);
            btnSkapaKategori.Name = "btnSkapaKategori";
            btnSkapaKategori.Size = new Size(143, 38);
            btnSkapaKategori.TabIndex = 2;
            btnSkapaKategori.Text = "Skapa kategori";
            btnSkapaKategori.UseVisualStyleBackColor = true;
            btnSkapaKategori.Click += btnSkapaKategori_Click;
            // 
            // lstKategorier
            // 
            lstKategorier.Dock = DockStyle.Fill;
            lstKategorier.FormattingEnabled = true;
            lstKategorier.ItemHeight = 25;
            lstKategorier.Location = new Point(0, 0);
            lstKategorier.Margin = new Padding(4, 5, 4, 5);
            lstKategorier.Name = "lstKategorier";
            lstKategorier.Size = new Size(488, 492);
            lstKategorier.TabIndex = 4;
            lstKategorier.SelectedIndexChanged += lstKategorier_SelectedIndexChanged;
            // 
            // btnRaderaKategori
            // 
            btnRaderaKategori.Location = new Point(340, 108);
            btnRaderaKategori.Margin = new Padding(4, 5, 4, 5);
            btnRaderaKategori.Name = "btnRaderaKategori";
            btnRaderaKategori.Size = new Size(137, 38);
            btnRaderaKategori.TabIndex = 5;
            btnRaderaKategori.Text = "Radera ";
            btnRaderaKategori.UseVisualStyleBackColor = true;
            btnRaderaKategori.Click += btnRaderaKategori_Click;
            // 
            // btnRaderaPodcast
            // 
            btnRaderaPodcast.Location = new Point(314, 108);
            btnRaderaPodcast.Margin = new Padding(4, 5, 4, 5);
            btnRaderaPodcast.Name = "btnRaderaPodcast";
            btnRaderaPodcast.Size = new Size(137, 38);
            btnRaderaPodcast.TabIndex = 11;
            btnRaderaPodcast.Text = "Radera";
            btnRaderaPodcast.UseVisualStyleBackColor = true;
            btnRaderaPodcast.Click += btnRaderaPodcast_Click;
            // 
            // btnUppdateraPodcast
            // 
            btnUppdateraPodcast.Location = new Point(314, 10);
            btnUppdateraPodcast.Margin = new Padding(4, 5, 4, 5);
            btnUppdateraPodcast.Name = "btnUppdateraPodcast";
            btnUppdateraPodcast.Size = new Size(137, 38);
            btnUppdateraPodcast.TabIndex = 10;
            btnUppdateraPodcast.Text = "Uppdatera";
            btnUppdateraPodcast.UseVisualStyleBackColor = true;
            btnUppdateraPodcast.Click += btnUppdateraPodcast_Click;
            // 
            // btnSkapaPodcast
            // 
            btnSkapaPodcast.Location = new Point(4, 108);
            btnSkapaPodcast.Margin = new Padding(4, 5, 4, 5);
            btnSkapaPodcast.Name = "btnSkapaPodcast";
            btnSkapaPodcast.Size = new Size(137, 38);
            btnSkapaPodcast.TabIndex = 5;
            btnSkapaPodcast.Text = "Lägg till podcast";
            btnSkapaPodcast.UseVisualStyleBackColor = true;
            btnSkapaPodcast.Click += btnSkapaPodcast_Click;
            // 
            // cbKategorier
            // 
            cbKategorier.FormattingEnabled = true;
            cbKategorier.Location = new Point(144, 65);
            cbKategorier.Margin = new Padding(4, 5, 4, 5);
            cbKategorier.Name = "cbKategorier";
            cbKategorier.Size = new Size(141, 33);
            cbKategorier.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 70);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(82, 25);
            label4.TabIndex = 7;
            label4.Text = "Kategori:";
            // 
            // txtPodcastUrl
            // 
            txtPodcastUrl.Location = new Point(97, 35);
            txtPodcastUrl.Margin = new Padding(4, 5, 4, 5);
            txtPodcastUrl.Name = "txtPodcastUrl";
            txtPodcastUrl.Size = new Size(1260, 31);
            txtPodcastUrl.TabIndex = 6;
            txtPodcastUrl.TextChanged += txtPodcastUrl_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 40);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 5;
            label3.Text = "RSS-URL:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 17);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 0;
            label2.Text = "Podcast namn:";
            // 
            // txtPodcastNamn
            // 
            txtPodcastNamn.Location = new Point(144, 10);
            txtPodcastNamn.Margin = new Padding(4, 5, 4, 5);
            txtPodcastNamn.Name = "txtPodcastNamn";
            txtPodcastNamn.Size = new Size(141, 31);
            txtPodcastNamn.TabIndex = 1;
            txtPodcastNamn.TextChanged += txtPodcastNamn_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.7977333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.7183361F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.3894157F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 0, 1);
            tableLayoutPanel1.Controls.Add(panel6, 1, 1);
            tableLayoutPanel1.Controls.Add(panel7, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 2, 0);
            tableLayoutPanel1.Controls.Add(panel2, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 194);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24.3718586F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75.62814F));
            tableLayoutPanel1.Size = new Size(1511, 663);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnUppdateraKategori);
            panel4.Controls.Add(btnRaderaKategori);
            panel4.Controls.Add(btnSkapaKategori);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(txtKategoriNamn);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(4, 5);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(488, 151);
            panel4.TabIndex = 0;
            // 
            // btnUppdateraKategori
            // 
            btnUppdateraKategori.Location = new Point(340, 38);
            btnUppdateraKategori.Margin = new Padding(4, 5, 4, 5);
            btnUppdateraKategori.Name = "btnUppdateraKategori";
            btnUppdateraKategori.Size = new Size(137, 38);
            btnUppdateraKategori.TabIndex = 12;
            btnUppdateraKategori.Text = "Uppdatera";
            btnUppdateraKategori.UseVisualStyleBackColor = true;
            btnUppdateraKategori.Click += btnUppdateraKategoriNamn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 0;
            label1.Text = "Kategori Namn";
            // 
            // panel5
            // 
            panel5.Controls.Add(lstKategorier);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(4, 166);
            panel5.Margin = new Padding(4, 5, 4, 5);
            panel5.Name = "panel5";
            panel5.Size = new Size(488, 492);
            panel5.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(lstPodcast);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(500, 166);
            panel6.Margin = new Padding(4, 5, 4, 5);
            panel6.Name = "panel6";
            panel6.Size = new Size(456, 492);
            panel6.TabIndex = 2;
            // 
            // lstPodcast
            // 
            lstPodcast.Dock = DockStyle.Fill;
            lstPodcast.FormattingEnabled = true;
            lstPodcast.ItemHeight = 25;
            lstPodcast.Location = new Point(0, 0);
            lstPodcast.Margin = new Padding(4, 5, 4, 5);
            lstPodcast.Name = "lstPodcast";
            lstPodcast.Size = new Size(456, 492);
            lstPodcast.TabIndex = 0;
            lstPodcast.SelectedIndexChanged += lstPodcast_SelectedIndexChanged;
            // 
            // panel7
            // 
            panel7.Controls.Add(label2);
            panel7.Controls.Add(btnRaderaPodcast);
            panel7.Controls.Add(txtPodcastNamn);
            panel7.Controls.Add(btnUppdateraPodcast);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(cbKategorier);
            panel7.Controls.Add(btnSkapaPodcast);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(500, 5);
            panel7.Margin = new Padding(4, 5, 4, 5);
            panel7.Name = "panel7";
            panel7.Size = new Size(456, 151);
            panel7.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPubliceringsdatum);
            panel1.Controls.Add(lblPubliceringsdatumText);
            panel1.Controls.Add(lblTitel);
            panel1.Controls.Add(lblTitelText);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(964, 5);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 151);
            panel1.TabIndex = 4;
            // 
            // lblPubliceringsdatum
            // 
            lblPubliceringsdatum.Location = new Point(177, 70);
            lblPubliceringsdatum.Margin = new Padding(4, 0, 4, 0);
            lblPubliceringsdatum.Name = "lblPubliceringsdatum";
            lblPubliceringsdatum.Size = new Size(143, 38);
            lblPubliceringsdatum.TabIndex = 16;
            // 
            // lblPubliceringsdatumText
            // 
            lblPubliceringsdatumText.Location = new Point(4, 70);
            lblPubliceringsdatumText.Margin = new Padding(4, 0, 4, 0);
            lblPubliceringsdatumText.Name = "lblPubliceringsdatumText";
            lblPubliceringsdatumText.Size = new Size(164, 38);
            lblPubliceringsdatumText.TabIndex = 15;
            lblPubliceringsdatumText.Text = "Publiceringsdatum:";
            // 
            // lblTitel
            // 
            lblTitel.Location = new Point(47, 10);
            lblTitel.Margin = new Padding(4, 0, 4, 0);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(483, 38);
            lblTitel.TabIndex = 14;
            // 
            // lblTitelText
            // 
            lblTitelText.Location = new Point(4, 10);
            lblTitelText.Margin = new Padding(4, 0, 4, 0);
            lblTitelText.Name = "lblTitelText";
            lblTitelText.Size = new Size(143, 38);
            lblTitelText.TabIndex = 13;
            lblTitelText.Text = "Titel:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtBeskrivning);
            panel2.Controls.Add(lstAvsnitt);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(964, 166);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(543, 492);
            panel2.TabIndex = 5;
            // 
            // txtBeskrivning
            // 
            txtBeskrivning.Dock = DockStyle.Bottom;
            txtBeskrivning.Location = new Point(0, 351);
            txtBeskrivning.Margin = new Padding(4, 5, 4, 5);
            txtBeskrivning.Multiline = true;
            txtBeskrivning.Name = "txtBeskrivning";
            txtBeskrivning.ReadOnly = true;
            txtBeskrivning.Size = new Size(543, 141);
            txtBeskrivning.TabIndex = 1;
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.FormattingEnabled = true;
            lstAvsnitt.ItemHeight = 25;
            lstAvsnitt.Location = new Point(0, 0);
            lstAvsnitt.Margin = new Padding(4, 5, 4, 5);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(541, 329);
            lstAvsnitt.TabIndex = 0;
            lstAvsnitt.SelectedIndexChanged += lstAvsnitt_SelectedIndexChanged;
            // 
            // panel8
            // 
            panel8.Controls.Add(label3);
            panel8.Controls.Add(txtPodcastUrl);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Margin = new Padding(4, 5, 4, 5);
            panel8.Name = "panel8";
            panel8.Size = new Size(1511, 123);
            panel8.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1511, 857);
            Controls.Add(panel8);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtKategoriNamn;
        private Button btnSkapaKategori;
        private ListBox lstKategorier;
        private Label label2;
        private TextBox txtPodcastNamn;
        private Label label4;
        private TextBox txtPodcastUrl;
        private Label label3;
        private Button btnRaderaPodcast;
        private Button btnUppdateraPodcast;
        private Button btnSkapaPodcast;
        private ComboBox cbKategorier;
        private Button btnRaderaKategori;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel8;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TextBox txtBeskrivning;
        private ListBox lstAvsnitt;
        private Label lblTitelText;
        private Label lblTitel;
        private Label lblPubliceringsdatumText;
        private Label lblPubliceringsdatum;
        private ListBox lstPodcast;
        private Button btnUppdateraKategori;
    }
}
