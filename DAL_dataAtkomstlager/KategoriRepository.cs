using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_dataAtkomstlager
{
    public class KategoriRepository : IRepository<Kategori>
    {
        private readonly IMongoCollection<Kategori> collection;
        private readonly MongoDBService service;

        public KategoriRepository(MongoDBService service)
        {
            this.service = service;
            collection = service.KategoriCollection;
        }

        // CREATE
        public async Task AddAsync(Kategori kategori)
        {
            using var session = service.Client.StartSession();
            session.StartTransaction();

            try
            {
                await collection.InsertOneAsync(session, kategori);
                await session.CommitTransactionAsync();
            }
            catch
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        // READ ALL
        public async Task<List<Kategori>> GetAllAsync()
        {
            try
            {
                var filter = Builders<Kategori>.Filter.Empty;
                return await collection.Find(filter).ToListAsync();
            }
            catch
            {
                return new List<Kategori>();
            }
        }

        // READ ONE
        public async Task<Kategori?> GetByIdAsync(string kategoriId)
        {
            try
            {
                var filter = Builders<Kategori>.Filter.Eq(k => k.Id, kategoriId);
                return await collection.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }

        // UPDATE
        public async Task<bool> UpdateAsync(Kategori uppdateradKategori)
        {
            using var session = service.Client.StartSession();
            session.StartTransaction();

            try
            {
                var filter = Builders<Kategori>.Filter.Eq(k => k.Id, uppdateradKategori.Id);
                var resultat = await collection.ReplaceOneAsync(session, filter, uppdateradKategori);

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
        public async Task<bool> DeleteAsync(string kategoriId)
        {
            try
            {
                if (!ObjectId.TryParse(kategoriId, out ObjectId oid))
                    return false;

                var filter = Builders<Kategori>.Filter.Eq("_id", oid);

                var resultat = await collection.DeleteOneAsync(filter);

                return resultat.DeletedCount > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
