using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarRental.DbContexts;
using CarRental.Exceptions;
using CarRental.Models;
using CarRental.Services;
using CarRental.Services.CarConflictValidators;
using CarRental.Services.CarCreators;
using CarRental.Services.CarProviders;
using CarRental.Stores;
using CarRental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarRental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=carrental.db";
        private readonly RentCar rentCar;
        private readonly RentCarStore rentCarStore;
        private readonly NavigationStore navigationStore;
        CarRentalDbContextFactory _carRentalDbContextFactory;

        public App()
        {
            _carRentalDbContextFactory = new CarRentalDbContextFactory(CONNECTION_STRING);
            ICarCreator carCreator = new DatabaseCarCreator(_carRentalDbContextFactory);
            ICarProvider carProvider = new DatabaseCarProvider(_carRentalDbContextFactory);
            ICarConflictValidator carConflictValidator = new DatabaseCarConflictValidator(_carRentalDbContextFactory);

            CarBook carBook = new CarBook(carCreator, carProvider, carConflictValidator);

            rentCar = new RentCar("Avis", carBook);
            rentCarStore = new RentCarStore(rentCar);
            navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (CarRentalDbContext dbContext = _carRentalDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            navigationStore.CurrentViewModel = CreateStartWindowViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private ReservationListingViewModel CreateReservationListingViewModel()
        {
            return new ReservationListingViewModel(rentCar, new NavigationService(navigationStore, CreateListForReservationViewModel), new NavigationService(navigationStore, CreateStartWindowViewModel));
        }

        private StartWindowViewModel CreateStartWindowViewModel()
        {
            return new StartWindowViewModel(new NavigationService(navigationStore, CreateListForReservationViewModel),
                                            new NavigationService(navigationStore, CreateCarAddingViewModel),
                                            new NavigationService(navigationStore, CreateCarListingViewModel),
                                            new NavigationService(navigationStore, CreateReservationListingViewModel));
        }

        private CarAddingViewModel CreateCarAddingViewModel()
        {
            return new CarAddingViewModel(rentCarStore, new NavigationService(navigationStore, CreateCarListingViewModel), new NavigationService(navigationStore, CreateStartWindowViewModel));
        }

        private CarListingViewModel CreateCarListingViewModel()
        {
            return CarListingViewModel.LoadCarListingViewModel(rentCarStore, CreateCarAddingViewModel(), new NavigationService(navigationStore, CreateListForReservationViewModel),
                                           new NavigationService(navigationStore, CreateCarAddingViewModel),
                                           new NavigationService(navigationStore, CreateStartWindowViewModel));
        }

        private ListForReservationViewModel CreateListForReservationViewModel()
        {
            return new ListForReservationViewModel(rentCar, rentCarStore, new NavigationService(navigationStore, CreateReservationListingViewModel), new NavigationService(navigationStore, CreateStartWindowViewModel));
        }
    }
}
