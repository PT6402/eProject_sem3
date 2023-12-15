using Lib.Dto;
using Lib.Dto.User.Repo;
using System.Threading.Tasks;

namespace Api.Interface.IRepo
{
    public interface IUserRepository
    {
        Task<UserDto?> GetByPhone(string phone);
        Task<DtoResult<UserDto>> Create(UserDto model);
        Task<DtoResult<UserDto>> CheckUser(UserDto model);
        Task<bool> UpdateToken(TokenDto model);

    }
}
