using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRental.Commands;
using CarRental.Models;
using CarRental.Services;
using CarRental.Stores;

namespace CarRental.ViewModels
{
    // ViewModel responsible for managing and displaying a list of reservations
    public class ReservationListingViewModel : ViewModelBase
    {
        // Collection of ReservationViewModels representing reservations
        private readonly ObservableCollection<ReservationViewModel> reservations;

        // RentCar instance for interacting with reservation data
        private readonly RentCar _rentCar;

        // Property exposing the list of reservations for data binding
        public IEnumerable<ReservationViewModel> Reservations => reservations;

        // Command for navigating to the reservation creation view
        public ICommand MakeReservationCommand { get; }

        // Command for navigating back to the main window
        public ICommand CancelCommand { get; }

        public ReservationListingViewModel(RentCar rentCar, NavigationService makeReservationViewNavigationService, NavigationService makeStartWindowViewNavigationService)
        {
            _rentCar = rentCar;
            reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationViewNavigationService);

            CancelCommand = new NavigateCommand(makeStartWindowViewNavigationService);

            UpdateReservations();
        }

        // Method to update the reservations collection with current reservation data
        private void UpdateReservations()
        {
            reservations.Clear();

            // Fetch all reservations and create corresponding ReservationViewModels
            foreach (Reservation reservation in _rentCar.GetAllReservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                reservations.Add(reservationViewModel);
            }
        }
    }

}


