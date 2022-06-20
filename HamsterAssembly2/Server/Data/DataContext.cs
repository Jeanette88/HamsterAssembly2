using HamsterAssembly2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterAssembly2.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
        }


        public DbSet<Hamster> Hamster { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<HamsterGame> HamsterGame { get; set; }
    }
}
