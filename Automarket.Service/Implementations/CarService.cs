using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Responce;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task<IBaseResponce<IEnumerable<Car>>> GetCars()
    {
        var baseResponce = new BaseResponce<IEnumerable<Car>>();
        try
        {
            var cars = await _carRepository.Select();
            if (cars.Count == 0)
            {
                baseResponce.Description = "Not found cars";
                baseResponce.StatusCode = StatusCode.InternalServerError;
                return baseResponce;
            }

            baseResponce.Data = cars;
            baseResponce.StatusCode = StatusCode.OK;
            
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<IEnumerable<Car>>()
            {
                Description = $"[GetCars]: {ex.Message}"
            };
            throw;
        }
    }
}