using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTracker.Business.DTOs;
using TaskTracker.Business.Interfaces;
using TaskTracker.Data.Repository;
using TaskTracker.Data.Models;

namespace TaskTracker.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ProjectDto AddTasksToProject(Guid projectId, IEnumerable<TaskForCreationDto> tasksDto)
        {
            var tasks = tasksDto.Select(taskDto => taskDto.ToEntity());

            Project project = _projectRepository.AddTasksToProject(projectId, tasks);

            return new ProjectDto(project);
        }

        public ProjectDto CreateProject(ProjectForCreationDto projectDto)
        {
            Project project = _projectRepository.CreateProject(projectDto.ToEntity());

            return new ProjectDto(project);
        }

        public void DeleteProject(Guid projectId)
        {
            _projectRepository.DeleteProject(projectId);
        }

        public IEnumerable<ProjectDto> GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();

            var projectsDto = projects.Select(project => new ProjectDto(project));

            return projectsDto;
        }

        public ProjectDto GetProjectById(Guid projectId)
        {
            var project = _projectRepository.GetProjectById(projectId);

            ProjectDto projectDto = null;

            if (project != null)
                projectDto = new ProjectDto(project);

            return projectDto;
        }

        public IEnumerable<TaskDto> GetProjectTasks(Guid projectId)
        {
            var tasks = _projectRepository.GetProjectTasks(projectId);

            var tasksDto = tasks?.Select(task => new TaskDto(task));

            return tasksDto;
        }

        public bool IsProjectExists(Guid projectId)
        {
            return _projectRepository.IsProjectExists(projectId);
        }

        public void UpdateProject(ProjectForUpdateDto projectDto)
        {
            _projectRepository.UpdateProject(projectDto.ToEntity());
        }
    }
}
