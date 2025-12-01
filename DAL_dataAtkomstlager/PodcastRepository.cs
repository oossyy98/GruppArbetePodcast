using MongoDB.Driver;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_dataAtkomstlager
{
    public class PodcastRepository : IRepository<Podcast>
    {
        private readonly IMongoCollection<Podcast> collection;
        private readonly MongoDBService service;

        public PodcastRepository(MongoDBService service)
        {
            this.service = service;
            collection = service.PodcastCollection;
        }

        // CREATE
        public async Task AddAsync(Podcast podcast)
        {
            using var session = service.Client.StartSession();
            session.StartTransaction();

            try
            {
                await collection.InsertOneAsync(session, podcast);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        // READ ALL
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

        // READ ONE
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

        // UPDATE
        public async Task<bool> UpdateAsync(Podcast uppdateradPodcast)
        {
            using var session = service.Client.StartSession();
            session.StartTransaction();

            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.Id, uppdateradPodcast.Id);
                var resultat = await collection.ReplaceOneAsync(session, filter, uppdateradPodcast);

                if (resultat.MatchedCount == 0)
                {
                    await session.AbortTransactionAsync();
                    return false;
                }

                await session.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await session.AbortTransactionAsync();
                return false;
            }
        }

        // DELETE
        public async Task<bool> DeleteAsync(string podcastId)
        {
            using var session = service.Client.StartSession();
            session.StartTransaction();

            try
            {
                var filter = Builders<Podcast>.Filter.Eq(p => p.Id, podcastId);
                var resultat = await collection.DeleteOneAsync(session, filter);

                if (resultat.DeletedCount == 0)
                {
                    await session.AbortTransactionAsync();
                    return false;
                }

                await session.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await session.AbortTransactionAsync();
                return false;
            }
        }
    }
}
