

using GestorPassword.Core.Application.Repositories;
using GestorPassword.Core.Domain.Entities;
using GestorPassword.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace GestorPassword.Infrastructure.Persistence.Repositories
{
    public class PasswordItemRepository : IPasswordItemRepository
    {
        private readonly ApplicactionContext applicactionContext;

        public PasswordItemRepository(ApplicactionContext applicactionContext)
        {
            this.applicactionContext = applicactionContext;
        }

        public virtual async Task<PasswordItem> AddAsync(PasswordItem t)
        {
            t.FechaRegustro = DateTime.UtcNow;
            await applicactionContext.Set<PasswordItem>().AddAsync(t);
            await applicactionContext.SaveChangesAsync();
            return t;
        }

        public virtual async Task UpdateAsync(PasswordItem t, int id)
        {
            var entity = await applicactionContext.Set<PasswordItem>().FindAsync(id);
            applicactionContext.Entry(entity).CurrentValues.SetValues(t!);
            await applicactionContext.SaveChangesAsync();

        }

        public virtual async Task DeleteAsync(PasswordItem t)
        {
            applicactionContext.Set<PasswordItem>().Remove(t);
            await applicactionContext.SaveChangesAsync();
        }

        public virtual async Task<List<PasswordItem>> GetAllAsync()
        {
            return await applicactionContext.Set<PasswordItem>().ToListAsync();
        }

        public virtual async Task<PasswordItem> GetByIdAsync(int id)
        {
            return await applicactionContext.Set<PasswordItem>().FindAsync(id);
        }

    }
}
