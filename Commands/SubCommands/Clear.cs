using CommandSystem;

namespace AutoPunisher.Commands.SubCommands;

public class Clear: ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "clear";
        return true;
    }

    public string Command { get; } = "clear";
    public string[] Aliases { get; } = { "c", "cl" };
    public string Description { get; } = "Insert Description here";
}