using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbAddress_store")]
    public class Address_store
    {
        [Key]
        public int Id { get; set; }
        public string Address_full { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public ICollection<Employee>? Employees { get; set; }
    }
}
