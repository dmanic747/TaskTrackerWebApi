using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class TaskForDeletionDto
    {
        [Required(ErrorMessage = "Id is required")]
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
