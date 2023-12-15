namespace Api.Service.Token
{
    public class TokenSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string SecretAccessToken { get; set; } = null!;
        public string SecretRefreshToken { get; set; } = null!;
        public int ExpiryMinutesAccessToken { get; set; }
        public int ExpiryDayRefreshToken { get; set; }
    }
}
