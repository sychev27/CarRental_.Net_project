using System;
using System.Collections.Generic;
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
    // ViewModel responsible for managing the addition of new cars
    public class CarAddingViewModel : ViewModelBase
    {
        // Property exposing all available car types for data binding
        public IEnumerable<CarType> AllTypes
        {
            get
            {
                return Enum.GetValues(typeof(CarType)).Cast<CarType>().ToList();
            }
        }

        // Property exposing all available car colors for data binding
        public IEnumerable<CarColor> AllColors
        {
            get
            {
                return Enum.GetValues(typeof(CarColor)).Cast<CarColor>().ToList();
            }
        }

        // Property representing the selected car color
        private CarColor selectedCarColor;

        public CarColor SelectedCarColor
        {
            get
            {
                return selectedCarColor;
            }
            set
            {
                selectedCarColor = value;
                OnPropertyChanged(nameof(SelectedCarColor));
            }
        }

        // Property representing the ID of the new car
        private int carID;

        public int CarID
        {
            get
            {
                return carID;
            }
            set
            {
                carID = value;
                OnPropertyChanged(nameof(CarID));
            }
        }

        // Property representing the selected car type
        private CarType selectedCarType;

        public CarType SelectedCarType
        {
            get
            {
                return selectedCarType;
            }
            set
            {
                selectedCarType = value;
                OnPropertyChanged(nameof(SelectedCarType));
            }
        }

        // Command for adding a new car
        public ICommand AddNewCarCommand { get; }

        // Command for canceling the car addition process
        public ICommand CancelCommand { get; }

        public CarAddingViewModel(RentCarStore rentCarStore, NavigationService reservationViewNavigationService, NavigationService makeStartWindowViewNavigationService)
        {
            AddNewCarCommand = new AddNewCarCommand(this, rentCarStore, reservationViewNavigationService);

            CancelCommand = new NavigateCommand(makeStartWindowViewNavigationService);
        }
    }
}

