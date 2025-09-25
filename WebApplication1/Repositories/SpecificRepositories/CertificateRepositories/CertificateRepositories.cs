using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories.SpecificRepositories.CertificateRepositories
{
    public class CertificateRepositories : ICertificateRepositories
    {
        private readonly PortfolioContext _context;
        public CertificateRepositories(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<Certificate> GetCertificateName(string certificateName)
        {
            return await _context.Certificate.Where(certificate => certificate.CertificateName == certificateName).FirstOrDefaultAsync();
        }
    }
}
