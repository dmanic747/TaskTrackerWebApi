using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Data.Enums;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class TaskForCreationDto
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public Task ToEntity()
        {
            return new Task
            {
                Name = Name,
                Status = Status,
                Description = Description,
                Priority = Priority
            };
        }
    }
}
