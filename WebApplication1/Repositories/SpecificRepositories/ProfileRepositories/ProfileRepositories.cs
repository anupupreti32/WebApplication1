using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.ProfileRepositories
{
    public class ProfileRepositories : IProfileRepositories
    {
        private readonly PortfolioContext _context;
        public ProfileRepositories(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<Profile> GetProfileName(string profileName)
        {
            return await _context.Profile.Where(profile => profile.ProfileName == profileName).FirstOrDefaultAsync();

        }
    }
}
