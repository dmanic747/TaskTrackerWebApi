using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Enums;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class ProjectForUpdateDto
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Completion date is required")]
        public DateTime CompletionDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Range(1, 3, ErrorMessage = "Status should be between 1 and 3")]
        public ProjectStatus Status { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [Range(1, 5, ErrorMessage = "Priority should be between 1 and 5")]
        public int Priority { get; set; }

        public Project ToEntity()
        {
            return new Project
            {
                ProjectId = Id,
                Name = Name,
                StartDate = StartDate,
                CompletionDate = CompletionDate,
                Status = Status,
                Priority = Priority
            };
        }
    }
}
