using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbPackage")]
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Connect_type_Id { get; set; }
        public Connect_type? Connect_type { get; set; }
        public ICollection<Duration>? Durations { get; set; }
    }
}
