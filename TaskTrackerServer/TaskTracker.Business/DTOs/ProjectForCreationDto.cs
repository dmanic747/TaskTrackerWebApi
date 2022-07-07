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
    public class ProjectForCreationDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }

        public Project ToEntity()
        {
            return new Project
            {
                Name = Name,
                StartDate = StartDate,
                CompletionDate = CompletionDate,
                Status = Status,
                Priority = Priority
            };
        }
    }
}
