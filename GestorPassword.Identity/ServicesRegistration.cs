﻿
using GestorPassword.Core.Application.Interfaces.Services;
using GestorPassword.Infrastructure.Identity.Context;
using GestorPassword.Infrastructure.Identity.Entities;
using GestorPassword.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GestorPassword.Infrastructure.Identity
{
    public static class ServicesRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            services.AddDbContext<IdentityContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                     m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

            #endregion

            services.AddIdentity<ApplitationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            //ESTO ES PARA CUANDO NO TENGA ACCESO A ALGO INTENTADO ENTRAR POR LA URL , TE MANDE AL LOGIN
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";
            });

            #region Identity


            services.AddAuthentication();
            #endregion

            services.AddTransient<IAccountServices, AccountServices>();
        }

    }
}
