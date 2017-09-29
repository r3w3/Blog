using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rewesblog.Models;
using Microsoft.AspNetCore.Authorization;
using Rewesblog.Data;
using Rewesblog.Helpers;

namespace Rewesblog.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hotmodel = new HotTopicBoxViewModel();
            hotmodel.Elemente = HotTopicManager.Styleelements(_context.Blogeinträge.Select(x=>new HotTopicElement(x)).ToList());
            var model = new HomeViewModel();
            model.hotmodel = hotmodel;
            return View("Index", model);
        }

        public IActionResult Home()
        {
            return Index();
        }

        public IActionResult About()
        {
           return View("About");
        }

        public IActionResult Contact(bool? success)
        {
            var model = new ContactViewModel();
            if(success != null)
            {
                model.SendenErfolgreich = success.Value;
            }
            return View("Contact", model);
        }

        //[ValidateAntiForgeryToken]
        public IActionResult ContactReturn(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Contact", new { success = true });
            }            
            return View("Contact", model);
        }

        public IActionResult Impressum()
        {
            return View("Impressum");
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
