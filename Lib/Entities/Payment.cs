using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbPayment")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; } = null!;
        public string Order_Id { get; set; } = null!;
        public string Method_Payment { get; set; } = null!;
        public bool Status { get; set; }
    }
}
