using System.Collections;
using UnityEngine;

public class SpawnInIntervals : ISpawner
{
    public bool CanSpawn { get { return timer.Stopped; } }

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

        Execute();
    }

    public void Tick(float deltaTime)
    {
        timer.Tick(deltaTime);
    }

    public void OnEnd()
    {
        timer = null;
    }

    public int Execute()
    {
        timer.Restart();
        SpawnObjectsAtSpots.Execute(spawnables, points);
        return points.points.Count;
    }
}