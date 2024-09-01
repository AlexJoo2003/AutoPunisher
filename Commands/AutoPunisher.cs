using AutoPunisher.Commands.SubCommands;
using CommandSystem;

namespace AutoPunisher.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class AutoPunisher : ParentCommand
{
    public AutoPunisher() => LoadGeneratedCommands();
    
    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new Punish());
    }

    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "Please enter a valid subcommand:";
        return false;
    }

    public override string Command { get; } = "autopunisher";
    public override string[] Aliases { get; } = {"ap", "autopunish"};
    public override string Description { get; } = "Insert description here";
}