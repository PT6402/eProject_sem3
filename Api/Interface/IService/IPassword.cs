using Api.Service.Password;
using Lib.Entities;

namespace Api.Interface.IService
{
    public interface IPassword
    {
        public PasswordResult CreatePassword(string password);
        public bool VerifyPassword(string password, User user);
    }
}
