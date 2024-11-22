using Automate.Interfaces;
using Automate.Models;
using Automate.Utils.LocalServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System;
using System.Runtime.CompilerServices;

namespace Automate.ViewModels
{
    public class GreenHouseViewModel : INotifyPropertyChanged
    {
        private bool _isWindowOpen;
        private bool _isHeaterActivated;
        private bool _isSprinklerActivated;
        private bool _isLightOpen;
        private bool _isFanActivated;

        private Window _window;
        public ICommand AddTaskCommand { get; }
        public ICommand UpdateTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public GreenHouseViewModel(Window openedWindow)
        {
            _window = openedWindow;
        }

        public bool IsWindowOpen { get => _isWindowOpen; set => _isWindowOpen = value; }
        public bool IsHeaterActivated { get => _isHeaterActivated; set => _isHeaterActivated = value; }
        public bool IsSprinklerActivated { get => _isSprinklerActivated; set => _isSprinklerActivated = value; }
        public bool IsFanActivated { get => _isFanActivated; set => _isFanActivated = value; }
        public bool IsLightOpen { get => _isLightOpen; set => _isLightOpen = value; }


        protected void NotifyOnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
