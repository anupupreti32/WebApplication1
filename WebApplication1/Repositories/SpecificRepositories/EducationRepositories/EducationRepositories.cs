using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.EducationRepositories
{
    public class EducationRepositories : IEducationRepositories
    {
        private readonly PortfolioContext _context;
        public EducationRepositories(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<Education> GetInstututionName(string instututionName)
        {
            return await _context.Education.Where(education=> education.InstututionName == instututionName).FirstOrDefaultAsync();
        }
    }
}
