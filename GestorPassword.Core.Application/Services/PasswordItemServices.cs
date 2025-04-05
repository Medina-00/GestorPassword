

using AutoMapper;
using GestorPassword.Core.Application.Interfaces.Services;
using GestorPassword.Core.Application.Repositories;
using GestorPassword.Core.Application.ViewModel.PasswordItem;
using GestorPassword.Core.Domain.Entities;

namespace GestorPassword.Core.Application.Services
{
    public class PasswordItemServices : IPasswordItemServices
    {
        private readonly IMapper mapper;
        private readonly IPasswordItemRepository passwordItemRepository;

        public PasswordItemServices(IMapper mapper, IPasswordItemRepository passwordItemRepository)
        {
            this.mapper = mapper;
            this.passwordItemRepository = passwordItemRepository;
        }
        public async Task<SavePasswordItemViewModel> Add(SavePasswordItemViewModel vm)
        {
            PasswordItem model = mapper.Map<PasswordItem>(vm);
            model = await passwordItemRepository.AddAsync(model);

            SavePasswordItemViewModel saveViewModel = mapper.Map<SavePasswordItemViewModel>(model);

            return saveViewModel;


        }
        public virtual async Task Delete(int id)
        {
            PasswordItem model = await passwordItemRepository.GetByIdAsync(id);

            await passwordItemRepository.DeleteAsync(model);
        }

        public virtual async Task<List<PasswordItemViewModel>> GetAllViewModel()
        {
            var Models = await passwordItemRepository.GetAllAsync();

            return mapper.Map<List<PasswordItemViewModel>>(Models);
        }

        public virtual async Task<SavePasswordItemViewModel> GetByIdSaveViewModel(int id)
        {
            PasswordItem model = await passwordItemRepository.GetByIdAsync(id);

            SavePasswordItemViewModel saveView = mapper.Map<SavePasswordItemViewModel>(model);

            return saveView;
        }

        public virtual async Task Update(SavePasswordItemViewModel vm, int id)
        {
            PasswordItem model = mapper.Map<PasswordItem>(vm);

            await passwordItemRepository.UpdateAsync(model, id);
        }

    }
}
