using MongoDB.Driver;
using backend.Models;

namespace backend.Services
{
    public class MongoService
    {
        private readonly IMongoDatabase _db;

        public MongoService()
        {
            var client = new MongoClient("mongodb://mongo:27017");
            _db = client.GetDatabase("HotelDB");
        }

        public IMongoCollection<Szoba> Szobak => _db.GetCollection<Szoba>("Szobak");

        public IMongoCollection<Foglalas> Foglalasok => _db.GetCollection<Foglalas>("Foglalasok");
    }
}