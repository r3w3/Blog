using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Blog.Data.Models;

namespace Blog.Data.Data
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext>options): base(options)
        {
        }

        public DbSet<Kommentar> Kommentare { get; set; }
        public DbSet<Blogeintrag> Blogeinträge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogeintrag>().ToTable("Blog");
            modelBuilder.Entity<Kommentar>().ToTable("Kommentare");
        }
    }
}
