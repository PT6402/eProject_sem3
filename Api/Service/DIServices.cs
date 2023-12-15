using Api.Interface.IService;
using Api.Service.Mail;
using Api.Service.Password;
using Api.Service.SMS;
using Api.Service.TimeProvider;
using Api.Service.Token;
using Microsoft.Extensions.Options;

namespace Api.Service
{
    public static class DIServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IMail, EmailService>();
            services.AddSingleton<ISMS, SMSService>();
            services.AddSingleton<IPassword, PasswordService>();
            services.AddSingleton<IToken, TokenService>();
            services.AddSingleton<IDateTimeProvider, DateTimeService>();
            return services;
        }
    }
}
