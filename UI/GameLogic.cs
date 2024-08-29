using System.Text;

namespace UI;

public class GameLogic : IGameLogic
{
    public string GenerateCorrectAnswer()
    {
        var availableDigits = Enumerable.Range(0, 10).ToList();
        var correctAnswer = new StringBuilder();
        Random randomGenerator = new Random();
        
        for (int i = 0; i < 4; i++)
        {
            int index = randomGenerator.Next(availableDigits.Count);
            int chosenDigit = availableDigits[index];
            correctAnswer.Append(chosenDigit);
            availableDigits.Remove(chosenDigit);
        }

        return correctAnswer.ToString();
    }

    public string CheckBullsAndCows(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
                {
                    if (i == j)
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
        }

        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
    }
}