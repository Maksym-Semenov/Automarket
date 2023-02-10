using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces;

public interface ICarRepository : IBaseRepository<Car>
{
    Car GetByName(string name);
}