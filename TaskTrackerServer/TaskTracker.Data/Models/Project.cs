using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Data.Enums;

namespace TaskTracker.Data.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }

        public ICollection<Task> Tasks { get; private set; }

        public void AddTasks(ICollection<Task> tasks)
        {
            foreach (var task in tasks)
            {
                task.ProjectId = ProjectId;
                task.Project = this;

                Tasks.Add(task);
            }
        }

        public void RemoveTasks(ICollection<Task> tasks)
        {
            foreach (var task in tasks)
            {
                var taskToRemove = Tasks.SingleOrDefault(taskInMemory => taskInMemory.TaskId.Equals(task.TaskId));

                if (taskToRemove != null)
                    Tasks.Remove(taskToRemove);
            }
        }
    }
}
