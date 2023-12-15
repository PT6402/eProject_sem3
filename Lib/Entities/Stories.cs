using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{

    [Table("tbStories")]
    public class Stories
    {
        [Key]
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; } = null!;
    }
}
