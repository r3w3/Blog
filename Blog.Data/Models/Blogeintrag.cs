using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Models
{
    public class Blogeintrag
    {
        public int ID { get; set; }
        public DateTime CreatedDate{get; set;}
        public string Text { get; set; }
        public string Titel { get; set; }
        
        public ICollection<Kommentar>Kommentare { get; set; }
    }
}
