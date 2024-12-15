using Automate.Models;
using Automate.Utils.LocalServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Runtime.CompilerServices;
using Automate.Views;
using Automate.Utils.DataServices;
using System.Threading;
using System;

namespace Automate.ViewModels
{
    public class GreenHouseViewModel : INotifyPropertyChanged
    {
        private readonly NavigationUtils _navigationService;

        private string _tempTip;
        private string _humidityTip;
        private string _lightingTip;
        private Timer? weatherReadingTimer;
        private List<Weather> weathers;

        private Window _window;
        public ICommand GotoHomeViewCommand { get; }
        public ICommand StartWeatherReadingCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public GreenHouseViewModel(Window openedWindow, NavigationUtils navigationService)
        {
            GetWeathers();
            _window = openedWindow;
            GotoHomeViewCommand = new RelayCommand(GoToHomeView);
            StartWeatherReadingCommand = new RelayCommand(StartWeatherReading);
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

        public string TempTip
        {
            get => _tempTip;
            set
            {
                _tempTip = value;
                NotifyOnPropertyChanged(nameof(TempTip));
            }
        }

        public string HumidityTip
        {
            get => _humidityTip;
            set
            {
                _humidityTip = value;
                NotifyOnPropertyChanged(nameof(HumidityTip));
            }
        }

        public string LightingTip
        {
            get => _lightingTip;
            set
            {
                _lightingTip = value;
                NotifyOnPropertyChanged(nameof(LightingTip));
            }
        }

        public void GetWeathers()
        {
            weathers = WeatherConditionsService.GetWeathers();
        }

        private int currentWeatherIndex = 0;

        public void StartWeatherReading()
        {
            const int delay = 0;
            const int interval = 10;
            if (weatherReadingTimer == null)
            {
                weatherReadingTimer = new Timer(GetTips, null, delay, interval);
            }
            else
            {
                weatherReadingTimer.Dispose();
                weatherReadingTimer = null;
                currentWeatherIndex = 0;
            }
        }

        public void GetTips(object? state)
        {
            if (currentWeatherIndex > weathers.Count - 1)
            {
                currentWeatherIndex = 0;
            }
            Weather currentWeather = weathers[currentWeatherIndex];
            TempTip = WeatherTips.GetTempTips(currentWeather.Temperature, IsHeaterActivated, IsWindowOpen);
            HumidityTip = WeatherTips.GetHumidityTips(currentWeather.Humidity, IsFanActivated, IsSprinklerActivated);
            LightingTip = WeatherTips.GetLightingTips(currentWeather.Lighting, currentWeather.DateTime.Hour, IsLightOpen);
            currentWeatherIndex++;
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

