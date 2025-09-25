using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.ProjectRepositories
{
    public interface IProjectRepositories
    {
        Task<Project> GetProjectName(string ProjectName);

    }
}
