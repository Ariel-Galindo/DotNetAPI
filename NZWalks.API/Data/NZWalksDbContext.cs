using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>() 
            {
                new Difficulty()
                {
                    Id = Guid.Parse("3FA352BE-D05F-49B2-8869-9C348457B68A"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("6870D922-614C-4E2E-8813-BD3EEBE22A55"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("372F2D6E-4AAE-4A1B-9D16-7923849AA30A"),
                    Name = "Hard"
                },
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("606dbfb1-78f2-4690-92d1-0f10e7b3e4b9"),
                    Name = "Boone Municipal Airport",
                    Code = "US-IA",
                    RegionImageUrl = "http://dummyimage.com/177x100.png/ff4444/ffffff"
                },
                new Region()
                {
                    Id = Guid.Parse("60a48162-1e5d-482d-8eea-53e31463245e"),
                    Name = "Moody Air Force Base",
                    Code = "US-GA",
                    RegionImageUrl = "http://dummyimage.com/175x100.png/cc0000/ffffff"
                },
                new Region()
                {
                    Id = Guid.Parse("59639d86-3f65-4732-9d75-8d84a22e9e3f"),
                    Name = "Red Dog Airport",
                    Code = "US-AK",
                    RegionImageUrl = "http://dummyimage.com/122x100.png/dddddd/000000"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
