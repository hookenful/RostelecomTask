using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Infrastructure.Configuration;

namespace RostelecomTask.Infrastructure
{
   public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            SeedData(modelBuilder);
            modelBuilder
                .ApplyConfiguration(new UserConfiguration());

            modelBuilder
                .ApplyConfiguration(new DepartmentConfiguration());
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasData(new Department
                    {
                        Id = 1, 
                        Name = "Production Department"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "Finance Department"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "IT Department"
                    });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    DepartmentId = 1,
                    UserName = "hoozr",
                    FullName = "Vladislav Vershinin"
                },
                    new User
                    {
                        Id = 2,
                        DepartmentId = 2,
                        UserName = "Alex Oxbrough",
                        FullName = "oxbrough99"
                    },
                    new User
                    {
                        Id = 3,
                        DepartmentId = 3,
                        UserName = "Courtney Gear",
                        FullName = "tespa_member"
                    });
        }
    }
}
