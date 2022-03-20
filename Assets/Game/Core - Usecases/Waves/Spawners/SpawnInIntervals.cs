using System.Collections;
using UnityEngine;

public class SpawnInIntervals : ISpawner
{
    private float interval;
    private Timer timer;
    private Spawnables spawnables;
    private SpawnPoints points;

    public SpawnInIntervals(Spawnables spawnables, SpawnPoints points, float interval)
    {
        this.interval = interval;
        this.spawnables = spawnables;
        this.points = points;
    }

    public void OnStart()
    {
        timer = new Timer(interval);
        timer.Start();
    }

    public void Tick(float deltaTime)
    {
        timer.Tick(deltaTime);

        if (timer.Stopped)
        {
            Execute();

            timer.Restart();
        }
    }

    public void OnEnd()
    {
        timer = null;
    }

    private void Execute()
    {
        SpawnObjectsAtSpots.Execute(spawnables, points);
    }
}