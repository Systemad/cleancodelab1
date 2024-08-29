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

            string playerGuesses = _userInterfaceManager.GetPlayerGuess();
            var numberOfGuesses = 1;
            string bullsAndCowsResult = _gameLogic.CheckBullsAndCows(goal, playerGuesses);
            _userInterfaceManager.DisplayMessage(bullsAndCowsResult + "\n");

            while (bullsAndCowsResult != "BBBB,")
            {
                numberOfGuesses++;
                playerGuesses = _userInterfaceManager.GetPlayerGuess();
                bullsAndCowsResult = _gameLogic.CheckBullsAndCows(goal, playerGuesses);
                Console.WriteLine(bullsAndCowsResult + "\n");
            }

            _scoreboardManager.WriteResult(playerName, playerGuesses);
            DisplayLeaderboard();
            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
            isGameRunning = _userInterfaceManager.AskToContinueGame();
        }
    }

    public void DisplayLeaderboard()
    {
        var results = _scoreboardManager.ReturnResults();
        _userInterfaceManager.PrintLeaderboard(results);
    }
}