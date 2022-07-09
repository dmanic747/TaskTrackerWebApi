using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Data.Enums;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public TaskDto(Task task)
        {
            Id = task.TaskId;
            Name = task.Name;
            Status = task.Status;
            Description = task.Description;
            Priority = task.Priority;
        }
    }
}
