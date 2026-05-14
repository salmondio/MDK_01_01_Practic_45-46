using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Practic_45.Models
{
    [Table("Order")]
    public class Order
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// id владельца заказа
        /// </summary>
        public int Id_user { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateOnly Date {  get; set; }
        /// <summary>
        /// Заказанное блюдо
        /// </summary>
        public int Id_dish { get; set; }
        /// <summary>
        /// Кол-во заказанных блюд
        /// </summary>
        public int Count { get; set; }
    }
}
