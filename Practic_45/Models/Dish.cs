using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practic_45.Models
{
    [Table("DISHES")]
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
