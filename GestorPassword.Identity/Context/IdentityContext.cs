

using GestorPassword.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestorPassword.Infrastructure.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplitationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //ESTO ES PARA DECIRLE A UAL ESQUEMA PERTENECERAN LAS TABLAS 
            builder.HasDefaultSchema("Identity");

            //AQUI CAMBIO LOS NOMBRES DE LAS TABLAS QUE SERAN GENERADAS

            builder.Entity<ApplitationUser>(e =>
            {
                e.ToTable(name: "Users");
            });



            builder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable(name: "UsersLogin");
            });
        }
    }
}
