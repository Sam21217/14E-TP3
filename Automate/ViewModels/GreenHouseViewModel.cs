using Automate.Interfaces;
using Automate.Models;
using Automate.Utils.LocalServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Automate.Views;
using System.Windows.Navigation;

namespace Automate.ViewModels
{
    public class GreenHouseViewModel : INotifyPropertyChanged
    {
        private readonly NavigationUtils _navigationService;

        private Window _window;
        public ICommand GotoHomeViewCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public GreenHouseViewModel(Window openedWindow, NavigationUtils navigationService)
        {
            _window = openedWindow;
            GotoHomeViewCommand = new RelayCommand(GoToHomeView);
            _navigationService = navigationService;
        }


        public bool IsWindowOpen
        {
            get => GreenHouse.isWindowOpen;
            set
            {
                GreenHouse.isWindowOpen = value;
                NotifyOnPropertyChanged(nameof(IsWindowOpen));
            }
        }

        public bool IsHeaterActivated
        {
            get => GreenHouse.isHeaterActivated;
            set
            {
                GreenHouse.isHeaterActivated = value;
                NotifyOnPropertyChanged(nameof(IsHeaterActivated));
            }
        }
        public bool IsSprinklerActivated 
        {
            get => GreenHouse.isSprinklerActivated;
            set
            {
                GreenHouse.isSprinklerActivated = value;
                NotifyOnPropertyChanged(nameof(IsSprinklerActivated));
            }
        }

        public bool IsFanActivated 
        {
            get => GreenHouse.isFanActivated;
            set 
            {
                GreenHouse.isFanActivated = value;
                NotifyOnPropertyChanged(nameof(IsFanActivated));
            }

        }

        public bool IsLightOpen 
        { 
            get => GreenHouse.isLightOpen;
            set
            {
                GreenHouse.isLightOpen = value;
                NotifyOnPropertyChanged(nameof(IsLightOpen));
            }
        }

        public void GoToHomeView()
        {
            _navigationService.OpenNewView<HomeWindow>();
            _navigationService.CloseCurrentView(_window);
        }

        protected void NotifyOnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
