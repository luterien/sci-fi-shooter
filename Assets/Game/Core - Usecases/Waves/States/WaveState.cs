using System.Collections;
using UnityEngine;

abstract public class WaveState : IState
{
    public bool IsComplete { get; set; }

    protected WaveManager manager;

    public WaveState(WaveManager manager)
    {
        this.manager = manager;
    }

    abstract public void OnEnter();
    abstract public void Tick();
    abstract public void OnExit();
}
