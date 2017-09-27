using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Data.Data;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _context;
        
        public BlogController(BlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x=>x.Bereich == Data.Models.Bereiche.Blog).ToList();
            return View("Blog", blogmodel);
        }
        public IActionResult Blog(bool? isSortbydate)
        {
            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.Where(x => x.Bereich == Data.Models.Bereiche.Blog).ToList();
            if(isSortbydate!= null)
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
            if(ID != null)
            {
                _context.Blogeinträge.First(x => x.ID == ID).ClickCount++;
                _context.SaveChanges();

                var model = new BlogdetailViewModel();
                model.eintrag = _context.Blogeinträge.First(x=>x.ID==ID);
                model.eintrag.Kommentare = _context.Kommentare.Where(x => x.BlogEintragID == ID).ToList();
                return View("Blogdetail", model);
            }
            return RedirectToAction("Blog");
        }
    }
}