using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.SkillRepositories
{
    public class SkillRepositories : ISkillRepositories

    {
        private readonly PortfolioContext _context;
        public SkillRepositories(PortfolioContext context)
        {
            _context = context;

        }

        public async Task<Skill> GetSkillName(string skillName)
        {
            return await _context.Skill.Where(skill => skill.SkillName == skillName).FirstOrDefaultAsync();  //remove the object which is found first. ->FirstOrDefaultAsync
        4
                ,
        }
    }
}
