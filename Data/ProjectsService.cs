using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Interfaces;

namespace ProjectManagementApp.Data
{
    public class ProjectsService : ProjectService
    {
        private readonly ProjectManagementContext _context;

        public ProjectsService(ProjectManagementContext context)
        {
            _context = context;
        }

        public override async Task<List<Projects>> GetProjects(string UserId)
        {
            try
            {
              List<Projects> projects = await _context.Projects
                .Where(p => p.CreatedBy == UserId)
                .ToListAsync();
              foreach (Projects project in projects)
              {
                TasksService tasksService = new (_context);
                project.Tasks = await tasksService.GetTasksForProject(project.Id);
              }
              return projects;
            }
            catch
            {
              throw;
            }
        }

        public override void AddProject(Projects project)
        {
            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public override void UpdateProject(Projects newProject)
        {
            try
            {
                Projects? OldProject = _context.Projects.Find(newProject.Id);
                if (OldProject != null)
                {
                    if (OldProject.ProjectStatus < 2 && newProject.ProjectStatus == 2 && newProject.TasksCompleted < newProject.TaskCount)
                    {
                        throw new ProjectStatusChangeException(newProject.StatusAsString);
                    }
                    {
                        newProject.DateDue = DateTime.Now;
                    }
                    _context.Entry(OldProject).CurrentValues.SetValues(newProject);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ProjectNotFoundException();
                }
            }
            catch
            {
                throw;
            }
        }

        public override async Task<Projects> GetProjectData(int id)
        {
            try
            {
                Projects? project = await _context.Projects.FindAsync(id);
                if (project != null)
                {
                    TasksService tasksService = new (_context);
                    project.Tasks = await tasksService.GetTasksForProject(project.Id);
                    return project;
                }
                else
                {
                    throw new ProjectNotFoundException(id);
                }
            }
            catch
            {
                throw;
            }
        }

        public override void DeleteProject(int id)
        {
            try
            {
                Projects? project = _context.Projects.Find(id);
                if (project != null)
                {
                    _context.Projects.Remove(project);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
