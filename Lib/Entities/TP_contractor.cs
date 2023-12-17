using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbTP_contractor")]
    public class TP_contractor
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        public int User_Id { get; set; }
        public User? User { get; set; }

        [Required]
        public int Addresses_Id { get; set; }
        public Addresses? Addresses { get; set; }

        public Order? Order { get; set; }
    }
}
