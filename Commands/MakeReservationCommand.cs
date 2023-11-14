using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRental.Exceptions;
using CarRental.Models;
using CarRental.Services;
using CarRental.ViewModels;

namespace CarRental.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly RentCar _rentCar;
        private readonly ListForReservationViewModel _listForReservationViewModel;
        private readonly NavigationService _reservationViewNavigationService;
        public MakeReservationCommand(ListForReservationViewModel listForReservationViewModel, RentCar rentCar, NavigationService reservationViewNavigationService)
        {
            _rentCar = rentCar;
            _listForReservationViewModel = listForReservationViewModel;
            _reservationViewNavigationService = reservationViewNavigationService;

            _listForReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_listForReservationViewModel.Username) ||
                e.PropertyName == nameof(_listForReservationViewModel.SelectedCar) ||
                e.PropertyName == nameof(_listForReservationViewModel.UserID))

                OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_listForReservationViewModel.Username) &&
                   _listForReservationViewModel.Username.All(char.IsLetter) &&
                   _listForReservationViewModel.SelectedCar != null &&
                   _listForReservationViewModel.UserID > 0 && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Reservation reservation = new Reservation(new Car(_listForReservationViewModel.SelectedCar.CarType,
                                                              _listForReservationViewModel.SelectedCar.CarColor,
                                                              _listForReservationViewModel.SelectedCar.CarID),
                                                      _listForReservationViewModel.Username,
                                                      _listForReservationViewModel.UserID,
                                                      _listForReservationViewModel.StartDate,
                                                      _listForReservationViewModel.EndDate);
            try
            {
                _rentCar.MakeReservation(reservation);
                MessageBox.Show("Successfully reserved car.", "Success",
                                 MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This car is already taken.", "Error",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
