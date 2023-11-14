using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Reservation
    {
        public Car Car { get; }
        public string UserName { get; }
        public int UserID { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public TimeSpan Length => EndDate.Subtract(StartDate);

        public Reservation(Car car, string userName, int userID, DateTime startDate, DateTime endDate)
        {
            Car = car;
            UserName = userName;
            UserID = userID;
            StartDate = startDate;
            EndDate = endDate;
        }

        internal bool Conflicts(Reservation reservation)
        {
            if (reservation.Car != Car)
                return false;

            return (reservation.StartDate >= StartDate && reservation.StartDate <= EndDate) ||
                   (reservation.EndDate >= StartDate && reservation.EndDate <= EndDate) ||
                   (reservation.EndDate <= reservation.StartDate) || (reservation.StartDate < StartDate && reservation.EndDate > EndDate);
        }
    }
}
