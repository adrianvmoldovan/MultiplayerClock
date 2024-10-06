using Microsoft.Extensions.Logging;
using MultiplayerClock.View;
using MultiplayerClock.ViewModel;

namespace MultiplayerClock
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageVM>();

            builder.Services.AddSingleton<GamePage>();
            builder.Services.AddSingleton<GameVM>();

            builder.Services.AddSingleton<PickColorPage>();
            builder.Services.AddSingleton<PickColorVM>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
