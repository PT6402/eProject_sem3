using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    [Table("tbDuration_callCharges")]
    public class Duration_callCharges
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Duration? Duration { get; set; }
        public int Duration_Id { get; set; }

        public Call_charges? Call_charges { get; set; }
        public int? Call_charges_Id { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
