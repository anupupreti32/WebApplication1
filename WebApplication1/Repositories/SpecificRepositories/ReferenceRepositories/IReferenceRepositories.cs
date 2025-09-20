//using System.Security.Cryptography.Xml;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.ReferenceRepositories
{
    public interface IReferenceRepositories
    {
        Task<Reference> GetReferenceName(string referenceName);
    }
}
