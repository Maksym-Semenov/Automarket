using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL.Repositiories;

public class CarReposytory : ICarRepository
{
    private readonly ApplicationDbContext _db;

    public CarReposytory(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public bool Create(Car entity)
    {
        throw new NotImplementedException();
    }

    public Car Get(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Car>> Select()
    {
        return await _db.Car.ToListAsync();
    }

    public bool Delete(Car entity)
    {
        throw new NotImplementedException();
    }

    public Car GetByName(string name)
    {
        throw new NotImplementedException();
    }
}