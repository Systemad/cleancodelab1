namespace UI;

public class UserInterfaceManager : IUserInterfaceManager
{
    public string GetPlayerName()
    {
        Console.WriteLine("Enter your user name:\n");
        // name -> playerName
        return Console.ReadLine();
    }

    public void DisplayMessage(string message) => Console.WriteLine(message);

    public string GetPlayerGuess() => Console.ReadLine();

    public bool AskToContinueGame()
    {
        throw new NotImplementedException();
    }
}