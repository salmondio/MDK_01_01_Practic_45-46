using Microsoft.EntityFrameworkCore;
using Practic_45.Models;

namespace Practic_45.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public UserContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.0.201.112;Trusted_Connection=False;Database=base1_ISP_23_2_8;User=ISP_23_2_8;Pwd=egW19je7D1_;");
        }
    }
}
