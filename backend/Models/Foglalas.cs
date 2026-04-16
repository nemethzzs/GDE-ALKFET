using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Foglalas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Szobaszam { get; set; }

        public string VendegNev { get; set; } = "";

        public DateTime Datum { get; set; }

        public int Ar { get; set; }
    }
}