using System.ComponentModel.DataAnnotations.Schema;

namespace Practic_45.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
    }
}
