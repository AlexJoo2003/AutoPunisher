namespace AutoPunisher;

using System.ComponentModel;
using Exiled.API.Interfaces;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;

    [Description("Will be the responce of the 'test' command.")]
    public string TestConfig { get; set; } = "test!";

    [Description("Should a broadcast appear everytime someone jumps?")]
    public bool BroadcastJumps { get; set; } = true;
}