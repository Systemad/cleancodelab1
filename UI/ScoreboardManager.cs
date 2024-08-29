namespace UI;

public class ScoreboardManager : IScoreboardManager
{
    private static readonly string SEPARATOR = "#&#";
    private static readonly string RESULT_FILENAME = "result.txt";
    public void WriteResult(string playerName, string numberOfGuesses)
    {
        using (var resultOutput = new StreamWriter(RESULT_FILENAME, append: true))
        {
            resultOutput.WriteLine($"{playerName}{SEPARATOR}{numberOfGuesses}");
            resultOutput.Close();
        }
    }

    // return this as a list<player> into gamecontroller, then in use userfacemanager.printleaderborard(playerlist)
    public List<PlayerData> ReturnResults()
    {
        var leaderboard = new List<PlayerData>();
        using (StreamReader fileInput = new StreamReader(RESULT_FILENAME))
        {
            string line;
            while ((line = fileInput.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { SEPARATOR }, StringSplitOptions.None);
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

        leaderboard.Sort((p1, p2) => p1.AverageGuesses().CompareTo(p2.AverageGuesses()));
        return leaderboard;

    }
}