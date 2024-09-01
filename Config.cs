namespace AutoPunisher;

using System.ComponentModel;
using Exiled.API.Interfaces;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;

    [Description(
        "If enabled, plugin would ask for confirmation displaying the affected players name before issuing a ban.")]
    public bool ConfirmBan { get; set; } = true;

    [Description("Whether or not allow banning multiple people with one command separating PlayerIds with a dot")]
    public bool AllowMultiban { get; set; } = false;

    [Description("If enabled, allows the clear command, will work only if player has permission")]
    public bool AllowClear { get; set; } = true;

    [Description("If enabled, allows adding alternative messages to the ban.")]
    public bool AllowMessage { get; set; } = true;

[Description("Should a broadcast appear everytime someone jumps?")]
    public bool BroadcastJumps { get; set; } = true;
}