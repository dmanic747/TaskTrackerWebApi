using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Business.DTOs;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(Guid projectId);
        IEnumerable<TaskDto> GetProjectTasks(Guid projectId);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
