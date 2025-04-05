﻿

namespace GestorPassword.Core.Application.ViewModel.PasswordItem
{
    public class PasswordItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string UserId { get; set; }

        public DateTime FechaRegustro { get; set; } 
    }
}
