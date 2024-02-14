using BankSimApi.Business.Interfaces;
using BankSimApi.Business.Notifications;
using BankSimApi.Business.Services;
using BankSimApi.Data.Context;
using BankSimApi.Data.Repository;

namespace BankSimApi.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<MyDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Business
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
