using System.Collections;
using UnityEngine;

abstract public class TimedState : IState
{
    public bool IsComplete { get; set; }

    abstract protected float Duration { get; }

    protected Timer timer;

    public TimedState()
    {
        timer = new Timer(Duration);
    }

    virtual public void OnEnter()
    {
        if (!timer.Stopped)
            timer.Start();
        else
            timer.Restart();
    }

    virtual public void Tick()
    {
        timer.Tick(Time.deltaTime);
        if (timer.Stopped)
            IsComplete = true;
    }

    virtual public void OnExit()
    {
        timer.Stop();
        IsComplete = false;
    }
}
