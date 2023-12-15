using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbEmployee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int Employee_type_Id { get; set; }
        public int Address_store_Id { get; set; }
        public User? User { get; set; }
        public Employee_type? Employee_type { get; set; }
        public Address_store? Address_store { get; set; }
    }
}
