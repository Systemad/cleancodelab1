namespace UI.UserInterface;

public interface IUserInterfaceManager
{
    string GetPlayerName();
    void DisplayMessage(string message);
    string GetPlayerGuess();
    bool AskPlayerToPlayAgain();
    void DisplayLeaderboard(List<PlayerData> players);
}