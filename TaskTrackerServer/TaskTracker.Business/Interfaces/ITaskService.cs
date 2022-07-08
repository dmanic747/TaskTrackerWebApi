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
        Task<TaskDto> CreateTask(TaskDetailsForCreationDto task);
        Task UpdateTask(TaskDetailsForUpdateDto task);
        Task DeleteTask(Guid taskId);

        Task<bool> IsTaskExists(Guid taskId);
    }
}
