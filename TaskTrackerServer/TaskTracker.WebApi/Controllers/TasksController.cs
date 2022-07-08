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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;

        public TasksController(ITaskService taskService, IProjectService projectService)
        {
            _taskService = taskService;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasks();

                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{taskId}", Name = "GetTaskById")]
        public async Task<IActionResult> GetTaskById(Guid taskId)
        {
            try
            {
                var taskDto = await _taskService.GetTaskById(taskId);

                if (taskDto == null)
                    return NotFound();

                return Ok(taskDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDetailsForCreationDto task)
        {
            try
            {
                if (task == null)
                    return BadRequest("Task object is null");

                if (!_projectService.IsProjectExists(task.ProjectId))
                    return BadRequest("Project doesn't exist");

                 var taskDto = await _taskService.CreateTask(task);

                return CreatedAtRoute(nameof(GetTaskById), new { id = taskDto.Id }, taskDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] TaskDetailsForUpdateDto task)
        {
            try
            {
                if (task == null)
                    return BadRequest("Task object is null");

                if (taskId != task.TaskId)
                    return BadRequest("Route parameter taskId and object's taskId do not match");

                if (!await _taskService.IsTaskExists(taskId))
                    return NotFound();

                await _taskService.UpdateTask(task);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("taskId")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            try
            {
                if (!await _taskService.IsTaskExists(taskId))
                    return NotFound();

                await _taskService.DeleteTask(taskId);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
