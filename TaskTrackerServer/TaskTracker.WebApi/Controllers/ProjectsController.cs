using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Business.Interfaces;
using TaskTracker.Business.DTOs;

namespace TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectRepository;

        public ProjectsController(IProjectService projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();

            return Ok(projects);
        }

        [HttpGet("{id}", Name = "GetProjectById")]
        public IActionResult GetProjectById(Guid id)
        {
            var projectDto = _projectRepository.GetProjectById(id);

            if(projectDto == null)
                return NotFound();

            return Ok(projectDto);
        }

        [HttpGet("{projectId}/tasks")]
        public IActionResult GetProjectTasks(Guid projectId)
        {
            if (!_projectRepository.IsProjectExists(projectId))
                return NotFound();

            var tasksDto = _projectRepository.GetProjectTasks(projectId);

            return Ok(tasksDto);
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] ProjectForCreationDto project)
        {
            if (project == null)
                return BadRequest("Project object is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid project object");

            var projectDto = _projectRepository.CreateProject(project);

            return CreatedAtRoute("GetProjectById", new { id = projectDto.Id }, projectDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(Guid id, [FromBody] ProjectForUpdateDto project)
        {
            if (project == null)
                return BadRequest("Project object is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid project object");

            var projectDto = _projectRepository.GetProjectById(project.Id);

            if (projectDto == null)
                return NotFound();

            _projectRepository.UpdateProject(project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(Guid id)
        {
            var project = _projectRepository.GetProjectById(id);

            if (project == null)
                return NotFound();

            _projectRepository.DeleteProject(id);

            return NoContent();
        }

        [HttpPost("{projectId}/tasks")]
        public IActionResult AddTasksToProject(Guid projectId, [FromBody] IEnumerable<TaskForCreationDto> tasks)
        {
            if (tasks == null || !tasks.Any())
                return BadRequest("Tasks object is null or empty");

            if (!_projectRepository.IsProjectExists(projectId))
                return BadRequest("Project doesn't exist");

            var projectDto = _projectRepository.AddTasksToProject(projectId, tasks);

            return CreatedAtRoute(nameof(GetProjectById), new { id = projectDto.Id }, projectDto);
        }
    }
}
