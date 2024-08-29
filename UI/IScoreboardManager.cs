namespace UI;

public interface IScoreboardManager
{
    public void WriteResult(string playerName, string numberOfGuesses);
    public List<PlayerData> ReturnResults();
}