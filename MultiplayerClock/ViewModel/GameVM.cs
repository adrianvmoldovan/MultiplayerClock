using MultiplayerClock.Model;
using MultiplayerClock.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class GameVM /*: INotifyPropertyChanged*/
    {
        //public event PropertyChangedEventHandler? PropertyChanged;

        public GameVM() 
        {
        }

        public ObservableCollection<PlayerVM> PlayerVMs => ServiceLocator<Context>.Instance.PlayerVMs;
    }
}
