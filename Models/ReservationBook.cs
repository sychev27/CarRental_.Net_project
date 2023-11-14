using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Exceptions;

namespace CarRental.Models
{
    class ReservationBook
    {
        private List<Reservation> reservations;

        public ReservationBook()
        {
            reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in reservations)
            {
                if (existingReservation.Conflicts(reservation))
                    throw new ReservationConflictException(existingReservation, reservation);
            }

            reservations.Add(reservation);
        }
    }
}
