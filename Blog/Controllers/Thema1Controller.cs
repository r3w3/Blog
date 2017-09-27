using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Data.Data;

namespace Blog.Controllers
{
    public class Thema1Controller : Controller
    {
        private readonly BlogContext _context;

        public Thema1Controller(BlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Data.Models.Bereiche.Thema1).ToList();
            return View("Thema1", blogmodel);
        }
        public IActionResult Thema1(bool? isSortbydate)
        {

            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Data.Models.Bereiche.Thema1).ToList();
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

                var model = new Thema1detailViewModel();
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