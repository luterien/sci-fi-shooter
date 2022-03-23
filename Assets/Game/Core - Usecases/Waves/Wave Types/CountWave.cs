using System.Collections;
using UnityEngine;

public class CountWave : Wave
{
    private CountWaveAsset asset;
    private ISpawner spawner;

    private Transform spawnPoint;

    private int spawnedUnitTotal = 0;

    private Timer timer;
    private float checkInterval = 0.2f;

    private bool canSpawn = true;

    override public int RemainingMonsters { get; set; }

    public CountWave(Spawnables spawnables, SpawnPoints points, CountWaveAsset asset, int number) : base(number)
    {
        this.asset = asset;

        spawnPoint = points.spawnPoint;
        timer = new Timer(checkInterval);

        spawner = new SpawnInIntervals(spawnables, points, 10f);
    }

    public override void OnStart()
    {
        timer.Restart();
        spawner.OnStart();

        canSpawn = true;

        RemainingMonsters = asset.maxUnits;
    }

    public override void Tick(float deltaTime)
    {
        timer.Tick(deltaTime);
        spawner.Tick(deltaTime);

        if (timer.Stopped)
        {
            UpdateRemaining();
        }

        if (!canSpawn && RemainingMonsters == 0)
        {
            IsComplete = true;
            return;
        }

        if (!canSpawn)
            return;

        if (spawnedUnitTotal > asset.maxUnits)
            canSpawn = false;

        if (spawner.CanSpawn)
        {
            var count = spawner.Execute();
            spawnedUnitTotal += count;
            UpdateRemaining();
        }
    }

    public override void OnEnd()
    {
        timer.Stop();
        spawner.OnEnd();
    }

    private void UpdateRemaining()
    {
        timer.Restart();

        RemainingMonsters = spawnPoint.childCount + (asset.maxUnits - spawnedUnitTotal);
    }
}