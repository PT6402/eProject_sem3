using Microsoft.EntityFrameworkCore;
namespace Api.Data_helper
{
    public static class DIContext
    {
        public static IServiceCollection AddContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DatabaseContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper(typeof(Program).Assembly);
            return services;
        }
    }
}
