
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.SkillRepositories
{
    public interface ISkillRepositories
    {
        Task<Skill>GetSkillName(string skillName);

    }
}
