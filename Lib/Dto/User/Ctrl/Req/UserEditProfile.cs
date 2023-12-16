using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dto.User.Ctrl.Req
{
    public class UserEditProfile
    {
        [Required]
        public int? UserId { get; set; }
        [Required]
        public string FullName { get; set; } = null!;


        public int? Id { get; set; }
        public string? Address_full { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
    }
}
