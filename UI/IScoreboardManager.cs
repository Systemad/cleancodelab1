namespace UI;

public interface IScoreboardManager
{
    public void WriteResult(string playerName, int numberOfGuesses);
    public List<PlayerData> GetResults();
}