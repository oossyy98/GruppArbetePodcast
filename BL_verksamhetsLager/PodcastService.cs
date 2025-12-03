using DAL_dataAtkomstlager;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL_verksamhetsLager
{
    public class PodcastService
    {
        private readonly IRepository<Podcast> repository;
        private readonly RssService rssService;

        public PodcastService(IRepository<Podcast> repository, RssService rssService)
        {
            this.repository = repository;
            this.rssService = rssService;
        }

        // Hämta RSS och bygg ett Podcast-objekt (innan sparning)
        public async Task<Podcast?> LasInRssAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            var titel = await rssService.HamtaPodcastTitelFranRssAsync(url);
            var avsnitt = await rssService.HamtaAvsnittFranRssAsync(url);

            if (titel == null)
                return null;

            return new Podcast
            {
                Namn = titel,
                Url = url,
                Avsnitt = avsnitt
            };
        }

        // CREATE
        public async Task<string?> SkapaPodcastAsync(Podcast podcast)
        {
            if (string.IsNullOrWhiteSpace(podcast.Namn))
                return "Podcast måste ha ett namn.";

            if (string.IsNullOrWhiteSpace(podcast.Url))
                return "Podcast måste ha en URL.";

            if (string.IsNullOrWhiteSpace(podcast.KategoriId))
                return "Podcast måste tillhöra en kategori.";

            var alla = await repository.GetAllAsync();
            if (alla.Any(p =>
                p.Url.Equals(podcast.Url, StringComparison.OrdinalIgnoreCase)
                && p.KategoriId == podcast.KategoriId))
            {
                return "Denna podcast finns redan i denna kategori.";
            }

            if (podcast.Avsnitt == null)
                podcast.Avsnitt = new List<Avsnitt>();

            await repository.AddAsync(podcast);
            return null;
        }

        // READ ALL
        public async Task<List<Podcast>> HamtaAllaPodcastsAsync()
        {
            return await repository.GetAllAsync() ?? new List<Podcast>();
        }

        // READ ONE
        public async Task<Podcast?> HamtaPodcastAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return await repository.GetByIdAsync(id);
        }

        // UPDATE
        public async Task<string?> UppdateraPodcastAsync(Podcast podcast)
        {
            if (podcast == null)
                return "Ogiltig podcast.";

            if (string.IsNullOrWhiteSpace(podcast.Namn))
                return "Podcast måste ha ett namn.";

            if (string.IsNullOrWhiteSpace(podcast.Url))
                return "Podcast måste ha en URL.";

            if (string.IsNullOrWhiteSpace(podcast.KategoriId))
                return "Podcast måste tillhöra en kategori.";

            var befintlig = await repository.GetByIdAsync(podcast.Id);
            if (befintlig == null)
                return "Podcasten finns inte.";

            // Uppdatera alla fält
            befintlig.Namn = podcast.Namn;
            befintlig.Url = podcast.Url;
            befintlig.KategoriId = podcast.KategoriId;
            befintlig.Avsnitt = podcast.Avsnitt;

            var lyckades = await repository.UpdateAsync(befintlig);
            if (!lyckades)
                return "Kunde inte uppdatera podcasten.";

            return null;
        }

        // DELETE
        public async Task<string?> RaderaPodcastAsync(string id)
        {
            var befintlig = await repository.GetByIdAsync(id);
            if (befintlig == null)
                return "Podcasten finns inte.";

            var lyckades = await repository.DeleteAsync(id);
            if (!lyckades)
                return "Kunde inte radera podcasten.";

            return null;
        }
    }
}
