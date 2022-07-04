using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTracker.Data.Models;
using TaskTracker.Data.Enums;
using System;

namespace TaskTracker.Data.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(project => project.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(project => project.Status)
                .IsRequired()
                .HasDefaultValue(ProjectStatus.NotStarted);

            builder
                .Property(project => project.Priority)
                .IsRequired()
                .HasDefaultValue(1);

            //builder
            //    .Property(project => project.ProjectId)
            //    .HasDefaultValueSql("NEWID()");
        }
    }
}
