using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rewesblog.Models;
using Rewesblog.Data;
using Rewesblog.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Rewesblog.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Bereiche.Blog).ToList();
            return View("Blog", blogmodel);
        }
        public IActionResult Blog(bool? isSortbydate)
        {
            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Bereiche.Blog).ToList();
            if (isSortbydate != null)
            {
                blogmodel.isdatesorted = isSortbydate.Value;
            }
            return View("Blog", blogmodel);
        }
        public IActionResult AddComment(BlogdetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.addedkommentar.BlogEintragID = model.eintrag.ID;
                model.addedkommentar.CreatedDate = DateTime.Now;
                _context.Kommentare.Add(model.addedkommentar);
                _context.SaveChanges();
                return RedirectToAction("Blogdetail", new { ID = model.eintrag.ID });
            }
            model.eintrag = _context.Blogeinträge.First(x => x.ID == model.eintrag.ID);
            model.eintrag.Kommentare = _context.Kommentare.Where(x => x.BlogEintragID == model.eintrag.ID).ToList();
            return View("Blogdetail", model);
        }

        public IActionResult Blogdetail(int? ID)
        {
            if (ID != null)
            {
                _context.Blogeinträge.First(x => x.ID == ID).ClickCount++;
                _context.SaveChanges();

                var hotmodel = new HotTopicBoxViewModel();
                hotmodel.Elemente = HotTopicManager.Styleelements(_context.Blogeinträge.Select(x => new HotTopicElement(x)).ToList());
                var model = new BlogdetailViewModel();
                var ele = _context.Blogeinträge.First(x => x.ID == ID);
                switch (ele.Bereich)
                {
                    case Bereiche.Thema1:
                        return RedirectToAction("Thema1detail", "Thema1", new { ID = ID });
                    case Bereiche.Thema2:
                        return RedirectToAction("Thema2detail", "Thema2", new { ID = ID });
                }

                model.eintrag = ele;
                model.eintrag.Kommentare = _context.Kommentare.Where(x => x.BlogEintragID == ID).ToList();
                model.hotmodel = hotmodel;
                return View("Blogdetail", model);
            }
            return RedirectToAction("Blog");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Blogeintrag()
        {
            var blogeintragmodel = new BlogeintragViewModel();
            return View("Blogeintrag", blogeintragmodel);
        }
        [HttpPost]
        public IActionResult Blogeintrag(BlogeintragViewModel blogeintragmodel)
        {
            _context.Blogeinträge.Add(blogeintragmodel);
            _context.SaveChanges();
            return Blogeintrag();
        }
    }
}