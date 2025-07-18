﻿using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel.Services
{
    public class Context : INotifyPropertyChanged
    {
        public Context() 
        {
            _SelectedGameType  = GameType.Classic;
            _SelectedDirection = Direction.Clockwise;
            _UseSameTime       = true;
            _IsPaused          = true;
            _GameStarted       = false;
            ColorsManager      = new ColorsManager();
        }
        public ObservableCollection<PlayerVM> PlayerVMs { get; } = new();
        public Player? CurrentPlayer { get; set; }
        public ColorsManager ColorsManager { get; set; }

        private bool _GameStarted;
        public bool GameStarted
        {
            get => _GameStarted;
            set
            {
                if (_GameStarted != value)
                {
                    _GameStarted = value;
                    OnPropertyChanged(nameof(GameStarted));
                }
            }
        }

        private bool _IsPaused;
        public bool IsPaused
        {
            get => _IsPaused;
            set
            {
                if (_IsPaused != value)
                {
                    _IsPaused = value;
                    OnPropertyChanged(nameof(IsPaused));
                }
            }
        }

        private GameType _SelectedGameType;
        public GameType SelectedGameType
        {
            get => _SelectedGameType;
            set
            {
                if (_SelectedGameType != value)
                {
                    _SelectedGameType = value;
                    OnPropertyChanged(nameof(SelectedGameType));
                }
            }
        }

        private Direction _SelectedDirection;
        public Direction SelectedDirection
        {
            get => _SelectedDirection;
            set
            {
                if (_SelectedDirection != value)
                {
                    _SelectedDirection = value;
                    OnPropertyChanged(nameof(SelectedDirection));
                }
            }
        }

        private bool _UseSameTime;
        public bool UseSameTime
        {
            get { return _UseSameTime; }
            set
            {
                _UseSameTime = value;
                OnPropertyChanged(nameof(UseSameTime));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
