﻿// <auto-generated />
using Blog.Data.Data;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Blog.Data.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20170927093958_LoginFunktion")]
    partial class LoginFunktion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Data.Models.Blogeintrag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bereich");

                    b.Property<int>("ClickCount");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Text");

                    b.Property<string>("Titel");

                    b.HasKey("ID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Blog.Data.Models.Kommentar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogEintragID");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("BlogEintragID");

                    b.ToTable("Kommentare");
                });

            modelBuilder.Entity("Blog.Data.Models.Kommentar", b =>
                {
                    b.HasOne("Blog.Data.Models.Blogeintrag", "Blogeintrag")
                        .WithMany("Kommentare")
                        .HasForeignKey("BlogEintragID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
