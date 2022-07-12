using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Business.Interfaces;
using TaskTracker.Business.DTOs;
using Microsoft.Extensions.Logging;

namespace TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProjects([FromQuery] ProjectQueryDto filter)
        {
            try
            {
                var projects = _projectService.GetAllProjects(filter);

                _logger.LogInformation("Returned {count} projects from database", projects.Count());

                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside GetAllProjects action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public IActionResult GetProjectById(Guid id)
        {
            try
            {
                var projectDto = _projectService.GetProjectById(id);

                if(projectDto == null)
                {
                    _logger.LogError("Project with id: {projectId} hasn't been found in db", id);
                    return NotFound();
                }

                _logger.LogInformation("Returned project with id: {projectId}", id);

                return Ok(projectDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside GetProjectById action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{projectId}/tasks")]
        public IActionResult GetProjectTasks(Guid projectId)
        {
            try
            {
                if (!_projectService.IsProjectExists(projectId))
                {
                    _logger.LogError("Project with id: {projectId} doesn't exist in db", projectId);
                    return NotFound();
                }

                var tasksDto = _projectService.GetProjectTasks(projectId);

                _logger.LogInformation("Returned tasks for the project with id: {projectId}", projectId);

                return Ok(tasksDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside GetProjectTasks action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectForCreationDto project)
        {
            try
            {
                if (project == null)
                {
                    _logger.LogError("Project object sent from the client is null");
                    return BadRequest("Project object is null");
                }

                var projectDto = _projectService.CreateProject(project);

                _logger.LogInformation("Created new project with the id: {projectId}", projectDto.Id);

                return CreatedAtRoute("GetProjectById", new { id = projectDto.Id }, projectDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside CreateProject action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(Guid id, [FromBody] ProjectForUpdateDto project)
        {
            try
            {
                if (project == null)
                {
                    _logger.LogError("Project object sent from the client is null");
                    return BadRequest("Project object is null");
                }

                var projectDto = _projectService.GetProjectById(project.Id);

                if (projectDto == null)
                {
                    _logger.LogError("Project with id: {projectId} hasn't been found in db", id);
                    return NotFound();
                }

                _projectService.UpdateProject(project);

                _logger.LogInformation("Updated existing project with the id: {projectId}", project.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside UpdateProject action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            try
            {
                var project = _projectService.GetProjectById(id);

                if (project == null)
                {
                    _logger.LogError("Project with id: {projectId} hasn't been found in db", id);
                    return NotFound();
                }

                _projectService.DeleteProject(id);

                _logger.LogInformation("Deleted existing project with the id: {projectId}", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside DeleteProject action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost("{projectId}/tasks")]
        public IActionResult AddTasksToProject(Guid projectId, [FromBody] IEnumerable<TaskForCreationDto> tasks)
        {
            try
            {
                if (tasks == null || !tasks.Any())
                {
                    _logger.LogError("Tasks object sent from the client is null or empty");
                    return BadRequest("Tasks object is null or empty");
                }

                if (!_projectService.IsProjectExists(projectId))
                {
                    _logger.LogError("Project with id: {projectId} hasn't been found in db", projectId);
                    return BadRequest("Project doesn't exist");
                }

                var projectDto = _projectService.AddTasksToProject(projectId, tasks);

                _logger.LogInformation("Added tasks to project with id: {projectId}", projectId);

                return CreatedAtRoute(nameof(GetProjectById), new { id = projectDto.Id }, projectDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside AddTasksToProject action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{projectId}/tasks")]
        public IActionResult RemoveTasksFromProject(Guid projectId, [FromBody] IEnumerable<TaskForDeletionDto> tasks)
        {
            try
            {
                if (tasks == null || !tasks.Any())
                {
                    _logger.LogError("Tasks object sent from the client is null or empty");
                    return BadRequest("Tasks object is null or empty");
                }

                if (!_projectService.IsProjectExists(projectId))
                {
                    _logger.LogError("Project with id: {projectId} hasn't been found in db", projectId);
                    return BadRequest("Project doesn't exist");
                }

                _projectService.RemoveTasksFromProject(projectId, tasks);

                _logger.LogInformation("Removed tasks from project with id: {projectId}", projectId);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside RemoveTasksFromProject action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
