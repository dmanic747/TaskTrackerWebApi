using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Models;
using TaskTracker.Data.Filters;
using TaskTracker.Data.Extensions;

namespace TaskTracker.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskTrackerContext _context;

        public ProjectRepository(TaskTrackerContext context)
        {
            _context = context;
        }

        public Project AddTasksToProject(Guid projectId, ICollection<Task> tasks)
        {
            Project projectInDb = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            projectInDb.AddTasks(tasks);

            _context.SaveChanges();

            return projectInDb;
        }

        public Project CreateProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return project;
        }

        public void DeleteProject(Guid projectId)
        {
            var projectToDelete = _context.Projects.Find(projectId);

            _context.Projects.Remove(projectToDelete);

            _context.SaveChanges();
        }

        public IEnumerable<Project> GetAllProjects(ProjectQuery projectQuery)
        {
            var query = _context.Projects
                .Include(project => project.Tasks)
                .AsQueryable();

            var fieldsMapper = new Dictionary<string, Expression<Func<Project, object>>>()
            {
                ["name"] = p => p.Name,
                ["startDate"] = p => p.StartDate,
                ["completionDate"] = p => p.CompletionDate,
                ["status"] = p => p.Status,
                ["priority"] = p => p.Priority
            };

            query = query.ApplyRangeFiltering(projectQuery);

            query = query.ApplyExactValueFiltering(projectQuery);

            query = query.ApplyOrdering(projectQuery, fieldsMapper);

            return query.ToList();
        }

        public Project GetProjectById(Guid projectId)
        {
            var project = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            return project;
        }

        public IEnumerable<Task> GetProjectTasks(Guid projectId)
        {
            var projectWithTasks = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            return projectWithTasks?.Tasks;
        }

        public bool IsProjectExists(Guid projectId)
        {
            return _context.Projects.Any(project => project.ProjectId.Equals(projectId));
        }

        public void RemoveTasksFromProject(Guid projectId, ICollection<Task> tasks)
        {
            var project = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            project.RemoveTasks(tasks);

            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            var projectInDb = _context.Projects.Find(project.ProjectId);

            projectInDb.Name = project.Name;
            projectInDb.StartDate = project.StartDate;
            projectInDb.CompletionDate = project.CompletionDate;
            projectInDb.Status = project.Status;
            projectInDb.Priority = project.Priority;

            _context.SaveChanges();
        }
    }
}
