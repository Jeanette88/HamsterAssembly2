using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterAssembly2.Shared.Models
{
    public class HamsterGame
    {
        public int Id { get; set; }
        public int HamsterId { get; set; }
        public Hamster? Hamster { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
        public string? WinStatus { get; set; }
    }
}
