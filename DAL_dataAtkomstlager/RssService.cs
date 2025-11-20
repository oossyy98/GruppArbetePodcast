using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL_dataAtkomstlager
{
    public class RssService
    {
        private readonly HttpClient enHttpClient;

        public RssService(HttpClient enHttpClient)
        {
            this.enHttpClient = enHttpClient;
        }
        public async Task<List<Avsnitt>> HamtaAvsnittFranRssAsync(string url)
        {
            using Stream dataStrom = await this.enHttpClient.GetStreamAsync(url);
            using XmlReader minXMLlasare = XmlReader.Create(dataStrom);
            SyndicationFeed dataFlode = SyndicationFeed.Load(minXMLlasare);

            List<Avsnitt> lista = new List<Avsnitt>();

            foreach (SyndicationItem item in dataFlode.Items)
            {
                Avsnitt ettAvsnitt = new Avsnitt();
                ettAvsnitt.Titel = item.Title?.Text;
                ettAvsnitt.Beskrivning = item.Summary?.Text;
                ettAvsnitt.PubliceringsDatum = item.PublishDate.DateTime;

                lista.Add(ettAvsnitt);
            }

            return lista;
        }


        public async Task<string?> HamtaPodcastTitelFranRssAsync(string url)
        {
            using Stream dataStrom = await this.enHttpClient.GetStreamAsync(url);
            using XmlReader minXMLlasare = XmlReader.Create(dataStrom);
            SyndicationFeed dataFlode = SyndicationFeed.Load(minXMLlasare);

            return dataFlode.Title?.Text;
        }
    }

}