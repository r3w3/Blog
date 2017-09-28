using System;
using System.Collections.Generic;
using System.Text;

namespace Rewesblog.Models
{
    public class Blogeintrag
    {
        public int ID { get; set; }
        public DateTime CreatedDate{get; set;}
        public string Text { get; set; }
        public string Titel { get; set; }
        public Bereiche Bereich { get; set; } = Bereiche.Blog;

        public int ClickCount { get; set; } = 0;
        
        public ICollection<Kommentar>Kommentare { get; set; }
    }
}
