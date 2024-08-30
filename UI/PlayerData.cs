namespace UI;

public class PlayerData
{
    public string Name { get; set; }
    private int NumberOfGames { get; set; }
    private int _totalGuess;

    public PlayerData(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        _totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        _totalGuess += guesses;
        NumberOfGames++;
    }

    public string FormatStats() => $"{Name,-9}{NumberOfGames,5:D}{AverageGuesses(),9:F2}";

    public double AverageGuesses()
    {
        return (double)_totalGuess / NumberOfGames;
    }

    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}