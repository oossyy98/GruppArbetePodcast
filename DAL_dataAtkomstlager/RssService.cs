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
        public async Task<List<Avsnitt>> HamtaAvsnittFranRssAsync(string rssUrl)
        {
            try
            {
                using (var reader = XmlReader.Create(rssUrl))
                {
                    var feed = SyndicationFeed.Load(reader);
                    var avsnittLista = new List<Avsnitt>();

                    foreach (var i in feed.Items)
                    {
                        var avsnitt = new Avsnitt
                        {
                            Titel = i.Title.Text,
                            Beskrivning = i.Summary?.Text,
                            PubliceringsDatum = i.PublishDate.UtcDateTime
                        };

                        avsnittLista.Add(avsnitt);
                    }

                    return avsnittLista;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ("Fel vid hämtning av RSS-flöde: " + ex.Message);
                return new List<Avsnitt>();
            }

        }

        public async Task<string?> HamtaPodcastTitelFranRssAsync(string rssUrl)
        {
            try
            {
                using (var reader = XmlReader.Create(rssUrl))
                {
                    var feed = SyndicationFeed.Load(reader);
                    return feed.Title.Text; //returna poddens titel
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning" + ex.Message);
                return null;
            }
        }
    }
}
