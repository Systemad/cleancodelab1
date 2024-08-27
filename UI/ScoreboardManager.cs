namespace UI;

public class ScoreboardManager : IScoreboardManager
{
    public void WriteResult(string playerName, string numberOfGuesses)
    {
        using (StreamWriter resultOutput = new StreamWriter("result.txt", append: true))
        {
            resultOutput.WriteLine(playerName + "#&#" + numberOfGuesses);
            resultOutput.Close();
        }
    }

    public void PrintResults()
    {
        var leaderboard = new List<PlayerData>();

        using (StreamReader fileInput = new StreamReader("result.txt"))
        {
            string line;
            while ((line = fileInput.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                
                var playerData = new PlayerData(name, guesses);
                
                int position = leaderboard.IndexOf(playerData);
                if (position < 0)
                {
                    leaderboard.Add(playerData);
                }
                else
                {
                    leaderboard[position].Update(guesses);
                }
            }
        }

        leaderboard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        Console.WriteLine("Player   games average");
        foreach (PlayerData playerData in leaderboard)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", playerData.Name, playerData.NumberOfGames, playerData.Average()));
        }
    }
}