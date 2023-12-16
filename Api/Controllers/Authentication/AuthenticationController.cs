using Api.Interface.IRepo;
using Api.Interface.IService;
using Api.Repository;
using AutoMapper;
using Lib.Dto.User.Ctrl.Req;
using Lib.Dto.User.Ctrl.Res;
using Lib.Dto.User.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Api.Controllers.Authentication
{

    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        private readonly IToken _token;
        private readonly IHttpContextAccessor _accessor;
        public AuthenticationController(
            IUserRepository user,
            IMapper mapper,
            IToken token,
            IHttpContextAccessor accessor)
        {
            _user = user;
            _mapper = mapper;
            _token = token;
            _accessor = accessor;
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

        [HttpPost]
        [Route("send-reset-pass")]
        public async Task<ActionResult> SendResetPass(UserReqResetPass request)
        {
            if (request.MethodReset is not null)
            {

                if (request.MethodReset == 0)
                {
                    var user = await _user.GetByEmail(request.Input);
                    if (user is null)
                    {
                        return BadRequest("user is not found");
                    }
                    var check = await _user.SendMailResetPassword(request.Input, user.Id);
                    if (!check)
                    {
                        return BadRequest("send mail fail");
                    }
                    return Ok("send mail success");
                }
                else
                {
                    var user = await _user.GetByPhone(request.Input);
                    if (user is null)
                    {
                        return BadRequest("user is not found");
                    }
                    var formatPhone = string.Concat("+84", request.Input.AsSpan(1));
                    var check = await _user.SendSMSResetPassword(formatPhone, user.Id);
                    if (!check.Status)
                    {
                        return BadRequest("send sms fail");
                    }
                    return Ok("send sms success");
                }


            }
            return BadRequest("reset pass fail");
        }

        [HttpPost]
        [Route("reset-pass")]
        public async Task<ActionResult> ResetPass(UserResetPass request)
        {
            if (request.MethodReset is not null)
            {
                UserDto? user;
                if (request.MethodReset == 0)
                {
                    user = await _user.GetByEmail(request.Input);
                }
                else
                {
                    user = await _user.GetByPhone(request.Input);
                }
                if (user is null)
                {
                    return BadRequest("user is not found");
                }
                var check = await _user.ResetPassword(user.Id, request.Password, request.Code);
                if (!check.Status)
                {
                    return BadRequest(check.Message);
                }
                return Ok();

            }
            return BadRequest("reset fail");
        }

        [HttpGet]
        [Route("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            if (_accessor.HttpContext != null)
            {
                var userId = int.Parse( _accessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));

                var user = await _user.GetById(userId)!;
                if (user is null) {
                    return BadRequest("user not found");
                }
                TokenDto updateToken = new() {
                    RefreshToken = string.Empty,
                    TokenCreated = null,
                    TokenExpires = null,
                    UserId = user.Id
                };
                await _user.UpdateToken(updateToken);
                HttpContext.Response.Cookies.Delete("refreshToken");
                return Ok("logout successfully!");
            }
            return BadRequest("logout fail");
        }


        [HttpPost]
        [Route("verify-phone/{phone}")]
        public async Task<ActionResult> VerifyPhone(string phone) {
            var formatPhone = string.Concat("+84", phone.AsSpan(1));
            var result = await _user.VerifyPhone(formatPhone);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }
            else {
                return Ok(result.Message);
            }
        }
    }
}
