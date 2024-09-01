namespace AutoPunisher.DataHandler;

// used some banning method 
public class Punishment
{
    public Punishment(Player player, int banDuration, string banMessage)
    {
        Player = player;
        BanDuration = banDuration;
        BanMessage = banMessage;
    }

    public Player Player { get; set; }
    public int BanDuration { get; set; }
    public string BanMessage { get; set; }
}