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
        public int Numb_Connect { get; set; }

        public int? Coupon_Id { get; set; }
        public Coupon? Coupon { get; set; }

        [Required]
        public string TP_contractor_Id { get; set; } = null!;
        public TP_contractor? TP_contractor { get; set; }

        public Order_handler? Order_handler { get; set; }

        [Required]
        public int Duration_callCharges_Id { get; set; }
        public Duration_callCharges? Duration_callCharges { get; set; }

        public Payment? Payment { get; set; }
    }
}
