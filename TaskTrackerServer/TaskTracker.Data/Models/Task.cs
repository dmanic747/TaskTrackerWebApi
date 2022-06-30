using System;
using TaskTracker.Data.Enums;

namespace TaskTracker.Data.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
