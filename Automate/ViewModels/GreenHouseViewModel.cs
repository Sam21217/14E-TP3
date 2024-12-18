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

        private string? _tempTip;
        private string? _humidityTip;
        private string? _lightingTip;
        private Timer? weatherReadingTimer;
        private List<Weather>? weathers;
        private int currentWeatherIndex = 0;

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

        public Weather CurrentWeather
        {
            get
            {
                return weathers![currentWeatherIndex];
            }
        }

        public bool IsWindowOpen
        {
            get => GreenHouse.isWindowOpen;
            set
            {
                GreenHouse.isWindowOpen = value;
                GetTipsForWeather(CurrentWeather);
                NotifyOnPropertyChanged(nameof(IsWindowOpen));
            }
        }

        public bool IsHeaterActivated
        {
            get => GreenHouse.isHeaterActivated;
            set
            {
                GreenHouse.isHeaterActivated = value;
                GetTipsForWeather(CurrentWeather);
                NotifyOnPropertyChanged(nameof(IsHeaterActivated));
            }
        }

        public bool IsSprinklerActivated
        {
            get => GreenHouse.isSprinklerActivated;
            set
            {
                GreenHouse.isSprinklerActivated = value;
                GetTipsForWeather(CurrentWeather);
                NotifyOnPropertyChanged(nameof(IsSprinklerActivated));
            }
        }

        public bool IsFanActivated
        {
            get => GreenHouse.isFanActivated;
            set
            {
                GreenHouse.isFanActivated = value;
                GetTipsForWeather(CurrentWeather);
                NotifyOnPropertyChanged(nameof(IsFanActivated));
            }

        }

        public bool IsLightOpen
        {
            get => GreenHouse.isLightOpen;
            set
            {
                GreenHouse.isLightOpen = value;
                GetTipsForWeather(CurrentWeather);
                NotifyOnPropertyChanged(nameof(IsLightOpen));
            }
        }

        public string TempTip
        {
            get => _tempTip!;
            set
            {
                _tempTip = value;
                NotifyOnPropertyChanged(nameof(TempTip));
            }
        }

        public string HumidityTip
        {
            get => _humidityTip!;
            set
            {
                _humidityTip = value;
                NotifyOnPropertyChanged(nameof(HumidityTip));
            }
        }

        public string LightingTip
        {
            get => _lightingTip!;
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

        public void StartWeatherReading()
        {
            const int delay = 0;
            const int interval = 10000;
            if (weatherReadingTimer == null)
            {
                weatherReadingTimer = new Timer(GetTipsOnTimer, null, delay, interval);
            }
            else
            {
                weatherReadingTimer.Dispose();
                weatherReadingTimer = null;
            }
        }

        public void GetTipsOnTimer(object? state)
        {
            if (currentWeatherIndex > weathers!.Count - 1)
                currentWeatherIndex = 0;

            GetTipsForWeather(CurrentWeather);
            currentWeatherIndex++;
        }

        public void GetTipsForWeather(Weather weather)
        {
            TempTip = WeatherTips.GetTempTips(weather.Temperature, IsHeaterActivated, IsWindowOpen);
            HumidityTip = WeatherTips.GetHumidityTips(weather.Humidity, IsFanActivated, IsSprinklerActivated);
            LightingTip = WeatherTips.GetLightingTips(weather.Lighting, weather.DateTime.Hour, IsLightOpen);
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

