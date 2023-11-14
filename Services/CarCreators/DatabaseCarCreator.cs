using CarRental.DbContexts;
using CarRental.DTOs;
using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.CarCreators
{
    public class DatabaseCarCreator : ICarCreator
    {
        private readonly CarRentalDbContextFactory _dbContextFactory;

        public DatabaseCarCreator(CarRentalDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateCar(Car car)
        {
            using (CarRentalDbContext context = _dbContextFactory.CreateDbContext())
            {
                CarDTO carDTO = ToCarDTO(car);

                context.Cars.Add(carDTO);
                await context.SaveChangesAsync();
            }
        }

        private CarDTO ToCarDTO(Car car)
        {
            return new CarDTO()
            {
            CarType = car.CarType,
            CarColor = car.CarColor,
            CarID = car.CarID
            };
        }
    }
}
