using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Models
{
    public class Kommentar
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Bitte gib Deinen Namen ein!")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Bitte gib Deine Email-Adresse ein!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bitte gib Deine Nachricht ein!")]
        public string Text { get; set; }
        

        [ForeignKey("Blogeintrag")]
        public int BlogEintragID { get; set; }
        
        public Blogeintrag Blogeintrag { get; set; }
    }
}
