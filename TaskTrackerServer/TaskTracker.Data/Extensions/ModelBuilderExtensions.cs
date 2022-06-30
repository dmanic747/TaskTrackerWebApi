using Microsoft.EntityFrameworkCore;
using System;
using TaskTracker.Data.Models;
using TaskTracker.Data.Enums;

namespace TaskTracker.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasData(
                    new Project 
                    {
                        ProjectId = new Guid("32504d45-34a0-4315-ab00-99caad137b8e"),
                        Name = "Project1",
                        StartDate = new DateTime(2022, 7, 1, 12, 0, 0),
                        CompletionDate = new DateTime(2022, 7, 7, 12, 0, 0),
                        Priority = 1,
                        Status = ProjectStatus.NotStarted,
                    },
                    new Project
                    {
                        ProjectId = new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352"),
                        Name = "Project2",
                        StartDate = new DateTime(2022, 7, 2, 13, 0, 0),
                        CompletionDate = new DateTime(2022, 7, 8, 13, 0, 0),
                        Priority = 2,
                        Status = ProjectStatus.NotStarted,
                    },
                    new Project
                    {
                        ProjectId = new Guid("c2f3eab5-ed1f-474f-add4-b6d14cf69564"),
                        Name = "Project3",
                        StartDate = new DateTime(2022, 7, 3, 14, 0, 0),
                        CompletionDate = new DateTime(2022, 7, 9, 14, 0, 0),
                        Priority = 3,
                        Status = ProjectStatus.NotStarted,
                    }
                );

            modelBuilder.Entity<Task>()
                .HasData(
                    new Task
                    {
                        TaskId = new Guid("2ac3dd2a-261f-4b91-9c09-fa1622cbe192"),
                        Name = "Task1",
                        Status = TaskStatus.ToDo,
                        Description = "Description for Task1",
                        Priority = 1,
                        ProjectId = new Guid("32504d45-34a0-4315-ab00-99caad137b8e")
                    }, 
                    new Task
                    {
                        TaskId = new Guid("2ee99086-6031-4624-b891-034ff894c247"),
                        Name = "Task2",
                        Status = TaskStatus.ToDo,
                        Description = "Description for Task2",
                        Priority = 1,
                        ProjectId = new Guid("32504d45-34a0-4315-ab00-99caad137b8e")
                    },
                    new Task
                    {
                        TaskId = new Guid("51f1f31d-1c1f-4b8a-b982-35c73bf5a59a"),
                        Name = "Task3",
                        Status = TaskStatus.ToDo,
                        Description = "Description for Task3",
                        Priority = 1,
                        ProjectId = new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352")
                    },
                    new Task
                    {
                        TaskId = new Guid("aa63cc96-b539-4d5b-8de2-bb9dbb36cab6"),
                        Name = "Task4",
                        Status = TaskStatus.ToDo,
                        Description = "Description for Task4",
                        Priority = 1,
                        ProjectId = new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352")
                    },
                    new Task
                    {
                        TaskId = new Guid("612ba24a-f8ac-410e-8343-40af1faab47a"),
                        Name = "Task5",
                        Status = TaskStatus.ToDo,
                        Description = "Description for Task5",
                        Priority = 1,
                        ProjectId = new Guid("c2870df6-f1ab-4524-bd9c-75ec47721352")
                    },
                    new Task
                    {
                        TaskId = new Guid("a0cce7c0-26f0-4379-9f10-c96912cb12bb"),
                        Name = "Task6",
                        Status = TaskStatus.ToDo,
                        Description = "Description for Task6",
                        Priority = 1,
                        ProjectId = new Guid("c2f3eab5-ed1f-474f-add4-b6d14cf69564")
                    }
                );
        }
    }
}
