using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Interfaces;

namespace ProjectManagementApp.Data
{
    public class TasksService : ATasksService
    {
        private readonly ProjectManagementContext _context;

        public TasksService(ProjectManagementContext context)
        {
            _context = context;
        }

        public override void AddTask(Tasks task)
        {
            try
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public override void DeleteTask(int id)
        {
            try
            {
                Tasks? task = _context.Tasks.Find(id);
                if (task != null)
                {
                    _context.Tasks.Remove(task);
                }
                else
                {
                    throw new TaskNotFoundException(id);
                }
            }
            catch
            {
                throw;
            }
        }

        public override async Task<List<Tasks>> GetTasksForProject(int projectId)
        {
            try
            {
                return await _context.Tasks
                    .Where(t => t.ProjectId == projectId)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public override void UpdateTask(Tasks task)
        {
            try
            {
                Tasks? OldTask = _context.Tasks.Find(task.Id);
                if (OldTask != null)
                {
                    _context.Entry(OldTask).CurrentValues.SetValues(task);
                    _context.SaveChanges();
                }
                else
                {
                    throw new TaskNotFoundException(task.Id);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
