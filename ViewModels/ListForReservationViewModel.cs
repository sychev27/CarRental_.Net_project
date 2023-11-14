using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    // ViewModel responsible for managing the list of cars available for reservation
    public class ListForReservationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        // Collection of CarViewModels representing the list of cars for reservation
        private readonly ObservableCollection<CarViewModel> carsToReservation;

        // Services and dependencies
        private readonly RentCar _rentCar;
        private readonly RentCarStore _rentCarStore;

        // Exposes the IEnumerable<CarViewModel> for external access
        public IEnumerable<CarViewModel> CarsToReservation => carsToReservation;

        // Selected car for reservation
        private CarViewModel selectedCar;
        public CarViewModel SelectedCar
        {
            get
            {
                return selectedCar;
            }
            set
            {
                selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        // User's name for the reservation
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));

                ClearErrors(nameof(Username));

                // Validate that the name contains only letters
                if (!Username.All(char.IsLetter))
                {
                    AddError("The name cannot contain numbers.", nameof(Username));
                }
            }
        }

        // User's ID for the reservation
        private int userID;
        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        // Start date for the reservation
        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));

                // Validate start and end date logic
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));

                if (EndDate.Date < StartDate.Date)
                {
                    AddError("The start date cannot be after the end date.", nameof(StartDate));
                }

                // Trigger update of cars for reservation
                _ = UpdateCarsToReservation();
            }
        }

        // End date for the reservation
        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));

                // Validate start and end date logic
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));

                if (EndDate.Date < StartDate.Date)
                {
                    AddError("The end date cannot be before the start date.", nameof(EndDate));
                }

                // Trigger update of cars for reservation
                _ = UpdateCarsToReservation();
            }
        }

        // Command for making a reservation
        public ICommand ReservationCommand { get; }

        // Command for canceling the reservation process
        public ICommand CancelCommand { get; }

        // Dictionary to track validation errors for each property
        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        // Indicates whether there are validation errors
        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        // Event raised when validation errors change
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        // Constructor to initialize the ViewModel with dependencies
        public ListForReservationViewModel(
            RentCar rentCar,
            RentCarStore rentCarStore,
            NavigationService makeReservationListingViewNavigationService,
            NavigationService makeStartWindowViewNavigationService)
        {
            _rentCar = rentCar;
            _rentCarStore = rentCarStore;
            carsToReservation = new ObservableCollection<CarViewModel>();
            ReservationCommand = new MakeReservationCommand(this, rentCar, makeReservationListingViewNavigationService);
            CancelCommand = new NavigateCommand(makeStartWindowViewNavigationService);

            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();

            // Initial update of cars for reservation
            _ = UpdateCarsToReservation();
        }

        // Method to asynchronously update the list of cars available for reservation
        private async Task UpdateCarsToReservation()
        {
            carsToReservation.Clear();

            // Check if the start date is after or equal to the end date
            if (StartDate.Day >= EndDate.Day)
                return;

            bool reservationConflict;

            // Load cars from the store
            await _rentCarStore.Load();

            // Retrieve loaded cars
            var loadedCars = _rentCarStore.Cars;

            // Iterate through each car and check for reservation conflicts
            foreach (Car car in loadedCars)
            {
                reservationConflict = false;
                foreach (Reservation reservation in _rentCar.GetAllReservations())
                {
                    // Check if there is a conflict with the reservation dates
                    if (car == reservation.Car && DateConflict(StartDate, EndDate, reservation.StartDate, reservation.EndDate))
                        reservationConflict = true;
                }
                // If no conflict, add the car to the collection
                if (!reservationConflict)
                {
                    CarViewModel carViewModel = new CarViewModel(car);
                    carsToReservation.Add(carViewModel);
                }
            }
        }

        // Method to check for date conflict between two date ranges
        private bool DateConflict(DateTime startDate1, DateTime endDate1, DateTime startDate2, DateTime endDate2)
        {
            return (startDate1 >= startDate2 && startDate1 <= endDate2) ||
                   (endDate1 >= startDate2 && endDate1 <= endDate2) ||
                   (endDate1 <= startDate1) || (startDate1 < startDate2 && endDate1 > endDate2);
        }

        // Method to get validation errors for a specific property
        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

        // Method to add a validation error for a specific property
        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }

            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

            // Notify subscribers about the change in validation errors
            OnErrorsChanged(propertyName);
        }

        // Method to clear validation errors for a specific property
        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);

            // Notify subscribers about the change in validation errors
            OnErrorsChanged(propertyName);
        }

        // Method to notify subscribers about the change in validation errors for a specific property
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}

