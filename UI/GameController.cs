namespace UI;

public class GameController : IGameController
{
    private readonly IGameLogic _gameLogic;
    private readonly IScoreboardManager _scoreboardManager;
    private readonly IUserInterfaceManager _userInterfaceManager;

    public GameController(IGameLogic gameLogic, IScoreboardManager scoreboardManager,
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
            string goal = _gameLogic.GenerateCorrectAnswer();
            _userInterfaceManager.DisplayMessage("New game:\n" );
            _userInterfaceManager.DisplayMessage("For practice, number is: " + goal + "\n");

            var numberOfGuesses = 1;
            BullsAndCowsResult result;
            
            do
            {
                numberOfGuesses++;
                var playerGuess = _userInterfaceManager.GetPlayerGuess();
                result = _gameLogic.CheckBullsAndCows(goal, playerGuess);
                _userInterfaceManager.DisplayMessage(result.ResultMessage + "\n");
            } while (!result.IsCorrect);

            _scoreboardManager.WriteResult(playerName, numberOfGuesses);
            DisplayLeaderboard();
            _userInterfaceManager.DisplayMessage("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
            isGameRunning = _userInterfaceManager.AskToContinueGame();
        }
    }

    public void DisplayLeaderboard()
    {
        var results = _scoreboardManager.GetResults();
        _userInterfaceManager.DisplayLeaderboard(results);
    }
}