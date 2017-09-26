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
            blogmodel.blogeintraege = _context.Blogeinträge.ToList();
            return View("Blog", blogmodel);
        }
        public IActionResult Blog()
        {
            var blogmodel = new BlogViewModel();
            blogmodel.blogeintraege = _context.Blogeinträge.ToList();
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
            }
            return RedirectToAction("Blogdetail",new {ID = model.eintrag.ID });
        }

        public IActionResult Blogdetail(int? ID)
        {
            if(ID != null)
            {
                var model = new BlogdetailViewModel();
                model.eintrag = _context.Blogeinträge.First(x=>x.ID==ID);
                model.eintrag.Kommentare = _context.Kommentare.Where(x => x.BlogEintragID == ID).ToList();
                return View("Blogdetail", model);
            }
            return RedirectToAction("Blog");
        }
    }
}