using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rewesblog.Models;
using Rewesblog.Data;
using Rewesblog.Helpers;

namespace Rewesblog.Controllers
{
    public class Thema1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Thema1Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Bereiche.Thema1).ToList();
            return View("Thema1", blogmodel);
        }
        public IActionResult Thema1(bool? isSortbydate)
        {

            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Bereiche.Thema1).ToList();
            if (isSortbydate != null)
            {
                blogmodel.isdatesorted = isSortbydate.Value;
            }
            return View("Thema1", blogmodel);
        }
        public IActionResult Thema1detail(int? ID)
        {
            if (ID != null)
            {
                _context.Blogeinträge.First(x => x.ID == ID).ClickCount++;
                _context.SaveChanges();

                var hotmodel = new HotTopicBoxViewModel();
                hotmodel.Elemente = HotTopicManager.Styleelements(_context.Blogeinträge.Select(x => new HotTopicElement(x)).ToList());
                var ele = _context.Blogeinträge.First(x => x.ID == ID);
                switch (ele.Bereich)
                {
                    case Bereiche.Blog:
                        return RedirectToAction("Blogdetail", "Blog", new { ID = ID });
                    case Bereiche.Thema2:
                        return RedirectToAction("Thema2detail", "Thema2", new { ID = ID });
                }
                var model = new Thema1detailViewModel();
                model.eintrag = ele;
                model.hotmodel = hotmodel;
                model.eintrag = _context.Blogeinträge.First(x => x.ID == ID);
                model.eintrag.Kommentare = _context.Kommentare.Where(x => x.BlogEintragID == ID).ToList();
                return View("Thema1detail", model);
            }
            return RedirectToAction("Thema1");
        }
        public IActionResult AddComment(Thema1detailViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.addedkommentar.BlogEintragID = model.eintrag.ID;
                model.addedkommentar.CreatedDate = DateTime.Now;
                _context.Kommentare.Add(model.addedkommentar);
                _context.SaveChanges();
                return RedirectToAction("Thema1detail", new { ID = model.eintrag.ID });
            }
            model.eintrag = _context.Blogeinträge.First(x => x.ID == model.eintrag.ID);
            model.eintrag.Kommentare = _context.Kommentare.Where(x => x.BlogEintragID == model.eintrag.ID).ToList();
            return View("Thema1detail", model);
        }

    }
}