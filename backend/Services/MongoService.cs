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

        public async Task SeedSzobak()
        {
            var count = await Szobak.CountDocumentsAsync(_ => true);

            if (count == 0)
            {
                var szobak = new List<Szoba>();

                for (int i = 1; i <= 50; i++)
                {
                    szobak.Add(new Szoba
                    {
                        Szobaszam = i,
                        Ar = 10000 + (i * 500)
                    });
                }

                await Szobak.InsertManyAsync(szobak);
            }
        }
    }
}