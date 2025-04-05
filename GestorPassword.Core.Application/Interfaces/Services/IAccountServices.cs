
using GestorPassword.Core.Application.Dtos.Account;
using GestorPassword.Core.Application.Dtos.Account.Request;
using GestorPassword.Core.Application.Dtos.Account.Response;
using GestorPassword.Core.Application.ViewModel.User;

namespace GestorPassword.Core.Application.Interfaces.Services
{
    public interface IAccountServices
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmarCuenta(string id, string token);
        Task<ForgotPasswordReponse> ForgotPasswor(ForgotPasswordRequest request, string origin);
        Task LogOut();
        Task<RegisterResponse> RegitroBasicAsync(RegisterRequest request, string origin);
        Task<ResetPasswordReponse> ResetPasswordAsync(ResetPasswordRequest request);
        Task<UpdateResponse> EditUserAsync(string userId, UpdateRequest request);

        Task<UpdateUserViewModel> GetById(string userId = "", bool action = true, string UserName = "");


    }
}
