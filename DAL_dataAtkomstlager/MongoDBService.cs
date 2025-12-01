using Models;
using MongoDB.Driver;

namespace DAL_dataAtkomstlager
{
    public class MongoDBService
    {
        private readonly IMongoDatabase databas;
        private readonly MongoClient klient;

        public MongoDBService()
        {
            klient = new MongoClient("mongodb+srv://OruMongoDBAdmin:OruPassword@orumongodb.nzapwps.mongodb.net/?appName=OruMongoDB");
            databas = klient.GetDatabase("OruMongoDB");
        }

        
        public MongoClient Client => klient;

        public IMongoCollection<Podcast> PodcastCollection =>
            databas.GetCollection<Podcast>("Podcasts");

        public IMongoCollection<Kategori> KategoriCollection =>
            databas.GetCollection<Kategori>("Kategorier");
    }
}
