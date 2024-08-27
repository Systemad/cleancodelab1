namespace UI;

public class PlayerData
{
    public string Name { get; set; }
    public int NumberOfGames { get; private set; }
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

    public double Average()
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