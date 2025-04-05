
using GestorPassword.Core.Application.Interfaces.Services;
using GestorPassword.Core.Domain.Settings;
using GestorPassword.Infrastructure.Shared.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorPassword.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //ESTO ES PARA LLENAR LA PROPIEDADES DE LOS SETTINGS DE DOMAIN
            services.Configure<MainSetting>(configuration.GetSection("MainSetting"));

            //AQUI HAGO LA INYECCIOON DE DEPENDENCIA
            services.AddTransient<IEmailService, EmailService>();
        }

    }
}
