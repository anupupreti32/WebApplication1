using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.ProjectRepositories
{
    public class ProjectRepositories : IProjectRepositories
    {
        private readonly PortfolioContext _context;
        public ProjectRepositories(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<Project> GetProjectName (string projectName)
        {
            return await _context.Project.Where(project => project.ProjectName == projectName).FirstOrDefaultAsync();
        }
    }
}
