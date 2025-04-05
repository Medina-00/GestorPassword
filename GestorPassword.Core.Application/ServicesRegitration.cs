

using GestorPassword.Core.Application.Interfaces.Services;
using GestorPassword.Core.Application.Repositories;
using GestorPassword.Core.Application.Services;
using GestorPassword.Core.Applitation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Applitation.Interfaces.Services;
using System.Reflection;

namespace GestorPassword.Core.Application
{
    public static class ServicesRegitration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient<IPasswordItemServices, PasswordItemServices>();
            services.AddTransient<IUserService, UserService>();

            #endregion
        }

    }
}
