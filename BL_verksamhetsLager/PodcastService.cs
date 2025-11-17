using DAL_dataAtkomstlager;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_verksamhetsLager
{
    public class PodcastService
    {
        private readonly IRepository<Podcast> repository;

        public PodcastService(IRepository<Podcast> repository)
        {
            this.repository = repository;
        }

        //CREATE
        public async Task<String?> SkapaPodcastAsync(Podcast podcast)
        {
            if (string.IsNullOrWhiteSpace(podcast.Namn))
            {
                return "Podcast måste ha ett namn.";
            }

            if (string.IsNullOrWhiteSpace(podcast.Url))
            {
                return "Podcast måste ha en URL.";
            }

            if (podcast.Avsnitt == null)
            {
                podcast.Avsnitt = new List<Avsnitt>();
            }

            await repository.AddAsync(podcast);
            return null;
        }
        //READ ALLA
        public async Task<List<Podcast>> HamtaAllaPodcastsAsync()
        {
            var lista = await repository.GetAllAsync();
            return lista ?? new List<Podcast>();
        }
        //READ EN
        public async Task<Podcast?> HamtaPodcastAsync(string podcastId)
        {
            var podcast = await repository.GetByIdAsync(podcastId);
            return podcast;
        }
        //UPDATE
        public async Task<string?> UppdateraPodcastAsync(Podcast uppdateradPodcast)
        {
            if (string.IsNullOrWhiteSpace(uppdateradPodcast.Namn))
            {
                return "Podcast måste ha ett namn.";
            }

            var original = await repository.GetByIdAsync(uppdateradPodcast.Id);
            if (original == null)
            {
                return "Podcasten finns inte.";
            }

            await repository.UpdateAsync(uppdateradPodcast);
            return null;
        }
        //DELETE
        public async Task<string?> RaderaPodcastAsync(string podcastId)
        {
            var podcast = await repository.GetByIdAsync(podcastId);
            if (podcast == null)
            {
                return "Podcasten finns inte.";
            }

            await repository.DeleteAsync(podcastId);
            return null;

        }
    }
}
