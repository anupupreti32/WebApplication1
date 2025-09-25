using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.WorkExperienceRepositories
{
    public class WorkExperienceRepositories : IWorkExperienceRepositories
    {
        private readonly PortfolioContext _context;
        public WorkExperienceRepositories(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<WorkExperience> GetCompanyName(string companyName)
        {
            return await _context.WorkExperience.Where(workExperience => workExperience.CompanyName == companyName).FirstOrDefaultAsync();
        }
    }
}
