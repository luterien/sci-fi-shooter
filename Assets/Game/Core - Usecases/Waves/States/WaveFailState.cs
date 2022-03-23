using System.Collections;
using UnityEngine;

public class WaveFailState : WaveState
{
    private Timer timer;

    public WaveFailState(WaveManager manager, WaveManagerUI ui) : base(manager, ui)
    {
        timer = new Timer(5f);
    }

    public override void OnEnter()
    {
        timer.Restart();

        ui.ToggleWaveFailScreen(true);
    }

    public override void Tick()
    {
        timer.Tick(Time.deltaTime);

        if (timer.Stopped)
            IsComplete = true;
    }

    public override void OnExit()
    {
        timer.Stop();

        ui.ToggleWaveFailScreen(false);
    }
}