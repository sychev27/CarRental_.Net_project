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
using CarRental.Stores;
using CarRental.ViewModels;

namespace CarRental.Commands
{
    public class AddNewCarCommand : AsyncCommandBase
    {
        private readonly RentCarStore _rentCarStore;
        private readonly CarAddingViewModel _carAddingViewModel;
        private readonly NavigationService _carAddingViewNavigationService;

        public AddNewCarCommand(CarAddingViewModel carAddingViewModel, RentCarStore rentCarStore, NavigationService carAddingViewNavigationService)
        {
            _rentCarStore = rentCarStore;
            _carAddingViewModel = carAddingViewModel;
            _carAddingViewNavigationService = carAddingViewNavigationService;

            _carAddingViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_carAddingViewModel.CarID))
                OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _carAddingViewModel.CarID > 0 && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Car car = new Car(_carAddingViewModel.SelectedCarType, _carAddingViewModel.SelectedCarColor, _carAddingViewModel.CarID);

            try
            {
                await _rentCarStore.AddNewCar(car);

                MessageBox.Show("Successfully added a car.", "Success",
                                 MessageBoxButton.OK, MessageBoxImage.Information);

                _carAddingViewNavigationService.Navigate();
            }
            catch (CarAddingConflictException)
            {
                MessageBox.Show("This car is already exist.", "Error",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add a new car", "Error",
                 MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
