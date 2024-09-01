namespace AutoPunisher;

using Events;
using Exiled.API.Enums;
using Exiled.API.Features;

public class Plugin : Plugin<Config>
{
    private static readonly Plugin Singleton = new();

    private PlayerHandler? _playerHandler;

    private Plugin()
    {
    }

    public static Plugin Instance => Singleton;

    public override void OnEnabled()
    {
        RegisterEvents();
        Log.Info("Plugin is enabled!");
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        UnregisterEvents();
        Log.Info("Plugin is Disabled.");
        base.OnDisabled();
    }

    private void RegisterEvents()
    {
        _playerHandler = new PlayerHandler();

        Exiled.Events.Handlers.Player.Jumping += _playerHandler.OnJumping;
    }

    private void UnregisterEvents()
    {
        Exiled.Events.Handlers.Player.Jumping -= _playerHandler!.OnJumping;

        _playerHandler = null;
    }

    public override string Name { get; } = "AutoPunisher";
    public override string Author { get; } = "Alex_Joo";
    public override Version Version { get; } = new Version(0, 0, 0);
    public override PluginPriority Priority { get; } = PluginPriority.Default;
}