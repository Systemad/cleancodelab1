namespace UI;

public class Program
{
    public static void Main(string[] args)
    {
        IGameLogic _gameLogic = new GameLogic();
        IScoreboardManager _scoreboardManager = new ScoreboardManager();
        IUserInterfaceManager _userInterfaceManager = new UserInterfaceManager();

        IGameController game = new GameController(_gameLogic, _scoreboardManager, _userInterfaceManager);

        game.StartGame();
    }
}