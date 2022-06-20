using HamsterAssembly2.Server.Data;
using HamsterAssembly2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterAssembly2.Server.Repository.BattleRepository;

public class BattleRepository : IBattleRepository
{
    private readonly DataContext _context;

    public BattleRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<int> AddGame()
    {
        var game = new Game
        {
            TimeStamp = DateTime.Now
        };

        _context.Game.Add(game);
        await _context.SaveChangesAsync();

        return game.Id;

    }

    public async Task<HamsterGame> AddFighterAndGame(HamsterGame request)
    {
        var fighterAndGame = new HamsterGame
        {
            HamsterId = request.HamsterId,
            GameId = request.GameId,
            WinStatus = request.WinStatus
        };

        _context.HamsterGame.Add(fighterAndGame);
        await _context.SaveChangesAsync();

        return fighterAndGame;
    }




    public async Task<List<JoinModel>> GetFighters(int id)
    {
        var fighters = await (from h in _context.Hamster
                              join hg in _context.HamsterGame on h.Id equals hg.HamsterId
                              join g in _context.Game on hg.GameId equals g.Id
                              where g.Id == id
                              select new JoinModel
                              {
                                  GameId = g.Id,
                                  HamsterName = h.Name,
                                  Wins = h.Wins,
                                  Losses = h.Losses,
                                  Games = h.Games,
                                  HamsterId = h.Id,
                                  ImgName = h.ImgName,
                                  WinStatus = hg.WinStatus,
                                  TimeStamp = g.TimeStamp

                              }).ToListAsync();


        return fighters;

    }
    
    public async Task<List<JoinModel>> BattleWinner(int id)
    {

        var games = (from hh in _context.Hamster
                     join hgg in _context.HamsterGame on hh.Id equals hgg.HamsterId
                     join gg in _context.Game on hgg.GameId equals gg.Id
                     where hgg.HamsterId == id && hgg.WinStatus == "Winner"
                     select gg.Id);

        var hamsters = await (from g in _context.Game
                              join hg in _context.HamsterGame on g.Id equals hg.GameId
                              join h in _context.Hamster on hg.HamsterId equals h.Id

                              where games.Contains(g.Id) && hg.WinStatus == "Loser"
                              select new JoinModel
                              {
                                  GameId = g.Id,
                                  HamsterName = h.Name,
                                  Wins = h.Wins,
                                  Losses = h.Losses,
                                  Games = h.Games,
                                  HamsterId = h.Id,
                                  ImgName = h.ImgName,
                                  WinStatus = hg.WinStatus,
                                  TimeStamp = g.TimeStamp


                              }).OrderByDescending(g => g.GameId).ToListAsync();

        return hamsters;

    }

    public async Task<List<JoinModel>> BattleHistory()
    {

        var games = await (from h in _context.Hamster

                           join hg in _context.HamsterGame on h.Id equals hg.HamsterId
                           join g in _context.Game on hg.GameId equals g.Id

                           select new JoinModel
                           {
                               GameId = g.Id,
                               HamsterName = h.Name,
                               Wins = h.Wins,
                               Losses = h.Losses,
                               Games = h.Games,
                               HamsterId = h.Id,
                               ImgName = h.ImgName,
                               WinStatus = hg.WinStatus,
                               TimeStamp = g.TimeStamp


                           }).OrderByDescending(g => g.GameId).ToListAsync();

        return games;

    }

    public async Task<Game> DeleteGame(int id)
    {
        var dbGame = await _context.Game.FindAsync(id);

        if (dbGame != null)
        {
            _context.Game.Remove(dbGame);
            await _context.SaveChangesAsync();
        }

        return dbGame;

    }

}

