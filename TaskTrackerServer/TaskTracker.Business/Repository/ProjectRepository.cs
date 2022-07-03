using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Business.DTOs;
using TaskTracker.Business.Interfaces;
using TaskTracker.Data;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskTrackerContext _context;

        public ProjectRepository(TaskTrackerContext context)
        {
            _context = context;
        }

        public void CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDto> GetAllProjects()
        {
            var projects = _context.Projects
                .Include(project => project.Tasks)
                .ToList();

            var projectsDto = projects.Select(project => new ProjectDto(project));

            return projectsDto;
        }

        public ProjectDto GetProjectById(Guid projectId)
        {
            var project = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            ProjectDto projectDto = null;

            if (project != null)
                projectDto = new ProjectDto(project);

            return projectDto;
        }

        public IEnumerable<TaskDto> GetProjectTasks(Guid projectId)
        {
            var projectWithTasks = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            var tasksDto = projectWithTasks?.Tasks.Select(task => new TaskDto(task));

            return tasksDto;
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
