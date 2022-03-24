using System.Collections;
using UnityEngine;

public class CountWave : Wave
{
    private CountWaveAsset asset;
    private ISpawner spawner;

    private Transform spawnPoint;

    private int spawnedUnitTotal = 0;

    private bool canSpawn = true;

    override public int RemainingMonsters { get { return spawner.Count; } }

    public CountWave(Spawnables spawnables, SpawnPoints points, CountWaveAsset asset, int number) : base(number)
    {
        this.asset = asset;

        spawnPoint = points.spawnPoint;

        spawner = new SpawnInIntervals(spawnables, points, 10f, asset.maxUnits);
    }

    public override void OnStart()
    {
        spawner.OnStart();

        canSpawn = true;
        spawnedUnitTotal = 0;
    }

    public override void Tick(float deltaTime)
    {
        if (RemainingMonsters == 0)
        {
            IsComplete = true;
            return;
        }

        if (canSpawn)
        {
            spawner.Tick(deltaTime);

            if (spawner.CanSpawn)
            {
                var count = spawner.Execute();
                spawnedUnitTotal += count;
            }

            if (spawnedUnitTotal >= asset.maxUnits)
                canSpawn = false;
        }
    }

    public override void OnEnd()
    {
        spawner.OnEnd();
    }
}