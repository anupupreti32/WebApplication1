namespace WebApplication1.Repositories.GenericRespositories
{
    public interface IGenericRepositories
    {
        Task<T> GetbyID<T>(int id) where T : class;
    }
}