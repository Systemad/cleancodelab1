namespace UI.Logic;

public interface IGameLogic
{
    string GenerateCorrectAnswer();
    BullsAndCowsResult CheckBullsAndCows(string goal, string guess);
}