﻿using CommunityToolkit.Mvvm.Input;
using MultiplayerClock.Model;
using MultiplayerClock.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace MultiplayerClock.ViewModel
{
    public class PlayerVM : INotifyPropertyChanged
    {
        private Player _Player;
        private IDispatcherTimer _Timer;
        private TimeSpan _Time;
        private bool _IsPaused;
        private bool _UseSameTimeRequested;
        public PlayerVM(Player player, int index)
        {
            _Player               = player;
            Name                  = player.Name;
            Color                 = player.BkColor;
            _IsIncreasing         = true;
            _IsPaused             = false;
            _UseSameTimeRequested = false;
            Minutes               = 0;
            Index                 = (index + 1).ToString();

            var dispatcher = Dispatcher.GetForCurrentThread();
            if (dispatcher != null)
            {
                _Timer = dispatcher.CreateTimer();
                _Timer.Interval = TimeSpan.FromSeconds(1);
                _Timer.Tick += OnTimerTick;
            }
            else
            {
                throw new InvalidOperationException("Dispatcher is not available.");
            }

            var context = ServiceLocator<Context>.Instance;
            AreFieldsEditable = !context.GameStarted;
            context.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(context.GameStarted))
                {
                    AreFieldsEditable = !context.GameStarted;
                }
                if(e.PropertyName == nameof(context.SelectedGameType))
                {
                    Minutes = context.SelectedGameType == Model.Enums.GameType.SuddenDeath ? 5 : 0;
                    IsIncreasing = context.SelectedGameType == Model.Enums.GameType.Classic;
                }
                if (e.PropertyName == nameof(context.GameStarted) ||
                    e.PropertyName == nameof(context.SelectedGameType) ||
                    e.PropertyName == nameof(context.UseSameTime))
                {
                    IsTimeAvailable = 
                        !context.GameStarted && 
                        context.SelectedGameType == Model.Enums.GameType.SuddenDeath &&
                        !_UseSameTimeRequested;
                }
                if(e.PropertyName == nameof(context.PlayerVMs))
                {
                    //update the Index property based on the index of the player in the PlayerVMs
                    var playerVMs = ServiceLocator<Context>.Instance.PlayerVMs;
                    int index = playerVMs.IndexOf(this);
                    if (index >= 0)
                        Index = (index + 1).ToString();
                }
            };
        }

        public Color Color { get; private set; }
        public string Name { get; private set; }

        public Player Player 
        { 
            get => _Player; 
            set
            {
                _Player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        private bool _AreFieldsEditable = true;
        public bool AreFieldsEditable
        {
            get => _AreFieldsEditable;
            set
            {
                if (_AreFieldsEditable != value)
                {
                    _AreFieldsEditable = value;
                    OnPropertyChanged(nameof(AreFieldsEditable));
                }
            }
        }

        private bool _IsTimeAvailable = false;
        public bool IsTimeAvailable
        {
            get => _IsTimeAvailable;
            set
            {
                if (_IsTimeAvailable != value)
                {
                    _IsTimeAvailable = value;
                    OnPropertyChanged(nameof(IsTimeAvailable));
                }
            }
        }

        private string _Index = "0";
        public string Index
        {
            get => _Index;
            set
            {
                if (_Index != value)
                {
                    _Index = value;
                    OnPropertyChanged(nameof(Index));
                }
            }
        }

        private bool _IsIncreasing = true;
        public bool IsIncreasing
        {
            get => _IsIncreasing;
            set
            {
                if (_IsIncreasing != value)
                {
                    _IsIncreasing = value;
                    OnPropertyChanged(nameof(IsIncreasing));
                }
            }
        }

        private int _Minutes;
        public int Minutes
        {
            get => _Minutes;
            set
            {
                int minValue = ServiceLocator<Context>.Instance.SelectedGameType == Model.Enums.GameType.SuddenDeath ? 1 : 0;
                int clamped = Math.Max(minValue, Math.Min(99, value));
                _Minutes = clamped;
                Time = TimeSpan.FromMinutes(_Minutes);
                OnPropertyChanged(nameof(Minutes));
            }
        }

        public TimeSpan Time
        {
            get => _Time;
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    OnPropertyChanged(nameof(Time));
                    OnPropertyChanged(nameof(TimeDisplay));
                }
            }
        }

        public string TimeDisplay => $"{Time.Minutes:D2}:{Time.Seconds:D2}";
        public string MinutesTimeDisplay => $"{Time.Minutes:D2}";

        public ICommand IncreaseTimeCommand => new RelayCommand(IncreaseTime);
        public ICommand DecreaseTimeCommand => new RelayCommand(DecreaseTime);

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_IsIncreasing)
                IncreaseTime();
            else
                DecreaseTime();
        }

        private void IncreaseTime()
        {
            if(!_IsPaused)
                Time += TimeSpan.FromSeconds(1);
        }

        private void DecreaseTime()
        {
            if(!_IsPaused)
                Time -= TimeSpan.FromSeconds(1);
        }

        public void StartTimer()
        {
            _Timer.Start();
        }

        public void StopTimer()
        {
            _Timer.Stop();
        }

        public void Reset()
        {
            _Timer.Stop();

            var context = ServiceLocator<Context>.Instance;
            Minutes = context.SelectedGameType == Model.Enums.GameType.SuddenDeath ? 5 : 0;
        }

        public void UseSameTimeRequested(bool useSameTime)
        {
            _UseSameTimeRequested = useSameTime;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
