using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Data.Enums;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }

        public ProjectDto(Project project)
        {
            Id = project.ProjectId;
            Name = project.Name;
            StartDate = project.StartDate;
            CompletionDate = project.CompletionDate;
            Status = project.Status;
            Priority = project.Priority;
            Tasks = project?.Tasks?.Select(task => new TaskDto(task));
        }
    }
}
