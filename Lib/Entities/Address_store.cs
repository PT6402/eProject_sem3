using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbAddress_store")]
    public class Address_store
    {
        [Key]
        public int Id { get; set; }
        public Addresses? Addresses { get; set; }
        public int? Addresses_Id { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
