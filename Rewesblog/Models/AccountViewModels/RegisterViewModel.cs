using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rewesblog.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Bitte gib eine Email-Adresse an!")]
        [EmailAddress(ErrorMessage ="Dies ist keine gültige Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bitte gib ein Passwort ein")]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} und maximal {1} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passwort bestätigen")]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }
    }
}
