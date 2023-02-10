using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces;

public interface IBaseRepository<T>
{
    bool Create(T entity);
    T Get(int Id);
    Task<List<T>> Select();
    bool Delete(T entity);
}