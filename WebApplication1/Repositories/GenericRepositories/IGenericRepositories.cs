namespace WebApplication1.Repositories.GenericRepositories
{
    public interface IGenericRepositories
    {
        Task<T> GetbyID<T>(int id) where T : class; // where <T> is class and getbyid is a method. : -> is so T is a class

    }
}
