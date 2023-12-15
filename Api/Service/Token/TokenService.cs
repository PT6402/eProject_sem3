using Api.Interface.IService;
using Api.Service.TimeProvider;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Api.Service.Token
{
    public class TokenService : IToken
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> option_Settings, IDateTimeProvider dateTimeProvider)
        {
            _tokenSettings = option_Settings.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateAccessToken(int userId, string Role)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretAccessToken)), SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new()
            {
            new Claim(JwtRegisteredClaimNames.NameId,userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Typ,Role),
            new Claim(ClaimTypes.Sid,userId.ToString()),
            new Claim(ClaimTypes.Role,Role)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_tokenSettings.ExpiryMinutesAccessToken)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public RefreshToken GenerateRefreshToken(int userId, string Role)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretRefreshToken)), SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new()
            {
            new Claim(JwtRegisteredClaimNames.NameId,userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Typ,Role),
            new Claim(ClaimTypes.Sid,userId.ToString()),
            new Claim(ClaimTypes.Role,Role)
            };
            var expires = _dateTimeProvider.UtcNow.AddDays(_tokenSettings.ExpiryDayRefreshToken);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: expires
                );
            string stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new RefreshToken
            (
              stringToken,
                _dateTimeProvider.UtcNow,
                expires
            );
        }
        public CookieOptions SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };
            return cookieOptions;

        }
        public string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
