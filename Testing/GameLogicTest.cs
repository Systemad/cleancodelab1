using UI;

namespace Testing;

public class GameLogicTest
{
    [Fact]
    public void GenerateCorrectAnswer_ShouldReturnFourDigitString()
    {
        var gameLogic = new GameLogic();
        var answer = gameLogic.GenerateCorrectAnswer();
        Assert.Equal(Constants.CorrectAnswerLenght, answer.Length);
    }
    
    [Fact]
    public void GenerateCorrectAnswer_ShouldContainUniqueDigits()
    {
        var gameLogic = new GameLogic();
        var answer = gameLogic.GenerateCorrectAnswer();
        var isUnique = answer.Distinct().Count() == answer.Length;
        
        Assert.True(isUnique, "All digits should be unique!");
    }
    
    [Fact]
    public void GenerateCorrectAnswer_ShouldContainDigitsOneToNine()
    {
        var gameLogic = new GameLogic();
        var answer = gameLogic.GenerateCorrectAnswer();
        var allDigitsAreValid = answer.All(d => d is >= Constants.Zero and <= Constants.Nine);
        
        Assert.True(allDigitsAreValid, $"Each digit should be between {Constants.Zero}-{Constants.Nine}");
    }

    [Fact]
    public void CheckBullsAndCows_ShouldReturnFourBullsForCorrectGuess()
    {
        var gameLogic = new GameLogic();
        var result = gameLogic.CheckBullsAndCows(Constants.CorrectAnswerOne, Constants.CorrectGuessOne);

        Assert.Equal(Constants.FourBulls, result.ResultMessage); 
    }
    
    [Fact]
    public void CheckBullsAndCows_ShouldReturnNoBullsOrCowsForNonMatchingGuess()
    {
        var gameLogic = new GameLogic();
        var result = gameLogic.CheckBullsAndCows(Constants.CorrectAnswerOne, Constants.RandomGuessOne);

        Assert.Equal(Constants.ZeroBullsZeroCows, result.ResultMessage); 
    }
    
    [Fact]
    public void CheckBullsAndCows_ShouldReturnCorrectFormatForMixedBullsAndCows()
    {
        var gameLogic = new GameLogic();
        var result = gameLogic.CheckBullsAndCows(Constants.CorrectAnswerOne, Constants.RandomGuessTwo);

        Assert.Equal(Constants.TwoBullsTwoCows, result.ResultMessage); 
    }
}