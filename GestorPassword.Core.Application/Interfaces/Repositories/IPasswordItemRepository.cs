using GestorPassword.Core.Domain.Entities;

namespace GestorPassword.Core.Application.Repositories
{
    public interface IPasswordItemRepository
    {
        Task<PasswordItem> AddAsync(PasswordItem t);
        Task DeleteAsync(PasswordItem t);
        Task<List<PasswordItem>> GetAllAsync();
        Task<PasswordItem> GetByIdAsync(int id);
        Task UpdateAsync(PasswordItem t, int id);
    }
}