using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Dto.User.Ctrl.Req
{
    public class UserReqResetPass
    {
        public int? MethodReset { get; set; }
        public string Input { get; set; } = null!;

    }
}
