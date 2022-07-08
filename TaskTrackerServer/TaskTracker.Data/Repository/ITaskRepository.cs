using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Data.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllTasks();
        Task<Models.Task> GetTaskById(Guid taskId);
        Task<Models.Task> CreateTask(Models.Task task);
        Task UpdateTask(Models.Task task);
        Task DeleteTask(Guid taskId);
        Task<bool> IsTaskExists(Guid taskId);

    }
}
