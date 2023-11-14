using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Exceptions;
using CarRental.Services.CarConflictValidators;
using CarRental.Services.CarCreators;
using CarRental.Services.CarProviders;

namespace CarRental.Models
{
    public class CarBook
    {
        private readonly ICarCreator _carCreator;
        private readonly ICarProvider _carProvider;
        private readonly ICarConflictValidator _carConflictValidator;
        public CarBook(ICarCreator carCreator, ICarProvider carProvider, ICarConflictValidator carConflictValidator)
        {
            _carCreator = carCreator;
            _carProvider = carProvider;
            _carConflictValidator = carConflictValidator;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carProvider.GetAllCars();
        }

        public async Task AddCar(Car car)
        {
            Car conflictingCar = await _carConflictValidator.GetConflictingCar(car);

            if (conflictingCar != null)
            {
                throw new CarAddingConflictException(conflictingCar, car);
            }

            await _carCreator.CreateCar(car);
        }
    }
}
