using ProjectManagementApp.Data;

namespace ProjectManagementApp.Interfaces
{
    public enum Status
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Cancelled = 3
    }

    public interface IProjectService
    {
        Task<List<Projects>> GetProjects(string UserId);
        void AddProject(Projects project);
        void UpdateProject(Projects project);
        Task<Projects> GetProjectData(int id);
        void DeleteProject(int id);
    }

    public abstract class ProjectService : IProjectService
    {
        public abstract Task<List<Projects>> GetProjects(string UserId);
        public abstract void AddProject(Projects project);
        public abstract void UpdateProject(Projects project);
        public abstract Task<Projects> GetProjectData(int id);
        public abstract void DeleteProject(int id);
    }
}
