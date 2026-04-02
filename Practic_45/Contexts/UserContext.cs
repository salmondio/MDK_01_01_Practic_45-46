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
            optionsBuilder.UseMySql("server=10.0.201.112;uid=ISP_23_2_8;pwd=egW19je7D1_;database=base1_ISP_23_2_8;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
