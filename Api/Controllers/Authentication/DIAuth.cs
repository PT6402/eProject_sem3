using Api.Service.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Controllers.Authentication
{
    public static class DIAuth
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var tokenSettings = new TokenSettings();
            configuration.Bind(TokenSettings.SectionName, tokenSettings);
            services.AddSingleton(Options.Create(tokenSettings));
            services.Configure<TokenSettings>(configuration.GetSection(TokenSettings.SectionName));

           
           


            // [AUTHENTICATION]
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                     .AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = tokenSettings.Issuer,
                         ValidAudience = tokenSettings.Audience,
                         IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(tokenSettings.SecretAccessToken))
                     });


            // [AUTHORIZATION]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Typ", "admin"));
                options.AddPolicy("Emp_Sale", policy => policy.RequireClaim("Typ", "e_sale"));
                options.AddPolicy("Emp_Tech", policy => policy.RequireClaim("Typ", "e_tech"));
                options.AddPolicy("Emp_Account", policy => policy.RequireClaim("Typ", "e_acc"));
                options.AddPolicy("User", policy => policy.RequireClaim("Typ", "user"));
            });


           

            return services;
        }
    }
}
