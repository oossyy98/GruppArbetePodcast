namespace PL_presentationsLager2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Label labelRss;
        private TextBox txtRssUrl;
        private Button btnForhandsgranska;
        private Button btnLaggTill;

        private TableLayoutPanel tlpMain;

        private Panel panelLeft;
        private TableLayoutPanel tlpLeft;
        private Panel panelLeftHeader;
        private Label lblMinaPoddar;
        private Label lblAntalPoddar;
        private ComboBox cbKategoriFilter;

        private Panel panelMiddle;
        private TableLayoutPanel tlpMiddle;
        private Panel panelMiddleHeader;
        private Label lblAvsnittTitel;
        private ListBox lstAvsnitt;

        private Panel panelRight;
        private TableLayoutPanel tlpRight;
        private Panel panelRightHeader;
        private Label lblTitelText;
        private Label lblPubliceringsdatumText;

        private Label lblTitel;
        private Label lblPubliceringsdatum;
        private Label lblLangd;

        private TextBox txtBeskrivning;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            labelRss = new Label();
            txtRssUrl = new TextBox();
            btnForhandsgranska = new Button();
            btnLaggTill = new Button();
            tlpMain = new TableLayoutPanel();
            panelLeft = new Panel();
            tlpLeft = new TableLayoutPanel();
            panelLeftHeader = new Panel();
            lblMinaPoddar = new Label();
            lblAntalPoddar = new Label();
            cbKategoriFilter = new ComboBox();
            lstPodcasts = new ListBox();
            panelMiddle = new Panel();
            tlpMiddle = new TableLayoutPanel();
            panelMiddleHeader = new Panel();
            lblAvsnittTitel = new Label();
            lstAvsnitt = new ListBox();
            panelRight = new Panel();
            tlpRight = new TableLayoutPanel();
            panelRightHeader = new Panel();
            lblTitelText = new Label();
            lblTitel = new Label();
            lblPubliceringsdatumText = new Label();
            lblPubliceringsdatum = new Label();
            lblLangd = new Label();
            txtBeskrivning = new TextBox();
            panelTop.SuspendLayout();
            tlpMain.SuspendLayout();
            panelLeft.SuspendLayout();
            tlpLeft.SuspendLayout();
            panelLeftHeader.SuspendLayout();
            panelMiddle.SuspendLayout();
            tlpMiddle.SuspendLayout();
            panelMiddleHeader.SuspendLayout();
            panelRight.SuspendLayout();
            tlpRight.SuspendLayout();
            panelRightHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(labelRss);
            panelTop.Controls.Add(txtRssUrl);
            panelTop.Controls.Add(btnForhandsgranska);
            panelTop.Controls.Add(btnLaggTill);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(1000, 70);
            panelTop.TabIndex = 1;
            // 
            // labelRss
            // 
            labelRss.Location = new Point(10, 25);
            labelRss.Name = "labelRss";
            labelRss.Size = new Size(100, 23);
            labelRss.TabIndex = 0;
            labelRss.Text = "RSS-flöde URL:";
            // 
            // txtRssUrl
            // 
            txtRssUrl.Location = new Point(120, 22);
            txtRssUrl.Name = "txtRssUrl";
            txtRssUrl.Size = new Size(400, 23);
            txtRssUrl.TabIndex = 1;
            // 
            // btnForhandsgranska
            // 
            btnForhandsgranska.Location = new Point(530, 20);
            btnForhandsgranska.Name = "btnForhandsgranska";
            btnForhandsgranska.Size = new Size(114, 23);
            btnForhandsgranska.TabIndex = 2;
            btnForhandsgranska.Text = "Förhandsgranska";
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(650, 20);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(75, 23);
            btnLaggTill.TabIndex = 3;
            btnLaggTill.Text = "Lägg till";
            btnLaggTill.Click += btnLaggTill_Click;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 3;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMain.Controls.Add(panelLeft, 0, 0);
            tlpMain.Controls.Add(panelMiddle, 1, 0);
            tlpMain.Controls.Add(panelRight, 2, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 70);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMain.Size = new Size(1000, 530);
            tlpMain.TabIndex = 0;
            tlpMain.Paint += tlpMain_Paint;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(tlpLeft);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(3, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(294, 524);
            panelLeft.TabIndex = 0;
            // 
            // tlpLeft
            // 
            tlpLeft.ColumnCount = 1;
            tlpLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpLeft.Controls.Add(panelLeftHeader, 0, 0);
            tlpLeft.Controls.Add(lstPodcasts, 0, 1);
            tlpLeft.Dock = DockStyle.Fill;
            tlpLeft.Location = new Point(0, 0);
            tlpLeft.Name = "tlpLeft";
            tlpLeft.RowCount = 2;
            tlpLeft.RowStyles.Add(new RowStyle());
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpLeft.Size = new Size(294, 524);
            tlpLeft.TabIndex = 0;
            // 
            // panelLeftHeader
            // 
            panelLeftHeader.Controls.Add(lblMinaPoddar);
            panelLeftHeader.Controls.Add(lblAntalPoddar);
            panelLeftHeader.Controls.Add(cbKategoriFilter);
            panelLeftHeader.Dock = DockStyle.Top;
            panelLeftHeader.Location = new Point(3, 3);
            panelLeftHeader.Name = "panelLeftHeader";
            panelLeftHeader.Size = new Size(288, 60);
            panelLeftHeader.TabIndex = 0;
            // 
            // lblMinaPoddar
            // 
            lblMinaPoddar.Location = new Point(5, 5);
            lblMinaPoddar.Name = "lblMinaPoddar";
            lblMinaPoddar.Size = new Size(100, 23);
            lblMinaPoddar.TabIndex = 0;
            lblMinaPoddar.Text = "Mina Poddar";
            // 
            // lblAntalPoddar
            // 
            lblAntalPoddar.Location = new Point(120, 5);
            lblAntalPoddar.Name = "lblAntalPoddar";
            lblAntalPoddar.Size = new Size(100, 23);
            lblAntalPoddar.TabIndex = 1;
            lblAntalPoddar.Text = "(0)";
            lblAntalPoddar.Click += lblAntalPoddar_Click;
            // 
            // cbKategoriFilter
            // 
            cbKategoriFilter.Location = new Point(5, 30);
            cbKategoriFilter.Name = "cbKategoriFilter";
            cbKategoriFilter.Size = new Size(150, 23);
            cbKategoriFilter.TabIndex = 2;
            // 
            // lstPodcasts
            // 
            lstPodcasts.Dock = DockStyle.Fill;
            lstPodcasts.ItemHeight = 15;
            lstPodcasts.Location = new Point(3, 69);
            lstPodcasts.Name = "lstPodcasts";
            lstPodcasts.Size = new Size(288, 452);
            lstPodcasts.TabIndex = 1;
            lstPodcasts.SelectedIndexChanged += lstPodcasts_SelectedIndexChanged_1;
            // 
            // panelMiddle
            // 
            panelMiddle.Controls.Add(tlpMiddle);
            panelMiddle.Dock = DockStyle.Fill;
            panelMiddle.Location = new Point(303, 3);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Size = new Size(394, 524);
            panelMiddle.TabIndex = 1;
            // 
            // tlpMiddle
            // 
            tlpMiddle.ColumnCount = 1;
            tlpMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMiddle.Controls.Add(panelMiddleHeader, 0, 0);
            tlpMiddle.Controls.Add(lstAvsnitt, 0, 1);
            tlpMiddle.Dock = DockStyle.Fill;
            tlpMiddle.Location = new Point(0, 0);
            tlpMiddle.Name = "tlpMiddle";
            tlpMiddle.RowCount = 2;
            tlpMiddle.RowStyles.Add(new RowStyle());
            tlpMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMiddle.Size = new Size(394, 524);
            tlpMiddle.TabIndex = 0;
            // 
            // panelMiddleHeader
            // 
            panelMiddleHeader.Controls.Add(lblAvsnittTitel);
            panelMiddleHeader.Location = new Point(3, 3);
            panelMiddleHeader.Name = "panelMiddleHeader";
            panelMiddleHeader.Size = new Size(200, 40);
            panelMiddleHeader.TabIndex = 0;
            // 
            // lblAvsnittTitel
            // 
            lblAvsnittTitel.Location = new Point(5, 10);
            lblAvsnittTitel.Name = "lblAvsnittTitel";
            lblAvsnittTitel.Size = new Size(100, 23);
            lblAvsnittTitel.TabIndex = 0;
            lblAvsnittTitel.Text = "Avsnitt";
            // 
            // lstAvsnitt
            // 
            lstAvsnitt.Dock = DockStyle.Fill;
            lstAvsnitt.ItemHeight = 15;
            lstAvsnitt.Location = new Point(3, 49);
            lstAvsnitt.Name = "lstAvsnitt";
            lstAvsnitt.Size = new Size(388, 472);
            lstAvsnitt.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(tlpRight);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(703, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(294, 524);
            panelRight.TabIndex = 2;
            // 
            // tlpRight
            // 
            tlpRight.ColumnCount = 1;
            tlpRight.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpRight.Controls.Add(panelRightHeader, 0, 0);
            tlpRight.Controls.Add(txtBeskrivning, 0, 1);
            tlpRight.Dock = DockStyle.Fill;
            tlpRight.Location = new Point(0, 0);
            tlpRight.Name = "tlpRight";
            tlpRight.RowCount = 2;
            tlpRight.RowStyles.Add(new RowStyle());
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRight.Size = new Size(294, 524);
            tlpRight.TabIndex = 0;
            // 
            // panelRightHeader
            // 
            panelRightHeader.Controls.Add(lblTitelText);
            panelRightHeader.Controls.Add(lblTitel);
            panelRightHeader.Controls.Add(lblPubliceringsdatumText);
            panelRightHeader.Controls.Add(lblPubliceringsdatum);
            panelRightHeader.Controls.Add(lblLangd);
            panelRightHeader.Location = new Point(3, 3);
            panelRightHeader.Name = "panelRightHeader";
            panelRightHeader.Size = new Size(200, 120);
            panelRightHeader.TabIndex = 0;
            // 
            // lblTitelText
            // 
            lblTitelText.Location = new Point(5, 5);
            lblTitelText.Name = "lblTitelText";
            lblTitelText.Size = new Size(100, 23);
            lblTitelText.TabIndex = 0;
            lblTitelText.Text = "Titel:";
            lblTitelText.Click += lblTitelText_Click;
            // 
            // lblTitel
            // 
            lblTitel.Location = new Point(5, 25);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(200, 23);
            lblTitel.TabIndex = 1;
            // 
            // lblPubliceringsdatumText
            // 
            lblPubliceringsdatumText.Location = new Point(5, 50);
            lblPubliceringsdatumText.Name = "lblPubliceringsdatumText";
            lblPubliceringsdatumText.Size = new Size(115, 23);
            lblPubliceringsdatumText.TabIndex = 2;
            lblPubliceringsdatumText.Text = "Publiceringsdatum:";
            // 
            // lblPubliceringsdatum
            // 
            lblPubliceringsdatum.Location = new Point(5, 70);
            lblPubliceringsdatum.Name = "lblPubliceringsdatum";
            lblPubliceringsdatum.Size = new Size(100, 23);
            lblPubliceringsdatum.TabIndex = 3;
            // 
            // lblLangd
            // 
            lblLangd.Location = new Point(5, 115);
            lblLangd.Name = "lblLangd";
            lblLangd.Size = new Size(100, 23);
            lblLangd.TabIndex = 5;
            // 
            // txtBeskrivning
            // 
            txtBeskrivning.Dock = DockStyle.Fill;
            txtBeskrivning.Location = new Point(3, 129);
            txtBeskrivning.Multiline = true;
            txtBeskrivning.Name = "txtBeskrivning";
            txtBeskrivning.ReadOnly = true;
            txtBeskrivning.ScrollBars = ScrollBars.Vertical;
            txtBeskrivning.Size = new Size(288, 392);
            txtBeskrivning.TabIndex = 1;
            // 
            // Form1
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(tlpMain);
            Controls.Add(panelTop);
            Name = "Form1";
            Text = "Poddhanteringsapplikation";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tlpMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            tlpLeft.ResumeLayout(false);
            panelLeftHeader.ResumeLayout(false);
            panelMiddle.ResumeLayout(false);
            tlpMiddle.ResumeLayout(false);
            panelMiddleHeader.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            tlpRight.ResumeLayout(false);
            tlpRight.PerformLayout();
            panelRightHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
        private ListBox lstPodcasts;
    }
}
