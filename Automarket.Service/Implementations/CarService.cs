using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Responce;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IBaseResponce<Car>> GetCar(int id)
    {
        var baseResponce = new BaseResponce<Car>();
        try
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                baseResponce.Description = "Car not found";
                baseResponce.StatusCode = StatusCode.CarNotFound;
                return baseResponce;
            }

            baseResponce.Data = car;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<Car>()
            {
                Description = $"[GetCar]: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    
    public async Task<IBaseResponce<Car>> GetCarByName(string name)
    {
        var baseResponce = new BaseResponce<Car>();
        try
        {
            var car = await _carRepository.GetByName(name);
            if (car == null)
            {
                baseResponce.Description = "Car not found";
                baseResponce.StatusCode = StatusCode.CarNotFound;
                return baseResponce;
            }

            baseResponce.Data = car;
            return baseResponce;
        }
        catch (Exception ex)
        {
            return new BaseResponce<Car>()
            {
                Description = $"[GetCarByName]: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponce<bool>> DeleteCar(int id)
    {
        var baseResponce = new BaseResponce<bool>();
        try
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                baseResponce.Description = "Car not found";
                baseResponce.StatusCode = StatusCode.CarNotFound;
                baseResponce.Data = false;
                return baseResponce;
            }

            await _carRepository.Delete(car);
            return baseResponce;

        }
        catch (Exception ex)
        {
            return new BaseResponce<bool>()
            {
                Description = $"[DeleteCar]: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponce<CarViewModel>> CreateCar(CarViewModel carViewModel)
    {
        var baseResponce = new BaseResponce<CarViewModel>();
        try
        {
            var car = new Car()
            {
                Description = carViewModel.Description,
                DateCreate = DateTime.Now,
                Speed = carViewModel.Speed,
                Model = carViewModel.Model,
                Price = carViewModel.Price,
                Name = carViewModel.Name,
                TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
            };
            await _carRepository.Create(car);
            return baseResponce;

        }
        
        catch (Exception ex)
        {
            return new BaseResponce<CarViewModel>()
            {
                Description = $"[CreateCar]: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
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
                Description = $"[GetCars]: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}