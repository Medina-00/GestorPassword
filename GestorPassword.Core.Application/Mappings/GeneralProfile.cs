
using AutoMapper;
using GestorPassword.Core.Application.Dtos.Account;
using GestorPassword.Core.Application.Dtos.Account.Request;
using GestorPassword.Core.Application.ViewModel.PasswordItem;
using GestorPassword.Core.Application.ViewModel.User;
using GestorPassword.Core.Domain.Entities;

namespace GestorPassword.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<PasswordItem, PasswordItemViewModel>()

                .ReverseMap();

            CreateMap<PasswordItem, SavePasswordItemViewModel>()
                .ReverseMap()
                .ForMember(d => d.FechaRegustro, o => o.Ignore());


            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(d => d.Error, o => o.Ignore())
                .ForMember(d => d.HasError, o => o.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(d => d.Error, o => o.Ignore())
                .ForMember(d => d.HasError, o => o.Ignore())
                .ReverseMap();

            CreateMap<UpdateRequest, UpdateUserViewModel>()
                .ForMember(d => d.Error, o => o.Ignore())
                .ForMember(d => d.HasError, o => o.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
               .ForMember(d => d.Error, o => o.Ignore())
               .ForMember(d => d.HasError, o => o.Ignore())
               .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
               .ForMember(d => d.Error, o => o.Ignore())
               .ForMember(d => d.HasError, o => o.Ignore())
               .ReverseMap();



        }
    }
}
