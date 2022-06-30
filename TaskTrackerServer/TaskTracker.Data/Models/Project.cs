using System;
using System.Collections.Generic;
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

        public ICollection<Task> Tasks { get; set; }
    }
}
