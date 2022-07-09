using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Models;
using TaskTracker.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskTracker.Data.EntityConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .Property(task => task.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(task => task.Status)
                .IsRequired()
                .HasDefaultValue(TaskStatus.ToDo);

            builder
                .Property(task => task.Description)
                .IsRequired()
                .HasMaxLength(600);

            builder
                .Property(task => task.Priority)
                .IsRequired()
                .HasDefaultValue(1);

            builder
                .Property(task => task.TaskId)
                .HasDefaultValueSql("NEWID()");
        }
    }
}
