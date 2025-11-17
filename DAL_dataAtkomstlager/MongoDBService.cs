using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_dataAtkomstlager
{
    public class MongoDBService
    {
        private readonly IMongoDatabase databas;

        public MongoDBService()
        {
            var klient = new MongoClient("mongodb+srv://OruMongoDBAdmin:OruPassword@orumongodb.nzapwps.mongodb.net/?appName=OruMongoDB");
            databas = klient.GetDatabase("OruMongoDB");
        }

        public IMongoCollection<Podcast> PodcastCollection =>
    databas.GetCollection<Podcast>("Podcasts");

        public IMongoCollection<Kategori> KategoriCollection =>
            databas.GetCollection<Kategori>("Kategorier");

    }
}
