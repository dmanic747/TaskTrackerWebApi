using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Enums;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class TaskDetailsForUpdateDto
    {
        [Required(ErrorMessage = "TaskId is required")]
        public Guid TaskId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Range(1, 3, ErrorMessage = "Status should be between 1 and 3")]
        public TaskStatus Status { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(600, ErrorMessage = "Description can't be longer than 600 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [Range(1, 5, ErrorMessage = "Priority should be between 1 and 5")]
        public int Priority { get; set; }

        public Task ToEntity()
        {
            return new Task
            {
                TaskId = TaskId,
                Name = Name,
                Status = Status,
                Description = Description,
                Priority = Priority
            };
        }

    }
}
