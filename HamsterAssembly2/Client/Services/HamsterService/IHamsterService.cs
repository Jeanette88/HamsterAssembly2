using HamsterAssembly2.Shared.Models;

namespace HamsterAssembly2.Client.Services.HamsterService
{
    public interface IHamsterService
    {
        List<Hamster> Hamsters { get; set; }
        Task GetHamsters();
        Task<Hamster> GetHamster(int id);
        Task AddHamster(Hamster hamster);
        Task UpdateHamster(HamsterGame request, int id);
        Task DeleteHamster(int id);
        Task GetRandomHamsters(int number);
        Task GetOneRandomHamster();
    }
}
