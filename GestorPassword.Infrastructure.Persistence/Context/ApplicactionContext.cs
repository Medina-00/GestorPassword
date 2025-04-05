

using GestorPassword.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorPassword.Infrastructure.Persistence.Context
{
    public class ApplicactionContext : DbContext
    {
        public ApplicactionContext(DbContextOptions<ApplicactionContext> options) : base(options)
        {
        }
        public DbSet<PasswordItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PasswordItem>().ToTable(nameof(Items));
            modelBuilder.Entity<PasswordItem>().HasKey(x => x.Id);
        }
    }
}
