namespace UI;

/// <summary>
/// This contains and handles the game logic
/// </summary>
public class GameLogic : IGameLogic
{
    public string GenerateCorrectAnswer()
    {
        Random randomGenerator = new Random();
        string goal = "";
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            while (goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }

            goal = goal + randomDigit;
        }

        return goal;
    }

    public string CheckBullsAndCows(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        guess += "    "; // if player entered less than 4 chars
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