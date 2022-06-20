using HamsterAssembly2.Shared.Models;

namespace HamsterAssembly2.Server.Repository.BattleRepository
{
    public interface IBattleRepository
    {
        Task<int> AddGame();
        Task<List<JoinModel>> GetFighters(int id);
        Task<HamsterGame> AddFighterAndGame(HamsterGame request);
        Task<List<JoinModel>> BattleWinner(int id);
        Task<List<JoinModel>> BattleHistory();
        Task<Game> DeleteGame(int id);
    }
}
