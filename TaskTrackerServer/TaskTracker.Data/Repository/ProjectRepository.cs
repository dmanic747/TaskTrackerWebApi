﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskTrackerContext _context;

        public ProjectRepository(TaskTrackerContext context)
        {
            _context = context;
        }

        public Project AddTasksToProject(Guid projectId, IEnumerable<Task> tasks)
        {
            var projectInDb = _context.Projects
                .Include(project => project.Tasks)
                .SingleOrDefault(project => project.ProjectId.Equals(projectId));

            foreach (var task in tasks)
            {
                task.TaskId = Guid.NewGuid();
                projectInDb.Tasks.Add(task);
            }

            _context.SaveChanges();

            return projectInDb;
        }

        public Project CreateProject(Project project)
        {
            project.ProjectId = Guid.NewGuid();

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

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _context.Projects
                .Include(project => project.Tasks)
                .ToList();

            return projects;
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