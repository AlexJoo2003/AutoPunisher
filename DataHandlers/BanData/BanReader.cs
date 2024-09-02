using AutoPunisher.DataHandler;
using AutoPunisher.ReasonHandler;

namespace AutoPunisher.DataHandlers;

public class BanReader
{
    public List<PlayerBans> PlayersBans { get; set; }

    public BanReader(string filePath)
    {
        // reads the banned.json and gets a list of PlayerBans ready
    }

    public PlayerBans GetPlayerBansByTarget(string targetId)
    {
        // returns Player bans list by targets name
        return new PlayerBans();
    }

    public Ban CreateBan(string issuer, Reason reason, Player player)
    {
        Ban ban = new Ban();
        ban.Issuer = issuer;
        ban.Duration = reason.CalculateDuration(player);
        ban.Message = reason.Message;
        
        return ban;
    }
}