using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Data.Enums;

namespace TaskTracker.Business.DTOs
{
    public class TaskForUpdateDto
    {
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public Data.Models.Task ToEntity()
        {
            return new Data.Models.Task
            {
                Name = Name,
                Status = Status,
                Description = Description,
                Priority = Priority
            };
        }
    }
}
