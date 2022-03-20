using System.Collections;
using UnityEngine;

public class TimedWave : Wave
{
    private TimedWaveAsset asset;
    private Timer timer;
    private ISpawner spawner;

    public TimedWave(Spawnables spawnables, SpawnPoints points, TimedWaveAsset asset, int number) : base(number)
    {
        this.asset = asset;

        spawner = new SpawnInIntervals(spawnables, points, 5f);
    }

    public override void OnStart()
    {
        timer = new Timer(asset.duration);
        timer.Start();

        spawner.OnStart();
    }

    public override void Tick(float deltaTime)
    {
        timer.Tick(deltaTime);
        spawner.Tick(deltaTime);

        if (timer.Stopped)
            IsComplete = true;
    }

    public override void OnEnd()
    {
        spawner.OnEnd();

        timer = null;
    }
}