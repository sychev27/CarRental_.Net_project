using CarRental.DbContexts;
using CarRental.DTOs;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Services.CarProviders
{
    public class DatabaseCarProvider : ICarProvider
    {
        private readonly CarRentalDbContextFactory _dbContextFactory;

        public DatabaseCarProvider(CarRentalDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Retrieves all cars from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result is an enumerable collection of cars.
        /// </returns>
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            // Create a new instance of the CarRentalDbContext using the factory.
            using (CarRentalDbContext context = _dbContextFactory.CreateDbContext())
            {
                // Asynchronously retrieve all CarDTOs from the Cars table and materialize the results into a list.
                IEnumerable<CarDTO> carDTOs = await context.Cars.ToListAsync();

                await Task.Delay(2000);

                return carDTOs.Select(carDTO => ToCar(carDTO));
            }
        }


        private static Car ToCar(CarDTO carDTO)
        {
            return new Car(carDTO.CarType, carDTO.CarColor, carDTO.CarID);
        }
    }
}
