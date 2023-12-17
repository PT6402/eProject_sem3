using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbConnect_type")]
    public class Connect_type
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string First_Letter { get; set; } = null!;

        public string? Description { get; set; }

        public float Security_Deposit { get; set; }
        public ICollection<Package>? Packages { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
