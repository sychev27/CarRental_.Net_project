using CarRental.DbContexts;
using CarRental.DTOs;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.CarConflictValidators
{
    public class DatabaseCarConflictValidator : ICarConflictValidator
    {
        private readonly CarRentalDbContextFactory _dbContextFactory;

        public DatabaseCarConflictValidator(CarRentalDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Car> GetConflictingCar(Car car)
        {
            using (CarRentalDbContext context = _dbContextFactory.CreateDbContext())
            {
                CarDTO carDTO = await context.Cars
                      .Where(c => c.CarID == car.CarID)
                      .FirstOrDefaultAsync();

                if(carDTO == null)
                {
                    return null;
                }  

                return ToCar(carDTO);
            }
        }

        private static Car ToCar(CarDTO dto)
        {
            return new Car(dto.CarType, dto.CarColor, dto.CarID);
        }
    }
}
