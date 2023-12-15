using Api.Interface.IRepo;
using Api.Interface.IService;
using AutoMapper;
using Lib.Dto.User.Ctrl.Req;
using Lib.Dto.User.Ctrl.Res;
using Lib.Dto.User.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Authentication
{

    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        private readonly IToken _token;
        public AuthenticationController(IUserRepository user, IMapper mapper, IToken token)
        {
            _user = user;
            _mapper = mapper;
            _token = token;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<ActionResult> SignUp(UserSignUp request)
        {

            var check = await _user.Create(_mapper.Map<UserDto>(request));
            if (!check.Status)
            {
                return BadRequest(check.Message);
            }

            return Ok(check.Model!.Phone);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserLogin request)
        {
            var check = await _user.CheckUser(_mapper.Map<UserDto>(request));
            if (!check.Status)
            {
                return BadRequest(check.Message);
            }

            string token = _token.GenerateAccessToken(check.Model!.Id, check.Model.Role!);
            var refreshToken = _token.GenerateRefreshToken(check.Model!.Id, check.Model.Role!);
            var optionCookie = _token.SetRefreshToken(refreshToken);
            Response.Cookies.Append("refreshToken", refreshToken.Token, optionCookie);
            TokenDto setToken = new()
            {
                UserId = check.Model.Id,
                TokenCreated = refreshToken.Created,
                TokenExpires = refreshToken.Expires,
                RefreshToken = refreshToken.Token
            };
            var checkUpdate = await _user.UpdateToken(setToken);
            if (!checkUpdate)
            {
                return BadRequest("update fail");
            }

            var userRes = _mapper.Map<UserRes>(check.Model);
            userRes.Token = token;

            return Ok(userRes);
        }


    }
}
