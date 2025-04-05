﻿
using AutoMapper;
using GestorPassword.Core.Application.Interfaces.Services;
using GestorPassword.Core.Application.Dtos.Account;
using GestorPassword.Core.Application.Dtos.Account.Request;
using GestorPassword.Core.Application.Dtos.Account.Response;
using GestorPassword.Core.Application.ViewModel.User;
using SocialNetwork.Core.Applitation.Interfaces.Services;


namespace GestorPassword.Core.Applitation.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IAccountServices accountServices;

        public UserService(IMapper mapper, IAccountServices accountServices)
        {
            this.mapper = mapper;
            this.accountServices = accountServices;
        }
        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await accountServices.ConfirmarCuenta(userId, token);
        }

        public async Task<ForgotPasswordReponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin)
        {
            ForgotPasswordRequest request = mapper.Map<ForgotPasswordRequest>(vm);
            return await accountServices.ForgotPasswor(request, origin);
        }

        public Task<UpdateUserViewModel> GetById(string userId = "", bool action = true, string UserName = "")
        {
            if (action)
            {
                return accountServices.GetById(userId);
            }
            return accountServices.GetById(UserName);
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest request = mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse response = await accountServices.AuthenticateAsync(request);
            return response;
        }

        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin)
        {
            RegisterRequest request = mapper.Map<RegisterRequest>(vm);

            return await accountServices.RegitroBasicAsync(request, origin);
        }

        public async Task<ResetPasswordReponse> ResetPasswordAsync(ResetPasswordViewModel vm)
        {
            ResetPasswordRequest request = mapper.Map<ResetPasswordRequest>(vm);
            return await accountServices.ResetPasswordAsync(request);
        }

        public async Task SignOutAsync()
        {
            await accountServices.LogOut();
        }

        public async Task<UpdateResponse> UpdateUserAsync(string userId, UpdateUserViewModel updateUser)
        {
            UpdateRequest request = mapper.Map<UpdateRequest>(updateUser);

            return await accountServices.EditUserAsync(userId, request);
        }

      
    }
}
