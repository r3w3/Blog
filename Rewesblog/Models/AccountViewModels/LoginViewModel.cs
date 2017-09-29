using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rewesblog.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Bitte gib deine Email-Adresse ein")]
        [EmailAddress(ErrorMessage ="Dies ist keine gülitge Email-Adresse")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bitte gib dein Passwort ein")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Angemeldet bleiben?")]
        public bool RememberMe { get; set; }
    }
}
