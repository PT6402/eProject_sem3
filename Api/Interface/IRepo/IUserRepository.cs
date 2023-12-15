using Lib.Dto;
using Lib.Dto.User.Repo;
using System.Threading.Tasks;

namespace Api.Interface.IRepo
{
    public interface IUserRepository
    {
        Task<UserDto?> GetByPhone(string phone);
        Task<UserDto?> GetByEmail(string email);
        Task<DtoResult<UserDto>> Create(UserDto model);
        Task<DtoResult<UserDto>> CheckUser(UserDto model);
        Task<bool> UpdateToken(TokenDto model);
        Task<bool> SendMailResetPassword(string toEmail, int UserId);
        Task<bool> SendSMSResetPassword(string toPhone, int UserId);

        Task<DtoResult<UserDto>> ResetPassword(int UserId, string Password, string Code);
    }
}
