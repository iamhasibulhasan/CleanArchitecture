namespace CleanArchitecture.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}