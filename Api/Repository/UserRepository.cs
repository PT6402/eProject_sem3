using Api.Data_helper;
using Api.Interface.IRepo;
using Api.Interface.IService;
using Api.Service.Mail;
using Api.Service.SMS;
using AutoMapper;
using Lib.Dto;
using Lib.Dto.User.Repo;
using Lib.Entities;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Api.V2010.Account;

namespace Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;
        private readonly IMail _mail;
        private readonly ISMS _sms;
        private readonly IMapper _mapper;
        private readonly IPassword _password;
        private readonly IDateTimeProvider _time;

        public UserRepository(DatabaseContext db, IMail mail, IMapper mapper, IPassword password, IDateTimeProvider time, ISMS sms)
        {
            _db = db;
            _mail = mail;
            _mapper = mapper;
            _password = password;
            _time = time;
            _sms = sms;
        }

        public async Task<UserDto?> GetByPhone(string phone)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Phone == phone);
                if (user is null)
                {
                    return null!;
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null!;
            }
        }

        public async Task<UserDto?> GetById(int userId)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user is null)
                {
                    return null!;
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null!;
            }
        }

        public async Task<UserDto?> GetByEmail(string email)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
                if (user is null)
                {
                    return null!;
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null!;
            }
        }

        public async Task<DtoResult<UserDto>> Create(UserDto model)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Phone == model.Phone);
                if (user is not null)
                {
                    return new()
                    {
                        Status = false,
                        Message = "Phone is exist"
                    };
                }
                var hash = _password.CreatePassword(model.Password);
                User newUser = new()
                {
                    FullName = model.FullName,
                    Phone = model.Phone,
                    PasswordHash = hash.PasswordHash,
                    PasswordSalt = hash.PasswordSalt
                };
                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();
                return new()
                {
                    Status = true,
                    Message = "Create User successfully!",
                    Model = _mapper.Map<UserDto>(newUser)
                };
            }
            catch (Exception e)
            {
                return new()
                {
                    Status = false,
                    Message = e.Message,
                };
            }
        }

        public async Task<DtoResult<UserDto>> CheckUser(UserDto model)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Phone == model.Phone);
                if (user is null)
                {
                    return new()
                    {
                        Status = false,
                        Message = "User is not found"
                    };
                }

                var checkPass = _password.VerifyPassword(model.Password, user);
                if (!checkPass)
                {
                    return new()
                    {
                        Status = false,
                        Message = "Password Invalid"
                    };
                }

                return new()
                {
                    Status = true,
                    Model = _mapper.Map<UserDto>(user)
                };
            }
            catch (Exception e)
            {
                return new()
                {
                    Status = false,
                    Message = e.Message
                };
            }
        }

        public async Task<bool> UpdateToken(TokenDto model)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
                if (user is null)
                {
                    return false;
                }
                user.RefreshToken = model.RefreshToken;
                user.TokenCreated = model.TokenCreated;
                user.TokenExpires = model.TokenExpires;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendMailResetPassword(string toEmail, int UserId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (user is null)
            {
                return false;
            }

            //
            Random r = new();
            string random_digit = r.Next(0, 1000000).ToString("000000");

            //
            user.PasswordReset = random_digit;
            user.ResetExpires = _time.UtcNow.AddDays(1);
            user.MethodReset = 0;
            await _db.SaveChangesAsync();

            //
            TemplateEmail template = new()
            {
                ProductName = "Nexus",
                UserName = user.FullName,
                CodeReset = random_digit
            };
            string body = template.TemplateEmailReset();
            EmailRequest sendMail = new()
            {
                To = toEmail,
                Subject = "email to reset password",
                Body = body
            };
            return _mail.SendEmail(sendMail);
        }
        public async Task<DtoResult<MessageResource>> SendSMSResetPassword(string toPhone, int UserId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (user is null)
            {
                return new()
                {
                    Status = false,
                    Message = "user not found"
                };
            }

            //
            Random r = new();
            string random_digit = r.Next(0, 1000000).ToString("000000");

            //
            user.PasswordReset = random_digit;
            user.ResetExpires = _time.UtcNow.AddDays(1);
            user.MethodReset = 1;
            await _db.SaveChangesAsync();

            //


            SMSRequest sendSMS = new()
            {
                To = toPhone,
                Body = random_digit
            };

            var result = await _sms.SendSMS(sendSMS);
            return result;
        }

        public async Task<DtoResult<UserDto>> ResetPassword(int UserId, string Password, string Code)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.Id == UserId);
                if (user is null)
                {
                    return new()
                    {
                        Status = false,
                        Message = "User not found",
                    };
                }

                if (user.PasswordReset != Code)
                {
                    return new()
                    {
                        Status = false,
                        Message = "code invalid"
                    };
                }

                if (user.ResetExpires < _time.UtcNow)
                {
                    return new()
                    {
                        Status = false,
                        Message = "code time expired"
                    };
                }

                var hash = _password.CreatePassword(Password);
                //[pass]
                user.PasswordHash = hash.PasswordHash;
                user.PasswordSalt = hash.PasswordSalt;

                //[reset-pass]
                user.ResetExpires = null;
                user.PasswordReset = string.Empty;
                user.MethodReset = null;
                await _db.SaveChangesAsync();
                return new()
                {
                    Status = true,
                    Message = "change password success",
                    Model = _mapper.Map<UserDto>(user)
                };
            }
            catch (Exception e)
            {
                return new()
                {
                    Status = false,
                    Message = e.Message
                };
            }
        }
        public async Task<DtoResult<MessageResource>> VerifyPhone(string Phone)
        {
            try
            {

                Random r = new();
                string random_digit = r.Next(0, 1000000).ToString("000000");

                SMSRequest sendSMS = new()
                {
                    To = Phone,
                    Body = random_digit
                };

                var result = await _sms.SendSMS(sendSMS);
                if (!result.Status)
                {
                    return result;
                }
                else
                {

                    return new()
                    {
                        Status = true,
                        Message = random_digit
                    };
                }

            }
            catch (Exception e)
            {
                return new()
                {
                    Status = false,
                    Message = e.Message
                };
            }
        }

        /* public async Task<DtoResult<UserDto>> Update(UserDto model)
         {
             try
             {
                 var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
             }
             catch (Exception e)
             {

             }
         }*/

    }
}
