using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public enum CarType { Toyota, Mazda, Suzuki, Mercede, BMW, Kia, Hunday, Opel };
    public enum CarColor { Black, White, Red, Green, Blue, Gray, Brown };
    public class Car
    {
        public CarType CarType { get; }
        public CarColor CarColor { get; }
        public int CarID { get; }
        public Car(CarType carType, CarColor carColor, int carID)
        {
            CarColor = carColor;
            CarType = carType;
            CarID = carID;
        }

        public override bool Equals(object obj)
        {
            return obj is Car car &&
                   car.CarID == CarID;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(CarType, CarID);
        }
        public override string ToString()
        {
            return $"{CarType} {CarID}";
        }

        public bool Conflicts(Car car)
        {
            return this == car;
        }

        public static bool operator ==(Car car1, Car car2)
        {
            if (car1 is null && car2 is null)
                return true;

            return !(car1 is null) && car1.Equals(car2);
        }
        public static bool operator !=(Car car1, Car car2)
        {
            return !(car1 == car2);
        }

    }
}
