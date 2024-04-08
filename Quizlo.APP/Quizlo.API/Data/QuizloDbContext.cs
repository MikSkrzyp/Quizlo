﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizlo.API.Model.Configurations;
using Quizlo.API.Model.Domain;

namespace Quizlo.API.Data
{
    public class QuizloDbContext : IdentityDbContext<User>
    {
        public QuizloDbContext(DbContextOptions<QuizloDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
                                                         
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }


    }
}