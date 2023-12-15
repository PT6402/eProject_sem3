using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbTP_contractor")]
    public class TP_contractor
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Addresses? Addresses { get; set; }
        public int? Addresses_Id { get; set; }
        public string Phone { get; set; } = null!;
        public ICollection<Order>? Orders { get; set; }
    }
}
