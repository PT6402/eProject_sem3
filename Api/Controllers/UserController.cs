using Api.Interface.IRepo;
using Api.Repository;
using Lib.Dto.User.Ctrl.Req;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly IHttpContextAccessor _accessor;

        public UserController(IUserRepository user, IHttpContextAccessor accessor)
        {
            _user = user;
            _accessor = accessor;
        }
        /*  [Route("update-profile")]
          [HttpPost]
          [Authorize]
          public async Task<ActionResult> UpdateUser(UserEditProfile request)
          {
              if (_accessor.HttpContext is not null)
              {
                  var findUserId = int.Parse(_accessor.HttpContext!.User.FindFirstValue(ClaimTypes.Sid));
                  var user = await _user.GetById(findUserId);
                  if (user is not null)
                  {
                      user.FirstName = request.FirstName;
                      user.LastName = request.LastName;
                      user.Phone = request.Phone;
                      await _userRepository.SaveUser();
                      return Ok(new UpdateResponse(user.FirstName, user.LastName, user.Phone));
                  }

              }
              return BadRequest("user not found");
          }*/

    }
}
