using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Home()
        {
            return View("Index");
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
