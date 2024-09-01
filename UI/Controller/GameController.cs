using UI.Scoreboard;
using UI.UserInterface;

namespace UI.Controller;

public class GameController : IGameController
{
    private readonly IGameLogic _gameLogic;
    private readonly IScoreboardManager _scoreboardManager;
    private readonly IUserInterfaceManager _userInterfaceManager;

    public GameController(
        IGameLogic gameLogic,
        IScoreboardManager scoreboardManager,
        IUserInterfaceManager userInterfaceManager)
    {
        _gameLogic = gameLogic;
        _scoreboardManager = scoreboardManager;
        _userInterfaceManager = userInterfaceManager;
    }

    public void StartGame()
    {
        string playerName = _userInterfaceManager.GetPlayerName();
        var isGameRunning = true;

        while (isGameRunning)
        {
            PlayGame(playerName);
            isGameRunning = AskPlayerToPlayAgain();
        }
    }

    private void PlayGame(string playerName)
    {
        string correctAnswer = _gameLogic.GenerateCorrectAnswer();
        _userInterfaceManager.DisplayMessage("New game:\n");
        _userInterfaceManager.DisplayMessage("For practice, number is: " + correctAnswer + "\n");

        var numberOfGuesses = 0;
        BullsAndCowsResult result;

        do
        {
            numberOfGuesses++;
            var playerGuess = _userInterfaceManager.GetPlayerGuess();
            result = _gameLogic.CheckBullsAndCows(correctAnswer, playerGuess);
            _userInterfaceManager.DisplayMessage(result.ResultMessage + "\n");
        } while (!result.IsCorrect);

        _scoreboardManager.WritePlayerResult(playerName, numberOfGuesses);
        DisplayLeaderboard();
        _userInterfaceManager.DisplayMessage("Correct, it took " + numberOfGuesses + " guesses");
    }

    public void DisplayLeaderboard()
    {
        var playerResults = _scoreboardManager.GetPlayerResults();
        _userInterfaceManager.DisplayLeaderboard(playerResults);
    }

    private bool AskPlayerToPlayAgain()
    {
        _userInterfaceManager.DisplayMessage("Do you play to play continue playing?");
        return _userInterfaceManager.AskPlayerToPlayAgain();
    }
}