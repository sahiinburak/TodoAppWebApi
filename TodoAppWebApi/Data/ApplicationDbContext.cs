using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoAppWebApi.Models;

namespace TodoAppWebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole

                {
                    Name = "Admin",
                    NormalizedName = "ADMİN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },

            };
      
            builder.Entity<IdentityRole>().HasData(roles);  

        
        }
    }
}


