using CarRental.Models;
using CarRental.Stores;
using CarRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRental.Commands
{
    public class LoadCarsCommand : AsyncCommandBase
    {
        private readonly RentCarStore _rentCarStore;
        private readonly CarListingViewModel _carListingViewModel;

        public LoadCarsCommand(CarListingViewModel carListingViewModel, RentCarStore rentCarStore)
        {
            _carListingViewModel = carListingViewModel;
            _rentCarStore = rentCarStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _carListingViewModel.IsLoading = true;

            try
            {
                await _rentCarStore.Load();

                _carListingViewModel.UpdateCars(_rentCarStore.Cars);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load cars", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _carListingViewModel.IsLoading = false;
        }
    }
}
