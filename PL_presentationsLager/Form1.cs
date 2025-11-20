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

            //timer för rss-hämtning
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

        //kategori hantering
        private async Task LaddaKategorierAsync()
        {
            var lista = await kategoriService.HamtaAllaKategorierAsync();

            // fyll lista till vänster
            lstKategorier.DataSource = null;
            lstKategorier.DataSource = lista;
            lstKategorier.DisplayMember = "Namn";
            lstKategorier.ValueMember = "Id";

            // fyll comboboxen i mitten
            cbKategorier.DataSource = null;
            cbKategorier.DataSource = lista;
            cbKategorier.DisplayMember = "Namn";
            cbKategorier.ValueMember = "Id";


            lstKategorier.ClearSelected();

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void lstKategorier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKategorier.SelectedItem is Kategori k)
            {
                var alla = await podcastService.HamtaAllaPodcastsAsync();

                var filtrerade = alla.Where(p => p.KategoriId == k.Id).ToList();

                lstPodcast.DataSource = null;
                lstPodcast.DataSource = filtrerade;
                lstPodcast.DisplayMember = "Namn";
                lstPodcast.ValueMember = "Id";


                lstPodcast.ClearSelected();

                // töm avsnittsdelen när kategori byts
                lstAvsnitt.DataSource = null;
                lblTitel.Text = "";
                lblPubliceringsdatum.Text = "";
                txtBeskrivning.Text = "";
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
            if (cbKategorier.SelectedValue == null)
            {
                MessageBox.Show("Välj en kategori.");
                return;
            }

            string url = txtPodcastUrl.Text.Trim();

            // HÄMTA RSS + avsnitt
            var podcast = await podcastService.LasInRssAsync(url);
            if (podcast == null)
            {
                MessageBox.Show("Kunde inte läsa RSS.");
                return;
            }

            // Lägg till kategori
            podcast.KategoriId = cbKategorier.SelectedValue.ToString();

            // Spara i databasen
            var fel = await podcastService.SkapaPodcastAsync(podcast);
            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            txtPodcastNamn.Clear();
            txtPodcastUrl.Clear();

            // Uppdatera listan
            lstKategorier_SelectedIndexChanged(null, null);
        }


        private async void btnRaderaPodcast_Click(object sender, EventArgs e)
        {
            if (lstPodcast.SelectedValue == null)
            {
                MessageBox.Show("Välj en podcast.");
                return;
            }

            // Bekräftelsedialog
            var podcastNamn = ((Podcast)lstPodcast.SelectedItem).Namn;
            var resultat = MessageBox.Show(
                $"Är du säker på att du vill radera podcasten '{podcastNamn}'?",
                "Bekräfta radering",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultat != DialogResult.Yes)
            {
                return;
            }

            var id = lstPodcast.SelectedValue.ToString();
            var fel = await podcastService.RaderaPodcastAsync(id);

            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            lstKategorier_SelectedIndexChanged(null, null);
            lstAvsnitt.DataSource = null;

            MessageBox.Show("Podcast raderad!");
        }

        private async void btnUppdateraPodcast_Click(object sender, EventArgs e)
        {
            if (lstPodcast.SelectedItem is not Podcast p)
            {
                MessageBox.Show("Välj en podcast.");
                return;
            }

            p.Namn = txtPodcastNamn.Text.Trim();
            p.Url = txtPodcastUrl.Text.Trim();
            p.KategoriId = cbKategorier.SelectedValue?.ToString();

            var fel = await podcastService.UppdateraPodcastAsync(p);
            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            lstKategorier_SelectedIndexChanged(null, null);
        }



        //LADDA KATEGORIER METOD
        private async void btnHamtaKategorier_Click(object sender, EventArgs e)
        {
            await LaddaKategoriListaAsync();


        }

        //FYLLA LISTAN
        private async Task LaddaKategoriListaAsync()
        {
            var lista = await kategoriService.HamtaAllaKategorierAsync();
            lstKategorier.DataSource = null;
            lstKategorier.DataSource = lista;
            lstKategorier.DisplayMember = "Namn";
            lstKategorier.ValueMember = "Id";
        }

        //RADERA KATEGORI KNAPP
        private async void btnRaderaKategori_Click(object sender, EventArgs e)
        {
            if (lstKategorier.SelectedValue == null)
            {
                MessageBox.Show("Välj en kategori.");
                return;
            }

            // Bekräftelsedialog
            var kategoriNamn = ((Kategori)lstKategorier.SelectedItem).Namn;
            var resultat = MessageBox.Show(
                $"Är du säker på att du vill radera kategorin '{kategoriNamn}'?",
                "Bekräfta radering",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultat != DialogResult.Yes)
            {
                return;
            }

            var id = lstKategorier.SelectedValue.ToString();
            var fel = await kategoriService.RaderaKategoriAsync(id);

            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            await LaddaKategorierAsync();
            lstPodcast.DataSource = null;
            lstAvsnitt.DataSource = null;

            MessageBox.Show("Kategori raderad!");
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvAvsnitt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void lstPodcast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPodcast.SelectedItem is Podcast p)
            {
                // fyll textfälten
                txtPodcastNamn.Text = p.Namn;
                txtPodcastUrl.Text = p.Url;
                cbKategorier.SelectedValue = p.KategoriId;

                // VISA AVSNITT DIREKT
                lstAvsnitt.DataSource = null;
                lstAvsnitt.DataSource = p.Avsnitt;
                lstAvsnitt.DisplayMember = "Titel";

                // tar bort instant blå-markering
                lstAvsnitt.SelectedIndex = -1;

                // töm avsnitts-detaljer
                lblTitel.Text = "";
                lblPubliceringsdatum.Text = "";
                txtBeskrivning.Text = "";
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvsnitt.SelectedItem is Avsnitt a)
            {
                lblTitel.Text = a.Titel;
                lblPubliceringsdatum.Text = a.PubliceringsDatum?.ToString("yyyy-MM-dd");
                txtBeskrivning.Text = a.Beskrivning;
                //lstAvsnitt.ClearSelected();
            }
        }

        private async void btnUppdateraKategoriNamn_Click(object sender, EventArgs e)
        {
            if (lstKategorier.SelectedItem is not Kategori valdKategori)
            {
                MessageBox.Show("Välj en kategori att redigera.");
                return;
            }

            var nyttNamn = txtKategoriNamn.Text.Trim();
            if (string.IsNullOrWhiteSpace(nyttNamn))
            {
                MessageBox.Show("Ange ett nytt kategorinamn.");
                return;
            }

            valdKategori.Namn = nyttNamn;
            var fel = await kategoriService.UppdateraKategoriAsync(valdKategori);

            if (fel != null)
            {
                MessageBox.Show(fel);
                return;
            }

            txtKategoriNamn.Clear();
            await LaddaKategorierAsync();
            MessageBox.Show("Kategori uppdaterad!");
        }

        private void txtPodcastNamn_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitel_Click(object sender, EventArgs e)
        {

        }
    }

}
