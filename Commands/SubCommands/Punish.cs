using CommandSystem;

namespace AutoPunisher.Commands.SubCommands;

public class Punish : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "YAY";
        return true;
    }

    public string Command { get; } = "punish";
    public string[] Aliases { get; } = { "p" };
    public string Description { get; } = "Insert Description here";
}