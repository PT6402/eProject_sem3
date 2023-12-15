using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbCoupon")]
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public int Range_Connect { get; set; }
        public float Percent { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
