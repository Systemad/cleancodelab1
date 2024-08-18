namespace UI;

// extracted out from Program.cs to an own file, for testing etc
public class PlayerData
{
    public string Name { get; private set; }
    public int NGames { get; private set; }
    // totalGuess -> private _totalGuess    
    private int _totalGuess;


    public PlayerData(string name, int guesses)
    {
        this.Name = name;
        NGames = 1;
        _totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        _totalGuess += guesses;
        NGames++;
    }

    public double Average()
    {
        return (double)_totalGuess / NGames;
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