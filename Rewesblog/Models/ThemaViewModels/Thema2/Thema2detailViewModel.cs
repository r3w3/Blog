using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rewesblog.Models
{
    public class Thema2detailViewModel
    {
        public HotTopicBoxViewModel hotmodel { get; set; }
        public Blogeintrag eintrag { get; set; }
        public Kommentar addedkommentar { get; set; } = new Kommentar();        
    }
}
