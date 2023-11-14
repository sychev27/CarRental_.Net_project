using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Stores
{
    public class RentCarStore
    {
        private readonly RentCar _rentCar;
        private readonly Lazy<Task> _initialineLazy;
        private readonly List<Car> _cars;

        public IEnumerable<Car> Cars => _cars;

        public RentCarStore(RentCar rentCar)
        {
            _rentCar = rentCar;
            _initialineLazy = new Lazy<Task>(Initialize);

            _cars = new List<Car>();
        }

        public async Task Load()
        {
            await _initialineLazy.Value;
        }

        public async Task AddNewCar(Car car)
        {
            await _rentCar.AddNewCar(car);

            _cars.Add(car);
        }

        private async Task Initialize()
        {
            IEnumerable<Car> cars = await _rentCar.GetAllCars();

            _cars.Clear();
            _cars.AddRange(cars);
        }
    }
}
