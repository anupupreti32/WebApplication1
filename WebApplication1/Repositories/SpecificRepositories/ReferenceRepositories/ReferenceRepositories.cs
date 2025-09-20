using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Repositories.SpecificRepositories.ReferenceRepositories
{
    public class ReferenceRepositories: IReferenceRepositories
    {
        private readonly PortfolioContext _context;
        public ReferenceRepositories(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<Reference> GetReferenceName(string referenceName)
        {
            //return await _context
            return await _context.Reference.Where(reference => reference.ReferenceName == referenceName).FirstOrDefaultAsync();

        }
    }
}
