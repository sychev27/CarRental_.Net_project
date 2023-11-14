using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarRental.Commands;
using CarRental.Services;

namespace CarRental.ViewModels
{
    public class StartWindowViewModel : ViewModelBase
    {
        public ICommand AddNewCarCommand { get; }
        public ICommand CarListCommand { get; }
        public ICommand ReservationCarCommand { get; }
        public ICommand ReservationListCommand { get; }

        public StartWindowViewModel(NavigationService makeListForReservationViewNavigationService,
                                    NavigationService makeCarAddingViewNavigationService,
                                    NavigationService makeCarListingViewNavigationService,
                                    NavigationService makeReservationListingViewNavigationService)
        {
            ReservationCarCommand = new NavigateCommand(makeListForReservationViewNavigationService);
            AddNewCarCommand = new NavigateCommand(makeCarAddingViewNavigationService);
            CarListCommand = new NavigateCommand(makeCarListingViewNavigationService);
            ReservationListCommand = new NavigateCommand(makeReservationListingViewNavigationService);
        }

    }
}
