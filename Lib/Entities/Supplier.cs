using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbSupplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Detail_contact { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

