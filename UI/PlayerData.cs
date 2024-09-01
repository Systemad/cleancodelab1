namespace UI;

public class PlayerData
{
    public string Name { get; set; }
    private int NumberOfGames { get; set; }
    private int TotalNumberOfGuess { get; set; }

    public PlayerData(string name, int numberOfGuesses)
    {
        Name = name;
        NumberOfGames = 1;
        TotalNumberOfGuess = numberOfGuesses;
    }

    public void AddGame(int guesses)
    {
        TotalNumberOfGuess += guesses;
        NumberOfGames++;
    }

    public string FormatStats() => $"{Name,-9}{NumberOfGames,5:D}{AverageGuesses(),9:F2}";

    public double AverageGuesses()
    {
        return (double)TotalNumberOfGuess / NumberOfGames;
    }

    public override bool Equals(object? obj)
    {
        if (obj is PlayerData playerData)
        {
            return Name.Equals(playerData.Name);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    
    public int GetGuesses()
    {
        return TotalNumberOfGuess;
    }
}