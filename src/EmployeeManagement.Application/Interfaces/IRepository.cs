namespace EmployeeManagement.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetAsync(int id);

    Task<T?> AddAsync(T entity);

    Task<T?> UpdateAsync(T entity);

    Task DeleteAsync(int id);
}
