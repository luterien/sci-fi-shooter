using System.Collections;
using UnityEngine;

public class SpawnInIntervals : ISpawner
{
    private float interval;
    private Timer timer;

    public SpawnInIntervals(float interval)
    {
        this.interval = interval;
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

    }
}