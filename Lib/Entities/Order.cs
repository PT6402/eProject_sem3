using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbOrders")]
    public class Order
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Tax { get; set; } = null!;
        public float Total_Price { get; set; }

        public TP_contractor? TP_contractor { get; set; }
        public string TP_contractor_Id { get; set; } = null!;
        public Coupon? Coupon { get; set; }
        public int Coupon_Id { get; set; }
        public Duration_detail? Duration_detail { get; set; }
        public int Duration_detail_Id { get; set; }
        public Duration? Duration { get; set; }
        public int Duration_Id { get; set; }

        public ICollection<Payment>? Payments { get; set; }
    }
}
