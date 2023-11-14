using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class RentCar
    {
        private readonly ReservationBook reservationBook;
        private readonly CarBook _carBook;

        public string Name { get; }

        public RentCar(string name, CarBook carBook)
        {
            Name = name;

            reservationBook = new ReservationBook();
            _carBook = carBook;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="userName">The username of the user</param>
        /// <returns>All reservations in the RentCar resetvation book</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservationBook.GetAllReservations();
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carBook.GetAllCars();
        }

        /// <summary>
        /// Make a reservation
        /// </summary>
        /// <param name="reservation">The username of the user</param>
        public void MakeReservation(Reservation reservation)
        {
            reservationBook.AddReservation(reservation);
        }

        public async Task AddNewCar(Car car)
        {
            await _carBook.AddCar(car);
        }
    }
}
