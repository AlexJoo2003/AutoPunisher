using CommandSystem;

namespace AutoPunisher.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Test : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = "Config, TestConfig = " + AutoPunisher.Instance.Config.TestConfig;
        return true;
    }

    public string Command { get; } = "test";
    public string[] Aliases { get; } = { "tt" };
    public string Description { get; } = "test command that just responds with the configured message";
}