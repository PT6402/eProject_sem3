using Api.Interface.IService;
using Lib.Entities;
using System.Security.Cryptography;

namespace Api.Service.Password
{
    public class PasswordService : IPassword
    {
        public PasswordResult CreatePassword(string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;
            using (var hash = new HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return new PasswordResult(passwordHash, passwordSalt);
        }
        public bool VerifyPassword(string password, User user)
        {
            using (var hash = new HMACSHA512(user.PasswordSalt))
            {
                var computerHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computerHash.SequenceEqual(user.PasswordHash);
            };

        }
    }
}
