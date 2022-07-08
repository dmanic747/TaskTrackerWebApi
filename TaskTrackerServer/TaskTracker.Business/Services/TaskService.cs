using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Business.Interfaces;
using TaskTracker.Business.DTOs;
using TaskTracker.Data.Repository;

namespace TaskTracker.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto> CreateTask(TaskDetailsForCreationDto taskDto)
        {
            Data.Models.Task task = await _taskRepository.CreateTask(taskDto.ToEntity());

            return new TaskDto(task);
        }

        public async Task DeleteTask(Guid taskId)
        {
            await _taskRepository.DeleteTask(taskId);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();

            var tasksDto = tasks.Select(task => new TaskDto(task));

            return tasksDto;
        }

        public async Task<TaskDto> GetTaskById(Guid taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);

            TaskDto taskDto = null;

            if (task != null)
                taskDto = new TaskDto(task);

            return taskDto;
        }

        public async Task<bool> IsTaskExists(Guid taskId)
        {
            return await _taskRepository.IsTaskExists(taskId);
        }

        public async Task UpdateTask(TaskDetailsForUpdateDto taskDto)
        {
            await _taskRepository.UpdateTask(taskDto.ToEntity());
        }
    }
}
