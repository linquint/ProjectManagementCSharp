using ProjectManagementApp.Data;

namespace ProjectManagementApp.Interfaces
{
    public interface ITaskService
    {
        public interface ITaskService
        {
            Task<List<Tasks>> GetTasksForProject(int projectId);
            void AddTask(Tasks task);
            void UpdateTask(Tasks task);
            void DeleteTask(int id);
        }

        public abstract class ATasksService : ITaskService
        {
            public abstract Task<List<Tasks>> GetTasksForProject(int projectId);
            public abstract void AddTask(Tasks task);
            public abstract void UpdateTask(Tasks task);
            public abstract void DeleteTask(int id);
        }
    }
}
