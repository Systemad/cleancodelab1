using UI.Controller;
using UI.Logic;
using UI.Scoreboard;
using UI.UserInterface;

namespace UI;

public class Program
{
    public static void Main(string[] args)
    {
        var gameLogic = new GameLogic();
        var scoreboardManager = new ScoreboardManager();
        var userInterfaceManager = new UserInterfaceManager();

        var gameController = new GameController(gameLogic, scoreboardManager, userInterfaceManager);

        gameController.StartGame();
    }
}