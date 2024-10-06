using MultiplayerClock.Model.Colors;
using MultiplayerClock.ViewModel;
using System.Security.Cryptography.X509Certificates;

namespace MultiplayerClock.View;

public partial class ColorSchemeView : ContentView
{
    public ColorSchemeView(ColorSchemeVM vm)
    {
        InitializeComponent();
        BindingContext = vm;

        foreach (var possibleColor in vm.PossibleColors)
        {
            ColorsGrid.ColumnDefinitions.Add(new ColumnDefinition());
            ColorsGrid.Children.Add(new Button());
        }
    }
}