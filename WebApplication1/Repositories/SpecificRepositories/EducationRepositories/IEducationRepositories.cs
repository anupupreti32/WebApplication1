using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.EducationRepositories
{
    public interface IEducationRepositories
    {
        Task<Education> GetInstututionName(string InstutionName);
    }
}
