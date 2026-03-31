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
        public DbSet<Task> Tasks { get; set; }
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
            optionsBuilder.UseMySql("server=;uid=;pwd=;database=;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
