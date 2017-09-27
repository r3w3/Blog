using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Passwort { get; set; }
    }
}
