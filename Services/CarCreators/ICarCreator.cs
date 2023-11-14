using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.CarCreators
{
    public interface ICarCreator
    {
        Task CreateCar(Car car);
    }
}
 