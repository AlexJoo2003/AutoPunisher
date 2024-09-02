using AutoPunisher.DataHandler;
using AutoPunisher.DataHandlers;
using AutoPunisher.ReasonHandler;
using CommandSystem;

namespace AutoPunisher.Commands.SubCommands;

public class Punish : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "YAY";
        
        // assuming all the checks are in order this will be run...
        ReasonReader reasonReader = new ReasonReader("path gotten from config");
        BanReader banReader = new BanReader("path gotten from config");
        Player player = new Player("id gotten from arguments");
        if (reasonReader.ReasonExists("Reason gotten from arguments"))
        {
            Ban ban = banReader.CreateBan(sender.ToString(), reasonReader.Reasons.GetReasonByName("Reason gotten from arguments"), player);
            player.BanPlayer(ban);
        }
        
        
        return true;
    }

    public string Command { get; } = "punish";
    public string[] Aliases { get; } = { "p" };
    public string Description { get; } = "Insert Description here";
}