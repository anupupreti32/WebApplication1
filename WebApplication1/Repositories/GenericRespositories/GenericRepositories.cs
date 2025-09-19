using WebApplication1.Models;
namespace WebApplication1.Repositories.GenericRespositories;

public class GenericRepositories : IGenericRepositories
{
    private readonly PortfolioContext _context;

    public GenericRepositories(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<T> GetbyID<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }
}