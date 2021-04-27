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


            builder.Entity<Answer>()
                .HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(builder);
        }

    }
}
