using BL_verksamhetsLager;
using DAL_dataAtkomstlager;
using Models;
using System.Threading.Tasks;

namespace PL_presentationsLager
{
    public partial class Form1 : Form
    {
        private readonly PodcastService podcastService;
        private readonly KategoriService kategoriService;
        private readonly RssService rssService;
        private System.Windows.Forms.Timer urlTimer;

        public Form1()
        {
            InitializeComponent();

            var mongo = new MongoDBService();

            var podcastRepository = new PodcastRepository(mongo);
            var kategoriRepository = new KategoriRepository(mongo);

            rssService = new RssService();
            podcastService = new PodcastService(podcastRepository, rssService);
            kategoriService = new KategoriService(kategoriRepository);
            

            urlTimer = new System.Windows.Forms.Timer();
            urlTimer.Interval = 1000;
            urlTimer.Tick += UrlTimer_Tick;
            txtPodcastUrl.TextChanged += txtPodcastUrl_TextChanged;

        }

        private void txtPodcastUrl_TextChanged(object sender, EventArgs e)
        {
            urlTimer.Stop();
            urlTimer.Start();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LaddaKategorierAsync();

        }

        private async Task LaddaKategorierAsync()
        {
            var lista = await kategoriService.HamtaAllaKategorierAsync();

            cbKategorier.DataSource = null;
            cbKategorier.DataSource = lista;
            cbKategorier.DisplayMember = "Namn";
            cbKategorier.ValueMember = "Id";
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKategorier.SelectedItem is Kategori kategori)
            {
                cbKategorier.SelectedValue = kategori.Id;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPodcasts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnSkapaKategori_Click(object sender, EventArgs e)
        {
            var kategori = new Kategori();
            kategori.Namn = txtKategoriNamn.Text.Trim();

            var fel = await kategoriService.SkapaKategoriAsync(kategori);

            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            MessageBox.Show("Kategori skapad!");
            await LaddaKategorierAsync();
        }

        private async void btnSkapaPodcast_Click(object sender, EventArgs e)
        {
            var podcast = new Podcast();
            podcast.Namn = txtPodcastNamn.Text.Trim();
            podcast.Url = txtPodcastUrl.Text.Trim();
            podcast.KategoriId = cbKategorier.SelectedValue.ToString();

            var fel = await podcastService.SkapaPodcastAsync(podcast);

            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            MessageBox.Show("Podcast skapad!");
        }

        private async void btnHamtaAllaPodcasts_Click(object sender, EventArgs e)
        {
            // 1. Hämta alla podcasts från databasen via BL
            var podcasts = await podcastService.HamtaAllaPodcastsAsync();

            // 2. Sätt som datakälla till griden
            dgvPodcasts.DataSource = podcasts;

            // 3. Dölj Podcast.Id (tekniskt fält som användaren inte behöver se)
            if (dgvPodcasts.Columns.Contains("Id"))
                dgvPodcasts.Columns["Id"].Visible = false;

            // 4. Dölj Podcast.KategoriId (användaren ska se kategori-namnet istället)
            if (dgvPodcasts.Columns.Contains("KategoriId"))
                dgvPodcasts.Columns["KategoriId"].Visible = false;

            // 5. Hämta alla kategorier (vi behöver dessa för att slå upp kategorinamn)
            var kategorier = await kategoriService.HamtaAllaKategorierAsync();

            // 6. Skapa en kolumn för kategori-namn om den inte finns
            if (!dgvPodcasts.Columns.Contains("KategoriNamn"))
            {
                // Första parametern är kolumnens namn i koden
                // Andra parametern är vad användaren ser som rubrik
                dgvPodcasts.Columns.Add("KategoriNamn", "Kategori");
            }

            // 7. Fyll kolumnen "KategoriNamn" utifrån varje podcasts KategoriId
            foreach (DataGridViewRow row in dgvPodcasts.Rows)
            {
                if (row.DataBoundItem is Podcast p)
                {
                    // hitta kategorin där Id == podcast.KategoriId
                    var kategori = kategorier.FirstOrDefault(k => k.Id == p.KategoriId);

                    // skriv kategori-namnet i den nya kolumnen
                    row.Cells["KategoriNamn"].Value = kategori?.Namn;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dgvPodcasts.CurrentRow?.DataBoundItem is Podcast podcast)
            {
                var fel = await podcastService.RaderaPodcastAsync(podcast.Id);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Podcast raderad!");

                var lista = await podcastService.HamtaAllaPodcastsAsync();
                dgvPodcasts.DataSource = lista;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dgvPodcasts.CurrentRow?.DataBoundItem is Podcast podcast)
            {
                podcast.Namn = txtPodcastNamn.Text.Trim();
                podcast.Url = txtPodcastUrl.Text.Trim();
                podcast.KategoriId = cbKategorier.SelectedValue.ToString();

                var fel = await podcastService.UppdateraPodcastAsync(podcast);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Podcast uppdaterad!");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtPodcastUrl.Text.Trim();
                if (string.IsNullOrWhiteSpace(url))
                {
                    MessageBox.Show("Ange en RSS-URL.");
                    return;
                }

                // Hämta RSS via BL
                var podcast = await podcastService.LasInRssAsync(url);

                if (podcast == null)
                {
                    MessageBox.Show("Kunde inte läsa RSS-flödet.");
                    return;
                }

                //Visa titel om textbox är tom
                if (string.IsNullOrWhiteSpace(txtPodcastNamn.Text))
                    txtPodcastNamn.Text = podcast.Namn;

                //Visa avsnitten
                dgvAvsnitt.DataSource = podcast.Avsnitt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tekniskt fel: " + ex.Message);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (dgvPodcasts.CurrentRow?.DataBoundItem is Podcast podcast)
            {
                try
                {
                    var avsnitt = await rssService.HamtaAvsnittFranRssAsync(podcast.Url);
                    dgvAvsnitt.DataSource = avsnitt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kunde inte hämta avsnitt: " + ex.Message);
                }
            }
        }

        private async void btnHamtaKategorier_Click(object sender, EventArgs e)
        {
            await LaddaKategoriListaAsync();
        }

        private async Task LaddaKategoriListaAsync()
        {
            var lista = await kategoriService.HamtaAllaKategorierAsync();
            lstKategorier.DataSource = null;
            lstKategorier.DataSource = lista;
            lstKategorier.DisplayMember = "Namn";
            lstKategorier.ValueMember = "Id";
        }
        private async void btnRaderaKategori_Click(object sender, EventArgs e)
        {
            if (lstKategorier.SelectedItem is Kategori kategori)
            {
                var allaPodcasts = await podcastService.HamtaAllaPodcastsAsync();
                var antalPodcasts = allaPodcasts.Count(p => p.KategoriId == kategori.Id);

                string meddelande;
                if (antalPodcasts > 0)
                {
                    meddelande = $"Kategorin '{kategori.Namn}' har {antalPodcasts} podcast(s) kopplade.\n\n" +
                                $"Är du säker på att du vill radera kategorin?\n" +
                                $"Alla {antalPodcasts} podcast(s) kommer också att raderas!";
                }
                else
                {
                    meddelande = $"Är du säker på att du vill radera kategorin '{kategori.Namn}'?";
                }

                var resultat = MessageBox.Show(
                    meddelande,
                    "Bekräfta radering",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultat == DialogResult.Yes)
                {
                    // Radera alla podcasts i kategorin FÖRST
                    if (antalPodcasts > 0)
                    {
                        var berordaPodcasts = allaPodcasts.Where(p => p.KategoriId == kategori.Id).ToList();
                        foreach (var podcast in berordaPodcasts)
                        {
                            await podcastService.RaderaPodcastAsync(podcast.Id);
                        }
                    }

                    // Radera kategorin
                    var fel = await kategoriService.RaderaKategoriAsync(kategori.Id);
                    if (fel != null)
                    {
                        MessageBox.Show(fel);
                        return;
                    }

                    if (antalPodcasts > 0)
                    {
                        MessageBox.Show($"Kategori och {antalPodcasts} podcast(s) raderade!");
                    }
                    else
                    {
                        MessageBox.Show("Kategori raderad!");
                    }

                    await LaddaKategoriListaAsync();
                    await LaddaKategorierAsync();

                    // ? Uppdatera podcast-listan direkt istället
                    var uppdateradLista = await podcastService.HamtaAllaPodcastsAsync();
                    dgvPodcasts.DataSource = uppdateradLista;
                }
            }
            else
            {
                MessageBox.Show("Välj en kategori att radera.");
            }
        }

        private async void UrlTimer_Tick(object sender, EventArgs e)
        {
            urlTimer.Stop();

            string url = txtPodcastUrl.Text.Trim();

            // Om URL-fältet är tomt, rensa också namnfältet
            if (string.IsNullOrWhiteSpace(url))
            {
                txtPodcastNamn.Clear();
                return;
            }

            // Kolla om det ser ut som en giltig URL
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                // ? ÄNDRING: Ta bort checken om txtPodcastNamn är tom
                // Nu hämtas alltid nytt namn när URL ändras
                try
                {
                    var podcastNamn = await rssService.HamtaPodcastTitelFranRssAsync(url);
                    if (podcastNamn != null)
                    {
                        txtPodcastNamn.Text = podcastNamn; // Skriver över gamla namnet
                    }
                    else
                    {
                        txtPodcastNamn.Clear(); // Rensa om inget namn hittades
                    }
                }
                catch
                {
                    // Om fel uppstår, rensa namnet
                    txtPodcastNamn.Clear();
                }
            }
        }
    }

}
