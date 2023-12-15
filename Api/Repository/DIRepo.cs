using Api.Interface.IRepo;
using Api.Interface.IService;
using Api.Service.Mail;
using Api.Service.Password;
using Api.Service.TimeProvider;
using Api.Service.Token;

namespace Api.Repository
{
    public static class DIRepo
    {
        public static IServiceCollection AddRepo(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
