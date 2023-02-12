using Automarket.Domain.Enum;

namespace Automarket.Domain.ViewModels.Car;

public class CarViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }   
    public string? Model { get; set; }   
    public int? Speed { get; set; }   
    public decimal? Price { get; set; }   
    public DateTime? DateCreate { get; set; }   
    public TypeCar? TypeCar { get; set; }
}