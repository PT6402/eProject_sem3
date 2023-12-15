using Api.Interface.IRepo;
using Api.Interface.IService;
using AutoMapper;
using Lib.Dto.User.Ctrl.Req;
using Lib.Dto.User.Ctrl.Res;
using Lib.Dto.User.Repo;
using Microsoft.AspNetCore.Mvc;
using System;

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
                    if (!check)
                    {
                        return BadRequest("send sms fail");
                    }
                    return Ok("send sms success");
                }


            }
            return BadRequest("reset pass fail");
        }

        [HttpPost]
        [Route("change-pass")]
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
    }
}
