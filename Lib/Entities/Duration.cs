using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbDuration")]
    public class Duration
    {
        [Key]
        public int Id { get; set; }
        public int Package_Id { get; set; }
        public Package? Package { get; set; }
        public DateTime Time { get; set; }
        public float Price { get; set; }
        public ICollection<Duration_detail>? Duration_details { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
