namespace UI;

public interface IScoreboardManager
{
    public void WriteResult(string playerName, string numberOfGuesses);
    public void PrintResults();
}