using HamsterAssembly2.Shared.Models;
using System.Net.Http.Json;

namespace HamsterAssembly2.Client.Services.BattleService;

public class BattleService : IBattleService
{
    private readonly HttpClient _http;

    public BattleService(HttpClient http)
    {
        _http = http;
    }
    public List<JoinModel> Fighters { get; set; } = new List<JoinModel>();
    //public List<PercentModel> PercentWin { get; set; } = new List<PercentModel>();
    //public List<PercentModel> PercentLoss { get; set; } = new List<PercentModel>();

    public async Task<int> AddGame()
    {
        var response = await _http.PostAsJsonAsync("api/matches/game", new { });
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public async Task AddFighterAndGame(HamsterGame request)
    {
        await _http.PostAsJsonAsync("api/matches", request);

    }

    public async Task GetGame(int id)
    {
        var result = await _http.GetFromJsonAsync<List<JoinModel>>($"api/matches/{id}");
        if (result != null)
            Fighters = result;
    }

    public async Task BattleWinner(int id)
    {
        var result = await _http.GetFromJsonAsync<List<JoinModel>>($"api/matchwinners/{id}");
        if (result != null)
            Fighters = result;
    }

    public async Task BattleHistory()
    {
        var result = await _http.GetFromJsonAsync<List<JoinModel>>($"api/matches");
        if (result != null)
            Fighters = result;
    }

    public async Task DeleteGame(int id)
    {
        await _http.DeleteAsync($"api/matches/{id}");
    }

}

