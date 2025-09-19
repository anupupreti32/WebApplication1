using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories.SpecificRepositories.SkillSpecificRepositories;
using WebApplication1.Models;
public class SkillSpecificRepositories : ISkillSpecificRepositories 
{
    private readonly PortfolioContext _context;

    public SkillSpecificRepositories(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<Skill> GetSkillName(string skillName)
    {
        return await _context.Skill.Where(skill => skill.SkillName == skillName).FirstOrDefaultAsync();  
    }
}