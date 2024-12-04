using Automate.Utils;
using Automate.Utils.LocalServices;
using Automate.Views;
using System.Windows;
using System.Windows.Input;

namespace Automate.ViewModels
{
    class HomeViewModel
    {
        private readonly NavigationUtils _navigationService;
        public ICommand GoToCalendarCommand { get; }
        public ICommand GoToSerreCommand { get; }

        public ICommand DisconnectUserCommand { get; }

        private Window _window;
        public HomeViewModel(Window openedWindow, NavigationUtils navigationService)
        {
            GoToCalendarCommand = new RelayCommand(GotoCalendarView);
            GoToSerreCommand = new RelayCommand(GotoSerreView);
            DisconnectUserCommand = new RelayCommand(DisconnectUser);
            _navigationService = navigationService;
            _window = openedWindow;
        }

        public void GotoCalendarView()
        {
            _navigationService.OpenNewView<CalendarWindow>();
            _navigationService.CloseCurrentView(_window);
        }
        public void GotoSerreView()
        {
            _navigationService.OpenNewView<GreenHouseWindow>();
            _navigationService.CloseCurrentView(_window);
        }

        public void DisconnectUser()
        {
            _navigationService.OpenNewView<LoginWindow>();
            Env.authenticatedUser = null;
            _navigationService.CloseCurrentView(_window);
        }
    }
}
