using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Data.Models;

namespace TaskTracker.Data.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(Guid projectId);
        IEnumerable<Task> GetProjectTasks(Guid projectId);
        Project CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Guid projectId);
        bool IsProjectExists(Guid projectId);
        Project AddTasksToProject(Guid projectId, ICollection<Task> tasks);
    }
}
