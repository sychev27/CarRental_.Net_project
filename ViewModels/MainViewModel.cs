using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Stores;

namespace CarRental.ViewModels
{
    // ViewModel responsible for managing the main content displayed in the application
    public class MainViewModel : ViewModelBase
    {
        // Store for managing navigation between different ViewModels
        private readonly NavigationStore _navigationStore;

        // Property representing the current ViewModel displayed in the main content
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            // Subscribe to the event raised when the current ViewModel changes
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        // Event handler triggered when the current ViewModel changes
        private void OnCurrentViewModelChanged()
        {
            // Notify subscribers about the change in the current ViewModel
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

