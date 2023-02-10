using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers;

public class CarController : Controller
{
    private readonly ICarRepository _carRepository;

    public CarController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var responce = await _carRepository.Select();
        var responce1 = await _carRepository.GetByName("BMW");
        var responce2 = await _carRepository.Get(3);

        var car = new Car()
        {
            Id = 6,
            Name = "Opel",
            Model = "Calibra",
            Description = "By Opel",
            DateCreate = DateTime.Now,
            Price = 14000
        }; 
        await _carRepository.Create(car);
        await _carRepository.Delete(car);
        return View(responce);
    }
}