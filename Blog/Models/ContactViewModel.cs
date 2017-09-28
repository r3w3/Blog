using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class ContactViewModel
    {
        [DisplayName("Name")]
        [Required(ErrorMessage ="Bitte gib Deinen Namen ein!")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Bitte eine gültige Email-Adresse eingeben!")]
        [Required(ErrorMessage = "Bitte gib Deine Email-Adresse ein!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bitte gib Deine Nachricht ein!")]
        public string Text { get; set; }

        public bool SendenErfolgreich { get; set; }
    }
}
