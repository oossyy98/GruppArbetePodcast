using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Podcast
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Namn { get; set; }
        public string Url { get; set; } 
        public string? KategoriId { get; set; } 
        public List<Avsnitt> Avsnitt { get; set; }

        public Podcast()
        {
            Avsnitt = new List<Avsnitt>();
        }

    }
}
