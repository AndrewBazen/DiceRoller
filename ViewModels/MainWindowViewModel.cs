using System.Diagnostics;
using System.Security.Cryptography;

namespace DiceRoller.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

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
