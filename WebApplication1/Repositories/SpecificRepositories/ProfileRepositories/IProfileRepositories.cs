using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.ProfileRepositories
{
    public interface IProfileRepositories
    {
        Task<Profile> GetProfileName(string ProfileName);

    }

}
