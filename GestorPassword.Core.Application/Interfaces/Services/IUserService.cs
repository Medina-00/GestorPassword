

using GestorPassword.Core.Application.Dtos.Account;
using GestorPassword.Core.Application.Dtos.Account.Response;
using GestorPassword.Core.Application.ViewModel.User;

namespace SocialNetwork.Core.Applitation.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordReponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<ResetPasswordReponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task SignOutAsync();
        Task<UpdateResponse> UpdateUserAsync(string userId, UpdateUserViewModel request);
        Task<UpdateUserViewModel> GetById(string userId = "", bool action = true, string UserName = "");
    }
}