using UI;

namespace Testing;

public class GameLogicTest
{
    [Fact]
    public void CheckCorrectAnswer()
    {
        IGameLogic gameLogic = new GameLogic();
        var correctAnswer = gameLogic.GenerateCorrectAnswer();
        
    }
    
    [Fact]
    public void CheckCorrectAnswerIsUnique()
    {
        IGameLogic gameLogic = new GameLogic();
        var correctAnswer = gameLogic.GenerateCorrectAnswer();

        var hey = correctAnswer.Distinct().Count() == correctAnswer.Length;
    }
    

}