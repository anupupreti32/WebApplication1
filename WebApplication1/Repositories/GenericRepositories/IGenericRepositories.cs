namespace WebApplication1.Repositories.GenericRepositories
{
    public interface IGenericRepositories
    {
        Task<T> GetbyID<T>(int id) where T : class;
    }
}