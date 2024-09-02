using CommandSystem;
using Exiled.Permissions.Extensions;

namespace AutoPunisher.Commands.SubCommands;

public class Clear: ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!sender.CheckPermission("ap.clear"))
        {
            response = "You don't have the permissions to run that command. (ap.clear)";
            return false;
        }
        if (arguments.Count == 0)
        {
            response = "No player ID provided. Usage: autopunisher clear {PlayerId}";
            return false;
        }
        
        
        response = "clear";
        return true;
    }

    public string Command { get; } = "clear";
    public string[] Aliases { get; } = { "c", "cl" };
    public string Description { get; } = "Insert Description here";
}