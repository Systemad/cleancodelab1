namespace UI;
// TODO:
/*
 * Felhantering
 * namngivning
 * clean test
 */
public class GameController : IGameController
{
    // use dependency injection
    private IGameLogic _gameLogic; // = new GameLogic();
    private IScoreboardManager _scoreboardManager; // = new ScoreboardManager();
    private IUserInterfaceManager _userInterfaceManager; // = new UserInterfaceManager();

    public GameController(IGameLogic gameLogic, IScoreboardManager scoreboardManager, IUserInterfaceManager userInterfaceManager)
    {
        _gameLogic = gameLogic;
        _scoreboardManager = scoreboardManager;
        _userInterfaceManager = userInterfaceManager;
    }
    public void StartGame()
    {
        bool isGameRunning = true;

        string playerName = _userInterfaceManager.GetPlayerName(); //Console.ReadLine();
        
        while (isGameRunning)
        {
            string goal = _gameLogic.GenerateCorrectAnswer();// GenerateCorrectAnswer();

            Console.WriteLine("New game:\n");
            Console.WriteLine("For practice, number is: " + goal + "\n");

            string playerGuesses = _userInterfaceManager.GetPlayerGuess();
            
            int numberOfGuesses = 1;
            string bbcc = _gameLogic.CheckBullsAndCows(goal, playerGuesses);
            Console.WriteLine(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                playerGuesses = _userInterfaceManager.GetPlayerGuess();
                Console.WriteLine(playerGuesses + "\n");
                bbcc = _gameLogic.CheckBullsAndCows(goal, playerGuesses);
                Console.WriteLine(bbcc + "\n");
            }
            
            _scoreboardManager.WriteResult(playerName, playerGuesses);
            DisplayLeaderboard();
            
            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");

            string continuePlayingResponse = _userInterfaceManager.GetPlayerGuess();
            if (continuePlayingResponse != null && continuePlayingResponse != "" &&
                continuePlayingResponse.Substring(0, 1) == "n")
            {
                isGameRunning = false;
            }
        }
    }

    public void DisplayLeaderboard()
    {
        _scoreboardManager.PrintResults();
    }
}