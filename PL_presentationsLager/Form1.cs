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
        public Form1()
        {
            InitializeComponent();

            var mongo = new MongoDBService();

            var podcastRepository = new PodcastRepository(mongo);
            var kategoriRepository = new KategoriRepository(mongo);

            podcastService = new PodcastService(podcastRepository);
            kategoriService = new KategoriService(kategoriRepository);
            rssService = new RssService();
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
            var lista = await podcastService.HamtaAllaPodcastsAsync();
            dgvPodcasts.DataSource = lista;
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
            if (dgvPodcasts.CurrentRow?.DataBoundItem is Podcast podcast)
            {
                var avsnittLista = await rssService.HamtaAvsnittFranRssAsync(podcast.Url);

                if (avsnittLista.Count == 0)
                {
                    MessageBox.Show("Kunde inte läsa RSS-flödet.");
                    return;
                }

                podcast.Avsnitt = avsnittLista;

                var fel = await podcastService.UppdateraPodcastAsync(podcast);

                if (fel != null)
                {
                    MessageBox.Show(fel);
                    return;
                }

                MessageBox.Show("Avsnitt uppdaterade.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvPodcasts.CurrentRow?.DataBoundItem is Podcast podcast)
            {
                dgvAvsnitt.DataSource = podcast.Avsnitt;
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
                    meddelande = $"Kategorin har {antalPodcasts} podcasts kopplade. Är du säker på att du vill radera kategorin?";
                }
                else
                {
                    meddelande = $"Är du säker på att du vill radera kategorin?";
                }
                var resultat = MessageBox.Show(meddelande, "Bekräfta radering", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultat == DialogResult.Yes)
                {
                    // Om kategorin används, sätt alla podcasts till okategoriserade
                    if (antalPodcasts > 0)
                    {
                        var berordaPodcasts = allaPodcasts.Where(p => p.KategoriId == kategori.Id).ToList();
                        foreach (var podcast in berordaPodcasts)
                        {
                            podcast.KategoriId = null; // Sätt till okategoriserad
                            await podcastService.UppdateraPodcastAsync(podcast);
                        }
                    }
                    

                    //raderar kategorin
                    var fel = await kategoriService.RaderaKategoriAsync(kategori.Id);
                    if (fel != null)
                    {
                        MessageBox.Show(fel);
                        return;
                    }
                    MessageBox.Show("Kategori raderad!");
                    await LaddaKategoriListaAsync();
                    await LaddaKategorierAsync();
                }
            }
            else
            {
                MessageBox.Show("Välj en kategori att radera.");
            }
        }
    }
}
