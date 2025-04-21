using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using ReactiveUI;

namespace DiceRoller.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private string _displayedRoll = "-";
    private DispatcherTimer? _rollingTimer;
    private int _rollingTicks;


    public string DisplayedRoll
    {
        get => _displayedRoll;
        set => this.RaiseAndSetIfChanged(ref _displayedRoll, value);
    }



    public async void RollAnimated(string diceId)
    {
        int maxValue = diceId switch
        {
            "D4" => 4,
            "D6" => 6,
            "D8" => 8,
            "D10" => 10,
            "D12" => 12,
            "D20" => 20,
            _ => 0
        };

        if (maxValue == 0)
        {
            DisplayedRoll = "Error";
            return;
        }

        _rollingTicks = 0;
        _rollingTimer?.Stop();

        _rollingTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(50)
        };

        _rollingTimer.Tick += (_, __) =>
        {
            _rollingTicks++;

            // Simulate fast flickering numbers
            DisplayedRoll = RandomNumberGenerator.GetInt32(1, maxValue + 1).ToString();

            if (_rollingTicks >= 20)
            {
                _rollingTimer?.Stop();
                DisplayedRoll = RollDice(diceId).ToString(); // your existing logic
            }
        };

        _rollingTimer.Start();
    }


    public int RollDice(string diceId)
    {
        // check which type of dice was clicked roll it
        switch (diceId)
        {
            case "D4":
                return RandomNumberGenerator.GetInt32(1, 5);
            case "D6":
                return RandomNumberGenerator.GetInt32(1, 7);
            case "D8":
                return RandomNumberGenerator.GetInt32(1, 9);
            case "D10":
                return RandomNumberGenerator.GetInt32(1, 11);
            case "D12":
                return RandomNumberGenerator.GetInt32(1, 13);
            case "D20":
                return RandomNumberGenerator.GetInt32(1, 21);
            default:
                Debug.WriteLine("Unknown dice type: " + diceId);
                return 0;
        }
    }
}
