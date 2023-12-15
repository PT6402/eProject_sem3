using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dto.User.Ctrl.Req
{
    public class UserResetPass
    {
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public int? MethodReset { get; set; }
        [Required]
        public string Input { get; set; } = null!;
    }
}
