using Microsoft.EntityFrameworkCore;

namespace Practic_45.Contexts
{
    /// <summary> 
    /// Контекст лдя задачек
    /// </summary>
    public class TaskContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Models.Task> Tasks { get; set; }
        public TaskContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        /// <summary>
        /// переопределил метод конфигурации
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=10.0.201.112;uid=ISP_23_2_8;pwd=egW19je7D1_;database=base1_ISP_23_2_8;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
