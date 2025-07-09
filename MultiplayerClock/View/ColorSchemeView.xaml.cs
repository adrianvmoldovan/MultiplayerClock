using Microsoft.Maui.Controls;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.ViewModel;

namespace MultiplayerClock.View
{
    public partial class ColorSchemeView : ContentView
    {
        public ColorSchemeView(ColorSchemeVM vm)
        {
            InitializeComponent();
            BindingContext = vm;

            int columnIndex = 0;
            foreach (var possibleColor in vm.PossibleColors)
            {
                var columnDefinition = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
                ColorsGrid.ColumnDefinitions.Add(columnDefinition);

                var button             = new Button();
                button.BackgroundColor = possibleColor.BkColor;
                button.AutomationId    = possibleColor.Name;

                button.SetBinding(targetProperty: Button.CommandProperty, "ColorSelected");
                button.CommandParameter = button;

                ColorsGrid.SetColumn(button, columnIndex++);
                ColorsGrid.Children.Add(button);
            }
        }
    }
}