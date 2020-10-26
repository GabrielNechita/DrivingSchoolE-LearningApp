using DriversPlatform.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.DAL
{
    public class DatabaseContext : IdentityDbContext<User, Role, string>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InstructorCategoryLink> InstructorCategoryLink { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Instructor Category many-to-many relationship
            modelBuilder.Entity<InstructorCategoryLink>()
            .HasKey(t => new { t.InstructorId, t.CategoryId });

            modelBuilder.Entity<InstructorCategoryLink>()
                .HasOne(pt => pt.Instructor)
                .WithMany(p => p.InstructorCategory)
                .HasForeignKey(pt => pt.InstructorId);

            modelBuilder.Entity<InstructorCategoryLink>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.InstructorCategory)
                .HasForeignKey(pt => pt.CategoryId);

            //Seedind data in Category table
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "A", Description = "Varsta minima: 24 ani" },
                new { Id = 2, Name = "B", Description = "Varsta minima: 18 ani" },
                new { Id = 3, Name = "C", Description = "Varsta minima: 21 ani" },
                new { Id = 4, Name = "D", Description = "Varsta minima: 24 ani" }
                );

        }

    }
}
