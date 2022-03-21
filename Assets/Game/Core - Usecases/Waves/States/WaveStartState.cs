using System.Collections;
using UnityEngine;

public class WaveStartState : WaveState
{
    private Timer timer;

    public WaveStartState(WaveManager manager, WaveManagerUI ui) : base(manager, ui) 
    {
        timer = new Timer(15f);
    }

    override public void OnEnter()
    {
        timer.Restart();
        ui.ToggleCountdownUI(true);
    }

    override public void Tick()
    {
        timer.Tick(Time.deltaTime);

        if ((int)timer.Duration > 0)
            ui.SetTimerCooldownText(string.Format("Wave starting in {0} seconds", (int)timer.Duration));

        if (timer.Stopped)
            IsComplete = true;
    }

    override public void OnExit()
    {
        IsComplete = false;

        ui.ToggleCountdownUI(false);
    }
}