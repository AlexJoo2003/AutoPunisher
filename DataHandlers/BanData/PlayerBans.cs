namespace AutoPunisher.DataHandlers;

public class PlayerBans
{
    public List<Ban> Bans { get; set; }
    public string Target { get; set; }

    public int reasonOccurances(string reason)
    {
        // return the amount of times a player has been banned for specified reason
        return -1;
    }
}