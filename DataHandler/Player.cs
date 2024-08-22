namespace AutoPunisher.DataHandler;

public class Player
{
    // gets info from json reader
    public Player(Dictionary<string, int> reasonRepeats, string steamid, string name)
    {
        ReasonRepeats = reasonRepeats;
        Steamid = steamid;
        Name = name;
    }

    public string Steamid { get; set; }
    public string Name { get; set; }
    public Dictionary<string, int> ReasonRepeats { get; set; }
    
    
}