using HamsterAssembly2.Server.Data;
using HamsterAssembly2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterAssembly2.Server.Repository.HamsterRepository
{
    public class HamsterRepository : IHamsterRepository
    {
        private readonly DataContext _context;
        public HamsterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Hamster>> GetHamsters()
        {
            var hamsters = await _context.Hamster.ToListAsync();
            return hamsters;
        }

        public async Task<Hamster> GetHamster(int id)
        {
            var hamster = await _context.Hamster.FirstOrDefaultAsync(h => h.Id == id);

            return hamster;
        }

        public async Task<Hamster> AddHamster(Hamster hamster)
        {
            _context.Hamster.Add(hamster);
            await _context.SaveChangesAsync();
            return hamster;

        }

        public async Task<Hamster> UpdateHamster(HamsterGame request, int id)
        {
            var dbHamster = await GetHamster(id);

            if (request.WinStatus == "Winner")
            {
                dbHamster.Wins++;
            }
            else
            {
                dbHamster.Losses++;
            }
            dbHamster.Games++;

            await _context.SaveChangesAsync();

            return dbHamster;

        }

        public async Task<Hamster> UpdateWholeHamster(Hamster request, int id)
        {
            var dbHamster = await GetHamster(id);

            if (dbHamster != null)
            {
                dbHamster.Id = request.Id;
                dbHamster.Name = request.Name;
                dbHamster.Age = request.Age;
                dbHamster.FavFood = request.FavFood;
                dbHamster.Loves = request.Loves;
                dbHamster.ImgName = request.ImgName;
                dbHamster.Wins = request.Wins;
                dbHamster.Losses = request.Losses;
                dbHamster.Games = request.Games;
            }

            await _context.SaveChangesAsync();

            return dbHamster;

        }
        public async Task<Hamster> DeleteHamster(int id)
        {
            var games = await (from h in _context.Hamster
                               join hg in _context.HamsterGame on h.Id equals hg.HamsterId
                               join g in _context.Game on hg.GameId equals g.Id
                               where h.Id == id
                               select new
                               {
                                   game = g

                               }).ToListAsync();


            foreach (var game in games)
            {
                _context.Game.Remove(game.game);
            }

            var dbHamster = await GetHamster(id);

            if (dbHamster != null)
            {
                string dbPath = dbHamster.ImgName;
                string path = $"wwwroot{dbPath}";

                _context.Hamster.Remove(dbHamster);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            await _context.SaveChangesAsync();
            return dbHamster;
        }

        public async Task<List<Hamster>> GetRandomHamsters(int number)
        {
            var hamsters = await _context.Hamster.OrderBy(h => Guid.NewGuid()).Take(number).ToListAsync();
            return hamsters;
        }


        // Just one random hamster
        public async Task<Hamster> GetRandomHamster()
        {
            var hamsters = await GetHamsters();

            Random rand = new Random();
            var hamster = new Hamster();

            for (int i = 0; i < hamsters.Count; i++)
            {
                int number = rand.Next(0, hamsters.Count);
                hamster = hamsters[number];
            }

            return hamster;
        }
    }
}

