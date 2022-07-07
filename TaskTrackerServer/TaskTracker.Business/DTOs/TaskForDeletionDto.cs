using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class TaskForDeletionDto
    {
        public Guid Id { get; set; }

        public Task ToEntity()
        {
            return new Task
            {
                TaskId = Id
            };
        }
    }
}
