using mhcapstone.Areas.Data;
using mhcapstone.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace mhcapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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

            var admin = new User
            {
                Id = "ADMIN",
                UserName = "Admin@develop.com",
                NormalizedUserName = "Admin@develop.com".ToUpper(),
                Email = "Admin@Develop.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                BirthDate = DateTime.Now,
                Active = true,
                PasswordHash = "AQAAAAEAACcQAAAAEE6fNGBLk0gWXtI+YF/euDFjEP3ASy0lEumjpTNbqgowNOzt9/dY3UByIFgSIFf1bA=="
            };

            builder.Entity<User>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ADMIN",
                UserId = "ADMIN"
            });

            var testUser = new User
            {
                Id = "USER",
                UserName = "user@develop.com",
                NormalizedUserName = "user@develop.com".ToUpper(),
                Email = "user@Develop.com",
                EmailConfirmed = true,
                FirstName = "user",
                LastName = "user",
                BirthDate = DateTime.Now,
                Active = true,
                PasswordHash = "AQAAAAEAACcQAAAAEE6fNGBLk0gWXtI+YF/euDFjEP3ASy0lEumjpTNbqgowNOzt9/dY3UByIFgSIFf1bA=="
            };

            builder.Entity<User>().HasData(testUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "USER",
                UserId = "USER"
            });


            base.OnModelCreating(builder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Surveys> Survey { get; set; }
        public DbSet<SurveyInfo> SurveyInfo { get; set; }


    }
}
