namespace UI.Scoreboard;

public interface IScoreboardManager
{
    public void WritePlayerResult(string playerName, int numberOfGuesses);
    public List<PlayerData> GetPlayerResults();
}