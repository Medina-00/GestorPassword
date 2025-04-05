
using GestorPassword.Core.Application.Repositories;
using GestorPassword.Infrastructure.Persistence.Context;
using GestorPassword.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorPassword.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts

            services.AddDbContext<ApplicactionContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            m => m.MigrationsAssembly(typeof(ApplicactionContext).Assembly.FullName)));

            #endregion

            #region Repositories
           
            services.AddTransient<IPasswordItemRepository, PasswordItemRepository>();


            #endregion

        }

    }
}
