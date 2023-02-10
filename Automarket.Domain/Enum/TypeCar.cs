using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum;

public enum TypeCar
{
    [Display(Name = "Passenger car")]
    PassengerCar,
    [Display(Name = "Sedan")]
    Sedan,
    [Display(Name = "Hatchback")]
    Hatchback,
    [Display(Name = "Minivan")]
    Minivan,
    [Display(Name = "Sports car")]
    Sportscar,
    [Display(Name = "SUV")]
    Suv
}