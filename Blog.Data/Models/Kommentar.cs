using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Models
{
    public class Kommentar
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }

        [ForeignKey("Blogeintrag")]
        public int BlogEintragID { get; set; }
        
        public Blogeintrag Blogeintrag { get; set; }
    }
}
