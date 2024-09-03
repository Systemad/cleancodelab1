using UI.Logic;

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
        var result = gameLogic.CheckBullsAndCows(Constants.CorrectAnswer, Constants.CorrectGuess);

        Assert.Equal(Constants.FourBullsResult, result.ResultMessage); 
    }
    
    [Fact]
    public void CheckBullsAndCows_ShouldReturnNoBullsOrCowsForNonMatchingGuess()
    {
        var gameLogic = new GameLogic();
        var result = gameLogic.CheckBullsAndCows(Constants.CorrectAnswer, Constants.ZeroBullsZeroCowsGuess);

        Assert.Equal(Constants.ZeroBullsZeroCowsResult, result.ResultMessage); 
    }
    
    [Fact]
    public void CheckBullsAndCows_ShouldReturnCorrectFormatForMixedBullsAndCows()
    {
        var gameLogic = new GameLogic();
        var result = gameLogic.CheckBullsAndCows(Constants.CorrectAnswer, Constants.TwoBullsTwoCowsGuess);

        Assert.Equal(Constants.TwoBullsTwoCowsResult, result.ResultMessage); 
    }
    
    [Theory]
    [InlineData(Constants.CorrectAnswer, Constants.CorrectAnswer, Constants.FourBullsResult)]
    [InlineData(Constants.CorrectAnswer, Constants.ZeroBullsZeroCowsGuess, Constants.ZeroBullsZeroCowsResult)]
    [InlineData(Constants.CorrectAnswer, Constants.TwoBullsTwoCowsGuess, Constants.TwoBullsTwoCowsResult)]
    public void CheckBullsAndCows_ShouldReturnCorrectResult(string correctAnswer, string guess, string expectedResult)
    {
        var gameLogic = new GameLogic();
        var result = gameLogic.CheckBullsAndCows(correctAnswer, guess);

        Assert.Equal(expectedResult, result.ResultMessage);
    }
}