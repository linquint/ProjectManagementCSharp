using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Interfaces;
using ProjectManagementApp.Data;

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
                    project.Tasks = await TasksService.GetTasksForProject(project.Id);
                }
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

        public override Projects GetProjectData(int id)
        {
            try
            {
                Projects? project = _context.Projects.Find(id);
                if (project != null)
                {
                    return project;
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
