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
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();

            return Ok(projects);
        }

        [HttpGet("{id}")]
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
            var tasksDto = _projectRepository.GetProjectTasks(projectId);

            return Ok(tasksDto);
        }
    }
}
