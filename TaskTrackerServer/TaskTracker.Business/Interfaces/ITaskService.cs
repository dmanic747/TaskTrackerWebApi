using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Business.DTOs;

namespace TaskTracker.Business.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<TaskDto> GetTaskById(Guid taskId);
        Task<TaskDto> CreateTask(TaskForCreationDto task);
        Task UpdateTask(TaskForUpdateDto task);
        Task DeleteTask(Guid taskId);
    }
}
