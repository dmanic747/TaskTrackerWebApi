using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Business.Interfaces;
using TaskTracker.Business.DTOs;
//using Microsoft.Extensions.Logging;

namespace TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        //private readonly ILogger _logger;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();

            return Ok(projects);
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public IActionResult GetProjectById(Guid id)
        {
            var projectDto = _projectService.GetProjectById(id);

            if(projectDto == null)
                return NotFound();

            return Ok(projectDto);
        }

        [HttpGet("{projectId}/tasks")]
        public IActionResult GetProjectTasks(Guid projectId)
        {
            if (!_projectService.IsProjectExists(projectId))
                return NotFound();

            var tasksDto = _projectService.GetProjectTasks(projectId);

            return Ok(tasksDto);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectForCreationDto project)
        {
            if (project == null)
                return BadRequest("Project object is null");

            var projectDto = _projectService.CreateProject(project);

            return CreatedAtRoute("GetProjectById", new { id = projectDto.Id }, projectDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(Guid id, [FromBody] ProjectForUpdateDto project)
        {
            if (project == null)
                return BadRequest("Project object is null");

            var projectDto = _projectService.GetProjectById(project.Id);

            if (projectDto == null)
                return NotFound();

            _projectService.UpdateProject(project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            var project = _projectService.GetProjectById(id);

            if (project == null)
                return NotFound();

            _projectService.DeleteProject(id);

            return NoContent();
        }

        [HttpPost("{projectId}/tasks")]
        public IActionResult AddTasksToProject(Guid projectId, [FromBody] IEnumerable<TaskForCreationDto> tasks)
        {
            if (tasks == null || !tasks.Any())
                return BadRequest("Tasks object is null or empty");

            if (!_projectService.IsProjectExists(projectId))
                return BadRequest("Project doesn't exist");

            var projectDto = _projectService.AddTasksToProject(projectId, tasks);

            return CreatedAtRoute(nameof(GetProjectById), new { id = projectDto.Id }, projectDto);
        }

        [HttpPut("{projectId}/tasks")]
        public IActionResult RemoveTasksFromProject(Guid projectId, [FromBody] IEnumerable<TaskForDeletionDto> tasks)
        {
            if (tasks == null || !tasks.Any())
                return BadRequest("Tasks object is null or empty");

            if (!_projectService.IsProjectExists(projectId))
                return BadRequest("Project doesn't exist");

            _projectService.RemoveTasksFromProject(projectId, tasks);

            return NoContent();
        }
    }
}
