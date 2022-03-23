using System.Collections;
using UnityEngine;

public class WaveSuccessState : WaveState
{
    private Timer timer;

    public WaveSuccessState(WaveManager manager, WaveManagerUI ui) : base(manager, ui)
    {
        timer = new Timer(5f);
    }

    public override void OnEnter()
    {
        timer.Restart();

        ui.ToggleWaveClearScreen(true);
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
        IsComplete = false;
        ui.ToggleWaveClearScreen(false);
    }
}