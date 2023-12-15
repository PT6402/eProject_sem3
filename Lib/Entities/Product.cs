using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbProduct")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Seri { get; set; } = null!;
        public int Quantity { get; set; }
        public Connect_type Connect_type_Id { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
        public int Supplier_Id { get; set; }
        public ICollection<Stories>? Stories { get; set; }
    }
}
