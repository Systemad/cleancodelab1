namespace UI.UserInterface;

public class UserInterfaceManager : IUserInterfaceManager
{
    public string GetPlayerName()
    {
        string name;
        do
        {
            Console.WriteLine("Enter your username; it must be at least 2 characters!\n");
            name = Console.ReadLine();
        } while (string.IsNullOrEmpty(name) || name.Length < 2);

        Console.WriteLine($"Your name is {name} \n");
        return name;
    }

    public void DisplayMessage(string message) => Console.WriteLine(message);

    public string GetPlayerGuess()
    {
        string guess;
        do
        {
            Console.WriteLine("Enter a 4 digit guess!\n");
            guess = Console.ReadLine();
        } while (string.IsNullOrEmpty(guess) || guess.Length != 4);

        Console.WriteLine($"Your guess {guess} \n");
        return guess;
    }

    public bool AskToContinueGame()
    {
        string continuePlayingResponse = Console.ReadLine();

        // if user doesn't enter anything, assume it's a yes
        if (string.IsNullOrEmpty(continuePlayingResponse))
            return true;

        continuePlayingResponse = continuePlayingResponse.Trim().ToLower();
        return !continuePlayingResponse.StartsWith('n');
    }

    public void DisplayLeaderboard(List<PlayerData> players)
    {
        Console.WriteLine("Player - Total Games - Average Guesses");
        foreach (PlayerData playerData in players)
        {
            var formattedStat = playerData.FormatStats();
            Console.WriteLine(formattedStat);
        }
    }
}