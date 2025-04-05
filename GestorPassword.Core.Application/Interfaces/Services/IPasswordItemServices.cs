

using GestorPassword.Core.Application.ViewModel.PasswordItem;

namespace GestorPassword.Core.Application.Interfaces.Services
{
    public interface IPasswordItemServices

    {
        Task Update(SavePasswordItemViewModel vm, int id);

        Task<SavePasswordItemViewModel> Add(SavePasswordItemViewModel vm);

        Task Delete(int id);

        Task<SavePasswordItemViewModel> GetByIdSaveViewModel(int id);

        Task<List<PasswordItemViewModel>> GetAllViewModel();

    }
}
