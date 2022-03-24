using System.Collections;
using UnityEngine;

public class TimedWave : Wave
{
    private TimedWaveAsset asset;
    private Timer timer;
    private ISpawner spawner;

    override public int RemainingMonsters { get; }

    public TimedWave(Spawnables spawnables, SpawnPoints points, TimedWaveAsset asset, int number) : base(number)
    {
        this.asset = asset;

        RemainingMonsters = -1;

        spawner = new SpawnInIntervals(spawnables, points, 10f, 1);
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