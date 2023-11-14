using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Exceptions
{
    public class CarAddingConflictException : Exception
    {
        public Car ExistingCar { get; }
        public Car IncomingCar { get; }
        public CarAddingConflictException(Car existingCar, Car incomingCar)
        {
            ExistingCar = existingCar;
            IncomingCar = incomingCar;
        }
    }
}