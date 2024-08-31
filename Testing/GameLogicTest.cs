using UI;

namespace Testing;

public class GameLogicTest
{
    [Fact]
    public void Check_Correct_Answer_Lenght()
    {
        var gameLogic = new GameLogic();
        var correctAnswer = gameLogic.GenerateCorrectAnswer();
        Assert.Equal(4, correctAnswer.Length);
    }
    
    [Fact]
    public void Check_Correct_Answer_IsUnique()
    {
        var gameLogic = new GameLogic();
        var correctAnswer = gameLogic.GenerateCorrectAnswer();
        var isUnique = correctAnswer.Distinct().Count() == correctAnswer.Length;
        Assert.True(isUnique, "All digits should be unique!");
    }
    
    [Fact]
    public void CheckCorrect_Returns_Digits_ZeroToFour()
    {
        var gameLogic = new GameLogic();
        var correctAnswer = gameLogic.GenerateCorrectAnswer();
        var allDigitsAreValid = correctAnswer.All(d => d is >= '0' and <= '9');
        Assert.True(allDigitsAreValid, "Each digit should be between 0-9");
    }

    [Fact]
    public void CheckCorrectAnswer_ReturnsFourBulls()
    {
        var gameLogic = new GameLogic();
        var correctAnswer = "1234";
        var guess = "1234";

        var result = gameLogic.CheckBullsAndCows(correctAnswer, guess);

        Assert.Equal("BBBB,", result.ResultMessage); 
    }
    
    [Fact]
    public void CheckBullsAndCows_ShouldReturnNoBullsOrCowsWhenNoMatches()
    {
        var gameLogic = new GameLogic();
        var correctAnswer = "1234";
        var guess = "5678";

        var result = gameLogic.CheckBullsAndCows(correctAnswer, guess);

        Assert.Equal(",", result.ResultMessage); 
    }
    
    [Fact]
    public void CheckBullsAndCows_ShouldReturnCorrectFormatForMixedBullsAndCows()
    {
        var gameLogic = new GameLogic();
        var goal = "1234";
        var guess = "1324";
        var result = gameLogic.CheckBullsAndCows(goal, guess);

        Assert.Equal("BB,CC", result.ResultMessage); 
        Assert.False(result.IsCorrect);
    }
}