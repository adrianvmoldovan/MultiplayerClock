using Microsoft.Extensions.Logging;
using MultiplayerClock.View;
using MultiplayerClock.ViewModel;
using MultiplayerClock.ViewModel.Services;

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

            builder.Services.AddSingleton<Context>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageVM>();

            builder.Services.AddTransient<GamePage>();
            builder.Services.AddTransient<GameVM>();

            builder.Services.AddSingleton<PickColorPage>();
            builder.Services.AddSingleton<PickColorVM>();

            builder.Services.AddTransient<ColorSchemeView>();
            builder.Services.AddTransient<ColorSchemeVM>();

            builder.Services.AddTransient<PlayerView>();
            builder.Services.AddTransient<PlayerVM>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            ServiceLocator<Context>.Initialize(app.Services);

            return app;
        }
    }
}
