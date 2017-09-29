using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Rewesblog.Models
{
    public class HotTopicElement
    {
        public int ClickCount { get; set; }
        public int ID { get; set; }
        public string Titel {get; set;}
        public DateTime CreateDate { get; set; }
        public double Wichtung { get; private set; }
        public int Schriftgröße { get; set; }
        public Color Schriftfarbe { get; set; }

        public HotTopicElement (int clickCount, int id, string titel, DateTime createDate)
        {
            ClickCount = clickCount;
            ID = id;
            Titel = titel;
            CreateDate = createDate;
            CalculateWichtung();
        }
        public HotTopicElement(Blogeintrag blogeintrag) : this(blogeintrag.ClickCount, blogeintrag.ID, blogeintrag.Titel, blogeintrag.CreatedDate)
        {
        }

        private void CalculateWichtung()
        {
            Wichtung = ClickCount > 0 ? ClickCount : 1 / (DateTime.Now - CreateDate).TotalDays;
        }
    }
}
