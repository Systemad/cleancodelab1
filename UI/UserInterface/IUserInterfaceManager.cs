namespace UI.UserInterface;

public interface IUserInterfaceManager
{
    string GetPlayerName();
    void DisplayMessage(string message);
    string GetPlayerGuess();
    bool AskToContinueGame();
    void DisplayLeaderboard(List<PlayerData> players);
}