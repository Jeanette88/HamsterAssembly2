using HamsterAssembly2.Shared.Models;

namespace HamsterAssembly2.Client.Services.BattleService
{
    public interface IBattleService
    {
        List<JoinModel> Fighters { get; set; }
        Task<int> AddGame();
        Task GetGame(int id);
        Task AddFighterAndGame(HamsterGame request);
        Task BattleWinner(int id);
        Task BattleHistory();
        Task DeleteGame(int id);

    }
}
