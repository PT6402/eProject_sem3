

using AutoMapper;
using Lib.Dto.User.Ctrl.Req;
using Lib.Dto.User.Ctrl.Res;
using Lib.Dto.User.Repo;
using Lib.Entities;

namespace Lib.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserSignUp, UserDto>();
            CreateMap<UserLogin, UserDto>();
            CreateMap<UserDto, UserRes>();
        }
    }
}
