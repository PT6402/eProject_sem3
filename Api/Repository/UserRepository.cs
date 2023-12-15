using Api.Data_helper;
using Api.Interface.IRepo;
using Api.Interface.IService;
using AutoMapper;
using Lib.Dto;
using Lib.Dto.User.Repo;
using Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;
        private readonly IMail _mail;
        private readonly IMapper _mapper;
        private readonly IPassword _password;

        public UserRepository(DatabaseContext db, IMail mail, IMapper mapper, IPassword password)
        {
            _db = db;
            _mail = mail;
            _mapper = mapper;
            _password = password;
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
    }
}
