﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View("Blog");
        }
        public IActionResult Blog()
        {
            return View("Blog");
        }
    }
}