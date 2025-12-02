using BL_verksamhetsLager;
using DAL_dataAtkomstlager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_presentationsLager
{
    public partial class Form1 : Form
    {
        private readonly PodcastService podcastService;
        private readonly KategoriService kategoriService;
        private readonly RssService rssService;
        private readonly HttpClient httpClient;
        private System.Windows.Forms.Timer urlTimer;

        public Form1()
        {
            InitializeComponent();

            var mongo = new MongoDBService();

            var podcastRepository = new PodcastRepository(mongo);
            var kategoriRepository = new KategoriRepository(mongo);

            httpClient = new HttpClient();
            rssService = new RssService(httpClient);
            podcastService = new PodcastService(podcastRepository, rssService);
            kategoriService = new KategoriService(kategoriRepository);

            urlTimer = new System.Windows.Forms.Timer();
            urlTimer.Interval = 1000;
            urlTimer.Tick += UrlTimer_Tick;

            txtPodcastUrl.TextChanged += txtPodcastUrl_TextChanged;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (urlTimer != null)
            {
                urlTimer.Stop();
                urlTimer.Dispose();
            }

            if (httpClient != null)
            {
                httpClient.Dispose();
            }

            base.OnFormClosing(e);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await LaddaKategorierAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid laddning av kategorier: " + ex.Message);
            }
        }


        private async Task LaddaKategorierAsync()
        {
            try
            {
                var lista = await kategoriService.HamtaAllaKategorierAsync();

                lstKategorier.DataSource = null;
                lstKategorier.DataSource = lista;
                lstKategorier.DisplayMember = "Namn";
                lstKategorier.ValueMember = "Id";

                cbKategorier.DataSource = null;
                cbKategorier.DataSource = lista;
                cbKategorier.DisplayMember = "Namn";
                cbKategorier.ValueMember = "Id";

                lstKategorier.ClearSelected();
                lstPodcast.DataSource = null;
                lstAvsnitt.DataSource = null;

                RensaAvsnittsDetaljer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid laddning av kategorier: " + ex.Message);
            }
        }

        private async Task LaddaPodcastsAsync()
        {
            try
            {
                if (lstKategorier.SelectedItem is not Kategori valdKategori)
                {
                    lstPodcast.DataSource = null;
                    lstAvsnitt.DataSource = null;
                    RensaAvsnittsDetaljer();
                    return;
                }

                var alla = await podcastService.HamtaAllaPodcastsAsync();
                var filtrerade = alla.Where(p => p.KategoriId == valdKategori.Id).ToList();

                lstPodcast.DataSource = null;
                lstPodcast.DataSource = filtrerade;
                lstPodcast.DisplayMember = "Namn";
                lstPodcast.ValueMember = "Id";

                lstPodcast.ClearSelected();
                lstAvsnitt.DataSource = null;
                RensaAvsnittsDetaljer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid laddning av podcasts: " + ex.Message);
            }
        }

        private void RensaAvsnittsDetaljer()
        {
            lblTitel.Text = "";
            lblPubliceringsdatum.Text = "";
            txtBeskrivning.Text = "";
        }

        private void FyllPodcastFält(Podcast p)
        {
            txtPodcastNamn.Text = p.Namn;
            txtPodcastUrl.Text = p.Url;
            cbKategorier.SelectedValue = p.KategoriId;

            lstAvsnitt.DataSource = null;
            lstAvsnitt.DataSource = p.Avsnitt;
            lstAvsnitt.DisplayMember = "Titel";

            lstAvsnitt.ClearSelected();
            RensaAvsnittsDetaljer();
        }

        private async void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LaddaPodcastsAsync();
        }

        private async void btnSkapaKategori_Click(object sender, EventArgs e)
        {
            try
            {
                var namn = txtKategoriNamn.Text.Trim();

                if (string.IsNullOrWhiteSpace(namn))
                {
                    MessageBox.Show("Kategori måste ha ett namn.");
                    return;
                }

                var kategori = new Kategori();
                kategori.Namn = namn;

                var fel = await kategoriService.SkapaKategoriAsync(kategori);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Kategori skapad.");
                txtKategoriNamn.Clear();
                await LaddaKategorierAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid skapande av kategori: " + ex.Message);
            }
        }

        private async void btnRaderaKategori_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstKategorier.SelectedItem is not Kategori valdKategori)
                {
                    MessageBox.Show("Välj en kategori.");
                    return;
                }

                var resultat = MessageBox.Show(
                    "Är du säker på att du vill radera kategorin '" + valdKategori.Namn + "'?",
                    "Bekräfta radering",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultat != DialogResult.Yes)
                {
                    return;
                }

                var fel = await kategoriService.RaderaKategoriAsync(valdKategori.Id);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Kategori raderad.");
                txtKategoriNamn.Clear();
                await LaddaKategorierAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid radering av kategori: " + ex.Message);
            }
        }

        private async void btnUppdateraKategoriNamn_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstKategorier.SelectedItem is not Kategori valdKategori)
                {
                    MessageBox.Show("Välj en kategori.");
                    return;
                }

                var nyttNamn = txtKategoriNamn.Text.Trim();
                if (string.IsNullOrWhiteSpace(nyttNamn))
                {
                    MessageBox.Show("Kategori måste ha ett namn.");
                    return;
                }

                valdKategori.Namn = nyttNamn;

                var fel = await kategoriService.UppdateraKategoriAsync(valdKategori);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Kategori uppdaterad.");
                txtKategoriNamn.Clear();
                await LaddaKategorierAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid uppdatering av kategori: " + ex.Message);
            }
        }

        private async void btnSkapaPodcast_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbKategorier.SelectedValue == null)
                {
                    MessageBox.Show("Välj en kategori för podcasten.");
                    return;
                }

                var url = txtPodcastUrl.Text.Trim();

                if (string.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("Ange en RSS-adress (URL).");
                    return;
                }

                var podcast = await podcastService.LasInRssAsync(url);
                if (podcast == null)
                {
                    MessageBox.Show("Kunde inte läsa in RSS-flödet.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtPodcastNamn.Text))
                    podcast.Namn = txtPodcastNamn.Text.Trim();


                podcast.KategoriId = cbKategorier.SelectedValue.ToString();

                var fel = await podcastService.SkapaPodcastAsync(podcast);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Podcast skapad.");
                txtPodcastNamn.Clear();
                txtPodcastUrl.Clear();

                await LaddaPodcastsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid skapande av podcast: " + ex.Message);
            }
        }

        private async void btnRaderaPodcast_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPodcast.SelectedItem is not Podcast valdPodcast)
                {
                    MessageBox.Show("Välj en podcast.");
                    return;
                }

                var resultat = MessageBox.Show(
                    "Är du säker på att du vill radera podcasten '" + valdPodcast.Namn + "'?",
                    "Bekräfta radering",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultat != DialogResult.Yes)
                {
                    return;
                }

                var fel = await podcastService.RaderaPodcastAsync(valdPodcast.Id);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Podcast raderad.");
                await LaddaPodcastsAsync();
                lstAvsnitt.DataSource = null;
                RensaAvsnittsDetaljer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid radering av podcast: " + ex.Message);
            }
        }

        private async void btnUppdateraPodcast_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPodcast.SelectedItem is not Podcast valdPodcast)
                {
                    MessageBox.Show("Välj en podcast.");
                    return;
                }

                var nyttNamn = txtPodcastNamn.Text.Trim();
                var nyUrl = txtPodcastUrl.Text.Trim();

                if (string.IsNullOrWhiteSpace(nyttNamn))
                {
                    MessageBox.Show("Podcast måste ha ett namn.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(nyUrl))
                {
                    MessageBox.Show("Podcast måste ha en URL.");
                    return;
                }

                valdPodcast.Namn = nyttNamn;
                valdPodcast.Url = nyUrl;
                valdPodcast.KategoriId = cbKategorier.SelectedValue != null
                    ? cbKategorier.SelectedValue.ToString()
                    : valdPodcast.KategoriId;

                var fel = await podcastService.UppdateraPodcastAsync(valdPodcast);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Podcast uppdaterad.");
                await LaddaPodcastsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod vid uppdatering av podcast: " + ex.Message);
            }
        }

        private void lstPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPodcast.SelectedItem is Podcast p)
            {
                FyllPodcastFält(p);
            }
            else
            {
                txtPodcastNamn.Clear();
                txtPodcastUrl.Clear();
                lstAvsnitt.DataSource = null;
                RensaAvsnittsDetaljer();
            }
        }

        private void lstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvsnitt.SelectedItem is Avsnitt a)
            {
                lblTitel.Text = a.Titel;
                lblPubliceringsdatum.Text = a.PubliceringsDatum.HasValue
                    ? a.PubliceringsDatum.Value.ToString("yyyy-MM-dd")
                    : "";
                txtBeskrivning.Text = a.Beskrivning;
            }
            else
            {
                RensaAvsnittsDetaljer();
            }
        }

        private void txtPodcastUrl_TextChanged(object sender, EventArgs e)
        {
            urlTimer.Stop();
            urlTimer.Start();
        }

        private async void UrlTimer_Tick(object sender, EventArgs e)
        {
            urlTimer.Stop();

            var url = txtPodcastUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                txtPodcastNamn.Clear();
                return;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                return;
            }

            try
            {
                var namn = await rssService.HamtaPodcastTitelFranRssAsync(url);
                if (namn != null)
                {
                    txtPodcastNamn.Text = namn;
                    var avsnitt = await rssService.HamtaAvsnittFranRssAsync(url);
                    lstAvsnitt.DataSource = null;
                    lstAvsnitt.DataSource = avsnitt;
                    lstAvsnitt.DisplayMember = "Titel";
                }
                else
                {
                    txtPodcastNamn.Clear();
                }
            }
            catch
            {
                txtPodcastNamn.Clear();
            }
        }

        private void txtPodcastNamn_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
