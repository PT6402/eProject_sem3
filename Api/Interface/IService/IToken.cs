using Api.Service.Token;

namespace Api.Interface.IService
{
    public interface IToken
    {
        public string GenerateAccessToken(int userId, string Role);
        public RefreshToken GenerateRefreshToken(int userId, string Role);
        public CookieOptions SetRefreshToken(RefreshToken refreshToken);
        public string CreateRandomToken();
    }
}
