using System.Collections;
using UnityEngine;

public class SpawnInIntervals : ISpawner
{
    public bool CanSpawn { get { return timer.Stopped; } }
    public int Count { get; set; }

    private float interval;
    private Timer timer;
    private Spawnables spawnables;
    private SpawnPoints points;
    private int maxSize;

    public SpawnInIntervals(Spawnables spawnables, SpawnPoints points, float interval, int maxSize)
    {
        this.interval = interval;
        this.spawnables = spawnables;
        this.points = points;
        this.maxSize = maxSize;
    }

    public void OnStart()
    {
        timer = new Timer(interval);
        timer.Start();

        Count = maxSize;

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

        var spawnCount = points.points.Count;

        for (int i = 0; i < spawnCount; i++)
        {
            var obj = Object.Instantiate(spawnables.items[0].obj, points.spawnPoint);

            obj.GetComponent<EnemyUnit>().healthComponent.OnDeath += RemoveSpawned;
            obj.transform.position = points.points[i].position;
        }

        return spawnCount;
    }

    private void RemoveSpawned()
    {
        Count -= 1;
    }
}