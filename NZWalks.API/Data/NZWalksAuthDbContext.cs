using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole> 
            {
                new IdentityRole
                {
                    Id = "657590EE-2ADF-4089-9CDB-1F3D78AD055F",
                    ConcurrencyStamp = "657590EE-2ADF-4089-9CDB-1F3D78AD055F",
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = "3F1D753D-5718-4966-BFDA-6D6CF1096131",
                    ConcurrencyStamp = "3F1D753D-5718-4966-BFDA-6D6CF1096131",
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
