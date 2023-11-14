using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.CarConflictValidators
{
    public interface ICarConflictValidator
    {
        Task<Car> GetConflictingCar(Car car);
    }
}
