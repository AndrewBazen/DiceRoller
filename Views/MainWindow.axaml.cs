using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using DiceRoller.ViewModels;
using System.Linq;

namespace DiceRoller.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Content is StackPanel sp &&
            sp.Children.OfType<TextBlock>().FirstOrDefault() is TextBlock tb)
        {
            Debug.WriteLine("Button clicked: " + tb.Text);
            string diceId = tb.Text; // "D4", "D6", etc.
            if (DataContext is MainWindowViewModel vm)
            {
                vm.RollAnimated(diceId);
            }
        }
    }
}
