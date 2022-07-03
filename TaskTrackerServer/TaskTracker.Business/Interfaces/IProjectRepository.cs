using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Business.DTOs;

namespace TaskTracker.Business.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(Guid projectId);
        IEnumerable<TaskDto> GetProjectTasks(Guid projectId);
        ProjectDto CreateProject(ProjectForCreationDto project);
        void UpdateProject(ProjectForUpdateDto project);
        void DeleteProject(Guid projectId);
    }
}
