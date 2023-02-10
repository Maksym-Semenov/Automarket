using Automarket.DAL.Interfaces;
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
    public async Task<IActionResult> GetCars()
    {
        var responce = await _carRepository.Select();
        return View(responce);
    }
}