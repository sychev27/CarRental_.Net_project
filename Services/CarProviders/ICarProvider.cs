using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.CarProviders
{
    public  interface ICarProvider
    {
        Task<IEnumerable<Car>> GetAllCars();
    }
}
