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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(
            ITaskService taskService, 
            IProjectService projectService, 
            ILogger<TasksController> logger)
        {
            _taskService = taskService;
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasks();

                _logger.LogInformation("Returned {count} tasks from database", tasks.Count());

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside GetAllTasks action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            try
            {
                var taskDto = await _taskService.GetTaskById(id);

                if (taskDto == null)
                {
                    _logger.LogError("Task with id: {taskId} hasn't been found in db", id);
                    return NotFound();
                }

                _logger.LogInformation("Returned task with id: {taskId}", id);

                return Ok(taskDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside GetTaskById action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDetailsForCreationDto task)
        {
            try
            {
                if (task == null)
                {
                    _logger.LogError("Task object sent from the client is null");
                    return BadRequest("Task object is null");
                }

                if (!_projectService.IsProjectExists(task.ProjectId))
                {
                    _logger.LogError("Project with id: {projectId} hasn't been found in db", task.ProjectId);
                    return BadRequest("Project doesn't exist");
                }

                var taskDto = await _taskService.CreateTask(task);

                _logger.LogInformation("Created new task with the id: {taskId}", taskDto.Id);

                return CreatedAtAction(nameof(GetTaskById), new { id = taskDto.Id }, taskDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside CreateTask action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] TaskDetailsForUpdateDto task)
        {
            try
            {
                if (task == null)
                {
                    _logger.LogError("Task object sent from the client is null");
                    return BadRequest("Task object is null");
                }

                if (taskId != task.TaskId)
                {
                    _logger.LogError("TaskId route parameter is different than object's taskId");
                    return BadRequest("Route parameter taskId and object's taskId do not match");
                }

                if (!await _taskService.IsTaskExists(taskId))
                {
                    _logger.LogError("Task with id: {taskId} hasn't been found in db", taskId);
                    return NotFound();
                }

                await _taskService.UpdateTask(task);

                _logger.LogInformation("Updated existing task with the id: {taskId}", task.TaskId);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside UpdateTask action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            try
            {
                if (!await _taskService.IsTaskExists(taskId))
                {
                    _logger.LogError("Task with id: {taskId} hasn't been found in db", taskId);
                    return NotFound();
                }

                await _taskService.DeleteTask(taskId);

                _logger.LogInformation("Deleted existing task with the id: {taskId}", taskId);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong inside DeleteTask action: {message}", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
