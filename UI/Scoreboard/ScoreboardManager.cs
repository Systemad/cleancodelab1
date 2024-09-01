namespace UI.Scoreboard;

public class ScoreboardManager : IScoreboardManager
{
    private const string Separator = "#&#";
    private const string ResultFilename = "result.txt";

    public void WritePlayerResult(string playerName, int numberOfGuesses)
    {
        using (var resultOutput = new StreamWriter(ResultFilename, append: true))
        {
            resultOutput.WriteLine($"{playerName}{Separator}{numberOfGuesses}");
            resultOutput.Close();
        }
    }

    public List<PlayerData> GetLeaderboard()
    {
        var leaderboard = new List<PlayerData>();
        using (var fileInput = new StreamReader(ResultFilename))
        {
            string line;
            while ((line = fileInput.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { Separator }, StringSplitOptions.None);
                var name = nameAndScore[0];
                var guesses = Convert.ToInt32(nameAndScore[1]);
                
                AddOrUpdatePlayer(guesses, name, leaderboard);
            }
        }

        SortLeaderboard(leaderboard);
        return leaderboard;
    }

    private static void AddOrUpdatePlayer(int guesses, string name, List<PlayerData> leaderboard)
    {
        var playerData = new PlayerData(name, guesses);
        var existingPlayer = leaderboard.Find(player => player.Name == name);

        if (existingPlayer is not null)
        {
            existingPlayer.Update(guesses);
        }
        else
        {
            leaderboard.Add(playerData);
        }
    }
    
    private static void SortLeaderboard(List<PlayerData> leaderboard) =>
        leaderboard.Sort((p1, p2) => p1.AverageGuesses().CompareTo(p2.AverageGuesses()));
}