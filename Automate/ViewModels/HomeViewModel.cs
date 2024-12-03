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
        public ICommand GoToGreenHouseCommand { get; }


        private Window _window;
        public HomeViewModel(Window openedWindow, NavigationUtils navigationService)
        {
            GoToCalendarCommand = new RelayCommand(GotoCalendarView);
            GoToGreenHouseCommand = new RelayCommand(GotoGreenHouseView);

            _navigationService = navigationService;
            _window = openedWindow;
        }

        public void GotoCalendarView()
        {
            _navigationService.OpenNewView<CalendarWindow>();
            _navigationService.CloseCurrentView(_window);
        }
        public void GotoGreenHouseView()
        {
            _navigationService.OpenNewView<GreenHouseWindow>();
            _navigationService.CloseCurrentView(_window);
        }
    }
}
