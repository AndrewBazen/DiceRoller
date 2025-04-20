using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace DiceRoller.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        // Handle button click event here  
        Debug.WriteLine("Button clicked!");
    }
}
