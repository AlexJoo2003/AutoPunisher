using CommandSystem;

namespace AutoPunisher.Commands.SubCommands;

public class Confirm: ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "confirmed";
        return true;
    }

    public string Command { get; } = "confirm";
    public string[] Aliases { get; } = { };
    public string Description { get; } = "Insert Description here";
}