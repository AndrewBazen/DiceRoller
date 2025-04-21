using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using DiceRoller.ViewModels;

namespace DiceRoller.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        // Ensure sender is not null and is of type Button
        if (sender is Button button && !string.IsNullOrEmpty(button.Name))
        {
            // Get the dice id from the button
            var diceId = button.Name.Replace("btn", "");
            // Get the view model
            var viewModel = (MainWindowViewModel)DataContext!;
            // Call the roll method
            var rollResult = viewModel.RollDice(diceId);

            // Display the result in the text block
            var resultTextBlock = this.FindControl<TextBlock>("ResultTextBlock");
        }
        else
        {
            Debug.WriteLine("Button click event sender is null or invalid.");
        }
    }
}
