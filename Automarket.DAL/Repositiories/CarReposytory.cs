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
    
    public async Task<bool> Create(Car entity)
    {
       await _db.Car.AddAsync(entity);
       await _db.SaveChangesAsync();

       return true;
    }

    public async Task<Car> Get(int id)
    {
        return await _db.Car.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Car>> Select()
    {
        return await _db.Car.ToListAsync();
    }

    public async Task<bool> Delete(Car entity)
    {
        _db.Car.Remove(entity);
        _db.SaveChangesAsync();

        return true;
    }

    public async Task<Car> GetByName(string name)
    {
        return await _db.Car.FirstOrDefaultAsync(x => x.Name == name);
    }
}