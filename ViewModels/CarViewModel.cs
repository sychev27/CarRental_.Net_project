using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.ViewModels
{
    public class CarViewModel : ViewModelBase
    {
        private readonly Car _car;

        public CarType CarType => _car.CarType;
        public CarColor CarColor => _car.CarColor;
        public int CarID => _car.CarID;

        public CarViewModel(Car car)
        {
            _car = car;
        }
    }
}
