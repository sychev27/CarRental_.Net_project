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
    // ViewModel responsible for managing the list of cars
    public class CarListingViewModel : ViewModelBase
    {
        // Collection of CarViewModel instances representing the list of cars
        private readonly ObservableCollection<CarViewModel> _cars;

        // Exposes the list of cars for data binding
        public IEnumerable<CarViewModel> Cars => _cars;

        // ViewModel for adding new cars
        public CarAddingViewModel CarAddingViewModel { get; }

        // Indicates whether the ViewModel is currently loading data
        private bool isLoading;

        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        // Command for adding a new car, bound to the makeCarAddingViewNavigationService
        public ICommand AddNewCarCommand { get; }

        // Command for loading the list of cars, bound to the rentCarStore
        public ICommand LoadCarsCommand { get; }

        // Command for navigating to the reservation view, bound to the makeListForReservationViewNavigationService
        public ICommand ReservationCarCommand { get; }

        // Command for canceling the current operation, bound to the makeStartWindowViewNavigationService
        public ICommand CancelCommand { get; }

        public CarListingViewModel(RentCarStore rentCarStore, CarAddingViewModel carAddingViewModel, NavigationService makeListForReservationViewNavigationService, NavigationService makeCarAddingViewNavigationService, NavigationService makeStartWindowViewNavigationService)
        {
            _cars = new ObservableCollection<CarViewModel>();

            CarAddingViewModel = carAddingViewModel;

            LoadCarsCommand = new LoadCarsCommand(this, rentCarStore);

            AddNewCarCommand = new NavigateCommand(makeCarAddingViewNavigationService);

            ReservationCarCommand = new NavigateCommand(makeListForReservationViewNavigationService);

            CancelCommand = new NavigateCommand(makeStartWindowViewNavigationService);
        }

        // Static method to load and create a new instance of CarListingViewModel
        public static CarListingViewModel LoadCarListingViewModel(RentCarStore rentCarStore, CarAddingViewModel carAddingViewModel, NavigationService makeListForReservationViewNavigationService, NavigationService makeCarAddingViewNavigationService, NavigationService makeStartWindowViewNavigationService)
        {
            CarListingViewModel carListingViewModel = new CarListingViewModel(rentCarStore, carAddingViewModel, makeListForReservationViewNavigationService, makeCarAddingViewNavigationService, makeStartWindowViewNavigationService);

            carListingViewModel.LoadCarsCommand.Execute(null);

            return carListingViewModel;
        }

        // Method to update the list of cars
        public void UpdateCars(IEnumerable<Car> cars)
        {
            _cars.Clear();

            // Create CarViewModel instances for each car and add to the collection
            foreach (Car car in cars)
            {
                CarViewModel carViewModel = new CarViewModel(car);
                _cars.Add(carViewModel);
            }
        }
    }
}

