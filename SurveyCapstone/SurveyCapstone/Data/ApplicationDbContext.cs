using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyCapstone.Areas.Data;
using SurveyCapstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Users> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var PasswordHash = new PasswordHasher();
            Random random = new Random();

            builder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Id = "ADMIN",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = "USER",
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                });

            var admin = new Users
            {
                Id = "ADMIN",
                UserName = "Admin@develop.com",
                NormalizedUserName = "Admin@develop.com".ToUpper(),
                Email = "Admin@Develop.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",

                PasswordHash = "AQAAAAEAACcQAAAAEE6fNGBLk0gWXtI+YF/euDFjEP3ASy0lEumjpTNbqgowNOzt9/dY3UByIFgSIFf1bA=="
            };

            builder.Entity<Users>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ADMIN",
                UserId = "ADMIN"
            });

            var testUser = new Users
            {
                Id = "USER",
                UserName = "user@develop.com",
                NormalizedUserName = "user@develop.com".ToUpper(),
                Email = "user@Develop.com",
                EmailConfirmed = true,
                FirstName = "user",
                LastName = "user",

                PasswordHash = "AQAAAAEAACcQAAAAEE6fNGBLk0gWXtI+YF/euDFjEP3ASy0lEumjpTNbqgowNOzt9/dY3UByIFgSIFf1bA=="
            };

            builder.Entity<Users>().HasData(testUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "USER",
                UserId = "USER"
            });


            var survey1 = new Survey
            {
                Name = "Test Survey 1",
                Id = 10000,
                UserID = "ADMIN",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,           
            };

            builder.Entity<Survey>().HasData(survey1);

            var question1_1 = new Question
            {
                Id = 10000,
                SurveyId = 10000,
                Title = "Test Question #1",
                CreatedOn = DateTime.Now,
                ModifiedOn =DateTime.Now
            };
            builder.Entity<Question>().HasData(question1_1);
            var question1_2 = new Question
            {
                Id = 10001,
                SurveyId = 10000,
                Title = "Test Question #2",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            builder.Entity<Question>().HasData(question1_2);
            var question1_3 = new Question
            {
                Id = 10002,                
                SurveyId = 10000,
                Title = "Test Question #3",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            builder.Entity<Question>().HasData(question1_3);
            var question1_4 = new Question
            {
                Id = 10003,
                SurveyId = 10000,
                Title = "Test Question #4",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };
            builder.Entity<Question>().HasData(question1_4);

            var response1 = new Response
            {
                Id = 10000,
                SurveyId = 10000,
                UserID = "USER",
                CreatedOn = DateTime.Now,              
            };
            builder.Entity<Response>().HasData(response1);

            var answer1 = new Answer
            {
                UserID = "USER",
                Id = 10000,
                ResponseId = 10000,
                QuestionId = 10000,
                Value = "Test Answer #1",
            };
            builder.Entity<Answer>().HasData(answer1);

            var answer2 = new Answer
            {
                UserID = "USER",
                Id = 10001,
                ResponseId = 10000,
                QuestionId = 10000,
                Value = "Test Answer #2",
            };
            builder.Entity<Answer>().HasData(answer2);

            var answer3 = new Answer
            {
                UserID = "USER",
                Id = 10002,
                ResponseId = 10000,
                QuestionId = 10000,
                Value = "Test Answer #3",
            };
            builder.Entity<Answer>().HasData(answer3);

            var answer4 = new Answer
            {
                UserID = "USER",
                Id = 10003,
                ResponseId = 10000,
                QuestionId = 10000,
                Value = "Test Answer #4",
            };
            builder.Entity<Answer>().HasData(answer4);

            builder.Entity<Answer>()
                .HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(builder);
        }

    }
}
