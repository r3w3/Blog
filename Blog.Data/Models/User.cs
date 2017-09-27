using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Data.Models
{
    public class User: IdentityUser
    {
        public string LastName { get; set; }
    }
}
