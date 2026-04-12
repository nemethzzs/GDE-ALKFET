using backend.Models;
using MongoDB.Driver;

namespace backend.Services
{
    public class HotelService
    {
        private readonly MongoService _mongo;

        public HotelService(MongoService mongo)
        {
            _mongo = mongo;
        }

        public async Task<List<Szoba>> GetSzobak()
        {
            return await _mongo.Szobak.Find(_ => true).ToListAsync();
        }

        public async Task<List<Foglalas>> GetFoglalasok()
        {
            return await _mongo.Foglalasok.Find(_ => true).ToListAsync();
        }

        public async Task Foglal(int szobaszam, DateTime datum)
        {
            if (datum.Date < DateTime.Today)
                throw new Exception("A foglalás dátuma nem lehet múltbeli!");

            var szoba = await _mongo.Szobak
                .Find(s => s.Szobaszam == szobaszam)
                .FirstOrDefaultAsync();

            if (szoba == null)
                throw new Exception("A szoba nem létezik!");

            var exists = await _mongo.Foglalasok
                .Find(f => f.Szobaszam == szobaszam && f.Datum.Date == datum.Date)
                .AnyAsync();

            if (exists)
                throw new Exception("A szoba ezen a napon már foglalt!");

            await _mongo.Foglalasok.InsertOneAsync(new Foglalas
            {
                Szobaszam = szobaszam,
                Datum = datum,
                Ar = szoba.Ar
            });
        }

        public async Task Torles(int szobaszam, DateTime datum)
        {
            var result = await _mongo.Foglalasok.DeleteOneAsync(
                f => f.Szobaszam == szobaszam && f.Datum.Date == datum.Date);

            if (result.DeletedCount == 0)
                throw new Exception("Nincs ilyen foglalás!");

            return;
        }
    }
}