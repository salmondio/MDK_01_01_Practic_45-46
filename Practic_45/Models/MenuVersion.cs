using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practic_45.Models
{
    [Table("Menu_version")]
    public class MenuVersion
    {
        [Key]
        public int Id { get; set; }
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
    }
}
