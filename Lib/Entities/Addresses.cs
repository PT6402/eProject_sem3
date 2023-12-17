using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    [Table("tbAddress")]
    public class Addresses
    {
        [Key]
        public int Id { get; set; }
        public string Address_full { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;

        public User? User { get; set; }
        public ICollection<Address_store>? Address_stores { get; set; }
        public ICollection<TP_contractor>? TP_contractors { get; set; }

    }
}
