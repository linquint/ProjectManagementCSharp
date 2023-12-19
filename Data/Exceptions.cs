namespace ProjectManagementApp.Data
{
    [Serializable]
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException() : base("Project not found") { }
        public ProjectNotFoundException(int id)
        : base(String.Format($"Invalid Project Id: {id}"))
        {
        }
    }

    [Serializable]
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() : base("Task not found") { }
        public TaskNotFoundException(int id) : base(String.Format($"Invalid Task Id: {id}")) { }
    }

    [Serializable]
    public class ProjectStatusChangeException : Exception
    {
        public ProjectStatusChangeException(string status) : base($"Project status cannot be changed to {status}") { }
    }
}
