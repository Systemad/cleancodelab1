namespace UI;

public interface IGameLogic
{
    string GenerateCorrectAnswer();
    string CheckBullsAndCows(string goal, string guess);
}