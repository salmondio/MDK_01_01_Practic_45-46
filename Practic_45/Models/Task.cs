using System.ComponentModel.DataAnnotations.Schema;

namespace Practic_45.Models
{
    [Table("Task")]
    /// <summary>
    /// Задачи
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Код
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// Дата и время задачи
        /// </summary>
        public DateTime DateExecute { get; set; }
        /// <summary>
        /// Комментарий к задаче
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Выполнена ли задача
        /// </summary>
        public bool Done { get; set; }
    }
}
