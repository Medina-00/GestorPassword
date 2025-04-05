using Microsoft.AspNetCore.Identity;
using GestorPassword.Infrastructure.Identity;
using GestorPassword.Infrastructure.Shared;
using GestorPassword.Infrastructure.Persistence;
using GestorPassword.Core.Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession();
        builder.Services.AddIdentityInfrastructure(builder.Configuration);
        builder.Services.AddSharedInfrastructure(builder.Configuration);
        builder.Services.AddPersistenceInfrastructure(builder.Configuration);
        builder.Services.AddApplicationLayer(builder.Configuration);

        var app = builder.Build();

        //aqui haremos la inteccion de dependencia manual

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSession();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        //(OJO) EN ESTE PARTE SIEMPRE HAY QUE ASEGURARSE QUE PRIMERO SE AUTHENTIQUE Y DESPUES AUTORIZE.
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=User}/{action=Login}/{id?}");

        app.Run();
    }
}