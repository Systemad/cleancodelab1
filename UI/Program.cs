using UI;

class MainClass
{
    public static void Main(string[] args)
    {
        // playOn -> isGameRunning
        bool isGameRunning = true;
        Console.WriteLine("Enter your user name:\n");

        // name -> playerName
        string playerName = Console.ReadLine();

        while (isGameRunning)
        {
            string goal = GenerateCorrectAnswer();

            Console.WriteLine("New game:\n");
            //comment out or remove next line to play real games!
            Console.WriteLine("For practice, number is: " + goal + "\n");

            // guess -> playerGuesses
            string playerGuesses = Console.ReadLine();

            // nGuess -> numberOfGuesses
            int numberOfGuesses = 1;
            string bbcc = CheckBullsAndCows(goal, playerGuesses);
            Console.WriteLine(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                numberOfGuesses++;
                playerGuesses = Console.ReadLine();
                Console.WriteLine(playerGuesses + "\n");
                bbcc = CheckBullsAndCows(goal, playerGuesses);
                Console.WriteLine(bbcc + "\n");
            }

            // output -> resultOutput
            StreamWriter resultOutput = new StreamWriter("result.txt", append: true);
            resultOutput.WriteLine(playerName + "#&#" + numberOfGuesses);
            resultOutput.Close();
            DisplayScoreboard();
            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");

            // answer -> continuePlayingResponse 
            string continuePlayingResponse = Console.ReadLine();
            if (continuePlayingResponse != null && continuePlayingResponse != "" &&
                continuePlayingResponse.Substring(0, 1) == "n")
            {
                isGameRunning = false;
            }
        }
    }

    // makeGoal -> GenerateCorrectAnswer 
    static string GenerateCorrectAnswer()
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

    // checkBC -> CheckBullsAndCows
    static string CheckBullsAndCows(string goal, string guess)
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


    // showTopList() -> Display()
    static void DisplayScoreboard()
    {
        StreamReader input = new StreamReader("result.txt");
        // results -> leaderboard
        List<PlayerData> leaderboard = new List<PlayerData>();
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData pd = new PlayerData(name, guesses);
            int pos = leaderboard.IndexOf(pd);
            if (pos < 0)
            {
                leaderboard.Add(pd);
            }
            else
            {
                leaderboard[pos].Update(guesses);
            }
        }

        leaderboard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player   games average");
        foreach (PlayerData p in leaderboard)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
        }

        input.Close();
    }
}

