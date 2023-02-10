using Automarket.Domain.Entity;
using Automarket.Domain.Responce;

namespace Automarket.Service.Interfaces;

public interface ICarService
{
    Task<IBaseResponce<IEnumerable<Car>>> GetCars();
    
}