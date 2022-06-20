using HamsterAssembly2.Server.Repository.HamsterRepository;
using HamsterAssembly2.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamsterAssembly2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamsterController : ControllerBase
    {
        private readonly IHamsterRepository _hamsterRepo;

        public HamsterController(IHamsterRepository hamsterRepo)
        {
            _hamsterRepo = hamsterRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHamsters()
        {
            var hamsters = await _hamsterRepo.GetHamsters();
            return Ok(hamsters);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneHamster(int id)
        {
            var hamster = await _hamsterRepo.GetHamster(id);
            if (hamster == null)
                return NotFound("No hamster here.");

            return Ok(hamster);
        }

        [HttpPost]
        public async Task<IActionResult> AddHamster(Hamster hamster)
        {
            var hamstero = await _hamsterRepo.AddHamster(hamster);
            return Ok(hamstero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHamster(HamsterGame request, int id)
        {
            var hamster = await _hamsterRepo.UpdateHamster(request, id);
            if (hamster == null)
                return NotFound("No hamster here.");
            return Ok(hamster);
        }
        [HttpPut("hamster/{id}")]
        public async Task<IActionResult> UpdateWholeHamster(Hamster request, int id)
        {
            var hamster = await _hamsterRepo.UpdateWholeHamster(request, id);
            if (hamster == null)
                return NotFound("No hamster here.");
            return Ok(hamster);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHamster(int id)
        {
            var dbHamster = await _hamsterRepo.DeleteHamster(id);

            if (dbHamster == null)
                return NotFound("No hamster here.");

            return Ok(dbHamster);
        }
        [HttpGet("random")]
        public async Task<IActionResult> RandomHamsters(int number)
        {
            var hamsters = await _hamsterRepo.GetRandomHamsters(number);
            return Ok(hamsters);
        }

        [HttpGet("onerandom")]
        public async Task<IActionResult> RandomHamster()
        {
            var hamsters = await _hamsterRepo.GetRandomHamster();
            return Ok(hamsters);
        }

    }
}

