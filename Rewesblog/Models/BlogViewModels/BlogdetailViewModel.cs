using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rewesblog.Models
{
    public class BlogdetailViewModel
    {
        public Blogeintrag eintrag { get; set; }
        public Kommentar addedkommentar { get; set; } = new Kommentar();        
    }
}
