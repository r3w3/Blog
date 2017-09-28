using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Rewesblog.Models;

namespace Rewesblog.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Blogeinträge.Any())
            {
                return;
            }
            var blogeintraege = new Blogeintrag[]
            {
                new Blogeintrag{CreatedDate=DateTime.Now, Titel="1. Eintrag", Text="fshguoahfpHEFIHefpIEFUHipef",},
                new Blogeintrag{CreatedDate=DateTime.Now, Titel="2. Eintrag", Text="fshguoahfp",},
            };
            foreach (Blogeintrag b in blogeintraege)
            {
                context.Blogeinträge.Add(b);
            }
            context.SaveChanges();

            var kommentar = new Kommentar[]
            {
                new Kommentar{CreatedDate=DateTime.Now, Text="f<eufih<of", Name="Günther", Email="günther@gmail.com", BlogEintragID=1},
                new Kommentar{CreatedDate=DateTime.Now, Text="fjhs<eof,fn<ogn ifhoi<sgho", Name="Dieter", Email="dieterderdumme@gmail.com", BlogEintragID=1}
            };
            foreach(Kommentar k in kommentar)
            {
                context.Kommentare.Add(k);
            }
            context.SaveChanges();
        }
    }
}
