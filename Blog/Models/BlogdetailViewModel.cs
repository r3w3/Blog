﻿using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BlogdetailViewModel
    {
        public Blogeintrag eintrag { get; set; }
        public Kommentar addedkommentar { get; set; } = new Kommentar();        
    }
}
