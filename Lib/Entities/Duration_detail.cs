using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbDuration_detail")]
    public class Duration_detail
    {
        [Key]
        public int Id { get; set; }
        public int Duration_Id { get; set; }
        public Duration? Duration { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public string Unit { get; set; } = null!;
        public ICollection<Order>? Orders { get; set; }
    }
}
