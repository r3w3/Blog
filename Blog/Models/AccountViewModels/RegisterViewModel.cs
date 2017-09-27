using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email-Feld darf nicht leer sein!")]
        [EmailAddress(ErrorMessage ="Bitte eine gültige Email-Adresse eingeben!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Es wird ein Passwort benötigt!")]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} und maximal {1} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }

        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Die Passwörter stimmen nicht überein!")]
        [DisplayName("Passwort bestätigen")]
        public string Passwortbestätigen { get; set; }
    }
}
