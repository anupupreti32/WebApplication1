using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.SkillSpecificRepositories;

public interface ISkillSpecificRepositories
{
    Task<Skill> GetSkillName(string skillName);
}