using MongoDB.Driver;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_dataAtkomstlager
{
    public class PodcastRepository : IRepository<Podcast>
    {
        private readonly IMongoCollection<Podcast> collection; // kolla vad denna gör

        public PodcastRepository(MongoDBService service)
        {
            collection = service.PodcastCollection;
        }

        //CREATE
        public async Task AddAsync(Podcast podcast)
        {
            try
            {
                await collection.InsertOneAsync(podcast);
            }
            catch
            {
            }
        }
        //READ ALLA
        public async Task<List<Podcast>> GetAllAsync()
        {
            try
            {
                var filter = Builders<Podcast>.Filter.Empty;
                return await collection.Find(filter).ToListAsync();
            }
            catch
            {
                return new List<Podcast>();
            }
        }
        //READ EN
        public async Task<Podcast?> GetByIdAsync(string podcastId)
        {
            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.Id, podcastId);
                return await collection.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }
        //UPDATE
        public async Task<bool> UpdateAsync(Podcast uppdateradPodcast)
        {
            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.Id, uppdateradPodcast.Id);
                var resultat = await collection.ReplaceOneAsync(filter, uppdateradPodcast);
                if (resultat.MatchedCount == 0) return false;
                if (resultat.ModifiedCount == 0) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        //DELETE
        public async Task<bool> DeleteAsync(string podcastId)
        {
            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.Id, podcastId);
                var resultat = await collection.DeleteOneAsync(filter);
                if (resultat.DeletedCount == 0) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
