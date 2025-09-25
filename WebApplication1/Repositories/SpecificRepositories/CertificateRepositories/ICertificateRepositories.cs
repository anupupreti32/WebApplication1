using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.CertificateRepositories
{
    public interface ICertificateRepositories
    {
        Task<Certificate> GetCertificateName(string CertificateName);

    }
}
