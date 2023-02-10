using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Automarket.Domain.Enum;

namespace Automarket.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var responce = await _carService.GetCars();
        if (responce.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(responce.Data);
        }

        return RedirectToAction("Error");
        /*var responce = await _carRepository.Select();
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
        await _carRepository.Delete(car);*/
    }

    public IActionResult Error()
    {
        throw new NotImplementedException();
    }
}