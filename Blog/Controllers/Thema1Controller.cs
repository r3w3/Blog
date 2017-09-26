using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class Thema1Controller : Controller
    {
        public IActionResult Index()
        {
            return View("Thema1");
        }
        public IActionResult Thema1()
        {
            return View("Thema1");
        }
    }
}