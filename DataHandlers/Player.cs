using AutoPunisher.DataHandlers;

namespace AutoPunisher.DataHandler;

public class Player
{
    // gets info from json reader
    public Player(string identifier)
    {
        if (identifier.Contains("@steam"))
        {
            Steamid = identifier;
        }
        else
        {
            // use Exiled to get steamid
        }
    }

    public void BanPlayer(Ban ban)
    {
        // ban the player and log it to the banned.json
    }

    public string Steamid { get; set; }
    public string Name { get; set; }
    public Dictionary<string, int> ReasonRepeats { get; set; }
    
    
}