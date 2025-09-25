using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.WorkExperienceRepositories
{
    public interface IWorkExperienceRepositories
    {
        Task<WorkExperience> GetCompanyName(string CompanyName);

    }
}
