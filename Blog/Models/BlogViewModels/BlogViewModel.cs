using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Models;

namespace Blog.Models
{
    public class BlogViewModel
    {
        public List<Blogeintrag> blogeintraege { get; set; }
        public bool isdatesorted { get; set; } = true;
    }
}
