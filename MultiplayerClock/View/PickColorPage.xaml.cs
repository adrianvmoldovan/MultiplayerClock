using MultiplayerClock.ViewModel;
using MultiplayerClock.ViewModel.Services;

namespace MultiplayerClock.View
{
    public partial class PickColorPage : ContentPage
    {
        public PickColorPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var context = serviceProvider.GetRequiredService<Context>();
            var vm      = serviceProvider.GetRequiredService<PickColorVM>();

            foreach (var colorSchemeName in vm.ColorsManager.GetPossibleColorSchemeNames())
            {
                var colorSchemeVM = new ColorSchemeVM(serviceProvider, colorSchemeName);
                var colorSchemeView = new ColorSchemeView(colorSchemeVM);

                ContentLayout.Children.Add(colorSchemeView);
            }

            BindingContext = vm;
        }
    }
}