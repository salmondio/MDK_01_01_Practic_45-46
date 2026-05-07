using System.ComponentModel.DataAnnotations.Schema;

namespace Practic_45.Models
{
    [Table("Categories")]
    public class Categori
    {
        int id { get; set; }
        string name { get; set; }
    }
}
