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
                        Name = "IT"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "Legal"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "Fix"
                    });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    DepartmentId = 1,
                    UserName = "hoozr",
                    FullName = "VV"
                },
                    new User
                    {
                        Id = 2,
                        DepartmentId = 1,
                        UserName = "kkkk",
                        FullName = "KK"
                    },
                    new User
                    {
                        Id = 3,
                        DepartmentId = 3,
                        UserName = "csharp_dev",
                        FullName = "Test"
                    });
        }
    }
}
