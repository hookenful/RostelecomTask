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
            modelBuilder
                .ApplyConfiguration(new UserConfiguration());

            modelBuilder
                .ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
