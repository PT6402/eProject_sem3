using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Entities
{
    [Table("tbUser")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public Addresses? Addresses { get; set; }
        public int? Addresses_Id { get; set; }
        //
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string Role { get; set; } = null!;
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }

        public ICollection<Employee>? Employees { get; set; }


        public User()
        {
            Role = "user";
        }
    }
}
