


using GestorPassword.Core.Application.Dtos.Email;

namespace GestorPassword.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);

    }
}
