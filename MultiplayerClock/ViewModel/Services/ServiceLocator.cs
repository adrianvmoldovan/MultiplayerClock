using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel.Services
{
    public static class ServiceLocator<T> where T : class
    {
        private static T? _Instance;
        public static T Instance
        { 
            get
            {
                Debug.Assert(_Instance != null);

                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Instance = serviceProvider.GetRequiredService<T>();
        }
    }
}
