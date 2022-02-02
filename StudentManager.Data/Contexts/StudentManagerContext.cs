using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StudentManager.Data.Entities;
using StudentManager.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace StudentManager.Data.Contexts
{
    public class StudentManagerContext : IdentityDbContext, IStudentManagerContext
    {
        static private DatabaseFacade dataBase;
        public StudentManagerContext(DbContextOptions<StudentManagerContext> options) : base(options)
        {
            dataBase = Database;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            base.OnConfiguring(optionbuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(e =>
            e.HasMany<Grade>().WithOne()
            );
            modelBuilder.Entity<Grade>(e =>
            e.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentId)
            );
        }

        public static void SeedData(StudentManagerContext context, UserManager<IdentityUser> userManager)
        {
            dataBase.EnsureCreated();
            context.Students.Add(new Student { Name = "Bela" });
            var result = userManager.CreateAsync(new IdentityUser { UserName = "admin" }, "edutest2021").GetAwaiter().GetResult();
            context.SaveChanges();
        }

        void IStudentManagerContext.SaveChanges()
        {
            base.SaveChanges();
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
