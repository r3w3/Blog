using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class Thema2Controller : Controller
    {
        public IActionResult Index()
        {
            return View("Thema2");
        }
        public IActionResult Thema2()
        {
            return View("Thema2");
        }
    }
}