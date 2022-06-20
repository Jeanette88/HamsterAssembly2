using HamsterAssembly2.Shared.Models;
using System.Net.Http.Json;

namespace HamsterAssembly2.Client.Services.HamsterService
{
    public class HamsterService : IHamsterService
    {
        private readonly HttpClient _http;

        public HamsterService(HttpClient http)
        {
            _http = http;
        }
        public List<Hamster> Hamsters { get; set; } = new List<Hamster>();

        public async Task AddHamster(Hamster hamster)
        {
            await _http.PostAsJsonAsync("api/hamster", hamster);
        }

        public async Task DeleteHamster(int id)
        {
            await _http.DeleteAsync($"api/hamster/{id}");
        }

        public async Task<Hamster> GetHamster(int id)
        {
            var result = await _http.GetFromJsonAsync<Hamster>($"api/hamster/{id}");
            if (result != null)
                return result;
            throw new Exception("Hamster not found.");
        }

        public async Task GetHamsters()
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>("api/hamster");
            if (result != null)
                Hamsters = result;
        }

        public async Task UpdateHamster(HamsterGame request, int id)
        {
            await _http.PutAsJsonAsync($"api/hamster/{id}", request);

        }
        public async Task GetRandomHamsters(int number)
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>($"api/hamster/random?number={number}");
            if (result != null)
                Hamsters = result;
        }

        public async Task GetOneRandomHamster()
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>($"api/hamster/onerandom");
            if (result != null)
                Hamsters = result;
        }
    }
}
