using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Business.DTOs;

namespace TaskTracker.Business.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAllProjects(ProjectQueryDto queryDto);
        ProjectDto GetProjectById(Guid projectId);
        IEnumerable<TaskDto> GetProjectTasks(Guid projectId);
        ProjectDto CreateProject(ProjectForCreationDto project);
        void UpdateProject(ProjectForUpdateDto project);
        void DeleteProject(Guid projectId);
        bool IsProjectExists(Guid projectId);
        ProjectDto AddTasksToProject(Guid projectId, IEnumerable<TaskForCreationDto> tasks);
        void RemoveTasksFromProject(Guid projectId, IEnumerable<TaskForDeletionDto> tasks);
    }
}
