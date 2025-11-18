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
        public async Task<List<Avsnitt>> HamtaAvsnittFranRssAsync(string url)
        {
            return await Task.Run(() =>
            {
                using (var reader = XmlReader.Create(url))
                {
                    var feed = SyndicationFeed.Load(reader);
                    var lista = new List<Avsnitt>();

                    foreach (var item in feed.Items)
                    {
                        lista.Add(new Avsnitt
                        {
                            Titel = item.Title?.Text,
                            Beskrivning = item.Summary?.Text,
                            PubliceringsDatum = item.PublishDate.UtcDateTime
                        });
                    }

                    return lista;
                }
            });
        }


        public async Task<string?> HamtaPodcastTitelFranRssAsync(string url)
        {
            return await Task.Run(() =>
            {
                using (var reader = XmlReader.Create(url))
                {
                    var feed = SyndicationFeed.Load(reader);
                    return feed.Title?.Text;
                }
            });
        }
    }
}
