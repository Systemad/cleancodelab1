using System.Text;

namespace UI;

public class GameLogic : IGameLogic
{
    
    public string GenerateCorrectAnswer()
    {
        var availableDigits = Enumerable.Range(0, 10).ToList();
        var correctAnswer = new StringBuilder();
        var randomGenerator = new Random();
        
        for (int i = 0; i < 4; i++)
        {
            var index = randomGenerator.Next(availableDigits.Count);
            var chosenDigit = availableDigits[index];
            correctAnswer.Append(chosenDigit);
            availableDigits.Remove(chosenDigit);
        }

        return correctAnswer.ToString();
    }

    public BullsAndCowsResult CheckBullsAndCows(string goal, string guess)
    {
        int cows = 0, bulls = 0;

        for (var i = 0; i < goal.Length; i++)
        {
            if (goal[i] == guess[i])
            {
                bulls++;
            }
            else if (goal.Contains(guess[i]))
            {
                cows++;
            }
        }

        var result = new string(Constants.BullChar, bulls) + Constants.Separator + new string(Constants.CowChar, cows);
        var isCorrect = bulls == goal.Length;
        return new BullsAndCowsResult(result, isCorrect);
    }
}