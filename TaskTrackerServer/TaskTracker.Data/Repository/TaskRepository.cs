using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskTrackerContext _context;

        public TaskRepository(TaskTrackerContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> CreateTask(Models.Task task)
        {
            task.TaskId = Guid.NewGuid();

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task DeleteTask(Guid taskId)
        {
            var taskToDelete = await _context.Tasks.FindAsync(taskId);

            _context.Tasks.Remove(taskToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            var tasks = await _context.Tasks
                .Include(task => task.Project)
                .ToListAsync();

            return tasks;
        }

        public async Task<Models.Task> GetTaskById(Guid taskId)
        {
            var taskInDb = await _context.Tasks
                .Include(task => task.Project)
                .SingleOrDefaultAsync(task => task.TaskId.Equals(taskId));

            return taskInDb;
        }

        public async Task<bool> IsTaskExists(Guid taskId)
        {
            return await _context.Tasks.AnyAsync(task => task.TaskId.Equals(taskId));
        }

        public async Task UpdateTask(Models.Task task)
        {
            var taskInDb = await _context.Tasks.FindAsync(task.TaskId);

            taskInDb.Name = task.Name;
            taskInDb.Status = task.Status;
            taskInDb.Description = task.Description;
            taskInDb.Priority = task.Priority;

            await _context.SaveChangesAsync();
        }
    }
}
