namespace AutoPunisher.Events;

using MEC;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;

internal sealed class PlayerHandler
{
    public void OnJumping(JumpingEventArgs ev)
    {
        if (AutoPunisher.Instance.Config.BroadcastJumps)
        {
            Exiled.API.Features.Broadcast test = new Exiled.API.Features.Broadcast();
            ev.Player.Broadcast(new Broadcast("you have jumped!", 1));
        }

        Timing.CallDelayed(1f, () => { Log.Info(ev.Player.Nickname + " has jumped 1 seconds ago!"); });
    }
}