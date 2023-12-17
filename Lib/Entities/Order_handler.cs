using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entities
{
    public class Order_handler
    {
        public int Id { get; set; }

        [Required]
        public int Address_store_Id { get; set; }
        public Address_store? Address_store { get; set; }

        [Required]
        public string Order_Id { get; set; } = null!;
        public Order? Order { get; set; }

        public int? Employee_Id { get; }
        public Employee? Employee { get; set; }

        public bool StatusHandle { get; set; }
    }
}
