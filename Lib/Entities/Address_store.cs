using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbAddress_store")]
    public class Address_store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Region_name { get; set; } = null!;
        [Required]
        public string Region_code { get; set; } = null!;

        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Order_handler>? Order_handlers { get; set; }
    }
}
