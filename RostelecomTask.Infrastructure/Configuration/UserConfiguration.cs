using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Infrastructure.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Department)
                .WithMany(m => m.Users)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(m => m.DepartmentId);

            builder
                .ToTable("Departments");
        }
    }
}
