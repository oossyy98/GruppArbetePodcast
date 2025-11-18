using BL_verksamhetsLager;
using DAL_dataAtkomstlager;
using Models;

namespace PL_presentationsLager2
{
    public partial class Form1 : Form
    {
        private readonly PodcastService podcastService;
        private readonly KategoriService kategoriService;
        private readonly RssService rssService;

        public Form1()
        {
            InitializeComponent();


            var mongo = new MongoDBService();
            var podcastRepo = new PodcastRepository(mongo);
            var kategoriRepo = new KategoriRepository(mongo);


            rssService = new RssService();


            podcastService = new PodcastService(podcastRepo, rssService);
            kategoriService = new KategoriService(kategoriRepo);

            // Eventkoppling
            lstPodcasts.SelectedIndexChanged += lstPodcasts_SelectedIndexChanged;
            lstAvsnitt.SelectedIndexChanged += lstAvsnitt_SelectedIndexChanged;
            cbKategoriFilter.SelectedIndexChanged += cbKategoriFilter_SelectedIndexChanged;
            btnForhandsgranska.Click += btnForhandsgranska_Click;
            btnLaggTill.Click += btnLaggTill_Click;

            // Ladda initial data
            Load += async (_, __) =>
            {
                await LaddaKategoriFilterAsync();
                await LaddaAllaPodcastsAsync();
            };
        }



        // LADDA KATEGORIER (FILTER)
        private async Task LaddaKategoriFilterAsync()
        {
            var kategorier = await kategoriService.HamtaAllaKategorierAsync();

            cbKategoriFilter.Items.Clear();
            cbKategoriFilter.Items.Add("Alla");

            foreach (var k in kategorier)
            {
                cbKategoriFilter.Items.Add(new KategoriListItem
                {
                    Kategori = k,
                    Text = k.Namn
                });
            }

            cbKategoriFilter.SelectedIndex = 0;
        }

        private class KategoriListItem
        {
            public Kategori Kategori { get; set; }
            public string Text { get; set; }
            public override string ToString() => Text;
        }

        // ---------------------------------------------------------------------
        // LADDA PODCASTS (LISTA)
        // ---------------------------------------------------------------------
        private async Task LaddaAllaPodcastsAsync(string kategoriFilter = null)
        {
            var podcasts = await podcastService.HamtaAllaPodcastsAsync();
            var kategorier = await kategoriService.HamtaAllaKategorierAsync();

            // Filtrera
            if (kategoriFilter != null && kategoriFilter != "Alla")
                podcasts = podcasts.Where(p => p.KategoriId == kategoriFilter).ToList();

            // Uppdatera antal
            lblAntalPoddar.Text = $"({podcasts.Count})";

            lstPodcasts.Items.Clear();

            foreach (var p in podcasts)
            {
                var kategori = kategorier.FirstOrDefault(k => k.Id == p.KategoriId);

                lstPodcasts.Items.Add(new PodcastListItem
                {
                    Podcast = p,
                    Text = $"{p.Namn} – {kategori?.Namn}"
                });
            }
        }

        private class PodcastListItem
        {
            public Podcast Podcast { get; set; }
            public string Text { get; set; }
            public override string ToString() => Text;
        }

        // ---------------------------------------------------------------------
        // FILTRERING
        // ---------------------------------------------------------------------
        private async void cbKategoriFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKategoriFilter.SelectedItem is KategoriListItem item)
                await LaddaAllaPodcastsAsync(item.Kategori.Id);
            else
                await LaddaAllaPodcastsAsync();
        }

        // ---------------------------------------------------------------------
        // PODCAST KLICK ? LADDA AVSNITT FRÅN RSS
        // ---------------------------------------------------------------------
        private async void lstPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPodcasts.SelectedItem is PodcastListItem item)
            {
                var podcast = item.Podcast;

                var avsnitt = await rssService.HamtaAvsnittFranRssAsync(podcast.Url);

                lstAvsnitt.DataSource = avsnitt;
                lstAvsnitt.DisplayMember = "Titel";

                lblAvsnittTitel.Text = $"Avsnitt – {podcast.Namn}";
            }
        }

        // ---------------------------------------------------------------------
        // VISA AVSNITTSDETALJER
        // ---------------------------------------------------------------------
        private void lstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvsnitt.SelectedItem is Avsnitt a)
            {
                lblTitel.Text = a.Titel;
                lblPubliceringsdatum.Text = a.PubliceringsDatum.ToString();
                txtBeskrivning.Text = a.Beskrivning;
            }
        }

        // ---------------------------------------------------------------------
        // FÖRHANDSGRANSKA RSS
        // ---------------------------------------------------------------------
        private async void btnForhandsgranska_Click(object sender, EventArgs e)
        {
            string url = txtRssUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Skriv in en RSS-URL.");
                return;
            }

            var flode = await rssService.HamtaAvsnittFranRssAsync(url);

            if (flode.Count == 0)
            {
                MessageBox.Show("Kunde inte läsa RSS-flödet.");
                return;
            }

            lstAvsnitt.DataSource = flode;
            lstAvsnitt.DisplayMember = "Titel";
        }

        // ---------------------------------------------------------------------
        // LÄGG TILL NY PODCAST
        // ---------------------------------------------------------------------
        private async void btnLaggTill_Click(object sender, EventArgs e)
        {
            string url = txtRssUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Skriv in en RSS-URL.");
                return;
            }

            // Hämta titel från RSS
            var titel = await rssService.HamtaPodcastTitelFranRssAsync(url);

            if (titel == null)
            {
                MessageBox.Show("Kunde inte läsa RSS-flödet.");
                return;
            }

            // Skapa podcast
            var podcast = new Podcast
            {
                Namn = titel,
                Url = url,
                KategoriId = HämtaKategoriId() // ? gör detta
            };

            var fel = await podcastService.SkapaPodcastAsync(podcast);

            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            MessageBox.Show("Podcast tillagd!");

            await LaddaAllaPodcastsAsync();
        }


        // Hämtar kategori för podcast (ändra om du vill ha popup)
        private string HämtaKategoriId()
        {
            if (cbKategoriFilter.SelectedItem is KategoriListItem k)
                return k.Kategori.Id;

            return null;
        }

        private void lstPodcasts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tlpMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAntalPoddar_Click(object sender, EventArgs e)
        {

        }

        private void lblTitelText_Click(object sender, EventArgs e)
        {

        }
    }
}
