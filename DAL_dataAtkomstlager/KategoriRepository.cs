using MongoDB.Driver;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_dataAtkomstlager
{
    public class KategoriRepository : IRepository<Kategori>
    {
        private readonly IMongoCollection<Kategori> collection; //kolla vad denna gör

        public KategoriRepository(MongoDBService service)
        {
            collection = service.KategoriCollection;
        }
        //CREATE
        public async Task AddAsync(Kategori kategori)
        {
            try
            {
                await collection.InsertOneAsync(kategori);
            }
            catch
            {
            }
        }
        //READ ALLA
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
        //READ EN
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
        //UPDATE
        public async Task<bool> UpdateAsync(Kategori uppdateradKategori)
        {
            try
            {
                var filter = Builders<Kategori>.Filter.Eq(k => k.Id, uppdateradKategori.Id);
                var resultat = await collection.ReplaceOneAsync(filter, uppdateradKategori);
                return resultat.ModifiedCount > 0;
            }
            catch
            {
                return false;
            }
        }
        //DELETE
        public async Task<bool> DeleteAsync(string kategoriId)
        {
            try
            {
                var filter = Builders<Kategori>.Filter.Eq(k => k.Id, kategoriId);
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
