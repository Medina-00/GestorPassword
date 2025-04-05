
using Microsoft.AspNetCore.Identity;

namespace GestorPassword.Infrastructure.Identity.Entities
{
    public class ApplitationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
    }
}
