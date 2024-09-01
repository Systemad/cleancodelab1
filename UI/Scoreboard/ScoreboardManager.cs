namespace UI.Scoreboard;

public class ScoreboardManager : IScoreboardManager
{
    private const string Separator = "#&#";
    private const string ResultFilename = "result.txt";

    public void WritePlayerResult(string playerName, int numberOfGuesses)
    {
        try
        {
            using (var resultOutput = new StreamWriter(ResultFilename, append: true))
            {
                resultOutput.WriteLine($"{playerName}{Separator}{numberOfGuesses}");
                resultOutput.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    public List<PlayerData> GetPlayerResults()
    {
        var leaderboard = new List<PlayerData>();
        using (var fileInput = new StreamReader(ResultFilename))
        {
            string line;
            while ((line = fileInput.ReadLine()) != null)
            {
                var parsedPlayerData = ParsePlayerData(line);
                AddOrUpdatePlayer(leaderboard, parsedPlayerData);
            }
        }

        SortLeaderboard(leaderboard);
        return leaderboard;
    }

    private static PlayerData ParsePlayerData(string line)
    {
        string[] nameAndScore = line.Split(new string[] { Separator }, StringSplitOptions.None);
        var name = nameAndScore[0];
        var guesses = Convert.ToInt32(nameAndScore[1]);
        var playerData = new PlayerData(name, guesses);
        return playerData;
    }

    private static void AddOrUpdatePlayer(List<PlayerData> leaderboard, PlayerData playerData)
    {
        var existingPlayer = leaderboard.Find(player => player.Name == playerData.Name);

        if (existingPlayer is not null)
        {
            var guesses = playerData.GetGuesses();
            existingPlayer.AddGame(guesses);
        }
        else
        {
            leaderboard.Add(playerData);
        }
    }

    private static void SortLeaderboard(List<PlayerData> leaderboard) =>
        leaderboard.Sort((p1, p2) => p1.AverageGuesses().CompareTo(p2.AverageGuesses()));
}