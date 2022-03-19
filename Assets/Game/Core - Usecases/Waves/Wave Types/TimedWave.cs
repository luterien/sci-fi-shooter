using System.Collections;
using UnityEngine;

public class TimedWave : Wave
{
    private TimedWaveAsset asset;
    private Timer timer;

    public TimedWave(TimedWaveAsset asset, int number) : base(number)
    {
        this.asset = asset;
    }

    public override void OnStart()
    {
        timer = new Timer(asset.duration);
        timer.Start();
    }

    public override void Tick(float deltaTime)
    {
        timer.Tick(deltaTime);

        if (timer.Stopped)
            IsComplete = true;
    }

    public override void OnEnd()
    {
        timer = null;
    }
}